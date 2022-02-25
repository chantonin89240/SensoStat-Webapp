using System;
using SensoStat.Entities;

namespace SensoStat.Models.HttpResponse
{
    public class PwaSessionResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MsgAccueil { get; set; }

        public string MsgFinal { get; set; }

        public List<InstructionResponse> Instructions { get; set; }

        public List<PwaPresentationResponse> Presentations { get; set; }

        public PwaSessionResponse()
        {
            Instructions = new List<InstructionResponse>();
            Presentations = new List<PwaPresentationResponse>();
        }

        public PwaSessionResponse(Session session) : this()
        {
            Id = session.Id;
            Name = session.Name;
            MsgAccueil = session.MsgAccueil;
            MsgFinal = session.MsgFinal;

            session.Instructions.ForEach(i => Instructions.Add(new InstructionResponse(i)));
        }
    }
}

