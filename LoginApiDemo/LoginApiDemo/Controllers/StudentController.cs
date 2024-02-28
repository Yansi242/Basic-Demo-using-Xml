using LoginApiDemo.Common.Helpers;
using LoginApiDemo.Service.Student;
using LoginApiDemo.Model.Login;
using LoginApiDemo.Model.Settings;
using LoginApiDemo.Model.Student;
using LoginApiDemo.Service.JWTAuthentication;
using LoginApiDemo.Service.login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Net.Http.Headers;

namespace LoginApiDemo.Controllers
{
	[Route("api/Student")]
	[ApiController]
	[Authorize]
	public class StudentController : Controller
	{
		#region Fields
		private IStudentService _studentService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IJwtAuthenticationService _jwtAuthenticationService;
		#endregion

		#region Constructor
		public StudentController(IStudentService studentService, IHttpContextAccessor httpContextAccessor, IJwtAuthenticationService jwtAuthenticationService)
		{
			_studentService = studentService;
			_httpContextAccessor = httpContextAccessor;
			_jwtAuthenticationService = jwtAuthenticationService;
		}
		#endregion
		[HttpGet("List")]
		public async Task<ApiResponse<StudentModel>> GetAllStudent()
		{
			ApiResponse<StudentModel> response = new ApiResponse<StudentModel>() { Data = new List<StudentModel>() };

			TokenModel tokenModel = new TokenModel();

			string? jwtToken = string.Empty;
			if (_httpContextAccessor.HttpContext?.Request.Headers.TryGetValue(HeaderNames.Authorization, out var authHeader) == true)
			{
				jwtToken = authHeader.ToString().Replace(JwtBearerDefaults.AuthenticationScheme + " ", "");
			}
			if (!string.IsNullOrEmpty(jwtToken))
			{
				tokenModel = _jwtAuthenticationService.GetUserTokenData(jwtToken);
			}
			if(tokenModel == null)
			{
				response.Message = "Please Log in First!, After You can Fetch data.";
				response.Success = false;
			}
			var result = await _studentService.GetStudentList();
			if (result != null)
			{
				response.Data = result;
				response.Success = true;
			}
			else
			{
				response.Success = false;
				response.Data = null;
			}
			return response;
		}
	}
}
