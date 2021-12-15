using LOB_server_template.Models;
using LOB_server_template.Services.SetupOperationServices;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Linq;
using LOB_server_template.Services.HelperServices;

namespace LOB_server_template.Services
{
    public interface IAutherticationService
    {
        string Authenticate(string userName, string password);
    }

    public class AuthenticateService : IAutherticationService
    {
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // Service Field Variables
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        private readonly ISettingsService _settingsService;
        private readonly IEncryptionService _encryptionService;
        private readonly IDataBaseService db;

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // CTOR
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        public AuthenticateService(
            ISettingsService settingsService,
            IEncryptionService encryptionService,
            IDataBaseService databaseService
            )
        {
            _settingsService = settingsService;
            _encryptionService = encryptionService;
            db = databaseService;
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // Public
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        public string Authenticate(string email, string password)
        {
            var user = GetUser(email, password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return token;
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // Private
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        private UserAccount GetUser(string email, string passWord)
        {
            List<UserAccount> users = new List<UserAccount>();
            try
            {
                var result = db.UserAccount.Find(o => true).ToList();
                users = result;
            }
            catch (Exception e)
            {
                return null;
            }

            string encryptedPassword = _encryptionService.EncryptPassword(passWord);

            var user = users.SingleOrDefault(x => x.Email == email && x.Password == encryptedPassword);

            if (user == null)
                return null;
            else
                return user;
        }

        private string generateJwtToken(UserAccount user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settingsService.AuthKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
