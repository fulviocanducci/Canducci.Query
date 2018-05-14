using System;
using System.Collections.Generic;
using System.Text;

namespace Canducci.Query.Interfaces
{
    public interface IResultCommand
    {
        string Raw { get; }
        object Parameters { get; }
    }
}
