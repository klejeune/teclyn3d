using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Lib.Logs
{
    class DummyLogger : ILogger
    {
        public void Log(string message)
        {
            UnityEngine.Debug.Log(message);
        }
    }
}
