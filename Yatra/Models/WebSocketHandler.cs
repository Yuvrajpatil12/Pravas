using Core.Business.BusinessFacade;
using Core.Entity;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace Yatra.Models
{
    public class WebSocketHandler
    {
        private readonly string _connectionString;

        public WebSocketHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task ProcessAsync(WebSocket webSocket)
        {
            var buffer = new ArraySegment<byte>(new byte[1024]);
            while (webSocket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                switch (result.MessageType)
                {
                    case WebSocketMessageType.Text:
                        string message = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                        await HandleMessageAsync(message, webSocket);
                        break;
                    case WebSocketMessageType.Close:
                        string closeDescription = result.CloseStatus.ToString(); // Get the close status string
                        await webSocket.CloseAsync(result.CloseStatus.Value, closeDescription, CancellationToken.None);
                        break;
                    default:
                        break;
                }
            }
        }

        private async Task HandleMessageAsync(string message, WebSocket webSocket)
        {
            try
            {
                // Deserialize the JSON message (replace with your preferred deserializer)
                dynamic data = JsonConvert.DeserializeObject(message);

                if (!data.ContainsKey("ID") || data.ID == 0) // Check for missing or invalid ID
                {
                    // Send the user message when ID is missing
                    string missingIdMessage = "Missing required parameter: ID. Please provide the user ID in the Parameter.";
                    await webSocket.SendAsync(
                        Encoding.UTF8.GetBytes(missingIdMessage),
                        WebSocketMessageType.Text,
                        true,
                        CancellationToken.None);
                    return; // Optionally, you can close the connection here
                }
                else
                {
                    Int64 paramID = data.ID;
                    string paramUserLastLatitude = data.Latitude;
                    string paramUserLastLongitude = data.Longitude;

                    Users objData = new Users();
                    UsersBusinessFacade usersBusinessFacade = new UsersBusinessFacade();
                    objData.ID = paramID;
                    objData.UserLastLatitude = paramUserLastLatitude;
                    objData.UserLastLongitude = paramUserLastLongitude;

                    // Update the database
                    var result = usersBusinessFacade.Save(objData);

                    if (result > 0)
                    {
                        string jsonData = JsonConvert.SerializeObject(result);
                        await webSocket.SendAsync(Encoding.UTF8.GetBytes(jsonData), WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                    else
                    {
                        // Send the user message when ID is missing
                        string missingIdMessage = "User location is not updated.";
                        await webSocket.SendAsync(
                            Encoding.UTF8.GetBytes(missingIdMessage),
                            WebSocketMessageType.Text,
                            true,
                            CancellationToken.None);
                        return; // Optionally, you can close the connection here
                    }
                }
                
                //await UpdateDatabaseAsync(objData);
            }
            catch (Exception ex)
            {
                // Handle exceptions gracefully (log, send error message to client)
                Console.WriteLine($"Error processing message: {ex.Message}");
                await webSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, ex.Message, CancellationToken.None);
            }
        }


    }
}
