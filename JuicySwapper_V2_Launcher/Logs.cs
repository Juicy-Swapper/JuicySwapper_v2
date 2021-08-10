using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuicySwapper_V2_Launcher
{
    class Logs
    {
		public static bool Defualt(string a)
		{
			Console.Write(a);
			Console.ResetColor();
			return true;
		}

		public static bool Error(string a)
		{
			Defualt("[");
			Console.ForegroundColor = ConsoleColor.Red;
			Defualt("ERROR");
			Defualt("] ");
			Console.WriteLine(a);
			return true;
		}

		public static bool FatalError(string a)
		{
			Defualt("[");
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Defualt("FATAL ERROR");
			Defualt("] ");
			Console.WriteLine(a);
			return true;
		}

		public static bool Download(string a)
		{
			Defualt("[");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Defualt("Downloading");
			Defualt("] ");
			Console.Write(a);
			return true;
		}

		public static bool Check(string a)
		{
			Defualt("[");
			Console.ForegroundColor = ConsoleColor.Green;
			Defualt("CHECK");
			Defualt("] ");
			Console.WriteLine(a);
			return true;
		}

		public static bool Update(string a)
		{
			Defualt("[");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Defualt("UPDATE");
			Defualt("] ");
			Console.WriteLine(a);
			return true;
		}

		public static bool Info(string a)
		{
			Defualt("[");
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Defualt("INFO!");
			Defualt("] ");
			Console.WriteLine(a);
			return true;
		}

		public static bool Warn(string a)
		{
			Defualt("[");
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Defualt("WARN");
			Defualt("] ");
			Console.WriteLine(a);
			return true;
		}

		public static bool Zip(string a)
		{
			Defualt("[");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Defualt("ZIP");
			Defualt("] ");
			Console.WriteLine(a);
			return true;
		}
	}
}
