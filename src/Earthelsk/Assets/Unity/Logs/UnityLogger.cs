using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Assets.Lib.Logs;

namespace Assets.Unity.Logs
{
    class UnityLogger : ILogger
    {
        public void Log(string message)
        {
            UnityEngine.Debug.Log(message);
        }
    }
}
