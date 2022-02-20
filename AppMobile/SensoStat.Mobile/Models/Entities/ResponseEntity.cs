using System;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Models.Entities.Interfaces;
using SQLite;

namespace SensoStat.Mobile.Models.Entities
{
    public class ResponseEntity : IResponseEntity
    {
        [PrimaryKey] [AutoIncrement] public int Id { get ; set ; }

        public int IdRemote { get ; set ; }

        public string Content { get ; set ; }

        public int IdInstruction { get ; set ; }

        public int IdProduct { get; set; }

        public ResponseEntity()
        {
        }

        public ResponseEntity(ResponseDownDto response)
        {
            IdRemote = response.Id;
            Content = response.Content;
            IdInstruction = response.Instruction.Id;
        }
    }
}
