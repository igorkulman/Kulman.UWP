using System;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.DataProtection;
using JetBrains.Annotations;

namespace Kulman.UWP.Code
{
    /// <summary>
    /// Extensions for device specific string encryption and decryption
    /// </summary>
    public static class DataProtectionExtensions
    {
        /// <summary>
        /// Encrypts given text in given scope
        /// </summary>
        /// <param name="clearText">Clear text to encrypt</param>
        /// <param name="scope">Scope</param>
        /// <returns>Encrypted text</returns>
        [NotNull]
        public static async Task<string> ProtectAsync([NotNull] this string clearText, [NotNull] string scope = "LOCAL=user")
        {
            if (clearText == null)
            {
                throw new ArgumentNullException("clearText");
            }
            if (scope == null)
            {
                throw new ArgumentNullException("scope");
            }

            var clearBuffer = CryptographicBuffer.ConvertStringToBinary(clearText, BinaryStringEncoding.Utf8);
            var provider = new DataProtectionProvider(scope);
            var encryptedBuffer = await provider.ProtectAsync(clearBuffer);
            return CryptographicBuffer.EncodeToBase64String(encryptedBuffer);
        }

        /// <summary>
        /// Decrypts given text
        /// </summary>
        /// <param name="encryptedText">Encrypted text</param>
        /// <returns>Clear text</returns>
        [NotNull]
        public static async Task<string> UnprotectAsync([NotNull] this string encryptedText)
        {
            if (encryptedText == null)
            {
                throw new ArgumentNullException("encryptedText");
            }

            var encryptedBuffer = CryptographicBuffer.DecodeFromBase64String(encryptedText);
            var provider = new DataProtectionProvider();
            var clearBuffer = await provider.UnprotectAsync(encryptedBuffer);
            return CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, clearBuffer);
        }
    }
}
