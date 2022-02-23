namespace SensoStat.Entities.Factory
{
    using Bogus;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
            var saltUser = GenerateSalt();
            var password = HashPasswordWithSalt("Azerty@123", saltUser);

            users.Add(new User(roles[0], "Thomas", "Arnaud", "arnaud.thomas@sensostat.fr", "Arnaud Thomas", password, Convert.ToBase64String(saltUser)));

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

        private static string HashPasswordWithSalt(string password, byte[] salt)
        {
            // obtenir une clé de 256-bit (en utilisant HMACSHA256 sur 100,000 itérations)
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
}
