using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTPrequestsUsingTasks
{
    class Program
    {        
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");            

            List<Post> posts = JsonSerializer.Deserialize<List<Post>>(result);

            //Console.WriteLine(posts.First().body);           

            await Task.WhenAll(posts.Select(post => Task.Run(() => post.GetCommentsAsync(client))));
            
        }
    }
}