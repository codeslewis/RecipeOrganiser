using RecipeOrganiser.Entities;

namespace RecipeOrganiser.Repositories
{
    interface IRecipeRepository
    {
        List<Recipe> GetAll();
        void Add(Recipe recipe);
    }
}
