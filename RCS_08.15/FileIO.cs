using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RCS_08._15
{
    class FileIO
    {
        public static List<string> Read()
        {
            String line;
            List<string> a = new List<string>();
            try
            {
                StreamReader sr = new StreamReader("Test.txt");

                line = sr.ReadLine();

                while (line != null)
                {
                    a.Add((line));
                    line = sr.ReadLine();
                }
                sr.Close();
                return a;
            }
            catch
            {
                Console.WriteLine("Neizdevas atvert failu!");
                return null;
            }
        }

        public static void Write(List<string> a, string fileName)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName, false);

                foreach (var item in a)
                    sw.WriteLine(item);

                sw.Close();
            }
            catch
            {
                Console.WriteLine("Neizdevas ierakstit faila!");
            }
        }
    }
}
