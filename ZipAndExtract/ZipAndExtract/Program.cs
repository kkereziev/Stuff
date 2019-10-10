using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            var zipFile = "myZip.zip";
            var files = Directory.GetFiles(Environment.CurrentDirectory);
            var extractFolderPath = @"C:\Users\Krum Kereziev\source\repos\ZipAndExtract\ZipAndExtract\ExtractFolder";
            using (var archive=ZipFile.Open(zipFile,ZipArchiveMode.Create))
            {
                foreach (var item in files)
                {
                    archive.CreateEntryFromFile(item, Path.GetFileName(item));
                }
            }
            ZipFile.ExtractToDirectory("myZip.zip", extractFolderPath);
        }
    }
}
