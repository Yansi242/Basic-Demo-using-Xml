using LoginApiDemo.Model.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Data.DBRepository.Student
{
	public interface IStudentRepository
	{
		Task<List<StudentModel>> GetStudentList();
	}
}
