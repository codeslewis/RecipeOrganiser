using RecipeOrganiser.Entities;
using RecipeOrganiser.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOrganiser.Services
{
    class RecipeService : IRecipeService
    {
        private IRecipeRepository _recipeRepository;

        public RecipeService()
        {
            _recipeRepository = new InMemoryRecipeRepository();
        }
        public void AddNewRecipe(Recipe recipe)
        {
            _recipeRepository.Add(recipe);
        }

        public void PrintAllRecipes()
        {
            Console.WriteLine("Recipes...");
            _recipeRepository.GetAll().ForEach(r => Console.WriteLine(r));
            Console.WriteLine("End of Recipes");
        }
    }
}
