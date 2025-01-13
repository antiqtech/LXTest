using HackerNewsFetcher.DataService;
using HackerNewsFetcher.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace HackerNewsFetcher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]

    public class HackerNewsStoryController : ControllerBase
    {
        private readonly IHackerNewsDataService _hackerNewsDataService;
        public HackerNewsStoryController(IHackerNewsDataService hackerNewsDataService) 
        {
            _hackerNewsDataService = hackerNewsDataService;
        }

        [HttpGet("bestNStories")]
        public async Task<IEnumerable<HackerNewsStoryView>>  Get(int N) 
        {
            var stories = await _hackerNewsDataService.GetBestStoriesWithLimit(N);
            return stories;
        }
    }
}
