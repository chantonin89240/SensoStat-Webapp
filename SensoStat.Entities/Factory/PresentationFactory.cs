namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class PresentationFactory
    {
        public static List<Presentation> GeneratePresentation(List<Panelist> panelists, List<Product> products)
        {
            List<Presentation> presentations = new List<Presentation>();
            var faker = new Faker();

            panelists.ForEach(panelist =>
            {
                var rankList = Enumerable.Range(1, products.Count).ToList();
                Random rnd = new Random();

                products.ForEach(product =>
                {
                    var presentation = new Presentation(panelist, product, rankList[rnd.Next(0, rankList.Count-1)]);
                    rankList.Remove(presentation.Rank);
                    presentations.Add(presentation);
                });
            });

            //var CreatePresentationFactory = new Faker<Presentation>()
            //    .StrictMode(true)
            //    .RuleFor(p => p.Rank, f => f.Random.Int(5));

            return presentations;
        }
    }
}
