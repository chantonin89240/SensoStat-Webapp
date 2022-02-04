namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class InstructionFactory
    {
        private static int nombreInstruction = 9;

        /// <summary>
        /// Générateur de fausses instructions pour chaque séance dans la liste sessions passée en paramètre
        /// </summary>
        /// <param name="sessions"></param>
        /// <returns></returns>
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
                instructions.AddRange(CreateInstructionFactory.Generate(nombreInstruction));
            });

            return instructions;
        }
    }
}
