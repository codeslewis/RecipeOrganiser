﻿using RecipeOrganiser.Entities;
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
            AddAsync(recipe).Wait();
        }
        private async Task AddAsync(Recipe recipe)
        {
            await _dbClient.Document.PostDocumentAsync<Recipe>(
                COLLECTION,
                recipe);
        }

        public IEnumerable<Recipe> GetAll()
        {
            throw new NotImplementedException();
        }

        //public async Task GetAllAsync()
        //{
        //    return await _dbClient.Cursor.PostCursorAsync<Recipe>(
        //        $"FOR doc IN {COLLECTION} RETURN doc");
        //}
    }
}
