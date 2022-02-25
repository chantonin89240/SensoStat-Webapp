namespace SensoStat.Models.HttpResponse
{
    using SensoStat.Entities;

    public class InstructionResponse
    {
        public int Id { get; set; }

        public string Libelle { get; set; }

        public int Chronology { get; set; }

        public int IsQuestion { get; set; }

        public InstructionResponse(Instruction instruction)
        {
            this.Id = instruction.Id;
            this.Libelle = instruction.Libelle;
            this.Chronology = instruction.Chronology;
            this.IsQuestion = instruction.IsQuestion;
        }

        public InstructionResponse()
        {
        }
    }
}
