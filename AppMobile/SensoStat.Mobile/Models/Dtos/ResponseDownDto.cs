using System;
using Newtonsoft.Json;

namespace SensoStat.Mobile.Models.Dtos
{
    public class ResponseDownDto
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("content")] public string Content { get; set; }

        public InstructionDownDto Instruction { get; set; }

        public ProductDownDto Product { get; set; }
    }
}
