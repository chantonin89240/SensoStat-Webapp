namespace SensoStat.Entities.HttpRequest
{
    using SensoStat.Entities;

    public class SessionRequest
    {
        public string Name { get; set; }

        public string Etat { get; set; }

        public int IdPerson { get; set; }

        public List<Product> Products { get; set; }

        public List<InstructionRequest> Instructions { get; set; }

        public List<Publication> Publications { get; set; }

    }
}
