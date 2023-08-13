using Yggdrasil.Enum;
using System.Collections.Generic;

namespace Yggdrasil.Database.Login
{
    public class UserAuthenticationQuery
    {
        private readonly BaseDB _db;

        public UserAuthenticationQuery(BaseDB db)
        {
            _db = db;
        }

        public UserValidationResult Validate(string username, string password)
        {
            string sqlQuery = @"
        SELECT
            ""Username"".""accountId"" AS ""AccountId"", 
            ""Username"".username AS username, 
            ""Username"".""password"" AS ""password"", 
            ""Username"".""2password"" AS ""2pass"", 
            ""Username"".""SubType"" AS ""SubType""
        FROM
            ""Account"".""LoginUser"" AS ""Username""
        WHERE
            ""Username"".username = @username";

            var parameters = new Dictionary<string, object>
            {
                { "@username", username }
            };

            List<Dictionary<string, object>> results = _db.Query(sqlQuery, parameters);

            var result = new UserValidationResult();

            if (results.Count > 0)
            {
                result.UserData = results[0];
                if (result.UserData["password"].ToString() == password)
                {
                    result.Status = LoginRequestStatusEnum.Success;
                }
                else
                {
                    result.Status = LoginRequestStatusEnum.WrongPassword;
                }
            }
            else
            {
                result.Status = LoginRequestStatusEnum.UserNotFound;
            }

            return result;
        }

    }
    public class UserValidationResult
    {
        public LoginRequestStatusEnum Status { get; set; }
        public Dictionary<string, object> UserData { get; set; }
    }

}