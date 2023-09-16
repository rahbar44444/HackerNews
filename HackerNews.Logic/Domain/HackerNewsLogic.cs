using HackerNews.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HackerNews.Logic
{
	public class HackerNewsLogic : IHackerNews
	{
		#region Private Fields

		private readonly IApiClient _apiClient;

		#endregion Private Fields

		#region Constructor

		public HackerNewsLogic(IApiClient apiClient)
        {
			_apiClient = apiClient;

		}

		#endregion Constructor

		#region Public Methods

		public async Task<List<BestStory>> GetBestStories(int number)
		{
			// Step 1: Get the list of best story IDs from the Hacker News API
			List<BestStory> bestStoryList = new List<BestStory>();
			List<long> bestStories = new List<long>();
			string url = @$"{_apiClient.BaseUrl}beststories.json?print=pretty";
			using (HttpResponseMessage response = _apiClient.APIClient.GetAsync(url).GetAwaiter().GetResult())
			{
				response.EnsureSuccessStatusCode();
				var responseContent = response.Content;
				var bestStoryJson = responseContent.ReadAsStringAsync().GetAwaiter().GetResult();
				bestStories = JsonConvert.DeserializeObject<List<long>>(bestStoryJson);

			}

			// Step 2: Retrieve details for the best n stories in parallel
			var tasks = bestStories.Take(number).Select(async storyId =>
			{				
				StoryDetail storyDetail = new StoryDetail();
				string url = @$"{_apiClient.BaseUrl}item/{storyId}.json?print=pretty";
				using (HttpResponseMessage response = _apiClient.APIClient.GetAsync(url).GetAwaiter().GetResult())
				{
					response.EnsureSuccessStatusCode();
					var responseContent = response.Content;
					var bestStoryJson = responseContent.ReadAsStringAsync().GetAwaiter().GetResult();
					storyDetail = JsonConvert.DeserializeObject<StoryDetail>(bestStoryJson);

				}
				return storyDetail;
			});

			var bestStories1 = await Task.WhenAll(tasks);

			// Step 3: Sort the stories by score in descending order
			foreach (var item in bestStories1.OrderByDescending(story => story?.score ?? 0).ToList())
			{
				// Parse the 'Time' int to a DateTime
				DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(item.time);
				DateTime dateTimeUtc = dateTimeOffset.UtcDateTime;
				bestStoryList.Add(new BestStory { Title = item.title, Score = item.score, PostedBy = item.by, Time = dateTimeUtc, Uri = item.url, CommentCount = item.kids.Count });
			}

			return bestStoryList;
		}

		#endregion Public Methods
	}
}
