using System;
using Tanks.Patterns;

namespace BattleCity
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Title = "TanksByKokhnenko";
            Console.SetWindowSize(158, 38);
            Console.CursorVisible = false;

            Invoker invoker = new Invoker();

            try
            {
                invoker.Function();
            }
            catch (ExceptionExit ex)
            {
                    GlobalParam.PrintEmptyFon();
                    Console.SetCursorPosition(
                        GlobalParam.WidthConsole / 2 - ex.Message.Length / 2, GlobalParam.HeightConsole / 2);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(ex.Message);
                    Console.SetCursorPosition(0, GlobalParam.HeightConsole);
            }

            Console.SetCursorPosition(0, GlobalParam.HeightConsole);
            Console.ResetColor();
            Console.CursorVisible = true;
        }
    }
}