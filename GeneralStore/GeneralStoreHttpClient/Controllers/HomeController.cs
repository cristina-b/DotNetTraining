using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeneralStoreHttpClient.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        private readonly IHttpClientFactory factory;
        private readonly CategoryClient client;
        private readonly ILogger<HomeController> logger;

        public HomeController(IHttpClientFactory factory, CategoryClient client, ILogger<HomeController> logger)
        {
            this.factory = factory;
            this.client = client;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            var client = this.factory.CreateClient("generalstore-api");
            var response = await client.GetAsync($"api/Category/{id}");
            //response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return this.NotFound();
                }

                var error = await response.Content.ReadAsStringAsync();
                this.logger.LogError("Error from api: " + error);

                return this.BadRequest(error);
            }
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
