using RecipeOrganiser.Entities;

namespace RecipeOrganiser.Services
{
    internal interface IRecipeService
    {
        void PrintAllRecipes();
        void AddNewRecipe(Recipe recipe);
        Recipe FindOneByName(string name);
    }
}
