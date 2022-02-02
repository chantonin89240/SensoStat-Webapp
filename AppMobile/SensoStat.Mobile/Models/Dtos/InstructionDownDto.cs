using System;
using Newtonsoft.Json;

namespace SensoStat.Mobile.Models.Dtos
{
    public class InstructionDownDto
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("content")] public string Content { get; set; }

        [JsonProperty("isQuestion")] public bool IsQuestion { get; set; }

        [JsonProperty("position")] public int Position { get; set; }

        [JsonProperty("onTheDate")] public DateTime onTheDate { get; set; }

        [JsonProperty("idSession")] public string IdSession { get; set; }

    }
}
