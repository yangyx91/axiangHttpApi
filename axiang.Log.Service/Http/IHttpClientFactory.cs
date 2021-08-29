using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace axiang.Log.Service.Http
{
	public interface IHttpClientFactory
	{
		/// <summary>
		/// Defines how HttpClient should be instantiated and configured by default. Do NOT attempt
		/// to cache/reuse HttpClient instances here - that should be done at the FlurlClient level
		/// via a custom FlurlClientFactory that gets registered globally.
		/// </summary>
		/// <param name="handler">The HttpMessageHandler used to construct the HttpClient.</param>
		/// <returns></returns>
		HttpClient CreateHttpClient();

		/// <summary>
		/// Defines how the 
		/// </summary>
		/// <returns></returns>
		HttpMessageHandler CreateMessageHandler();
	}
}
