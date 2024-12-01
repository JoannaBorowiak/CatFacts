using CatFacts.Models;

namespace CatFacts.Interfaces
{
    public interface ICatFactService
    {
        Task<CatFact> GetFactsAsync();
    }
}
