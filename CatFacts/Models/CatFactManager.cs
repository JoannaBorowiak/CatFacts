using System;
using System.Collections.Generic;
using System.Linq;
using CatFacts.Interfaces;

namespace CatFacts.Models
{
    public class CatFactManager
    {
        private ICatFactService _factService;
        private IFileService _fileService;
        public CatFactManager(ICatFactService factService, IFileService fileService) 
        {
        _factService = factService;
        _fileService = fileService;
        }

        public async Task SaveCatFactsToFile(string path, int numberOfFacts)
        {
            int sum = 0;
            
            for (int i = 0; i < numberOfFacts; i++)
            {   
                CatFact catFact = await _factService.GetFactsAsync();
                _fileService.AppendToFile(path, catFact.Fact);
                sum += catFact.Length;
                Console.WriteLine($"{i + 1}. {catFact.Fact}");
            }
            string fullPath = Path.GetFullPath(path);
            Console.WriteLine($"\nThe above facts have been added to the file: {fullPath}");
            Console.WriteLine($"Total length of all added facts: {sum}");
        }
    }
}
