using RecipeOrganiser.Entities;
using RecipeOrganiser.Repositories;

namespace RecipeOrganiser.Services
{
    class RecipeService : IRecipeService
    {
        private IRecipeRepository _recipeRepository;

        public RecipeService()
        {
            //_recipeRepository = new InMemoryRecipeRepository();
            _recipeRepository = new ArangoRecipeRepository();
        }
        public void AddNewRecipe(Recipe recipe)
        {
            _recipeRepository.Add(recipe);
        }

        public void PrintAllRecipes()
        {
            Console.WriteLine("Recipes...");
            //_recipeRepository.GetAll().Result.ToList<Recipe>().ForEach(r => Console.WriteLine(r));
            Console.WriteLine("End of Recipes");
        }
    }
}
