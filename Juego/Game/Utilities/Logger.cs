using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Utilities
{
    public static class Logger
    {
        private static readonly string path = "/LOGS/Log.txt";
        public static void Log(Exception e)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(DateTime.Now.ToString("HH/mm") + ":" + e.Message);
                }
            }
            else
            { 
                using (StreamWriter sr = new StreamWriter(path))
                {
                    sr.WriteLine(DateTime.Now.ToString("HH/mm") + ":" + e.Message);
                }
            }
        }
    }
}
