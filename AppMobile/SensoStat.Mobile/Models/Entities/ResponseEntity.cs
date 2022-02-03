using System;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Models.Entities.Interfaces;
using SQLite;

namespace SensoStat.Mobile.Models.Entities
{
    public class ResponseEntity : IResponseEntity
    {
        [PrimaryKey] [AutoIncrement] public int Id { get ; set ; }
        public string IdResponse { get ; set ; }
        public string Content { get ; set ; }
        public string IdInstruction { get ; set ; }

        public ResponseEntity()
        {
        }

        public ResponseEntity(ResponseDownDto response)
        {
            IdResponse = response.Id;
            Content = response.Content;
            IdInstruction = response.Id;
        }
    }
}
