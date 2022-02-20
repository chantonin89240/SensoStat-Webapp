using System;
using SensoStat.Entities;

namespace SensoStat.Models.HttpResponse
{
    public class PwaSessionResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PublicationResponse Publication { get; set; }

        public List<InstructionResponse> Instructions { get; set; }

        public List<ProductResponse> Products { get; set; }

        public List<PwaPresentationResponse> Presentations { get; set; }

        public PwaSessionResponse()
        {
            Instructions = new List<InstructionResponse>();
            Products = new List<ProductResponse>();
            Presentations = new List<PwaPresentationResponse>();
        }

        public PwaSessionResponse(Session session) : this()
        {
            Id = session.Id;
            Name = session.Name;

            session.Products.ForEach(p => Products.Add(new ProductResponse(p)));
            session.Instructions.ForEach(i => Instructions.Add(new InstructionResponse(i)));
        }
    }
}

