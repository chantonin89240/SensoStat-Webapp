namespace SensoStat.Entities.Factory
{
    using Bogus;
    using System.Security.Cryptography;

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
            var salt = GenerateSalt();
            var PersonId = 0;
            var CreatePersonFactory = new Faker<User>("fr")
                .CustomInstantiator(f => new User(
                    roles[f.Random.Number(0, 2)],
                    f.Name.LastName(),
                    f.Name.FirstName(),
                    f.Internet.Email(),
                    f.Name.FullName(),
                    f.Random.String2(10),
                    Convert.ToBase64String(salt)));

            var users = CreatePersonFactory.Generate(nombreUtilisateur);
            return users;
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            return salt;
        }
    }
}
