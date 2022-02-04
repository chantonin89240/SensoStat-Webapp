namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class PanelistFactory
    {
        /// <summary>
        /// Cette méthode n'est plus utilisée
        /// </summary>
        /// <returns></returns>
        public static List<Panelist> GeneratePanelist()
        {
            var PanelistId = 0;
            var CreatePanelistFactory = new Faker<Panelist>("fr")
                .CustomInstantiator( f => new Panelist(
                    new Bogus.Randomizer().Replace("?##")));

            var panelists = CreatePanelistFactory.Generate(100);
            return panelists;
        }
    }
}
