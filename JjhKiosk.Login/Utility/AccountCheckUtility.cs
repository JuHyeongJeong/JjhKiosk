using JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse;
using JjhKiosk.Login.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Login.Utility
{
    public static class AccountCheckUtility
    {
        public static LOGIN_CHECK Authenticate(string username, string password, JjhKioskDbContext dbContext)
        {
            var user = dbContext.KioskAccounts.ToList().FirstOrDefault(x => x.UserName == username);

            if(user == null)
            {
                return LOGIN_CHECK.ACCOUNT_MISSMATCH;
            }
            // 사용자 이름 확인
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return LOGIN_CHECK.PASSWORD_MISSMATCH;
            }

            return LOGIN_CHECK.SUCCESS;
        }
    }
}
