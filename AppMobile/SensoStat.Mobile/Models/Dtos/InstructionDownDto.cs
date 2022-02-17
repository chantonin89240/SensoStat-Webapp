using System;
using Newtonsoft.Json;
using SensoStat.Mobile.Models.Entities.Interfaces;

namespace SensoStat.Mobile.Models.Dtos
{
    public class InstructionDownDto : IInstructionEntity
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("content")] public string Content { get; set; }

        [JsonProperty("isQuestion")] public bool IsQuestion { get; set; }

        [JsonProperty("position")] public int Position { get; set; }

        [JsonProperty("onTheDate")] public DateTime onTheDate { get; set; }

        [JsonProperty("idSession")] public string IdSession { get; set; }

        
    }
}
