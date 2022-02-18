namespace SensoStat.Models.HttpRequest
{
    using SensoStat.Entities;

    public class InstructionRequest
    {
        public string Libelle { get; set; }

        public int Chronology { get; set; }

        public int IdSession { get; set; }
        public int IsQuestion { get; set; }

        //public List<Response> Responses { get; set; }
    }
}
