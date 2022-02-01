namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Instruction
    {
        public int Id { get; set; }

        [Required]
        public string Libelle { get; set; }

        [Required]
        public int Chronology { get; set; }

        public int IsQuestion { get; set; }

        public Session Session { get; set; }

        public int IdSession { get; set; }

        public List<Response> Responses { get; set; }

        public Instruction()
        {
            this.Responses = new List<Response>();
        }

        public Instruction(string libelle, int chronology, int isQuestion,Session session)
        {
            this.Libelle = libelle;
            this.Chronology = chronology;
            this.IsQuestion = isQuestion;
            this.Session = session;
            this.IdSession = session.Id;
        }

    }
}
