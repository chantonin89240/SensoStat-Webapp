namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class ProductFactory
    {
        private static int nombreProduit = 1000;

        /// <summary>
        /// Génèrateur de produits, chacun est associé à une séance  
        /// </summary>
        /// <param name="sessions"></param>
        /// <returns></returns>
        public static List<Product> GenerateProduct(List<Session> sessions)
        {
            var ProductId = 0;
            var CreateProductFactory = new Faker<Product>()
                .CustomInstantiator(p => new Product(
                    new Bogus.Randomizer().Replace("###"),
                    sessions[p.Random.Number(0, sessions.Count-1)]
                    ));

            var products = CreateProductFactory.Generate(nombreProduit);
            return products;
        }
    }
}
