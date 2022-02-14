namespace SensoStat.Entities.Request
{
    public class InstructionRequest
    {
        public string Libelle { get; set; }

        public int Chronology { get; set; }

        public int IdSession { get; set; }
        public int IsQuestion { get; set; }

        public List<Response> Responses { get; set; }
    }
}
