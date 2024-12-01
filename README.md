# Cat Facts Application

## Overview

The **Cat Facts Application** is a simple console-based program that retrieves interesting cat facts from an online API and saves them to a text file. Users can specify the number of facts they want to fetch, and the application handles the data retrieval, processing, and storage.

---

## Features

- Fetches random cat facts from an external API (`https://catfact.ninja/fact`).
- Saves the fetched facts into a text file.
- Displays each fact and the total character count of saved facts on the console.
- Implements **Dependency Injection** to decouple logic and improve maintainability.
- Includes **unit tests** for validating the functionality of core components.
- Handles errors gracefully with informative messages.

## Architecture
The application is organized into modular components, with a clear separation of concerns. Below is the project structure:

```bash
CatFacts/
├── Interfaces/
│   ├── ICatFactService.cs    # Interface for fetching cat facts from an API
│   ├── IFileService.cs       # Interface for handling file operations
├── Models/
│   ├── CatFact.cs            # Data model representing a single cat fact
│   ├── CatFactManager.cs     # Core logic for fetching and saving cat facts
│   ├── CatFactService.cs     # Implementation of ICatFactService (fetches data from API)
│   ├── FileService.cs        # Implementation of IFileService (handles file operations)
├── Program.cs                # Entry point of the application
├── Tests/
│   ├── CatFactManagerTests.cs # Unit tests for CatFactManager
```
### Description of Components

1. **Interfaces**: Contains abstractions (`ICatFactService` and `IFileService`) to decouple business logic from implementation details.
2. **Models**: Contains:
   - `CatFact`: Represents the data structure for a cat fact.
   - `CatFactManager`: Manages the fetching and saving of cat facts.
   - `CatFactService`: Fetches cat facts from the API.
   - `FileService`: Handles file creation and appending.
3. **Program.cs**: Main entry point where dependencies are initialized, and the application workflow begins.
4. **Tests**: Contains unit tests to validate the functionality of key components using mock implementations.

This structure ensures:
- High cohesion within components.
- Clear separation of concerns for better maintainability.
- Testability through Dependency Injection and abstraction via interfaces.

---

## Unit Testing

The application includes unit tests to validate the functionality of core components:

- **Mock Implementations**:
  - Custom mock implementations of `ICatFactService` and `IFileService` are used to simulate API responses and file operations.
- **Coverage**:
  - Tests ensure the correctness of fetching cat facts, appending them to files, and handling user input.
- **Framework**:
  - Tests are written using the **xUnit** framework.

### Example Unit Test

```csharp
[Fact]
public async Task SaveCatFactsToFile_ValidInput_SavesFactsToFile()
{
    // Arrange
    var testFactService = new TestCatFactService(); // Mock source
    var testFileService = new TestFileService(); // Mock file service
    var manager = new CatFactManager(testFactService, testFileService);
    string path = "testFile.txt";

    // Act
    await manager.SaveCatFactsToFile(path, 2);

    // Assert
    var savedFacts = testFileService.GetSavedContent(path);
    Assert.Contains("Cats sleep 16-18 hours per day.", savedFacts);
    Assert.Contains("A group of cats is called a clowder.", savedFacts);
}
```
## Getting Started

### Prerequisites
- [.NET 6 or later](https://dotnet.microsoft.com/download)

### Installation

1. Clone the repository:
   ```csharp
   git clone https://github.com/JoannaBorowiak/CatFacts.git
   ```
2. Navigate to the project directory:
   ```csharp
   cd CatFacts
   ```
3. Build the application:
   ```csharp
   dotnet build
   ```
## Running the Application
Run the application from the command line:
  ```csharp
  dotnet run
  ```
## Usage
1. Enter the number of cat facts you want to save.
2. The facts will be fetched from the API and saved to a file named `CatFacts.txt` in the project directory.
3. The application will display the facts and the total length of the added facts in the console.

## Example output
Console Output:
```csharp
How many new facts do you want to add to the file?
> 2
1. Cats sleep 16-18 hours per day.
2. A group of cats is called a clowder.

The above facts have been added to the file: /path/to/CatFacts.txt
Total length of all added facts: 65
```
Saved File (CatFacts.txt):
```csharp
Cats sleep 16-18 hours per day.
A group of cats is called a clowder.
```
## Error Handling
- Ensures proper validation of user input (expects numbers).
- Catches and displays exceptions if issues occur during API calls or file operations.

## Author
- Joanna Borowiak
- GitHub: JoannaBorowiak
   
