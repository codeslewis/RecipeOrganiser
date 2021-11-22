using System.Text;

namespace RecipeOrganiser.Entities;
public class Recipe
{
    public string Name { get; set; }
    public IEnumerable<string> Ingredients { get; set; }

    public Recipe()
    {
        Name = "";
        Ingredients = new List<string>();
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Recipe Name: {Name}");
        foreach(string ingredient in Ingredients)
        {
            stringBuilder.AppendLine($"    {ingredient}");
        }
        return stringBuilder.ToString();
    }
}

