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
            string text = File.ReadAllText(@"C:\FTP\WriteText.txt");
            Console.WriteLine("Contents of WriteText.txt = {0}", text);

            int min = 10000;
            int max = -1000;
            for (int i = 0; i < text.Length; i++)
            {
                int g = Convert.ToInt16(text[i]);
                for (int j = 2; j <= g; j++)
                {
                    if (g % j == 0)
                    {
                        if (g < min)
                        {
                            min = g;
                        }
                        if (g > max)
                        {
                            max = g;
                        }
                        break;  
                    }

                }
            }
            Console.WriteLine("Min is " + min);
            Console.WriteLine("Max is " + max);
            Console.ReadKey();
        }
    }
}
