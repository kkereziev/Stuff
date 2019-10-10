using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MergeFIles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            using (var readerOne=new StreamReader("FileOne.txt"))
            {
                using (var readerTwo=new StreamReader("FileTwo.txt"))
                {
                    while (!readerTwo.EndOfStream)
                    {
                        int lineOne = int.Parse(readerOne.ReadLine());
                        int lineTwo = int.Parse(readerTwo.ReadLine());
                        list.Add(lineOne);
                        list.Add(lineTwo);
                    }
                }
            }
            int count = 0;
            using (var writer=new StreamWriter("result.txt"))
            {
                while (list.Count>count)
                {
                    writer.WriteLine(list[count]);
                    count++;
                }
            }
        }
    }
}
