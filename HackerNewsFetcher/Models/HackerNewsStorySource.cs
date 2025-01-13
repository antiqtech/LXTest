using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace HackerNewsFetcher.Models
{
    public class HackerNewsStorySource
    {
        public string? Title { get; set; }
        public string? Uri { get; set; }
        public string? PostedBy { get; set; }
        public int Time { get; set; }
        public int Score { get; set; }
        public int Descendants { get; set; }
    }


 
}
