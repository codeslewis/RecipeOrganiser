﻿namespace RecipeOrganiser.Entities
{
    public class Recipe
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Recipe Name: {Name}";
        }
    }
}