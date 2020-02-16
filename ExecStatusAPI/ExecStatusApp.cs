using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace ExecStatusAPI
{
    class ExecStatusApp
    {
        static HttpClient client = new HttpClient();

        //Put request
        static async Task<Uri> CreateExecStatsAsync(ExecStats stats)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "ExecStats", stats);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        //Get request, returns a list of ExecStats
        static async Task<List<ExecStats>> GetExecStatsAsync()
        {
            string path = "ExecStats";
            List<ExecStats> stats = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                stats = await response.Content.ReadAsAsync<List<ExecStats>>();
            }
            return stats;
        }

        //Get request by Id
        static async Task<ExecStats> GetExecStatsAsync_Id(string Id)
        {
            string path = $"ExecStats/{Id}";
            ExecStats stats = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                stats = await response.Content.ReadAsAsync<ExecStats>();
            }
           
            return stats;
        }

        //Put request
        static async Task<ExecStats> UpdateExecStatsAsync(ExecStats stats)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"ExecStats/{stats.Id}", stats);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            stats = await response.Content.ReadAsAsync<ExecStats>();
            return stats;
        }

        //Delete request by id
        static async Task<HttpStatusCode> DeleteExecStatsAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"ExecStats/{id}");
            return response.StatusCode;
        }

        //Get request by task, returns a list of ExecStats
        static async Task<List<ExecStats>> GetExecStatsActivityAsync_Id(string Id)
        {
            string path = $"ExecStatsActivity/{Id}";
            List<ExecStats> stats = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                stats = await response.Content.ReadAsAsync<List<ExecStats>>();
            }
            
            return stats;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        //Enter API calls here
        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://execstatusapp.azurewebsites.net/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            try
            {
                //create two new ExecStats
                ExecStats stats1 = new ExecStats("1580505409", "machine1", "appname1", "task1", 0, 1, 2, 3);
                ExecStats stats2 = new ExecStats("1580505410", "machine2", "appname2", "task2", 0, 1, 2, 3);

                Console.WriteLine("PUT 2 ITEMS");
                var url = await CreateExecStatsAsync(stats1);
                Console.WriteLine($"Created at {url}");
                url = await CreateExecStatsAsync(stats2);
                Console.WriteLine($"Created at {url}");

                Console.WriteLine("GET ALL ITEMS");
                List<ExecStats> all_stats = null;
                all_stats = await GetExecStatsAsync();
                foreach(var i in all_stats)
                {
                    i.ShowExecStats();
                }
                
                Console.WriteLine("\nGET ITEMS BY ID");
                ExecStats stats = null;
                stats = await GetExecStatsAsync_Id("1580505409");
                stats.ShowExecStats();

                Console.WriteLine("\nGET ITEMS BY TASK");
                all_stats = null;
                all_stats = await GetExecStatsActivityAsync_Id("task2");
                foreach (var i in all_stats)
                {
                    i.ShowExecStats();
                }

                Console.WriteLine("DELETE ALL");
                var statuscode1 = await DeleteExecStatsAsync(stats1.Id);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statuscode1})");
                var statuscode2 = await DeleteExecStatsAsync(stats2.Id);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statuscode2})");

                Console.WriteLine("done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
            
        }
  
    }
}
