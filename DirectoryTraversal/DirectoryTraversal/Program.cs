using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var filesByExtensions = new Dictionary<string, Dictionary<string, long>>();
            var directory = new DirectoryInfo(Environment.CurrentDirectory);
            var files=directory.GetFiles();
            foreach (var file in files)
            {
                var extension = file.Extension;
                var name = file.Name;
                var length = file.Length;
                if (!filesByExtensions.ContainsKey(extension))
                {
                    filesByExtensions.Add(extension, new Dictionary<string, long>());
                }
                filesByExtensions[extension].Add(name, length);
            }
            filesByExtensions = filesByExtensions
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            using (var writer=File.AppendText("report.txt"))
            {
                foreach (var item in filesByExtensions)
                {
                    writer.WriteLine($"{item.Key}");
                    foreach (var file in item.Value)
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value}kb");
                    }
                }
            }
        }
    }
}
