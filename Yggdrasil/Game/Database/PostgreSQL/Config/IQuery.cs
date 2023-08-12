using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yggdrasil.Database;

public interface IQuery<TResult>
{
    TResult Execute(string sqlQuery);
}

public interface ICommand
{
    void Execute(string sqlQuery, Dictionary<string, object> parameters = null);
}

