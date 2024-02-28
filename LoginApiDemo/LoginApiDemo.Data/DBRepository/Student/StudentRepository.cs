using LoginApiDemo.Common.Helpers;
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

namespace LoginApiDemo.Data.DBRepository.Student
{
	public class StudentRepository : BaseRepository, IStudentRepository
	{
		#region Constructor
		public StudentRepository(IOptions<DataConfig> dataConfig) : base(dataConfig)
		{
		}
		#endregion
		public async Task<List<StudentModel>> GetStudentList()
		{
			var data = await QueryAsync<StudentModel>(StoredProcedures.studentlist, commandType: CommandType.StoredProcedure);
			return data.ToList();
		}
	}
}
