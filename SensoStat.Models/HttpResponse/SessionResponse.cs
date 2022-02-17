namespace SensoStat.Models.HttpResponse
{
    public class SessionResponse
    {
        public string Name { get; set; }

        public string Etat { get; set; }

        public int IdPerson { get; set; }

        public List<InstructionResponse> Instructions { get; set; }
    }
}
