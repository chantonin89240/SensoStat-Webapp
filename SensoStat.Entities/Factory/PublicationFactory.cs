namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class PublicationFactory
    {
        private static int nombrePaneliste = 50;
        /// <summary>
        /// Générateur de panéliste et de leur publication d'url respective
        /// </summary>
        /// <param name="sessions"></param>
        /// <returns></returns>
        public static List<Publication> GeneratePublication(List<Session> sessions)
        {
            List<Publication> publications = new List<Publication>();

            sessions.ForEach(session =>
            {
                var CreatePanelistFactory = new Faker<Panelist>("fr")
                .CustomInstantiator(f => new Panelist(
                   new Bogus.Randomizer().Replace("?##")));

                var CreatePublicationFactory = new Faker<Publication>()
               .CustomInstantiator(p => new Publication(
                   session,
                   CreatePanelistFactory.Generate(),
                   p.Internet.Url(),
                   p.Date.Recent(),
                   p.Date.Future()
                   ));

                publications.AddRange(CreatePublicationFactory.Generate(nombrePaneliste));
            });

            return publications;
        }
    }
}
