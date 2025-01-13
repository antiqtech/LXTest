using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace HackerNewsFetcher.Models
{
    public class HackerNewsStoryView
    {
        public string? Title { get; set; }
        public string? Uri { get; set; }
        public string? PostedBy { get; set; }
        public string? Time { get; set; }
        public int Score { get; set; }
        public int CommentCount { get; set; }
        public HackerNewsStoryView(HackerNewsStorySource sourceStory) 
        {
            Title = sourceStory.Title;
            Uri = sourceStory.Title;
            PostedBy = sourceStory.Title;
            Time = DateTime.UnixEpoch.AddSeconds(sourceStory.Time).ToString("yyyy-MM-ddTHH:mm:ss+00:00") ;
            Score = sourceStory.Score;
            CommentCount = sourceStory.Descendants;
        }    
    }


 
}
