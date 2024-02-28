using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Model.Login
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Email id required!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password required!")]
        public string? Password { get; set; }
    }
    public class RegisterUserModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class SaltResponseModel
    {
        public string? PasswordSalt { get; set; }
        public string? Password { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }

    public class ForgotPasswordRequestModel
    {
        [Required]
        public string? EmailId { get; set; }
        public string? AppURL { get; set; }
        public long AdminRoleId { get; set; }
    }

    public class VerificationOtpRequestModel
    {
        [Required(ErrorMessage = "Email id required!")]
        public string? EmailId { get; set; }
        [Required(ErrorMessage = "Verification-code is required!")]
        public int OTP { get; set; }

    }
    public class AccessTokenModel
    {
        public string? Token { get; set; }
        public int ValidityInMin { get; set; }
        public DateTime ExpiresOnUTC { get; set; }
        public long UserId { get; set; }
    }
    public class TokenModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? message { get; set; }

    }
}
