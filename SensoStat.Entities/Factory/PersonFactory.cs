namespace SensoStat.Entities.Factory
{
    using Bogus;

    public static class PersonFactory
    {
        private static int nombreUtilisateur = 10;

        /// <summary>
        /// Générateur de faux utilisateurs et attribution d'un rôles random
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static IEnumerable<User> GeneratePerson(List<Role> roles) 
        {
            var PersonId = 0;
            var CreatePersonFactory = new Faker<User>("fr")
                .CustomInstantiator(f => new User(
                    roles[f.Random.Number(0, 2)],
                    f.Name.LastName(),
                    f.Name.FirstName(),
                    f.Internet.Email(),
                    f.Name.FullName(),
                    f.Random.String2(10)));

            var users = CreatePersonFactory.Generate(nombreUtilisateur);
            return users;
        }
    }
}
