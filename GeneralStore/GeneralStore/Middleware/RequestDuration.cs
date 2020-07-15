using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStore.Middleware
{
    public class RequestDuration
    {
        private readonly ILogger logger;
        private readonly RequestDelegate next;

        public RequestDuration(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.logger = loggerFactory.CreateLogger<RequestDuration>();
        }

        public async Task Invoke(HttpContext context)
        {
            DateTime start = DateTime.Now;
            this.logger.LogInformation("Handling request: {}, time: {}", context.Request.Path, start);
            await this.next.Invoke(context);
            DateTime finish = DateTime.Now;
            this.logger.LogInformation("Finished handling request, time: {}", finish);
            this.logger.LogInformation("Total time: {}", finish - start);
        }

    }
}
