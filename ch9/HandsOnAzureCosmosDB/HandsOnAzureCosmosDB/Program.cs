using System;
using Microsoft.Azure.CosmosDB.Table;
using Microsoft.Azure.Storage;

namespace HandsOnAzureCosmosDB
{
    internal class Program
    {
        private static void Main()
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=handsonazure;AccountKey=JcgOQ1A4PbZ3ScHeZ5LPhKKszdwZabFksvU2xJyJQUgD2ZpTzTFpt4b8rJ6jPFr5JLZnInbnBx6S3c6OZkLXdw==;TableEndpoint=https://handsonazure.table.cosmosdb.azure.com:443/;";
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();

            var reference = tableClient.GetTableReference("handsonazure");
            var result = reference.CreateIfNotExists();

            var executionResult = reference.Execute(TableOperation.Insert(new TableEntity("handsonazure", Guid.NewGuid().ToString())));
            Console.WriteLine(executionResult.Result);

            Console.ReadLine();
        }
    }
}
