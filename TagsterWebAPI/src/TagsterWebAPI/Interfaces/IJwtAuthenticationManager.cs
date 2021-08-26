using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagsterWebAPI.Controllers;

namespace TagsterWebAPI
{
    public interface IJwtAuthenticationManager
    {
        
        object Authenticate(string userName, string password);
    }
}
