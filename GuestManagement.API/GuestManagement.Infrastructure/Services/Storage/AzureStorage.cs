using System;
using System.IO;
using System.Net;
using Azure.Storage.Blobs;
using GuestManagement.Infrastructure.Base;
using GuestManagement.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;

namespace GuestManagement.Infrastructure.Services
{
    public class AzureStorage : IStorageService
    {
        private readonly IConfiguration _configuration;

        private BlobServiceClient blobServiceClient;      

        private AzureStorageOptions  storageOptions;
        public AzureStorage(IConfiguration configuration)
        {
            _configuration = configuration;

            storageOptions = configuration.GetSection("Features:AzureOptions")
            .Get<AzureOptions>().AzureStorageOptions;
            
        }

        public void UploadFile(StorageFile file)
        {        
           using FileStream uploadFileStream = File.OpenRead(file.PathWithName);
        
          try
          {
            blobServiceClient ??= new BlobServiceClient(storageOptions.BlobStorageUrl);

            string hostName = Dns.GetHostName();

            string containerName = String.Concat(storageOptions.LogsContainerPrefix,'-',hostName).ToLowerInvariant();
            
            BlobContainerClient blobContainerClient =  blobServiceClient.GetBlobContainerClient(containerName);
            
            blobContainerClient.CreateIfNotExists();
            
            var blobClient = blobContainerClient.GetBlobClient(file.Name);

            blobClient.Upload(uploadFileStream,true);
         
          }
          catch (System.Exception ex)
          {
               // TODO
          }
          
          finally{
              uploadFileStream.Close();
          }

         
        }
    }
}