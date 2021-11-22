using RecipeOrganiser.Entities;
using RecipeOrganiser.Services;

namespace RecipeOrganiser;

public class Program
{
    public static void Main()
    {
        IRecipeService service = new RecipeService();
        int option = 0;
        while (true)
        {
            Console.WriteLine("1. Add" + Environment.NewLine + "2. Find" + Environment.NewLine + "3. Print");
            option= 0;
            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:
                    AddRecipe(service);
                    break;
                case 2:
                    FindRecipe(service);
                    break;
                case 3:
                    service.PrintAllRecipes();
                    break;
                default:
                    return;
            }
        }
    }

    private static void FindRecipe(IRecipeService service)
    {
        Console.WriteLine("Enter Recipe name:");
        string name = Console.ReadLine();
        Console.WriteLine(service.FindOneByName(name));
    }

    private static void AddRecipe(IRecipeService recipeService)
    {
        Console.WriteLine("Enter Recipe name:");
        string name = Console.ReadLine();

        Console.WriteLine("How many ingredients:");
        int numberOfIngredients;
        int.TryParse(Console.ReadLine(), out numberOfIngredients);

        string[] ingredients = new string[numberOfIngredients];
        for(int index = 0; index < numberOfIngredients; index++)
        {
            Console.WriteLine("Enter Ingredient:");
            string ingredient = Console.ReadLine();
            ingredients[index] = ingredient;
        }
        recipeService.AddNewRecipe(new Recipe 
        {  
            Name = name,
            Ingredients = ingredients
        });
    }
}