using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LAB2._2
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
            while (!sr.EndOfStream)
            {
                ger = Convert.ToInt16(sr.ReadLine());
                    if (ger < min)
                    {
                        min = ger;
                    }
                    if (ger > max)
                    {
                        max = ger;
                    }
            }
            sr.Close();

            /*string text = File.ReadAllText (@"C:\FTP\WriteText.txt");   
            Console.WriteLine("Contents of WriteText.txt = {0}", text);

            int max = -1000;
            int min = 10000;
            for (int i = 0; i < text.Length; i++) 
            {   
                int g = Convert.ToInt16(text[i]);
                Console.WriteLine(g);
                if (g < min) 
                {
                    min = g;
                }
                if (g > max)
                {
                    max = g;
                }
            }
            */
            Console.WriteLine("Min is " + min);
            Console.WriteLine("Max is " + max);
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
