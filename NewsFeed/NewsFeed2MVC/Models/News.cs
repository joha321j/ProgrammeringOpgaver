
using System;
namespace NewsFeed2MVC.Models
{

public class News
{
public int NewsId { get; set; }

public string Author { get; set; }
public string Title { get; set; }
public string Content { get; set; }
public DateTime CreatedDate { get; set; }
public DateTime UpdatedDate { get; set; }
public string HashTags { get; set; }
    }
}