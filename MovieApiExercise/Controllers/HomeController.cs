using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApiExercise.Models;
using MovieApiExercise.ViewModels;
using Newtonsoft.Json;

namespace MovieApiExercise.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly MovieViewModel _movieViewModel = new MovieViewModel();

        public async Task<IActionResult> Index()
        {
            InitializeApi();

            return View(_movieViewModel);
        }

        public async Task<IActionResult> ReserveSeat(int id)
        {
            var url = "http://simonsmoviebooking.azurewebsites.net/api/movie/BookMovie/" + id;
            HttpResponseMessage response = await _client.PutAsJsonAsync(url, 0);

            response.EnsureSuccessStatusCode();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("title,genre,description,numSeats")] Movie movie)
        {
            var url = "http://simonsmoviebooking.azurewebsites.net/api/movie";

            HttpResponseMessage response = await _client.PostAsJsonAsync(url, movie);

            return RedirectToAction(nameof(Index));
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

        public IActionResult IndexJs()
        {
            return View();
        }
        public void InitializeApi()
        {
            string data;
            HttpWebRequest request =
                (HttpWebRequest) WebRequest.Create("http://simonsmoviebooking.azurewebsites.net/api/movie");

            using(HttpWebResponse response = (HttpWebResponse) request.GetResponse()) 
            using(Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream ?? throw new InvalidOperationException()))
            {
                data = reader.ReadToEnd();
            }

            var model = JsonConvert.DeserializeObject<List<Movie>>(data);

            _movieViewModel.Movies = model;
        }
    }
}
