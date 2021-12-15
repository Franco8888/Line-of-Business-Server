using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LOB_server_template.Services.HelperServices
{
    public interface IEncryptionService
    {
        string EncryptPassword(string password);
    }

    public class EncryptionService : IEncryptionService
    {
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // public
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        public string EncryptPassword(string password)
        {
            string salt = "1TrzkSHcUe4zJpcvOWQc";
            byte[] array = new byte[password.Length + salt.Length];
            Span<byte> span = array;
            MemoryMarshal.Cast<char, byte>(password).CopyTo(span.Slice(0, password.Length));
            MemoryMarshal.Cast<char, byte>(salt).CopyTo(span.Slice(password.Length));
            byte[] array2 = SHA1.Create().ComputeHash(array);
            return Convert.ToBase64String(array2);
        }
    }
}
