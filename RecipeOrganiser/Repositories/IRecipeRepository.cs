using RecipeOrganiser.Entities;

namespace RecipeOrganiser.Repositories
{
    interface IRecipeRepository
    {
        IEnumerable<Recipe> GetAll();
        void Add(Recipe recipe);
    }
}
