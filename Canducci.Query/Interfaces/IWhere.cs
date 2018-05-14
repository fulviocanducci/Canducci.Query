using System;
using System.Collections.Generic;
using System.Text;

namespace Canducci.Query.Interfaces
{
    public interface IWhere
    {        
        IAnd Where(string name, object value, string comparation = "=");
    }
}
