using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerNews.Logic
{
	public interface IApiClient
	{
		HttpClient APIClient { get; }

		string BaseUrl { get; }
	}
}
