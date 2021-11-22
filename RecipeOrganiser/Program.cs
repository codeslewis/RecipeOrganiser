using RecipeOrganiser.Entities;
using RecipeOrganiser.Repositories;
using RecipeOrganiser.Services;
using System;

namespace RecipeOrganiser;

public class Program
{
    public static void Main()
    {
        IRecipeService service = new RecipeService();
        int option = 0;
        while (true)
        {
            Console.WriteLine("1. Add" + Environment.NewLine + "2. Print");
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AddRecipe(service);
                    break;
                case 2:
                    service.PrintAllRecipes();
                    break;
                default:
                    return;
            }
        }
    }

    private static void AddRecipe(IRecipeService recipeService)
    {
        Console.WriteLine("Enter Recipe name:");
        string name = Console.ReadLine();
        Console.WriteLine("How many ingredients:");
        int numberOfIngredients = int.Parse(Console.ReadLine());
        string[] ingredients = new string[numberOfIngredients];
        for(int index = 0; index < numberOfIngredients; index++)
        {
            Console.WriteLine("Enter Ingredient:");
            ingredients[index] = Console.ReadLine();
        }
        recipeService.AddNewRecipe(new Recipe 
        {  
            Name = name,
            Ingredients = ingredients
        });
    }
}