using RecipeOrganiser.Entities;

namespace RecipeOrganiser.Repositories
{
    class InMemoryRecipeRepository : IRecipeRepository
    {
        private readonly List<Recipe> _recipes;
        public InMemoryRecipeRepository()
        {
            _recipes = new List<Recipe>();
        }
        public void Add(Recipe recipe)
        {
            _recipes.Add(recipe);
        }

        public List<Recipe> GetAll()
        {
            return _recipes;
        }
    }
}
