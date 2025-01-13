using HackerNewsFetcher.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace HackerNewsFetcher.DataService
{
    public class HackerNewsDataService : IHackerNewsDataService
    {
        private IConfiguration _configuration;
        public HackerNewsDataService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<int>> GetBestStories()
        {
            List<int>? results = new List<int>();

            using (var httpClient = new HttpClient())
            {
                var uri = _configuration["Settings:BestStoriesUri"];
                var json = await httpClient.GetStringAsync(uri);
                results = JsonConvert.DeserializeObject<List<int>>(json);
                // Now parse with JSON.Net
            }
            return results;
        }
        public async Task<IEnumerable<HackerNewsStoryView>> GetBestStoriesWithLimit(int numberOfBestStories)
        {
            List<int> bestStoriesIdList = await GetBestStories();
            List<HackerNewsStoryView> bestStories = new List<HackerNewsStoryView>();

            if (bestStoriesIdList != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var uriBase = _configuration["Settings:StoryItemBaseUri"];
                    for (int i = 0; i < bestStoriesIdList.Count && i < numberOfBestStories; i++)
                    {
                        var json = await httpClient.GetStringAsync(uriBase + bestStoriesIdList[i] + ".json");
                        var sourceObj=JsonConvert.DeserializeObject<HackerNewsStorySource>(json);
                        if (sourceObj != null)
                            bestStories.Add(new HackerNewsStoryView(sourceObj));


                    }
                }
            }

            return bestStories;
        }
    }
}
