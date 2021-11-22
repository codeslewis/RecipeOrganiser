using RecipeOrganiser.Entities;
using static RecipeOrganiser.Repositories.DbConnectionInfo;

using ArangoDBNetStandard;
using ArangoDBNetStandard.Transport.Http;

namespace RecipeOrganiser.Repositories
{
    class ArangoRecipeRepository : IRecipeRepository
    {
        private readonly HttpApiTransport _transport;
        //private readonly DatabaseApiClient _databaseApiClient;
        private readonly ArangoDBClient _dbClient;

        public ArangoRecipeRepository()
        {
            _transport = HttpApiTransport.UsingBasicAuth(
                new Uri(URI),
                DB_NAME,
                USER_NAME,
                PASSWORD);
            _dbClient = new ArangoDBClient(_transport);
        }

        ~ArangoRecipeRepository()
        {
            _transport.Dispose();
            _dbClient.Dispose();
        }

        public void Add(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
