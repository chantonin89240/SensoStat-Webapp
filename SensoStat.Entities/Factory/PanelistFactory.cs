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
                .RuleFor(p => p.CodePanelist, f => f.Random.String(4))
                .RuleFor(p => p.Publications, PublicationFactory.GeneratePublication().Generate(4))
                .RuleFor(p => p.Responses, ResponseFactory.GenerateResponse().Generate(10))
                .RuleFor(p => p.Presentations, PresentationFactory.GeneratePresentation().Generate(4));

            return CreatePanelistFactory;
        }
    }
}
