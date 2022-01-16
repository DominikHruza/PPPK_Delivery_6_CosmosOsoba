using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PPPK_Delivery_6_CosmosOsoba.Dao
{
    public static class CosmosDbServiceProvider
    {
        private const string DatabaseName = "People";
        private const string ContainerName = "People";
        private const string Account = "https://osobeppk.documents.azure.com:443/";
        private const string Key = "2tCzLD95kYnrhwKFmWtiMAkFz2SfqkhVuc6g2FTuytkpa8BzhlaFE6ukLbVpZVYcDxnJmQGmaLdn5UxmzaT45A==";
        private static ICosmosDbService cosmosDbService;

        public static ICosmosDbService CosmosDbService { get => cosmosDbService; }

        public async static Task Init()
        {
            CosmosClient client = new CosmosClient(Account, Key);
            cosmosDbService = new CosmosDbService(client, DatabaseName, ContainerName);
            DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await database.Database.CreateContainerIfNotExistsAsync(ContainerName, "/id");
        }
    }
}