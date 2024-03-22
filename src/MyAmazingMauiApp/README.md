# MyAmazingMauiApp

MyAmazingMauiApp � um aplicativo moderno e responsivo desenvolvido com .NET MAUI e .NET 8.0. Este projeto est� estruturado para promover uma arquitetura limpa e separa��o de preocupa��es, facilitando a manuten��o e expans�o futuras.

## Arquitetura do Projeto

O projeto � dividido em v�rias camadas para garantir a separa��o de responsabilidades:

- **App.Core**: Esta camada cont�m a l�gica de neg�cios central, incluindo view models, models, helpers, provedores de inje��o de depend�ncia e interfaces.
- **App.Data**: Respons�vel pela conex�o com o banco de dados e implementa��o das reposit�rios.
- **App.Domain**: Cont�m toda a modelagem de neg�cios, definindo as entidades e regras de neg�cio principais.
- **App.ErrorHandling**: Gerencia a captura de erros e a gera��o de logs para facilitar o diagn�stico e a corre��o de problemas.
- **MyAmazingApp**: A camada de apresenta��o do aplicativo, desenvolvida com .NET MAUI para oferecer uma experi�ncia de usu�rio rica e responsiva em m�ltiplas plataformas.

## Iniciando

Para come�ar a trabalhar com o MyAmazingApp, siga estes passos:

### Pr�-requisitos

- .NET 8.0 SDK
- Visual Studio 2022 ou superior com suporte a .NET MAUI

### Configura��o do Ambiente

1. Clone o reposit�rio para a sua m�quina local.
2. Abra a solu��o no Visual Studio.
3. Restaure os pacotes NuGet.
4. Configure a string de conex�o do banco de dados em `App.Data`.
5. Compile a solu��o para verificar se tudo est� configurado corretamente.

### Executando o Projeto

Para executar o MyAmazingApp, defina o projeto `MyAmazingApp` como o projeto de inicializa��o e pressione F5. O Visual Studio compilar� o projeto e iniciar� o aplicativo em um emulador ou dispositivo f�sico, dependendo da sua configura��o.


## Licen�a

N�o se aplica

## Contato

Rafael Sacomani - @rafael.saccomani (instagram)
