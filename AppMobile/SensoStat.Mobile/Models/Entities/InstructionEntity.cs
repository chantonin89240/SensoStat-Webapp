using System;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Models.Entities.Interfaces;
using SQLite;

namespace SensoStat.Mobile.Models.Entities
{
    public class InstructionEntity : IInstructionEntity
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }
        public string IdInstruction { get; set; }
        public string Content { get; set; }
        public int Position { get; set; }


        public InstructionEntity()
        {
        }

        public InstructionEntity(InstructionDownDto instruction)
        {
            IdInstruction = instruction.Id;
            Content = instruction.Content;
            Position = instruction.Position;
        }
    }
}
