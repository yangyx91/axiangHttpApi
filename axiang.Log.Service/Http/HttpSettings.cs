using System;
using System.Collections.Generic;
using System.Text;

namespace axiang.Log.Service.Http
{
	public class HttpSettings
	{
		private static IDictionary<string, object> _vals = new Dictionary<string, object>();

		internal T Get<T>(string propName = null)
		{
			return _vals.ContainsKey(propName) ? (T)_vals[propName] : default(T);
		}

		/// <summary>
		/// Sets a settings value for this instance.
		/// </summary>
		internal void Set<T>(T value, string propName = null)
		{
			_vals[propName] = value;
		}

		public string HttpClientFactoryName { get; set; } = "DefaultHttpClientFactory";

		public IHttpClientFactory HttpClientFactory
		{
			get => Get<IHttpClientFactory>(this.HttpClientFactoryName);
			set => Set(value, this.HttpClientFactoryName);
		}

		/// <summary>
		/// Resets all global settings to their default values.
		/// </summary>
		public virtual void ResetDefaults(string factoryName)
		{
			if (_vals.Count == 0)
			{
				HttpClientFactory = new DefaultHttpClientFactory();
				HttpClientFactoryName = factoryName;
			}
			else if (_vals.Count == 1)
			{

			}
			else if (_vals.Count > 1)
			{
				_vals.Clear();
				HttpClientFactory = new DefaultHttpClientFactory();
				HttpClientFactoryName = factoryName;
			}
		}
	}
}
