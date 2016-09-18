using System;
using UnityEditor;

namespace Assets.Lib.Tools
{
    public class IdGenerator
    {
        public string Generate()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}