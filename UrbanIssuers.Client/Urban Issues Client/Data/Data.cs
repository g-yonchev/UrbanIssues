namespace Urban_Issues_Client.Data
{
    using System;
    using System.Threading.Tasks;
    using Windows.Web.Http;
    using Windows.Web.Http.Headers;
    using Models;
    using Newtonsoft.Json;

    public static class Data
    {
        private const string BASE_URL = "http://localhost:58368/";

        public static async Task<bool> LoginUser(LoginUserModel user)
        {
            user.Grant_type = "password";
            var client = new HttpClient();
            var url = BASE_URL + "/token";
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));

            client.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new HttpStringContent(JsonConvert.SerializeObject(user), Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/x-www-form-urlencoded");
            var response = await client.SendRequestAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            return true;
        }
        public static async Task<bool> RegisterUser(RegisterUserModel user)
        {
            var client = new HttpClient();
            var url = BASE_URL + "/api/account/register";
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));

            client.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new HttpStringContent(JsonConvert.SerializeObject(user), Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
            var response = await client.SendRequestAsync(request);
            bool result = response.IsSuccessStatusCode;
            return result;
        }
    }
}
