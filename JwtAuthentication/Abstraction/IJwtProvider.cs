using JwtAuthentication.DataClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentication.Abstraction
{
    internal interface IJwtProvider
    {
        string Generate(Member member);
    }
}
