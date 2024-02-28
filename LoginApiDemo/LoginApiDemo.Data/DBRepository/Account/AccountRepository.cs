using Dapper;
using LoginApiDemo.Model.Config;
using LoginApiDemo.Model.Login;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApiDemo.Common.Helpers;
using System.Reflection;

namespace LoginApiDemo.Data.DBRepository.Account
{
    public class AccountRepository :BaseRepository, IAccountRepository
    {
        #region Constructor
        public AccountRepository(IOptions<DataConfig> dataConfig) : base(dataConfig)
        {
        }
        #endregion

        #region Post

        //public async Task<long> ValidateUserTokenData(long UserId, string jwtToken, DateTime TokenValidDate)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@UserId", UserId);
        //    param.Add("@jwtToken", jwtToken);
        //    param.Add("@TokenValidDate", TokenValidDate);
        //    return await QueryFirstOrDefaultAsync<long>(StoredProcedures.ValidateToken, param, commandType: CommandType.StoredProcedure);
        //}

        //public async Task<SaltResponseModel> GetUserSalt(string EmailId)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@EmailId", EmailId);
        //    var data = await QueryFirstOrDefaultAsync<SaltResponseModel>(StoredProcedures.GetUserSaltByEmail, param, commandType: CommandType.StoredProcedure);
        //    return data;
        //}

        public async Task<LoginResponseModel> LoginUser(LoginRequestModel model)
        {
            var param = new DynamicParameters();
            param.Add("@email", model.Email);
            param.Add("@password", model.Password);
            var data = await QueryFirstOrDefaultAsync<LoginResponseModel>(StoredProcedures.LoginUser, param, commandType: CommandType.StoredProcedure);
            return data;
        }
        public async Task<responsemodel> RegisterUser(RegisterUserModel model)
        {
            var param = new DynamicParameters();
            param.Add("@FirstName", model.FirstName);
            param.Add("@LastName", model.LastName);
            param.Add("@Gender", model.Gender);
            param.Add("@Email", model.Email);
            param.Add("@Password", model.Password);
            var data = await QueryFirstOrDefaultAsync<responsemodel>(StoredProcedures.RegisterUser, param, commandType: CommandType.StoredProcedure);
            return data;
        }


        public async Task<long> UpdateLoginToken(string Token, long UserId)
        {
            var param = new DynamicParameters();
            param.Add("@Token", Token);
            param.Add("@UserId", UserId);
            return await QueryFirstOrDefaultAsync<long>(StoredProcedures.UpdateLoginToken, param, commandType: CommandType.StoredProcedure);
        }

        //public async Task<long> LogoutUser(long UserId)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@UserId", UserId);
        //    return await QueryFirstOrDefaultAsync<long>(StoredProcedures.Logout, param, commandType: CommandType.StoredProcedure);
        //}

        //public async Task<ForgotPasswordResponseModel> ForgotPassword(ForgotPasswordRequestModel model)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@EmailId", model.EmailId);
        //    param.Add("@AdminRoleId", model.AdminRoleId);
        //    return await QueryFirstOrDefaultAsync<ForgotPasswordResponseModel>(StoredProcedures.ForgotPassword, param, commandType: CommandType.StoredProcedure);
        //}
        //public async Task<bool> ValidateResetPassword(long UserId, int PasswordLinkValidityMins)
        //{

        //    var param = new DynamicParameters();
        //    param.Add("@UserId", UserId);
        //    param.Add("@HoursToValidate", PasswordLinkValidityMins);
        //    return await QueryFirstOrDefaultAsync<bool>(StoredProcedures.ValidateResetPassword, param, commandType: CommandType.StoredProcedure);

        //}
        //public async Task<int> SaveOTP(long UserId, int randomNumer, string EmailId)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@UserId", UserId);
        //    param.Add("@OTP", randomNumer);
        //    param.Add("@EmailId", EmailId);
        //    return await ExecuteAsync<int>(StoredProcedures.SaveOTP, param, commandType: CommandType.StoredProcedure);
        //}

        //public async Task<long> GetUserIDByEmail(string EmailId)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@EmailId", EmailId);
        //    return await QueryFirstOrDefaultAsync<long>(StoredProcedures.GetUserIdByEmail, param, commandType: CommandType.StoredProcedure);
        //}

        //public async Task<string> ResetPassword(long UserId, string Password, string Salt)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@UserId", UserId);
        //    param.Add("@Password", Password);
        //    param.Add("@Salt", Salt);
        //    return await QueryFirstOrDefaultAsync<string>(StoredProcedures.ResetPassword, param, commandType: CommandType.StoredProcedure);
        //}

        //public async Task<string> ChangePassword(long UserId, string ConfirmPassword, string Salt, long AdminRoleId)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@UserId", UserId);
        //    param.Add("@ConfirmPassword", ConfirmPassword);
        //    param.Add("@Salt", Salt);
        //    param.Add("@AdminRoleId", AdminRoleId);
        //    return await QueryFirstOrDefaultAsync<string>(StoredProcedures.ChangePassword, param, commandType: CommandType.StoredProcedure);
        //}
        #endregion
    }
}
