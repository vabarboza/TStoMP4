# TStoMP4 Converter

Este projeto � uma aplica��o em .NET Core 8 que converte arquivos de v�deo no formato TS para MP4 usando a biblioteca Xabe.FFmpeg. O objetivo � fornecer uma ferramenta simples e eficiente para a convers�o de v�deos, utilizando codecs de alta qualidade.

## Requisitos

- .NET Core 8
- FFmpeg
- Biblioteca Xabe.FFmpeg

## Instala��o

1. **Clone o reposit�rio:**
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

- A aplica��o ir� converter todos os arquivos .ts no diret�rio de entrada para arquivos .mp4 no diret�rio de sa�da.

## Configura��es
O projeto est� configurado para usar o codec H.265 (HEVC) por padr�o. Se desejar usar outro codec, como H.266 (VVC), ajuste o c�digo conforme necess�rio e certifique-se de que sua vers�o do FFmpeg suporta o codec escolhido.

## Contribui��es
Contribui��es s�o bem-vindas! Sinta-se � vontade para abrir issues ou enviar pull requests.

## Licen�a
Este projeto est� licenciado sob a MIT License.