using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Model.Login
{
    public class LoginResponseModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? message { get; set; }
        public string? JWTToken { get; set; }
        //public string? Photo { get; set; }
        //public bool IsChangeMatrix { get; set; }
        //public bool IsTrainingAnalysis { get; set; }
        //public int CompanyId { get; set; }
        //public int AdminRoleId { get; set; }
        //public string? JWTToken { get; set; }
        //public string? CompanyName { get; set; }

    }
    public class responsemodel
    {
        public int Id { get; set; } = 0;
        public string message { get; set; }
    }
    public class ForgotPasswordResponseModel
    {
        public long UserId { get; set; }
        public DateTime LastForgotPasswordSend { get; set; }
        public string? UserName { get; set; }
        public string? EmailId { get; set; }
    }

    public class ResetPasswordRequestModel
    {
        [Required(ErrorMessage = "Email Id required!")]
        public long UserId { get; set; }
        [Required(ErrorMessage = "The Create Password is required.")]
        public string? NewPassword { get; set; }
        [Required(ErrorMessage = "The Confirm Password is required.")]
        public string? ConfirmPassword { get; set; }
    }
    public class ChangePasswordRequestModel
    {
        [Required(ErrorMessage = "Please enter current password")]
        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }

        [Required(ErrorMessage = "Please enter new password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!#%*?&])[A-Za-z\d@$!#%*?&^]{8,}$", ErrorMessage = "Please enter strong New password.")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Please enter confirm  password")]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirmation Password must match")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!#%*?&])[A-Za-z\d@$!#%*?&^]{8,}$", ErrorMessage = "Please enter strong Confirm password.")]
        public string? ConfirmPassword { get; set; }

    }

}
