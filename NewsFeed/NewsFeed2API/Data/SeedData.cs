using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed2API.Data
{
    public static class SeedData
    {
        public static void Initialize(NewsContext context)
        {
            context.Database.EnsureCreated();

            if (context.news.Any())
            {
                return;
            }

            var News = new News[]
            {
                new News
                {
                    Author = "Mike",
                    Title = "Mike Sutter Meget Pik",
                    Content = "Hans forældre skammer sig virkeligt meget.",
                    CreatedDate = DateTime.Now.AddDays(-5)
                        .AddYears(-2),
                    UpdatedDate = DateTime.Now.AddDays(-5)
                        .AddYears(-2),
                    HashTags = "#Pik;#BJ;#Prettyboi"
                },
                new News
                {
                    Author = "Hans-Frederik",
                    Title = "Hans-Frederik vinder i minestryger.",
                    Content = "Hans forældre skammer sig virkeligt meget.",
                    CreatedDate = DateTime.Now.AddDays(-1)
                        .AddYears(-5),
                    UpdatedDate = DateTime.Now.AddDays(0)
                        .AddYears(0),
                    HashTags = "#Prettyboi"
                },
                new News
                {
                    Author = "Allan",
                    Title = "ALLAN KOMMER FOR SENT!!!!!!!!!!",
                    Content = "Hans undskyldning er, at hans cykel punkterede.",
                    CreatedDate = DateTime.Now.AddDays(0)
                        .AddYears(0),
                    UpdatedDate = DateTime.Now.AddDays(0)
                        .AddYears(0),
                    HashTags = "#FullOfShit;#DårligUndskyldning"
                },
                new News
                {
                    Author = "Kaare",
                    Title = "Cyno er dårlig til SMITE",
                    Content = "Det er under alt kritik.",
                    CreatedDate = DateTime.Now.AddDays(-532)
                        .AddYears(-1).AddMonths(2),
                    UpdatedDate = DateTime.Now.AddDays(-532)
                        .AddYears(-1).AddMonths(2),
                    HashTags = "#FullOfShit;#DårligUndskyldning"
                },
                new News
                {
                    Author = "Johannes",
                    Title = "Anders når aldrig DIAMOND i LOL",
                    Content = "Det er under alt kritik.",
                    CreatedDate = DateTime.Now.AddDays(0)
                        .AddYears(-1).AddMonths(2),
                    UpdatedDate = DateTime.Now.AddDays(0)
                        .AddYears(-1).AddMonths(2),
                    HashTags = "#FullOfShit;#MidOrFeed"
                },
                new News
                {
                    Author = "Anders",
                    Title = "Johannes skriver alt for meget lort.",
                    Content = "Hvordan kan man lukke så meget bullshit ud?",
                    CreatedDate = DateTime.Now.AddDays(2)
                        .AddYears(-5).AddMonths(2),
                    UpdatedDate = DateTime.Now.AddDays(-532)
                        .AddYears(-1).AddMonths(2),
                    HashTags = "#FullOfShit"
                }

            };

            context.AddRange(News);
            context.SaveChanges();
        }
    }
}
