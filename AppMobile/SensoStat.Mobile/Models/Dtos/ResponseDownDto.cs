using System;
using Newtonsoft.Json;

namespace SensoStat.Mobile.Models.Dtos
{
    public class ResponseDownDto
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("content")] public string Content { get; set; }

        [JsonProperty("idQuestion")] public string IdQuestion { get; set; }

        public InstructionDownDto Instruction { get; set; }
    }
}
