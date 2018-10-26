using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Bot.Sample.AadV2Bot.Areas.Bot.Models
{
    public class WebChatModel
    {
        public WebChatModel()
        {
            Task.Run(async () => await SetToken()).Wait();
        }

        public string Token { get; set; }
        public string UserId { get; set; }

        async Task SetToken()
        {
            string botChatSecret = "{YOUR DIRECT LINE SECRET}";
            this.UserId = $"dl_{ Guid.NewGuid() }";
            var request = new HttpRequestMessage(HttpMethod.Post, "https://directline.botframework.com/v3/directline/tokens/generate");
            request.Headers.Add("Authorization", "Bearer " + botChatSecret);
            request.Content = new StringContent(JsonConvert.SerializeObject(new { User = new { Id = this.UserId } }), Encoding.UTF8, "application/json");
            
            using (HttpResponseMessage response = await new HttpClient().SendAsync(request))
            {
                string tokenJson = await response.Content.ReadAsStringAsync();
                Token = JObject.Parse(tokenJson)["token"].ToString();
            }
        }
    }
}