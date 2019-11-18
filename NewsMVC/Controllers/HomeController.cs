using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsMVC.Models;

namespace NewsMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            News news = new News()
            {
                NewsId = 1,
                Author = "Simon",
                Title = "Overskrift",
                Content = "Indhold",
                CreatedDate = DateTime.Now.AddDays(-1),
                UpdatedDate = DateTime.Now,
                HashTags = "#SimonGod;#/r/ProgrammerHumor"

            };


            return View(news);
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
