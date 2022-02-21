using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SensoStat.Mobile.Models.Dtos
{
    public class SessionDownDto
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("msgHome")] public string MsgHome { get; set; }

        [JsonProperty("msgFinal")] public string MsgFinal { get; set; }

        [JsonProperty("publication")] public PublicationDownDto Publication { get; set; }

        [JsonProperty("instructions")] public List<InstructionDownDto> Instructions { get; set; }

        [JsonProperty("products")] public List<ProductDownDto> Products { get; set; }

        [JsonProperty("presentations")] public List<PresentationDownDto> Presentations { get; set; }

    }
}
