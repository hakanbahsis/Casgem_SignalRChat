using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebUI.Hubs;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Context _context=new Context();
        IHubContext<CategoryHub> _hubContext;

        public HomeController(ILogger<HomeController> logger, IHubContext<CategoryHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Category()
        {
 
            return View();
        }

        private async Task GetCategoryAsync()
        {
            int categoryCount = await _context.Categories.CountAsync();
            
            await _hubContext.Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
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