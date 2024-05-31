# TStoMP4 Converter

Este projeto é uma aplicação em .NET Core 8 que converte arquivos de vídeo no formato TS para MP4 usando a biblioteca Xabe.FFmpeg. O objetivo é fornecer uma ferramenta simples e eficiente para a conversão de vídeos, utilizando codecs de alta qualidade.

## Requisitos

- .NET Core 8
- FFmpeg
- Biblioteca Xabe.FFmpeg

## Instalação

1. **Clone o repositório:**
   ```sh
   git clone https://github.com/seu-usuario/TStoMP4.git
   cd TStoMP4


2. **Instale o .NET Core 8::**
   - [Baixe e instale o .NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)


3. **Instale o .NET Core 8::**
   - [Baixe e instale o FFmpeg](https://ffmpeg.org/download.html)
	- Certifique-se de adicionar o FFmpeg ao PATH do sistema


4. **Restaure os pacotes NuGet:::**

   ```sh
   dotnet restore

## Uso

- A aplicação irá converter todos os arquivos .ts no diretório de entrada para arquivos .mp4 no diretório de saída.

## Configurações
O projeto está configurado para usar o codec H.265 (HEVC) por padrão. Se desejar usar outro codec, como H.266 (VVC), ajuste o código conforme necessário e certifique-se de que sua versão do FFmpeg suporta o codec escolhido.

## Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

## Licença
Este projeto está licenciado sob a MIT License.