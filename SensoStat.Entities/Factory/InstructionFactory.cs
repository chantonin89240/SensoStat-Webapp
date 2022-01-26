namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class InstructionFactory
    {
        public static Faker<Instruction> GenerateInstruction()
        {
            var InstructionId = 0;
            var CreateInstructionFactory = new Faker<Instruction>()
                .StrictMode(true)
                .RuleFor(p => p.Id, f => InstructionId++)
                .RuleFor(p => p.Libelle, f => f.Lorem.Paragraph())
                .RuleFor(p => p.Chronology, f => f.Random.Int(5))
                .RuleFor(p => p.Session, SessionFactory.GenerateSession().Generate());

            return CreateInstructionFactory;
        }
    }
}
