using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TelegramWebAppDataValidator
{
    /// <summary>
    /// Class for validating data recieved from Telegram
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Validates WebAppData recieved from Telegram when entering Mini App
        /// </summary>
        /// <param name="initData">Received data string from Telegram</param>
        /// <param name="token">Your bot token</param>
        /// <param name="cStr">Property set by default is "WebAppData", change if Telegram api is changed</param>
        /// <returns><see langword="true"/> if data is from Telegram and <see langword="false"/> if is not</returns>
        public static bool Validate(string initData, string token, string cStr = "WebAppData")
        {
            try
            {
                var (dataCheckString, hash) = ParseAuthString(initData);

                // Создаем секретный ключ
                var secretKey = EncodeHmac(token, Encoding.UTF8.GetBytes(cStr));

                // Создаем ключ валидации
                var validationKeyBytes = EncodeHmac(dataCheckString, secretKey);
                var validationKey = BitConverter.ToString(validationKeyBytes).Replace("-", "").ToLower();

                if (validationKey == hash)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Parses data and hash from provided string
        /// </summary>
        /// <param name="initData"> data from Telegram</param>
        /// <returns>Tuple of parsed strings: data and hash</returns>
        private static (string dataCheckString, string? hash) ParseAuthString(string initData)
        {
            try
            {
                var query = HttpUtility.ParseQueryString(initData);
                var hash = query["hash"];
                query.Remove("hash");

                // Сортируем параметры
                var parameters = query.AllKeys
                    .OrderBy(k => k)
                    .Select(k => $"{k}={query[k]}")
                    .ToList();

                var dataCheckString = string.Join("\n", parameters);

                return (dataCheckString, hash);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Encodes data with <see cref="HMACSHA256"/> algorythm
        /// </summary>
        /// <param name="message">string to encode</param>
        /// <param name="key">encoding key</param>
        /// <returns>Encoded string</returns>
        private static byte[] EncodeHmac(string message, byte[] key)
        {
            using var hmac = new HMACSHA256(key);
            return hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
        }
    }
}
