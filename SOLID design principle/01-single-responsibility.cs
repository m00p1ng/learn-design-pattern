using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace SOLID
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count} : {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveTofile(Journal journal, string filename, bool overwrite = false)
        {
            if(overwrite || !File.Exists(filename)) 
            {
                File.WriteAllText(filename, journal.ToString());
            }
        }
    }

    public class Demo
    {
        public static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);

            var p = new Persistence();
            var filename = @"test.txt";
            p.SaveTofile(j, filename);
            Process.Start(filename);
        }
    }
}
