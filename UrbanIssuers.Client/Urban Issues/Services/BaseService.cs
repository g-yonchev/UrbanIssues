using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using Windows.Storage;

namespace UrbanIssues.Services
{
	public abstract class BaseService
	{
		protected string baseUrl = "http://localhost:4861/";

		private static HttpClient client = new HttpClient();

		public BaseService()
		{
		}

		public static HttpClient Client
		{
			get { return client; }
			set { client = value; }
		}

		public async Task<string> LogIn(/*LoginViewModel data*/)
		{
			try
			{
				var content = new StringContent("grant_type=password&username=" + "data.Username" + "&password=" + "data.Password");
				var response = await Client.PostAsync(this.baseUrl + "Token", content);
				var responseContent = await response.Content.ReadAsStringAsync();
				var responseContentAsDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
				var token = responseContentAsDictionary["access_token"];

				return token;
			}
			catch (Exception ex)
			{
				return string.Empty;
			}
		}

		public async Task<string> GetToken()
		{
			if (!File.Exists(Path.Combine(ApplicationData.Current.LocalFolder.Path, "token")))
			{
				return string.Empty;
			}

			var tokenFile = await ApplicationData.Current.LocalFolder.GetFileAsync("token");
			return await FileIO.ReadTextAsync(tokenFile);
		}

		public async Task<HttpResponseMessage> GetData(string url)
		{
			try
			{
				var response = await Client.GetAsync(url);

				return response;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<HttpResponseMessage> GetPrivateData(string url)
		{
			var token = await this.GetToken();

			if (string.IsNullOrEmpty(token))
			{
				return new HttpResponseMessage(HttpStatusCode.Unauthorized);
			}

			if (!Client.DefaultRequestHeaders.Contains("Authorization"))
			{
				Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
			}

			return await this.GetData(url);
		}

		public async Task<HttpResponseMessage> PostData(object data, string url)
		{
			try
			{
				string json = string.Empty;

				if (data != null)
				{
					json = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(data));
				}

				var contentToSend = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await Client.PostAsync(url, contentToSend);

				return response;
			}
			catch (Exception ex)
			{
				return new HttpResponseMessage(HttpStatusCode.BadRequest);
			}
		}
	}
}
