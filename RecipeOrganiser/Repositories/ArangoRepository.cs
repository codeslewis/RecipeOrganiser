using static RecipeOrganiser.Repositories.DbConnectionInfo;

using ArangoDBNetStandard;
using ArangoDBNetStandard.Transport.Http;
using ArangoDBNetStandard.CursorApi.Models;

namespace RecipeOrganiser.Repositories
{
    internal class ArangoRepository<T> : IRepository<T> where T : class
    {
        private readonly HttpApiTransport _transport;
        private readonly ArangoDBClient _dbClient;

        public ArangoRepository()
        {
            _transport = HttpApiTransport.UsingBasicAuth(
                new Uri(URI),
                DB_NAME,
                USER_NAME,
                PASSWORD);
            _dbClient = new ArangoDBClient(_transport);
        }

        ~ArangoRepository()
        {
            _transport.Dispose();
            _dbClient.Dispose();
        }

        public void Add(T item)
        {
            AddAsync(item).Wait();
        }
        private async Task AddAsync(T item)
        {
            await _dbClient.Document.PostDocumentAsync<T>(
                COLLECTION,
                item);
        }

        public IEnumerable<T> GetAll()
        {
            CursorResponse<T> item = GetAllAsync().Result;
            return item.Result;
        }

        private async Task<CursorResponse<T>> GetAllAsync()
        {
            CursorResponse<T> response = await _dbClient.Cursor.PostCursorAsync<T>(
                $"FOR doc IN {COLLECTION} RETURN doc");
            return response;

        }

        public T GetByName(string name)
        {
            CursorResponse<T> item = GetByNameAsync(name).Result;
            return item.Result.First();
        }

        private async Task<CursorResponse<T>> GetByNameAsync(string name)
        {
            CursorResponse<T> response = await _dbClient.Cursor.PostCursorAsync<T>(
                $"FOR doc IN {COLLECTION} FILTER doc.Name == {name} RETURN doc");
            return response;
        }
    }
}
