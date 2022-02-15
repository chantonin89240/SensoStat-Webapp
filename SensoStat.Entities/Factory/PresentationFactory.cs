namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class PresentationFactory
    {
        /// <summary>
        /// Générateur de de plan de présentation pour chaque panéliste et chaque produits en paramètres
        /// </summary>
        /// <param name="panelists"></param>
        /// <param name="products"></param>
        /// <returns></returns>
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
                    var presentation = new Presentation(panelist, product, rankList[rnd.Next(0, rankList.Count-1)], product.IdSession);
                    rankList.Remove(presentation.Rank);
                    presentations.Add(presentation);
                });
            });

            return presentations;
        }
    }
}
