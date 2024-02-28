using LoginApiDemo.Model.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Data.DBRepository.Account
{
    public interface IAccountRepository
    {
        //Task<long> ValidateUserTokenData(long UserId, string jwtToken, DateTime TokenValidDate);
        //Task<SaltResponseModel> GetUserSalt(string EmailId);
        Task<LoginResponseModel> LoginUser(LoginRequestModel model);
        Task<responsemodel> RegisterUser(RegisterUserModel model);
        Task<long> UpdateLoginToken(string Token, long UserId);
        //Task<long> LogoutUser(long UserId);
        //Task<ForgotPasswordResponseModel> ForgotPassword(ForgotPasswordRequestModel model);
        //Task<int> SaveOTP(long UserId, int randomNumer, string EmailId);
        //Task<long> GetUserIDByEmail(string EmailId);
        //Task<string> ResetPassword(long UserId, string Password, string Salt);
        //Task<string> ChangePassword(long UserId, string ConfirmPassword, string Salt, long AdminRoleId);
        //Task<bool> ValidateResetPassword(long UserId, int PasswordLinkValidityMins);
    }
}
