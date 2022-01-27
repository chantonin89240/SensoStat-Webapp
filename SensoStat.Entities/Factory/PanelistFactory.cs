namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class PanelistFactory
    {
        public static Faker<Panelist> GeneratePanelist()
        {
            var PanelistId = 0;
            var CreatePanelistFactory = new Faker<Panelist>()
                .StrictMode(true)
                .RuleFor(p => p.Id, f => PanelistId++)
                .RuleFor(p => p.CodePanelist, f => f.Random.String(4));


            return CreatePanelistFactory;
        }
    }
}
