using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using NewsFeed2MVC.Data;
using NewsFeed2MVC.Models;
using NewsFeed2MVC.ViewModel;
using Newtonsoft.Json;

namespace NewsFeed2MVC.ViewComponents
{
    public class DateIntervalNewsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public DateIntervalNewsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string startDateInput, string endDateInput)
        {
            if ((startDateInput == null) && (endDateInput == null))
            {
                return View(new List<News>());
            }

            var startDate = DateTime.Parse(startDateInput);

            var endDate = DateTime.Parse(endDateInput);

            int startYear = startDate.Year;
            int startMonth = startDate.Month;
            int endYear = endDate.Year;
            int endMonth = endDate.Month;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client
                    .GetAsync(
                        $"https://localhost:44325/api/values/from/{startYear}/{startMonth}/to/{endYear}/{endMonth}")
                    .Result;

                response.EnsureSuccessStatusCode();
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var model = JsonConvert.DeserializeObject<List<News>>(responseBody);

                return View(model);
            } 
        }
    }
}
