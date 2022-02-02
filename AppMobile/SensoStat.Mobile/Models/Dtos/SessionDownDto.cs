using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SensoStat.Mobile.Models.Dtos
{
    public class SessionDownDto
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("msgHome")] public string MsgHome { get; set; }

        [JsonProperty("msgFinal")] public string MsgFinal { get; set; }

        public List<InstructionDownDto> Instructions { get; set; }

    }
}
