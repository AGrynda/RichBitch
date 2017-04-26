using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RichBitch
{
    public class ExchangeResponse
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; set; }
    }
}