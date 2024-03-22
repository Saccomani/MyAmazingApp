# MyAmazingMauiApp - Basic project for template

This is a base project with layer separations and responsibilities to facilitate when creating a new project in .net maui.

## Project Architecture

The project is divided into several layers to ensure the separation of responsibilities:

- **App.Core**: This layer contains the core business logic, including view models, models, helpers, dependency injection providers, and interfaces.
- **App.Data**: Responsible for database connection and repository implementation.
- **App.Domain**: Contains all the business modeling, defining the main entities and business rules.
- **App.ErrorHandling**: Manages error catching and log generation to facilitate problem diagnosis and correction.
- **MyAmazingApp**: The application's presentation layer, developed with .NET MAUI to offer a rich and responsive user experience across multiple platforms.

## Getting Started

To start working with MyAmazingMauiApp, follow these steps:

### Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or higher with .NET MAUI support

### Environment Setup

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Restore the NuGet packages.
4. Build the solution to verify everything is set up correctly.

### Running the Project

To run MyAmazingMauiApp, set the `MyAmazingMauiApp` project as the startup project and press F5. Visual Studio will compile the project and start the application on an emulator or physical device, depending on your setup.

## License

Not applicable

## Contact
Rafael Sacomani - @rafael.saccomani (instagram)

Windows Screen
![image](https://github.com/Saccomani/MyAmazingApp/assets/3049349/50c0f6bd-ca8a-42b6-ac4b-3e4c9655bcf0)

