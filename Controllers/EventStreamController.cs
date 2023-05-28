using Microsoft.AspNetCore.Mvc;

namespace StreamingAPI.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventStreamController : Controller
    {
        //this method works fine
        [HttpGet]
        public async Task EventStream()
        {
            var response = Response;
            response.Headers.Add("Cache-Control", "no-cache");
            response.Headers.Add("Content-Type", "text/event-stream");

            for (var i = 0; i<10 ; ++i)
            {
                await response.WriteAsync($"data: {i}\n\n");
                await response.Body.FlushAsync();

                await Task.Delay(5000);
            }
        }
    }
}
