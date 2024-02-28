using LoginApiDemo.Model.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Service.JWTAuthentication
{
    public interface IJwtAuthenticationService
    {
        AccessTokenModel GenerateToken(TokenModel userToken, string JWT_Secret, int JWT_Validity_Mins);
        TokenModel GetUserTokenData(string jwtToken);
    }
}
