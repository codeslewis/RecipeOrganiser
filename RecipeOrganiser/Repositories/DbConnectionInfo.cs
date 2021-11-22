namespace RecipeOrganiser.Repositories
{
    internal class DbConnectionInfo
    {
        internal static readonly string URI = "http://localhost:8529/";
        internal static readonly string DB_NAME = "recipe";
        internal static readonly string USER_NAME = "recipe-app";
        internal static readonly string PASSWORD = "password";
        internal static readonly string COLLECTION = "recipes";
    }
}
