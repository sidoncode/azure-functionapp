using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class BlobTrigger1
    {
        [FunctionName("BlobTrigger1")]
       public static void Run(
        [BlobTrigger("demo/{name}",Connection = "AzureWebJobsStorage")]Stream myBlob,
        [Blob("output/{name}",FileAccess.Write, Connection = "AzureWebJobsStorage")]Stream outputBlob,

        String name,
        ILogger log)
        {
            var len = myBlob.Length;
            myBlob.CopyTo(outputBlob);
        }
    }
}
