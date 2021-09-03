using TagsterWebAPI.Controllers;

namespace TagsterWebAPI
{
    public interface IJwtAuthenticationManager
    {

        object Authenticate(UserCredential userCredential);

    }
}