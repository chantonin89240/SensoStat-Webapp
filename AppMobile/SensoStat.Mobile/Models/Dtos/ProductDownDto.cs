using System;
using Newtonsoft.Json;

namespace SensoStat.Mobile.Models.Dtos
{
    public class ProductDownDto
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("code")] public string Code { get; set; }
    }
}
