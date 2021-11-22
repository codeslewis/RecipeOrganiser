using RecipeOrganiser.Entities;
using RecipeOrganiser.Services;

namespace RecipeOrganiser.UI
{
    internal class CommandLineInterface
    {
        private readonly IRecipeService _recipeService;

        internal CommandLineInterface(IRecipeService service) => _recipeService = service;

        public void Run()
        {
            int option = 0;
            while (true)
            {
                Console.WriteLine("1. Add" + Environment.NewLine + "2. Find" + Environment.NewLine + "3. Print");
                option = 0;
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        AddRecipe();
                        break;
                    case 2:
                        FindRecipe();
                        break;
                    case 3:
                        _recipeService.PrintAllRecipes();
                        break;
                    default:
                        return;
                }
            }
        }

        private void FindRecipe()
        {
            Console.WriteLine("Enter Recipe name:");
            string name = Console.ReadLine();
            Console.WriteLine(_recipeService.FindOneByName(name));
        }

        private void AddRecipe()
        {
            Console.WriteLine("Enter Recipe name:");
            string name = Console.ReadLine();

            Console.WriteLine("How many ingredients:");
            int numberOfIngredients;
            int.TryParse(Console.ReadLine(), out numberOfIngredients);

            string[] ingredients = new string[numberOfIngredients];
            for (int index = 0; index < numberOfIngredients; index++)
            {
                Console.WriteLine("Enter Ingredient:");
                string ingredient = Console.ReadLine();
                ingredients[index] = ingredient;
            }
            _recipeService.AddNewRecipe(new Recipe
            {
                Name = name,
                Ingredients = ingredients
            });
        }
    }
}
