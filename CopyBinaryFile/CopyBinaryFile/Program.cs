using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.IO;
namespace _4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new FileStream("CopyMe.png", FileMode.Open, FileAccess.Read))
            {
                using (var writer = new FileStream("copiedFile.png", FileMode.Create, FileAccess.Write))
                {
                    var buffer = new byte[4096];
                    var length = 0;

                    while ((length = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, length);
                    }
                }
            }
        }
    }
}