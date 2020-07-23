using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeneralStoreHttpClient.Controllers
{
    public class CategoryClient
    {
        private readonly HttpClient client;

        public CategoryClient(HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri("http://localhost:5000/");
            this.client.Timeout = TimeSpan.FromSeconds(1);
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<CategoryModel> GetCategory(int id)
        {
            var response = await this.client.GetAsync($"api/Category/{id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoryModel>(result);
        }

        public async Task<CategoryModel> CreateCategory(CreateCategoryModel model)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync("api/Category", content);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoryModel>(result);
        }

        public class CreateCategoryModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class CategoryModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }    
}
