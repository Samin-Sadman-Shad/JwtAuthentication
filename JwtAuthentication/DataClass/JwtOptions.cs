using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentication.DataClass
{
    internal class JwtOptions
    {
        public string? Issuer = null;
        public string? Audience = null;
        public string security_key = "key";
    }
}
