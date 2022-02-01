namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class PanelistFactory
    {
        public static List<Panelist> GeneratePanelist()
        {
            var PanelistId = 0;
            var CreatePanelistFactory = new Faker<Panelist>()
                .StrictMode(true)
                .RuleFor(p => p.Id, f => PanelistId++)
                .RuleFor(p => p.CodePanelist, f => f.Random.String(4));

            var panelists = CreatePanelistFactory.Generate(100);
            return panelists;
        }
    }
}
