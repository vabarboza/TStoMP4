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

                // Seleciona o primeiro fluxo de vídeo e define o codec NVIDIA H.264
                var videoStream = mediaInfo.VideoStreams.First()
                    .SetCodec(VideoCodec.h264_nvenc);

                // Seleciona o primeiro fluxo de áudio e define o codec AAC
                var audioStream = mediaInfo.AudioStreams.First()
                    .SetCodec(AudioCodec.aac);

                // Cria um conversor
                var conversion = FFmpeg.Conversions.New()
                    .AddStream(videoStream)
                    .AddStream(audioStream)
                    .SetOutput(outputPath)
                    .SetOverwriteOutput(true);

                // Define a opção para forçar a substituição do arquivo de saída se já existir
                conversion.OnProgress += (sender, args) => Console.WriteLine($"Progresso: {args.Percent}%");

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
