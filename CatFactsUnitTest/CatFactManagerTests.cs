using CatFacts.Interfaces;
using CatFacts.Models;
using NUnit.Framework;

namespace CatFacts.Tests
{
    public class CatFactManagerTests
    {
        [Test]
        public async Task SaveCatFactsToFile_ValidInput_SavesFactsToFile()
        {
            // Arrange
            var testFactService = new TestCatFactService(); // Mockowane źródło faktów
            var testFileService = new TestFileService(); // Mockowany system plików
            string testPath = "testFile.txt"; // Ścieżka pliku
            int numberOfFacts = 2; // Liczba faktów do zapisania

            var manager = new CatFactManager(testFactService, testFileService);

            // Act
            await manager.SaveCatFactsToFile(testPath, numberOfFacts);

            // Assert
            // Pobierz zawartość "pliku"
            var savedFacts = testFileService.GetSavedContent(testPath);

            // Sprawdź, czy zapisano odpowiednie dane
            Assert.Contains("Cats sleep 16-18 hours per day.", savedFacts);
            Assert.Contains("A group of cats is called a clowder.", savedFacts);

            // Sprawdź, czy metoda GetFactsAsync została wywołana odpowiednią ilość razy
            Assert.AreEqual(2, testFactService.CallsToGetFactsAsync);
        }
    }

    // Implementacja testowa ICatFactService
    public class TestCatFactService : ICatFactService
    {
        private readonly Queue<CatFact> _facts = new Queue<CatFact>();
        public int CallsToGetFactsAsync { get; private set; } = 0;

        public TestCatFactService()
        {
            // Przykładowe dane zwracane przez mock
            _facts.Enqueue(new CatFact { Fact = "Cats sleep 16-18 hours per day.", Length = 31 });
            _facts.Enqueue(new CatFact { Fact = "A group of cats is called a clowder.", Length = 34 });
        }

        public Task<CatFact> GetFactsAsync()
        {
            CallsToGetFactsAsync++; // Liczenie wywołań
            return Task.FromResult(_facts.Dequeue());
        }
    }

    // Implementacja testowa IFileService
    public class TestFileService : IFileService
    {
        private readonly Dictionary<string, List<string>> _fileStorage = new Dictionary<string, List<string>>();

        public void AppendToFile(string path, string content)
        {
            if (!_fileStorage.ContainsKey(path))
            {
                _fileStorage[path] = new List<string>();
            }
            _fileStorage[path].Add(content); // Dodanie zawartości do symulowanego pliku
        }

        public List<string> GetSavedContent(string path)
        {
            return _fileStorage.ContainsKey(path) ? _fileStorage[path] : new List<string>();
        }
    }
}
