using LoginApiDemo.Common.Helpers;
using LoginApiDemo.Model.Login;
using LoginApiDemo.Model.Settings;
using LoginApiDemo.Service.JWTAuthentication;
using LoginApiDemo.Service.login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace LoginApiDemo.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Fields
        private IAccountServices _accountServices;
        private readonly AppSettings _appSettings;
        private IJwtAuthenticationService _jwtAuthenticationService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor
        public AccountController(IAccountServices accountServices,IHttpContextAccessor httpContextAccessor,IJwtAuthenticationService jwtAuthenticationService, IOptions<AppSettings> appSettings,Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _accountServices = accountServices;
            _appSettings = appSettings.Value;
            _hostingEnvironment = hostingEnvironment;
            _jwtAuthenticationService = jwtAuthenticationService;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Methods
        [HttpPost("UserLogin")]
        public async Task<ApiPostResponse<LoginResponseModel>> UserLogin(LoginRequestModel model)
        {
            ApiPostResponse<LoginResponseModel> response = new ApiPostResponse<LoginResponseModel>();
            LoginResponseModel result = await _accountServices.LoginUser(model);
            if (result.message == null)
            {
                response.Data = result;
                //UserTokenModel objTokenData = new UserTokenModel();
                //objTokenData.EmailId = result.EmailId;
                //objTokenData.UserId = result.Id != null ? result.Id : 0;
                //objTokenData.UserName = result.UserName;
                //AccessTokenModel objAccessTokenData = new AccessTokenModel();
                //objAccessTokenData = _jWTAuthenticationService.GenerateToken(objTokenData, _appSettings.JWT_Secret, _appSettings.JWT_Validity_Mins);

                //await _accountServices.UpdateLoginToken(objAccessTokenData.Token, objAccessTokenData.UserId);
                //AccessTokenResponseModel AccessToken = new AccessTokenResponseModel();
                //AccessToken.Token = objAccessTokenData.Token;
                //AccessToken.ExpiresOnUTC = objAccessTokenData.ExpiresOnUTC;


                if (result != null && result.Id > 0)
                {
                    TokenModel objTokenData = new TokenModel();
                    objTokenData.Email = model.Email;
                    objTokenData.Id = result.Id;
                    objTokenData.FullName = result.FullName;
                    AccessTokenModel objAccessTokenData = _jwtAuthenticationService.GenerateToken(objTokenData, !string.IsNullOrEmpty(_appSettings.JWT_Secret) ? _appSettings.JWT_Secret : "", _appSettings.JWT_Validity_Mins);
                    result.JWTToken = objAccessTokenData.Token;

                    await _accountServices.UpdateLoginToken(!string.IsNullOrEmpty(objAccessTokenData.Token) ? objAccessTokenData.Token : "", objAccessTokenData.UserId);
                    string? host = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value + "/";

                    response.Message = "Login Success";
                    response.Success = true;
                    response.Data.JWTToken = !string.IsNullOrEmpty(result.JWTToken) ? result.JWTToken : "";
                    response.Data.Id = result.Id;
                    response.Data.FullName = result.FullName;
                    response.Data.Email = result.Email;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "InvalidCredential";
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = result.message;
            }
            return response;

        }

        [HttpPost("RegisterUser")]
        public async Task<ApiPostResponse<responsemodel>> RegisterUser(RegisterUserModel user)
        {
            ApiPostResponse<responsemodel> response = new ApiPostResponse<responsemodel>();
            responsemodel result = await _accountServices.RegisterUser(user);
            if (result.Id != 0)
            {
                response.Success = true;
                response.Message = result.message;
                response.Data = result;
            }
            else
            {
                response.Success = false;
                response.Message = result.message;
            }
            return response;
        }
        //[AllowAnonymous]
        //[HttpPost("ForgotPassword")]
        //public async Task<BaseApiResponse> ForgotPassword([FromBody] ForgotDetails user)
        //{
        //    BaseApiResponse response = new BaseApiResponse();
        //    var result = await _accountServices.GetUserDetailsByEmail(user);
        //    if (result != null)
        //    {
        //        var logopath = Path.Combine(_hostingEnvironment.WebRootPath, "Logo/ggg.jpg");
        //        var email = new MimeMessage();
        //        email.Sender = MailboxAddress.Parse(_smtpSettings.FromEmail);
        //        email.To.Add(MailboxAddress.Parse(result.EMAILID));
        //        email.Subject = "Forgot Id/Password Email";
        //        var builder = new BodyBuilder();
        //        builder.HtmlBody = $"<img src='{logopath}' alt='' ><h2>UserName : {result.USERNAME}</h2><br><h2>Email : {result.EMAILID}</h2><br><h2>Password : {result.PASSWORD}</h2><br> ";
        //        email.Body = builder.ToMessageBody();
        //        using var smtp = new SmtpClient();
        //        smtp.Connect(_smtpSettings.EmailHostName, Convert.ToInt32(_smtpSettings.EmailPort), SecureSocketOptions.StartTls);
        //        smtp.Authenticate(_smtpSettings.FromEmail, _smtpSettings.EmailAppPassword);
        //        await smtp.SendAsync(email);
        //        smtp.Disconnect(true);

        //        response.Success = true;
        //        response.Message = APIMessages.ForgotPasswordSuccess;
        //    }
        //    else
        //    {
        //        response.Success = false;
        //        response.Message = APIMessages.ForgotPasswordFailed;
        //    }
        //    return response;
        //}

        #endregion
    }
}
