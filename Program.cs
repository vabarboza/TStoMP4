using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace TStoMP4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Pasta de origem dos arquivos TS
            string inputFolder = @"C:\Users\lkmor\Downloads\Video\TS";

            // Pasta de destino dos arquivos MP4
            string outputFolder = @"C:\Users\lkmor\Downloads\Video\MP4";

            // Verifica se as pastas de entrada e saída existem
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Pasta de entrada não encontrada.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Console.WriteLine("Pasta de saída não encontrada. Criando pasta...");
                Directory.CreateDirectory(outputFolder);
            }

            // Lista todos os arquivos com extensão .ts na pasta de entrada
            string[] inputFiles = Directory.GetFiles(inputFolder, "*.ts");

            // Processa os arquivos TS em sequência
            foreach (string inputFile in inputFiles)
            {
                string outputFile = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputFile) + ".mp4");
                await ConvertToMP4(inputFile, outputFile);
            }

            Console.WriteLine("Conversão concluída.");
        }

        // Função para converter um arquivo TS para MP4 utilizando Xabe.FFmpeg
        static async Task ConvertToMP4(string inputPath, string outputPath)
        {
            try
            {
                // Carrega o arquivo de entrada
                var mediaInfo = await FFmpeg.GetMediaInfo(inputPath);

                // Seleciona o primeiro fluxo de vídeo
                var videoStream = mediaInfo.VideoStreams.FirstOrDefault()?.SetCodec(VideoCodec.h264); // <-- Altere aqui o coodec para o desejado
                var audioStream = mediaInfo.AudioStreams.FirstOrDefault();

                // Cria um conversor
                var conversion = FFmpeg.Conversions.New();

                // Adiciona os fluxos de entrada
                if (videoStream != null)
                {
                    conversion.AddStream(videoStream);
                }

                if (audioStream != null)
                {
                    conversion.AddStream(audioStream);
                }

                // Define o formato de saída (MP4)
                conversion.SetOutput(outputPath);

                // Define a opção para forçar a substituição do arquivo de saída se já existir
                conversion.SetOverwriteOutput(true);

                // Define preset ultrafast para aumentar a velocidade de conversão
                conversion.SetPreset(ConversionPreset.Faster); // <-- Altere aqui a velocidade de conversão, velocidades mais altes geram arquivos maiores

                // Define a opção para monitorar o progresso
                conversion.OnProgress += (sender, args) => Console.WriteLine($"Progresso {inputPath}: {args.Percent}%");

                // Executa a conversão
                await conversion.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao converter o arquivo {inputPath}: {ex.Message}");
            }
        }
    }
}
