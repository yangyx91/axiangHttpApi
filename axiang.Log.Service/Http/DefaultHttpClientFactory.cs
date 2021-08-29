using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;

namespace axiang.Log.Service.Http
{
	/// <summary>
	/// 参照：https://github.com/tmenier/Flurl/tree/dev/src/Flurl.Http/Configuration
	/// </summary>
	public class DefaultHttpClientFactory : IHttpClientFactory
	{
		/// <summary>
		/// Override in custom factory to customize the creation of HttpClient used in all Flurl HTTP calls.
		/// In order not to lose Flurl.Http functionality, it is recommended to call base.CreateClient and
		/// customize the result.
		/// </summary>
		public virtual HttpClient CreateHttpClient()
		{
			return new HttpClient()
			{
				// Timeouts handled per request via FlurlHttpSettings.Timeout
				Timeout = System.Threading.Timeout.InfiniteTimeSpan
			};
		}

		/// <summary>
		/// Override in custom factory to customize the creation of HttpClientHandler used in all Flurl HTTP calls.
		/// In order not to lose Flurl.Http functionality, it is recommended to call base.CreateMessageHandler and
		/// customize the result.
		/// </summary>
		public virtual HttpMessageHandler CreateMessageHandler()
		{
			var httpClientHandler = new HttpClientHandler();
			try
			{
				httpClientHandler.UseCookies = true;
				//config cookies and redirects
			}
			catch (PlatformNotSupportedException)
			{

			}
			if (httpClientHandler.SupportsRedirectConfiguration)
				httpClientHandler.AllowAutoRedirect = false;

			if (httpClientHandler.SupportsAutomaticDecompression)
			{
				httpClientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			}
			return httpClientHandler;
		}
	}
}

