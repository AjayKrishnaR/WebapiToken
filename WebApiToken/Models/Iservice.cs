using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiToken.Models
{
    interface Iservice
    {
        TokenEntity GenerateToken(string username, string password);
        TokenEntity ValidateToken(string tokenValue);
    }
}
