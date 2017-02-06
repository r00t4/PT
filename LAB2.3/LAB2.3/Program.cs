using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LAB2._3
{
    class ReadFromFile
    {
        static void Main()
        {
            FileStream text = new FileStream(@"C:\FTP\WriteText.txt", FileMode.Open);
            StreamReader sr = new StreamReader(text);
            int ger;
            int max = -1000;
            int min = 10000;
            int r = 1;
            while (!sr.EndOfStream)
            {
                ger = Convert.ToInt16(sr.ReadLine());
                for (int i = 2; i < ger; i++)
                {
                    if (ger % i == 0)
                    {
                        r = i;
                        break;
                    }
                }
                if (r == 1)
                {
                    if (ger < min)
                    {
                        min = ger;
                    }
                    if (ger > max)
                    {
                        max = ger;
                    }
                }
            }
            sr.Close();
            
            /*FileStream text = new FileStream(@"C:\FTP\WriteText.txt", FileMode.Open);
            StreamReader sr = new StreamReader(text);

            int min = 10000;
            int max = -1000;
            for (int i = 0; i < text.Length; i++)
            {
                int r = 1;
                int g = Convert.ToInt16(text[i]);
                for (int j = 2; j < g; j++)
                {
                    if (g % j == 0)
                    {
                        r = g;
                        break;
                    }
                }
                if (r == 1)
                {
                    if (max < g)
                    {
                        max = g;
                    }
                    if (min > g)
                    {
                        min = g;
                    }
                }
            }*/
            Console.WriteLine("Min is " + min);
            Console.WriteLine("Max is " + max);
            using (StreamWriter file = new StreamWriter(@"C:\FTP\WriteLines2.txt"))
            {
                file.WriteLine("Min is " + min);
                file.WriteLine("Max is " + max);
            }
            Console.ReadKey();
        }
    }
}
