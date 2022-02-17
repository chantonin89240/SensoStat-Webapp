namespace SensoStat.Models.HttpRequest
{
    public class SessionRequest
    {
        public string Name { get; set; }

        public string Etat { get; set; }

        public int IdPerson { get; set; }

        public List<InstructionRequest> Instructions { get; set; }

    }
}
