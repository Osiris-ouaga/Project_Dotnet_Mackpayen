using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP.Server.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Model;
using ASP.Server.Database;

namespace ASP.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryDbContext libraryDbContext;

        public HomeController(ILogger<HomeController> logger, LibraryDbContext libraryDbContext)
        {
            _logger = logger;
            this.libraryDbContext = libraryDbContext;
        }

        public IActionResult Index()
        {
            List<Book> ListBooks = libraryDbContext.Books.ToList();
            return View(ListBooks);
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
