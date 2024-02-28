using Dapper;
using LoginApiDemo.Common.Helpers;
using LoginApiDemo.Data.DBRepository.Account;
using LoginApiDemo.Model.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Service.login
{
    public class AccountServices : IAccountServices
    {
        #region Fields
        private IAccountRepository _accountRepository;
        #endregion

        #region Constructor
        public AccountServices(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        #endregion
        public async Task<LoginResponseModel> LoginUser(LoginRequestModel model)
        {
            return await _accountRepository.LoginUser(model);
        }
        public async Task<responsemodel> RegisterUser(RegisterUserModel model)
        {
            return await _accountRepository.RegisterUser(model);
        }
        public async Task<long> UpdateLoginToken(string Token, long UserId)
        {
            return await _accountRepository.UpdateLoginToken(Token, UserId);
        }
    }
}
