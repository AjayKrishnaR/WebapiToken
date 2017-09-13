using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiToken.Models
{
    public class BusinessService : Iservice
    {
     

        public TokenEntity GenerateToken(String username, string password)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddMinutes(5);
            var tokendomain = new TokenEntity
            {
                Username = username,
                Authtoken = token,
                IssuedOn = issuedOn,
                ExpiryOn = expiredOn
            };
            TokenEntity tk = new TokenEntity();
            StoreDbEntities sd = new StoreDbEntities();
            tk = sd.WebApiTokens.Where(x => x.Username == username & x.Password == password).FirstOrDefault();
            if (tk.Username != null)
            {
                tk.Authtoken = tokendomain.Authtoken;
                tk.IssuedOn = tokendomain.IssuedOn;
                tk.ExpiryOn = tokendomain.ExpiryOn;
                sd.SaveChanges();
            }
            return tokendomain;
        }



        internal bool ValidateToken(string tokenValue)
        {
            throw new NotImplementedException();
        }

        TokenEntity Iservice.ValidateToken(string tokenValue)
        {
            throw new NotImplementedException();
        }
    }
}