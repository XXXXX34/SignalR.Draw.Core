using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Draw.Core.Models;
using SignalR.Draw.Core.SignalR;

namespace SignalR.Draw.Core.Controllers
{
    //1
    public class HomeController : Controller
    {
        private readonly IHubContext<ChatHub> _chatHub;

        public HomeController(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
