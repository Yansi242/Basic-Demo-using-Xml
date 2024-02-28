using LoginApiDemo.Model.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Service.login
{
    public interface IAccountServices
    {
        Task<LoginResponseModel> LoginUser(LoginRequestModel model);
        Task<responsemodel> RegisterUser(RegisterUserModel model);
        Task<long> UpdateLoginToken(string Token, long UserId);
    }
}
