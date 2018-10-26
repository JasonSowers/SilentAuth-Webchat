using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Bot.Sample.AadV2Bot.Areas.Bot.Models;

namespace Microsoft.Bot.Sample.AadV2Bot.Areas.Bot.Controllers
{
    public class WebChatController : Controller
    {
        // GET: Bot/WebChat
        public ActionResult Index()
        {
            var vm = new WebChatModel();
            return View(vm);
        }
    }
}