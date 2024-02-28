using LoginApiDemo.Data.DBRepository.Account;
using LoginApiDemo.Data.DBRepository.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Data
{
    public static class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dataDictionary = new Dictionary<Type, Type>
            {
                {typeof(IAccountRepository),typeof(AccountRepository)},
				{typeof(IStudentRepository),typeof(StudentRepository)}
			};
            return dataDictionary;
        }
    }
}
