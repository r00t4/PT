using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                int g = Convert.ToInt32(args[i]);
                int r = 1;
                for (int j = 2; j < g; j++)
                    { 
                        if (g % j == 0)
                        {
                            r = j;
                            break;
                            }
                    }
                    if (r == 1) {
                        Console.WriteLine(g + " is prime"); 
                    }
            }
            Console.ReadKey();
        }
    }
}
