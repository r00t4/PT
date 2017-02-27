﻿using System;
using System.IO;
using System.Collections.Generic;

namespace Snake
{
	public class Wall : Fucntions
	{
		public Wall(string FileName)
		{
			sign = '#';
			color = ConsoleColor.Blue;
			for (int i = 0; i < 50; ++i)
				for (int j = 0; j < 50; ++j)
					u[i, j] = 0;
			body = new List<Point>();
			StreamReader sr = new StreamReader(FileName);
			int n = int.Parse(sr.ReadLine());
			for (int i = 0; i < n; ++i)
			{
				string s = sr.ReadLine();
				//Console.WriteLine(s);
				for (int j = 0; j < s.Length; j++)
				{
					//Console.WriteLine(s[j]);
					if (s[j] == '*')
					{
						body.Add(new Point(j, i));
					}
				}
			}
			foreach (Point p in body)
			{
				u[p.x, p.y] = 1;
			}
		}
	}
}
