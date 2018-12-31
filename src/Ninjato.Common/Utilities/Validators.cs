using System.Text.RegularExpressions;

namespace Ninjato.Common.Utilities
{
    /// <summary>
    /// Validators.
    /// </summary>
    public class Validators
    {
        /// <summary>
        /// Ises the valid email.
        /// </summary>
        /// <returns><c>true</c>, if valid email was ised, <c>false</c> otherwise.</returns>
        /// <param name="email">Email.</param>
        /// <remarks>This method doesn't handle nulls.</remarks>
        public static bool IsValidEmail(string email)
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            return isEmail;
        }
    }
}
