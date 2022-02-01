namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class PanelistFactory
    {
        public static List<Panelist> GeneratePanelist()
        {
            var PanelistId = 0;
            var CreatePanelistFactory = new Faker<Panelist>("fr")
                .CustomInstantiator( f => new Panelist(
                    new Bogus.Randomizer().Replace("?##")));
                //.RuleFor(p => p.CodePanelist, f => f.Random.String(4));

            var panelists = CreatePanelistFactory.Generate(100);
            return panelists;
        }
    }
}
