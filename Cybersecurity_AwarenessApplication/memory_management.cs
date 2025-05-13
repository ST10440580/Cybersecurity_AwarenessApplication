using System.Collections.Generic;
using System.IO;
using System;

namespace Cybersecurity_AwarenessApplication
{
    public class memory_management
    {
        private string path;
        public List<string> MemoryData { get; private set; }

        public memory_management()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string new_path = projectPath.Replace("bin\\Debug", "");
            path = Path.Combine(new_path, "memory.txt");

            MemoryData = memory_load(path);
        }

        private List<string> memory_load(string path)
        {
            if (File.Exists(path))
            {
                return new List<string>(File.ReadAllLines(path));
            }
            else
            {
                File.CreateText(path).Close();
                return new List<string>();
            }
        }

        public void AddToMemory(string entry)
        {
            MemoryData.Add(entry);
            File.WriteAllLines(path, MemoryData);
        }
    }
}