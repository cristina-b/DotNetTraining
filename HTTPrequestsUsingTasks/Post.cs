using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HTTPrequestsUsingTasks
{
    class Post
    {        
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        List<Comment> comments = new List<Comment>();

        public async void GetCommentsAsync(HttpClient client)
        {            
            string url = "https://jsonplaceholder.typicode.com/comments?postId=";
            string result = await client.GetStringAsync(url + id.ToString());

            this.comments = JsonSerializer.Deserialize<List<Comment>>(result); ;            

            /*foreach (Comment comment in comments)
            {
                Console.WriteLine(comment.body);
            }*/
        }
    }
}
