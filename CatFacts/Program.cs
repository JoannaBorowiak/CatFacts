using CatFacts.Models;

namespace CatFacts
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            CatFactManager cfm = new CatFactManager(new CatFactService(), new FileService());

            bool run = true;
            while (run)
            {
                Console.WriteLine("How many new facts do you want to add to the file?");
                if (int.TryParse(Console.ReadLine(), out int numberOfFacts))
                {
                    try
                    {   
                        string path = @"..\..\..\CatFacts.txt";
                        await cfm.SaveCatFactsToFile(path, numberOfFacts);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        run = false;
                        break;
                    }
                }   
                else
                {
                    Console.WriteLine("Select a number!");
                }
            }
        }
    }
}