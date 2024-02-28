using LoginApiDemo.Data.DBRepository.Student;
using LoginApiDemo.Service.JWTAuthentication;
using LoginApiDemo.Service.login;
using LoginApiDemo.Service.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Service
{
    public static class ServiceRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var serviceDictonary = new Dictionary<Type, Type>
            {
                {typeof(IAccountServices),typeof(AccountServices) },
                {typeof(IJwtAuthenticationService),typeof(JwtAuthenticationService) },
                {typeof(IStudentService),typeof(StudentServivce) },
            };
            return serviceDictonary;
        }
    }
}
