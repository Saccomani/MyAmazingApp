# RommaApp

RommaApp é um aplicativo moderno e responsivo desenvolvido com .NET MAUI e .NET 8.0. Este projeto está estruturado para promover uma arquitetura limpa e separação de preocupações, facilitando a manutenção e expansão futuras.

## Arquitetura do Projeto

O projeto é dividido em várias camadas para garantir a separação de responsabilidades:

- **App.Core**: Esta camada contém a lógica de negócios central, incluindo view models, models, helpers, provedores de injeção de dependência e interfaces.
- **App.Data**: Responsável pela conexão com o banco de dados e implementação das repositórios.
- **App.Domain**: Contém toda a modelagem de negócios, definindo as entidades e regras de negócio principais.
- **App.ErrorHandling**: Gerencia a captura de erros e a geração de logs para facilitar o diagnóstico e a correção de problemas.
- **RommaApp**: A camada de apresentação do aplicativo, desenvolvida com .NET MAUI para oferecer uma experiência de usuário rica e responsiva em múltiplas plataformas.

## Iniciando

Para começar a trabalhar com o RommaApp, siga estes passos:

### Pré-requisitos

- .NET 8.0 SDK
- Visual Studio 2022 ou superior com suporte a .NET MAUI

### Configuração do Ambiente

1. Clone o repositório para a sua máquina local.
2. Abra a solução no Visual Studio.
3. Restaure os pacotes NuGet.
4. Compile a solução para verificar se tudo está configurado corretamente.

### Executando o Projeto

Para executar o RommaApp, defina o projeto `RommaApp` como o projeto de inicialização e pressione F5. O Visual Studio compilará o projeto e iniciará o aplicativo em um emulador ou dispositivo físico, dependendo da sua configuração.


## Licença

Não se aplica

## Contato

Rafael Sacomani - 11970784168 ou r.saccomani@gmail.com
