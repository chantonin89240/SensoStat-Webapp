namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class InstructionFactory
    {
        public static List<Instruction> GenerateInstruction(List<Session> sessions)
        {
            List<Instruction> instructions = new List<Instruction>();
            sessions.ForEach(session =>
            {
                var chronologie = 1;
                var CreateInstructionFactory = new Faker<Instruction>()
                .CustomInstantiator(i => new Instruction(
                    i.Lorem.Paragraph(),
                    chronologie++,
                    i.Random.Number(0, 1),
                    session
                    ));
                instructions.AddRange(CreateInstructionFactory.Generate(9));
            });
                //.RuleFor(p => p.Libelle, f => f.Lorem.Paragraph())
                //.RuleFor(p => p.Chronology, f => f.Random.Int(5));

            return instructions;
        }
    }
}
