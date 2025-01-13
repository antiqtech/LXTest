using HackerNewsFetcher.Models;

namespace HackerNewsFetcher.DataService
{
    public interface IHackerNewsDataService
    {
        public Task<List<int>> GetBestStories();
        public Task<IEnumerable<HackerNewsStoryView>> GetBestStoriesWithLimit(int numberOfBestStories);
    }
}
