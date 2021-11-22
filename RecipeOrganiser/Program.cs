using RecipeOrganiser.Entities;
using RecipeOrganiser.Services;
using RecipeOrganiser.UI;

namespace RecipeOrganiser;

public class Program
{
    public static void Main()
    {
        new CommandLineInterface(new RecipeService()).Run();
    }
}