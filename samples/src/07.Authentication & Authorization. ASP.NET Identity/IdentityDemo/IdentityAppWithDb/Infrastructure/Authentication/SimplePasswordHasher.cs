using Microsoft.AspNet.Identity;

namespace IdentityAppWithDb.Infrastructure.Authentication
{
    public class SimplePasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// The hash password.
        /// </summary>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string HashPassword(string password)
        {
            return password;
        }

        /// <summary>
        /// The verify hashed password.
        /// </summary>
        /// <param name="hashedPassword">
        /// The hashed password.
        /// </param>
        /// <param name="providedPassword">
        /// The provided password.
        /// </param>
        /// <returns>
        /// The <see cref="PasswordVerificationResult"/>.
        /// </returns>
        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return this.HashPassword(providedPassword) == hashedPassword ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}