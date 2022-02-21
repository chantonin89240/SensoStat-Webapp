namespace SensoStat.Services
{
    using System;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using Microsoft.Extensions.Options;
    using SensoStat.Entities;
    using SensoStat.Repository.Contracts;
    using SensoStat.Services.Contracts;
    using SensoStat.WebAPI.Helpers;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using SensoStat.Models.HttpResponse;
    using SensoStat.Models.HttpRequest;

    public class UserService : IUserService
    {
        private readonly JwtSettings _jwtSettings;

        private IUserRepository _userRepository;

        private IRoleRepository _roleRepository;

        public UserService(IOptions<JwtSettings> jwtSettings, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this._jwtSettings = jwtSettings.Value;
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = this._userRepository.FindByEmail(model.Email);

            // return null si on ne trouve pas l'utilisateur
            if (user == null)
            {
                return null;
            }

            var hashedPassword = HashPasswordWithSalt(model.Password, Convert.FromBase64String(user.Salt));

            // Si les mots de passe ne correspondent pas on retourne null.
            if (user.Password != hashedPassword)
            {
                return null;
            }

            user.Role = this._roleRepository.FindById(user.IdRole);

            // authentification réussie, on génère le token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return this._userRepository.FindAll();
        }

        public User GetById(int id)
        {
            return this._userRepository.FindById(id);
        }

        public CreateUserResponse CreateUser(CreateUserRequest model)
        {
            var emailNotAvailable = this._userRepository.FindByEmail(model.Email);

            var salt = GenerateSalt();
            var hashedPassword = HashPasswordWithSalt(model.Password, salt);

            var user = new User
            {
                Email = model.Email,
                Password = hashedPassword,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IdRole = model.IdRole,
                Salt = Convert.ToBase64String(salt),
            };

            if (emailNotAvailable == null)
            {
                this._userRepository.Add(user);

                return new CreateUserResponse(user);
            }

            user.Password = model.Password;
            return new CreateUserResponse(user);
        }

        public IEnumerable<Role> GetRoles()
        {
            return this._roleRepository.FindAll();
        }

        private string generateJwtToken(User user)
        {
            // génère un token valide pour 7 jours
            var tokenHandler = new JwtSecurityTokenHandler();
            var debug = _jwtSettings.JwtSecret;
            var key = Encoding.ASCII.GetBytes(_jwtSettings.JwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(ClaimTypes.Role, user.Role.Libelle),
                    // Cela va garantir que le token est unique
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                }),
                Issuer = _jwtSettings.JwtIssuer,
                Audience = _jwtSettings.JwtAudience,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            return salt;
        }

        public string HashPasswordWithSalt(string password, byte[] salt)
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