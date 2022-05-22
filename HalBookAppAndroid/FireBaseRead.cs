using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
//using Microsoft.WindowsAzure.Storage.Blob;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace EmailReader //rename
{
    public class FireBaseRead
    {
        public FireBaseRead()
        {

        }

        const String storageConnection = "DefaultEndpointsProtocol=https;AccountName=halbookappstorage;AccountKey=+D6AxCmqVcfNVCG27qpciwmIsYL1FaAaLodN7iY6L+s6MjVWuVfq8yjWbKOrfgYLBvntOzIteFdW+ASt6HSKpw==;EndpointSuffix=core.windows.net;";
        const String accessKey = "+D6AxCmqVcfNVCG27qpciwmIsYL1FaAaLodN7iY6L+s6MjVWuVfq8yjWbKOrfgYLBvntOzIteFdW+ASt6HSKpw==";
        const String storageName = "halbookappstorage";

        public static void UploadFile(String file, String phoneUUID = "",String cont = "halbookappblob")
        {

            try { 
            var connectionString = String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
            storageName, // your storage account name
            accessKey); // your storage account access key

            var storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(cont);

            SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(30);
            sasConstraints.Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create;

            var blob = container.GetBlockBlobReference(phoneUUID + "outputfile.txt");
                var sas = blob.Uri + blob.GetSharedAccessSignature(sasConstraints);
            //File.AppendAllText(EmailFileRead.fileName1,
            //    blob.Uri+blob.GetSharedAccessSignature(sasConstraints));

            var cloudBlockBlob = new CloudBlockBlob(new Uri(sas));
            FileInfo file1 = new FileInfo(file);
            cloudBlockBlob.UploadFromFile(file1.FullName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                File.AppendAllText(EmailFileRead.fileName1, e.Message);
            }
        }

        public static void DownloadFile(String file, String phoneUUID = "", String cont = "halbookappblob")
        {
            try
            {
                var connectionString = String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                storageName, // your storage account name
                accessKey); // your storage account access key
                var storageAccount = CloudStorageAccount.Parse(connectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(cont);

                SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
                sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(30);
                sasConstraints.Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create;

                var blob = container.GetBlockBlobReference(phoneUUID + "outputfile.txt");
                var sas = blob.Uri + blob.GetSharedAccessSignature(sasConstraints);
                //File.AppendAllText(EmailFileRead.fileName1,
                //    blob.Uri + blob.GetSharedAccessSignature(sasConstraints));

                var cloudBlockBlob = new CloudBlockBlob(new Uri(sas));
                FileInfo file1 = new FileInfo(file);
                cloudBlockBlob.DownloadToFile(file1.FullName,FileMode.OpenOrCreate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                File.AppendAllText(EmailFileRead.fileName1, e.Message);
            }
        }

    }
}
