using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
namespace _2dTopdownGameThingy {
	class Program {
		static Point[] level = new Point[] {
			new Point(5, 10),
			new Point(5, 9),
			new Point(5, 8),
			new Point(5, 7),
			new Point(5, 6),
			new Point(6, 6),
			new Point(7, 6),
			new Point(8, 6),
			new Point(9, 6),
			new Point(9, 7),
			new Point(9, 9),
			new Point(9, 10),
			new Point(8, 10),
			new Point(7, 10),
			new Point(6, 10)
		};
		static Point plr = new Point(7, 8);
		static void Render() {
			Console.CursorVisible = false;
			foreach (Point point in level) {
				Console.SetCursorPosition(point.X, point.Y);
				Console.Write('#');
			}
			Console.SetCursorPosition(plr.X, plr.Y);
			Console.CursorVisible = true;
		}
		static void ShowDebug() {
			Console.CursorVisible = false;
			Console.ForegroundColor = ConsoleColor.Cyan;
			PrintAtRight($"Running on {(Environment.Is64BitOperatingSystem ? 64 : 32)} bit OS", 1);
			Console.ResetColor();
			PrintAtRight($"X: {plr.X}; Y: {plr.Y}", 2, true, 6);
			Console.CursorVisible = true;
		}
		static void PrintAtRight(object content, int dy, bool cleanup = false, int cleanupChars = 0) {
			if (cleanup) {
				Console.SetCursorPosition(Console.BufferWidth - cleanupChars, dy + Console.WindowTop);
				Console.Write(new string(' ', cleanupChars));
			}
			Console.SetCursorPosition(Console.BufferWidth - content.ToString().Length, dy + Console.WindowTop);
			if (showdebug)
				Console.Write(content);
			else
				Console.Write(new string(' ', content.ToString().Length));
		}
		static bool levelChanged = true;
		static bool showdebug = false;
		static void Main(string[] args) {
			Console.SetCursorPosition(plr.X, plr.Y);
			while (true) {
				if (levelChanged) {
					Render();
					levelChanged = false;
				}
				else {

				}
				if (Console.KeyAvailable) {
					ConsoleKeyInfo key = Console.ReadKey(true);
					if (key.Key == ConsoleKey.UpArrow && !level.Contains(new Point(plr.X, plr.Y - 1)) && plr.Y > 0) {
						plr = new Point(plr.X, plr.Y - 1);
						ShowDebug();
					} else if (key.Key == ConsoleKey.DownArrow && !level.Contains(new Point(plr.X, plr.Y + 1)) && plr.Y < Console.BufferHeight) {
						plr = new Point(plr.X, plr.Y + 1);
						ShowDebug();
					} else if (key.Key == ConsoleKey.RightArrow && !level.Contains(new Point(plr.X + 1, plr.Y)) && plr.X < Console.BufferWidth) {
						plr = new Point(plr.X + 1, plr.Y);
						ShowDebug();
					} else if (key.Key == ConsoleKey.LeftArrow && !level.Contains(new Point(plr.X - 1, plr.Y)) && plr.X > 0) {
						plr = new Point(plr.X - 1, plr.Y);
						ShowDebug();
					} else if (key.Key == ConsoleKey.Tab) {
						showdebug = !showdebug;
						ShowDebug();
					}
					Console.SetCursorPosition(plr.X, plr.Y);
				}
			}
		}
	}
}
