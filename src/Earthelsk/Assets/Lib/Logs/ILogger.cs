using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Assets.Lib.Logs
{
    public interface ILogger
    {
        void Log(string message);
    }
}
