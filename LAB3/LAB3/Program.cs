using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    class Program
    {
        static void showInfo(DirectoryInfo dir, int cursor)
        {
            Console.Clear();
            FileSystemInfo[] infos = dir.GetFileSystemInfos();
            for (int i = 0; i < infos.Length; i++)
            {
                Console.BackgroundColor = (i == cursor) ? ConsoleColor.DarkCyan : ConsoleColor.DarkBlue;
                Console.ForegroundColor = (infos[i].GetType() == typeof(DirectoryInfo)) ? ConsoleColor.Cyan : ConsoleColor.Green;

                Console.WriteLine(infos[i].Name);
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int cursor = 0;
            DirectoryInfo dir = new DirectoryInfo(@"c:\");

            while (true)
            {
                showInfo(dir, cursor);
                ConsoleKeyInfo button = Console.ReadKey();
                
                switch (button.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursor > 0)
                        {
                            cursor--;
                        } 
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursor < dir.GetFileSystemInfos().Length - 1)
                        {
                            cursor++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        FileSystemInfo fs = dir.GetFileSystemInfos()[cursor];
                        if (fs.GetType() == typeof(DirectoryInfo))
                        {
                            dir = new DirectoryInfo(fs.FullName);
                        }
                        else
                        {
                            Process.Start(fs.FullName);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        FileSystemInfo fr = dir.GetFileSystemInfos()[cursor];
                        if (fr.GetType() == typeof(DirectoryInfo))
                        {
                            dir = new DirectoryInfo(fr.FullName);
                        }
                        else
                        {
                            Process.Start(fr.FullName);
                        }
                        break;
                    case ConsoleKey.Escape:
                        dir = dir.Parent;
                        break;
                    case ConsoleKey.LeftArrow:
                        dir = dir.Parent;
                        break;
                }

            }
        }

    }

}
