using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Utils
{
    public static class PwdHashComparer
    {
        public static bool VerifyPassword(string? password, string hashedPassword)
        {
            // 입력된 비밀번호와 저장된 해시값을 비교
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
