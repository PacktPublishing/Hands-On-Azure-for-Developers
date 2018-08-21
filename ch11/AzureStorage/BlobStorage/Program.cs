using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BlobStorage
{
    internal class Program
    {
        private static void Main()
        {
            var storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
            var cloudBlobClient = storageAccount.CreateCloudBlobClient();
            var container = cloudBlobClient.GetContainerReference("blob");

            container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);

            var blob = container.GetBlockBlobReference("foo.txt");          
            blob.UploadText("This is my first blob!");

            Console.ReadLine();
        }
    }
}
