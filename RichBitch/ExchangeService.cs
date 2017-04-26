using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace RichBitch
{
    public class ExchangeService
    {
        private const string baseUrl = "http://api.fixer.io/";


        public void GetLatest(Currency currency = Currency.USD)
        {
            var request = WebRequest.Create($"{baseUrl}latest?base={currency}");
            request.ContentType = "application/json";
            request.Method = "GET";

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response != null && response.StatusCode != HttpStatusCode.OK)
                    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                if (response != null)
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var serializer = new JsonSerializer();
                        var res = serializer.Deserialize(reader, typeof(ExchangeResponse));
                    }
            }
        }
    }
}