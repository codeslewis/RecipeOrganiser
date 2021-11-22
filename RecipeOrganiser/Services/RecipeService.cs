using RecipeOrganiser.Entities;
using RecipeOrganiser.Repositories;

namespace RecipeOrganiser.Services
{
    class RecipeService : IRecipeService
    {
        private IRepository<Recipe> _recipeRepository;

        public RecipeService()
        {
            //_recipeRepository = new InMemoryRecipeRepository();
            _recipeRepository = new ArangoRepository<Recipe>();
        }
        public void AddNewRecipe(Recipe recipe)
        {
            _recipeRepository.Add(recipe);
        }

        public Recipe FindOneByName(string name)
        {
            return _recipeRepository.GetByName(name);
        }

        public void PrintAllRecipes()
        {
            Console.WriteLine("Recipes...");
            _recipeRepository.GetAll().ToList<Recipe>().ForEach(r => Console.WriteLine(r));
            Console.WriteLine("End of Recipes");
        }
    }
}
