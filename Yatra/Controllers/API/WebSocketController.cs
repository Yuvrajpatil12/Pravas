using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using Yatra.Models;

namespace Yatra.Controllers.API
{
    public class WebSocketController : ControllerBase
    {
        private readonly ILogger<WebSocketController> _logger;

        public WebSocketController(ILogger<WebSocketController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        [Microsoft.AspNetCore.Mvc.HttpGet("/ws/driver-location")] // Define the path for endpoint 2
        public async Task GetDriverLocation()
        {
            try
            {
                if (HttpContext.WebSockets.IsWebSocketRequest)
                {
                    using (var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync())
                    {
                        _logger.LogInformation("WebSocket connection established for endpoint 2");
                        WebSocketHandlerHelper webSocketHandlerHelper = new WebSocketHandlerHelper();

                        await webSocketHandlerHelper.ProcessAsync(webSocket); // Pass `null` if no parameter needed
                    }
                }
                else
                {
                    HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                }
            }
            catch (Exception ex)
            {

                
            }
            
        }
    }
}
