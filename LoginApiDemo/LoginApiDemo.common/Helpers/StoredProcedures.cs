using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiDemo.Common.Helpers
{
    public static class StoredProcedures
    {
        public const string LoginUser = "sp_userlogin";
        public const string RegisterUser = "Sp_RegisterUser";
        public const string UpdateLoginToken = "SP_UpdateLoginToken";
        public const string studentlist = "sp_GetStudentList";

	}
}
