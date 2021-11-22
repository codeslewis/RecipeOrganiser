using RecipeOrganiser.Entities;

namespace RecipeOrganiser.Repositories
{
    interface IRecipeRepository
    {
        //<IEnumerable<Recipe> GetAll();
        Task AddAsync(Recipe recipe);
    }
}
