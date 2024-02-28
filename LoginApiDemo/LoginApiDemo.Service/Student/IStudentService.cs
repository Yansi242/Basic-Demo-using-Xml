using LoginApiDemo.Model.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Service.Student
{
	public interface IStudentService
	{
		Task<List<StudentModel>> GetStudentList();
	}
}
