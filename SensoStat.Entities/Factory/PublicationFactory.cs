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
        public static List<Publication> GeneratePublication(List<Session> sessions, List<Panelist> panelists)
        {
            List<Publication> publications = new List<Publication>();

            sessions.ForEach(session =>
            {
                var CreatePanelistFactory = new Faker<Panelist>()
                .CustomInstantiator(f => new Panelist(
                   new Bogus.Randomizer().Replace("?##")));

                panelists.ForEach(panelist =>
                {
                    var CreatePublicationFactory = new Faker<Publication>()
                      .CustomInstantiator(p => new Publication(
                          session,
                          panelist,
                          p.Internet.Url(),
                          p.Date.Recent(),
                          p.Date.Future(),
                          p.Internet.Password()));

                    publications.Add(CreatePublicationFactory.Generate());
                });
            });

            return publications;
        }
    }
}
