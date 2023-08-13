using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yggdrasil.Enum
{
    public enum LoginRequestStatusEnum
    {
        Success,
        WrongPassword,
        UserNotFound,
        Admin,
        Banned,
        UnknowError
    }
}
