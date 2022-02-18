using SensoStat.Entities;

namespace SensoStat.Models.HttpResponse
{
    public class SessionResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Etat { get; set; }

        public int IdPerson { get; set; }

        public List<Instruction> Instructions { get; set; }

        public SessionResponse()
        {
        }

        public SessionResponse(Session session)
        {
            Id = session.Id;
            Name = session.Name;
            Etat = session.Etat;
            Instructions = session.Instructions;
        }
    }
}
