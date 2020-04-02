using System;
using System.Security.Cryptography;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCardPasswordHashProvider : IGiftCardPasswordHashProvider, ITransientDependency
    {
        public virtual string GetPasswordHash(string password)
        {
            if (password.IsNullOrWhiteSpace())
            {
                return string.Empty;
            }

            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}