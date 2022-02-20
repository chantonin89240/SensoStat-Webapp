﻿using System;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Models.Entities.Interfaces;
using SQLite;

namespace SensoStat.Mobile.Models.Entities
{
    public class InstructionEntity : IInstructionEntity
    {
        [PrimaryKey] public int Id { get; set; }

        public string Libelle { get; set; }

        public int Chronology { get; set; }

        public InstructionEntity()
        {
        }

        public InstructionEntity(IInstructionEntity instruction) : this()
        {
            Id = instruction.Id;
            Libelle = instruction.Libelle;
            Chronology = instruction.Chronology;
        }
    }
}
