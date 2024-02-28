using LoginApiDemo.Common.Helpers;
using LoginApiDemo.Data.DBRepository.Account;
using LoginApiDemo.Data.DBRepository.Student;
using LoginApiDemo.Model.Config;
using LoginApiDemo.Model.Login;
using LoginApiDemo.Model.Student;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Service.Student
{
	public class StudentServivce : IStudentService
	{
		#region Fields
		private IStudentRepository _studentRepository;
		#endregion

		#region Constructor
		public StudentServivce(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}
		#endregion
		public async Task<List<StudentModel>> GetStudentList()
		{
			return await _studentRepository.GetStudentList();
		}
	}
}
