using System;
using Newtonsoft.Json;

namespace SensoStat.Mobile.Models.Dtos
{
    public class ProductDownDto
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("codeProduct")] public string CodeProduct { get; set; }
    }
}
