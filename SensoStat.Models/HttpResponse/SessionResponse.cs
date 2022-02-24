using SensoStat.Entities;

namespace SensoStat.Models.HttpResponse
{
    public class SessionResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MsgAccueil { get; set; }

        public string MsgFinal { get; set; }

        public string Etat { get; set; }

        public int IdPerson { get; set; }

        public string Role { get; set; }

        public DateTime? DateCreate { get; set; }

        public List<Instruction> Instructions { get; set; }

        public SessionResponse()
        {
        }

        public SessionResponse(Session session) : this()
        {
            Id = session.Id;
            Name = session.Name;
            MsgAccueil = session.MsgAccueil;
            MsgFinal = session.MsgFinal;
            Etat = session.Etat;
            Instructions = session.Instructions;
            DateCreate = session.DateCreate;
        }
    }
}
