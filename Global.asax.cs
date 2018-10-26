using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Sample.AadV2Bot.Areas.Bot;

namespace Microsoft.Bot.Sample.AadV2Bot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly object Key_DataStore = new object();

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();

            Conversation.UpdateContainer(
            builder =>
            {
                var store = new InMemoryDataStore();
                builder.Register(c => store)
                          .Keyed<IBotDataStore<BotData>>(Key_DataStore)
                          .AsSelf()
                          .SingleInstance();
            });
        }
    }
}
