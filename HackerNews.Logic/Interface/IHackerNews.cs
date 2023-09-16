using HackerNews.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerNews.Logic
{
	public interface IHackerNews
	{
		Task<List<BestStory>> GetBestStories(int number);
	}
}
