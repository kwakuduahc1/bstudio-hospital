using System.Linq;

namespace WinClinic.DTOs
{
    public static class RandomStringGenerator
    {
        public static string RandomString(int length)
        {
            string alphabet = "ABCDEFGHIJKLMNPQRTUVWXYZ0123456789";
            var outOfRange = byte.MaxValue + 1 - (byte.MaxValue + 1) % alphabet.Length;
            return string.Concat(
                Enumerable
                    .Repeat(0, byte.MaxValue)
                    .Select(e => RandomByte())
                    .Where(randomByte => randomByte < outOfRange)
                    .Take(length)
                    .Select(randomByte => alphabet[randomByte % alphabet.Length])
            );
        }

        static byte RandomByte()
        {
            using (var randomizationProvider = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[1];
                randomizationProvider.GetBytes(randomBytes);
                return randomBytes.Single();
            }
        }
    }
}
