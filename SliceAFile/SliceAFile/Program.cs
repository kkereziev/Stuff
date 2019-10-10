using System;
using System.IO;
using System.Linq;

namespace SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLength = new FileInfo("./sliceMe.txt");
            var parts = 4;
            var partSize = fileLength.Length/parts;
            var fileNumber = 1;
            var readBytes = 0;
            using (var reader = new StreamReader("sliceMe.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var bufferSize = partSize;
                    if (fileNumber==parts)
                    {
                        bufferSize = fileLength.Length - (parts - 1) * partSize;
                    }
                    var buffer = new char[bufferSize];
                    readBytes += reader.Read(buffer, 0, buffer.Length);
                    using (var writer = new StreamWriter($"./sliced-{fileNumber}.txt"))
                    {
                        writer.Write(buffer);
                    }
                    if (readBytes==fileLength.Length)
                    {
                        break;
                    }
                    fileNumber++;
                }
            }
        }
    }
}
