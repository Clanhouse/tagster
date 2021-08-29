using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagsterWebAPI.Controllers;
using TagsterWebAPI.Models;

namespace TagsterWebAPI
{
    public interface IJwtAuthenticationManager
    {

       object Authenticate(UserCredential userCredential);
        
    }
}