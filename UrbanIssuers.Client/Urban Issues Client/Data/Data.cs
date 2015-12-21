namespace Urban_Issues_Client.Data
{
    using System;
    using Windows.Web.Http;
    using Windows.Web.Http.Headers;
    using Models;
    using Newtonsoft.Json;

    public static class Data
    {

        public static void LoginUser()
        {

        }
        public static async void RegisterUser(RegisterUserModel user)
        {
            var client = new HttpClient();
            var url = "http://localhost:58368/api/account/register";
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));

            client.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new HttpStringContent(JsonConvert.SerializeObject(user), Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
            var response = await client.SendRequestAsync(request);

        }
    }
}
