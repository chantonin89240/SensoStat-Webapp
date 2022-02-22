namespace SensoStat.EntitiesContext
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SensoStat.Entities;
    using SensoStat.Entities.Factory;

    public class SeedData
    {
        public static List<Role> roles;
        public static List<User> users;
        public static List<Panelist> panelists;
        public static List<Session> sessions;
        public static List<Product> products;
        public static List<Instruction> instructions;
        public static List<Publication> publications;
        public static List<Presentation> presentations = new List<Presentation>();
        public static List<Response> responses = new List<Response>();

        /// <summary>
        /// Méthode d'amorçage de la base de données 
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SensoStatDbContext(serviceProvider.GetRequiredService<DbContextOptions<SensoStatDbContext>>()))
            {
                roles = RoleFactory.GenerateRole().ToList();
                context.Roles.AddRange(roles);
                context.SaveChanges();

                users = UserCreator();
                context.Users.AddRange(users);
                context.SaveChanges();

                sessions = SessionCreator();
                context.Sessions.AddRange(sessions);
                context.SaveChanges();

                panelists = PanelistCreator();
                context.Panelists.AddRange(panelists);
                context.SaveChanges();

                products = ProductCreator();
                context.Products.AddRange(products);
                context.SaveChanges();

                instructions = InstructionCreator();
                context.Instructions.AddRange(instructions);
                context.SaveChanges();

                publications = PublicationCreator();
                context.Publications.AddRange(publications);
                context.SaveChanges();

                sessions.ForEach(session =>
                {
                    presentations.AddRange(PresentationCreator(session, context));
                });

                context.Presentations.AddRange(presentations);
                context.SaveChanges();

                sessions.ForEach(session =>
                {
                    responses.AddRange(ResponseCreator(session, context)); 
                });

                context.Responses.AddRange(responses);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Génère 10 utilisateurs du back office
        /// </summary>
        /// <returns>Liste d'utilisateurs</returns>
        public static List<User> UserCreator()
        {
            return PersonFactory.GeneratePerson(roles).ToList();
        }

        /// <summary>
        /// Génère 100 séances
        /// </summary>
        /// <returns>Liste de séances</returns>
        public static List<Session> SessionCreator()
        {
            return SessionFactory.GenerateSession(users).ToList();
        }

        /// <summary>
        /// Génère 1000 produits
        /// </summary>
        /// <returns>Liste de produits</returns>
        public static List<Product> ProductCreator()
        {
            return ProductFactory.GenerateProduct(sessions);
        }

        /// <summary>
        /// Génère 1000 produits
        /// </summary>
        /// <returns>Liste de produits</returns>
        public static List<Panelist> PanelistCreator()
        {
            return PanelistFactory.GeneratePanelist().ToList();
        }

        /// <summary>
        /// Génère 9 instructions par session
        /// </summary>
        /// <returns>Liste d'instructions</returns>
        public static List<Instruction> InstructionCreator()
        {
            return InstructionFactory.GenerateInstruction(sessions);
        }

        /// <summary>
        /// Génère 50 panélistes et la publication de leurs URL pour chaque session
        /// </summary>
        /// <returns>Liste de publications</returns>
        public static List<Publication> PublicationCreator()
        {
            return PublicationFactory.GeneratePublication(sessions, panelists);
        }

        /// <summary>
        /// Génère un plan de présentation pour pour chaque panélist participant à une séance
        /// </summary>
        /// <param name="session"></param>
        /// <param name="context"></param>
        /// <returns>Liste de Plan de présentation</returns>
        public static List<Presentation> PresentationCreator(Session session, SensoStatDbContext context)
        {
            var panelistSession = from panelist in context.Panelists
                                  join pub in context.Publications
                                  on panelist.Id equals pub.IdPaneslist
                                  where pub.IdSession == session.Id
                                  select panelist;

            var panelistSessionMethod = context.Panelists
                                            .Join(context.Publications,
                                                    pan => pan.Id,
                                                    pub => pub.IdPaneslist,
                                                    (pan, pub) => new { pan, pub })
                                            .Where(o => o.pub.IdSession == session.Id)
                                            .Select(o => o.pan);

            var productSession = context.Products.Where(p => p.IdSession == session.Id).ToList();

            return PresentationFactory.GeneratePresentation(panelistSession.ToList(), productSession);
        }

        /// <summary>
        /// Génère les réponses de chaque panéliste pour chaque produit et chaque question
        /// </summary>
        /// <param name="session"></param>
        /// <param name="context"></param>
        /// <returns>Liste de réponse</returns>
        public static List<Response> ResponseCreator(Session session, SensoStatDbContext context)
        {
            var panelistSession = from panelist in context.Panelists
                                  join pub in context.Publications
                                  on panelist.Id equals pub.IdPaneslist
                                  where pub.IdSession == session.Id
                                  select panelist;

            var productSession = context.Products.Where(p => p.IdSession == session.Id).ToList();
            var instructionSession = context.Instructions.Where(i => i.IdSession == session.Id && i.IsQuestion == 1).ToList();

            return ResponseFactory.GenerateResponse(panelistSession.ToList(), productSession, instructionSession);
        }
    }
}
