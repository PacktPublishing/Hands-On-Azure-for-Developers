using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Azure.NotificationHubs;

namespace HandsOnAzureApp.Web.Controllers
{
    public class HubController : ApiController
    {
        public static Lazy<NotificationHubClient> Hub = new Lazy<NotificationHubClient>(() =>
            NotificationHubClient.CreateClientFromConnectionString("<connection string>", "<hub>"));

        [HttpPost]
        public async Task<HttpResponseMessage> Send()
        {
            var notification = new Notification("Hey, check this out!");
            var fullNotification = "{\"aps\": {\"content-available\": 1, \"sound\":\"\"}, \"richId\": \"" + notification.Id +
                            "\",  \"richMessage\": \"" + notification.Message + "\", \"richType\": \"" +
                            notification.RichType + "\"}";

            await Hub.Value.SendAppleNativeNotificationAsync(fullNotification, "<tag>");
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Get(string id)
        {
            var image = Notification.ReadImage(id);
            var result = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StreamContent(image)};
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/{png}");

            return result;
        }
    }

    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public Guid Id => Guid.NewGuid();
        public string Message { get; set; }
        public string RichType => "img";

        public static Stream ReadImage(string id)
        {
            // Find image based on ID...
            return Stream.Null;
        }
    }
}