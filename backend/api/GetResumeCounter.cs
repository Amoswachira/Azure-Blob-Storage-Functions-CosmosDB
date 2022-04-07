using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"AzureresumeDb", containerName:"Counter", Connection  = "AzureresumeConnetinString", Id = "1", PartitionKey ="1")] Counter counter,
            [CosmosDB(databaseName:"AzureresumeDb", containerName:"Counter", Connection  = "AzureresumeConnetinString", Id = "1", PartitionKey ="1")] out Counter updatedCounter,
            ILogger log)
            
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            // testing comment
            updatedCounter = counter;
            updatedCounter.Count += 1;

            var jsonToReturn = JsonConvert.SerializeObject(updatedCounter);
             return new HttpResponseMessage(System.Net.HttpStatusCode.OK)  
            {  
                Content = new StringContent(jsonToReturn, System.Text.Encoding.UTF8, "application/json")    //returning the updated counter value 

            };
         

            
        }
    }
}
