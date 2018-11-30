using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableStorage
{
    internal class Program
    {
        private static void Main()
        {
            var storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("orders");
            
            table.CreateIfNotExists();

            var op = TableOperation.Insert(new DynamicTableEntity("orders", Guid.NewGuid().ToString(), "*",
                new Dictionary<string, EntityProperty>
                {
                    {"Created", EntityProperty.GeneratePropertyForDateTimeOffset(DateTimeOffset.Now)},
                    {"CustomerId", EntityProperty.GeneratePropertyForString("Customer-001")}
                }));

            table.Execute(op);

            var query = new TableQuery();
            var result = table.ExecuteQuery(query);

            foreach (var entity in result)
            {
                Console.WriteLine($"{entity.PartitionKey}|{entity.RowKey}|{entity.Timestamp}|{entity["Created"].DateTimeOffsetValue}|{entity["CustomerId"].StringValue}");
            }

            var query2 =
                new TableQuery().Where(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "orders"));

            Console.ReadLine();
        }
    }
}
