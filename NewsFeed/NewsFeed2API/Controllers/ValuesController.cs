using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewsFeed2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly NewsContext _context;
        public ValuesController(NewsContext context)
        {
            _context = context;
        }
      

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<News>> Get()
        {
            List<News> newsList = _context.news.ToList();
            return newsList;
        }

        // GET api/values/5
        [HttpGet("from/{startYear}/{startMonth}/to/{endYear}/{endMonth}")]
        public ActionResult<List<News>> Get(int startYear, int startMonth, int endYear, int endMonth)
        {
            DateTime dt1 = new DateTime(startYear, startMonth, 1);
            DateTime dt2 = new DateTime(endYear, endMonth, 1);


             List<News> newsList = _context.news.Where(x => x.CreatedDate >= dt1 && x.CreatedDate <= dt2).ToList();
            return newsList;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //POST api/values
        [HttpPost]
        public async Task<ActionResult<News>> PostNews(News news)
        {
            _context.news.AddRange(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostNews", new {id = news.NewsId}, news);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
