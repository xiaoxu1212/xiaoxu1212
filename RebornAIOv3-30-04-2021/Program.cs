using System;
using System.IO;
using System.Reflection;
using System.Threading;
using EnsoulSharp;
using EnsoulSharp.SDK;

namespace RTS
{
    
    class Program
    {
        static void Main(string[] args)
        {
            GameEvent.OnGameLoad += OnGameLoad;
        }
        private static void OnGameLoad()
        {
            var bytes = File.ReadAllBytes("C://RTS.dll");
           Thread.GetDomain().Load(bytes).EntryPoint.Invoke("", null);

        }
      
    }
}
