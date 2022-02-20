namespace SensoStat.Mobile.Models.Dtos
{
    using System;
    using Newtonsoft.Json;

    public class PublicationDownDto
    {
        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("dateStart")] public DateTime DateStart { get; set; }

        [JsonProperty("dateEnd")] public DateTime DateEnd { get; set; }
    }
}
