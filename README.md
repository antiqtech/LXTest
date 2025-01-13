

This projet is design to make request to fetch a varying number of stories from HackerNewsAPI using a provided uri. 

For more information about HackerNewsAPI :  https://github.com/HackerNews/API


There is only a signle endpoint to make request:

https://[HOST]/HackerNewsStory/bestNStories?N=[StoryLimit]

The Requested amount of best stories will be fetched from HackerNewsAPI in descending order of score and the result will be in the following format:
[ 
  {
    "title": "A uBlock Origin update was rejected from the Chrome Web Store",
    "uri": "https://github.com/uBlockOrigin/uBlock-issues/issues/745",
    "postedBy": "ismaildonmez",
    "time": "2025-01-06T15:48:50+00:00",
    "score": 3074,
    "commentCount": 584
  },
  {...},
  {...},
  {...},
  ...
]

The project is in the initial development phase and certain specifications such request rate limit values will be addressed 
as the project development continues and request handling limit requirements get solidified. 

Curently it is assumed  the results will be in descending order of score. In future, order option might need to be added to endpoint as parameter to provide
flexibility. The model design might need to be updated depending on changes on HackerNewsAPI.  