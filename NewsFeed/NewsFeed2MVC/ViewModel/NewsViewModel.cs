using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsFeed2MVC.Models;

namespace NewsFeed2MVC.ViewModel
{
    public class NewsViewModel
    {
        public List<News> News { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}
