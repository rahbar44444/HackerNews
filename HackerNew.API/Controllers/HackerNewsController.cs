using HackerNews.Logic;
using HackerNews.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class HackerNewsController : ControllerBase
{
	private readonly IHackerNews _hackerNews;

	public HackerNewsController(IHackerNews hackerNews)
	{
		_hackerNews = hackerNews;
	}

	[HttpGet("best-stories")]
	public async Task<ActionResult<IEnumerable<BestStory>>> GetBestStories(int n)
	{
		try
		{
			var bestStories = _hackerNews.GetBestStories(n);

			return Ok(bestStories);
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"An error occurred: {ex.Message}");
		}
	}

}
