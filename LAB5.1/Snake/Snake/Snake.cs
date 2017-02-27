﻿using System;
using System.IO;
using System.Collections.Generic;

namespace Snake
{
	public class Snake : Fucntions
	{
		public int GM;
        public int[,] u = new int[50, 50];
        public Snake()
		{
			sign = '0';
			body = new List<Point>();
			body.Add(new Point(10, 10));
			color = ConsoleColor.DarkYellow;
		}
		public void Move()
		{
			ConsoleKeyInfo pressed = Console.ReadKey();
			Erase();
			if (pressed.Key == ConsoleKey.UpArrow)
				Move(0, -1);
			if (pressed.Key == ConsoleKey.DownArrow)
				Move(0, 1);
			if (pressed.Key == ConsoleKey.RightArrow)
				Move(1, 0);
			if (pressed.Key == ConsoleKey.LeftArrow)
				Move(-1, 0);
		}
		public void Move(int dx, int dy)
		{
			for (int i = 0; i < 50; ++i)
				for (int j = 0; j < 50; ++j)
					u[i, j] = 0;
			for (int i = body.Count - 1; i > 0; --i)
			{
				body[i].x = body[i - 1].x;
				body[i].y = body[i - 1].y;
				u[body[i].x, body[i].y] = 1;
			}
			body[0].x += dx;
			body[0].y += dy;
			if (body[0].x >= 20)
				body[0].x = 0;
			if (body[0].y >= 20)
				body[0].y = 0;

			if (body[0].x < 0)
				body[0].x = 19;
			if (body[0].y < 0)
				body[0].y = 19;
			if (u[body[0].x, body[0].y] == 1)
				GM = 1;
			u[body[0].x, body[0].y] = 1;
		}
		public void Game_Over(Wall wall)
		{
			if (wall.u[body[0].x, body[0].y] == 1)
				GM = 1;
		}
	}
}
