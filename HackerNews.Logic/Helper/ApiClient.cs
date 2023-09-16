using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HackerNews.Logic
{
	public class ApiClient : IApiClient
	{
		public ApiClient()
		{
		}

		public HttpClient APIClient => GetClient();

		public string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];

		private HttpClient GetClient()
		{
			// ToDo [HG] WIP: temporary code to skip SSL cert validation for development
			var handler = new HttpClientHandler()
			{
				ServerCertificateCustomValidationCallback = (msg, cert, chain, err) => { return true; }
			};

			var client = new HttpClient(handler);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return client;
		}
	}
}
