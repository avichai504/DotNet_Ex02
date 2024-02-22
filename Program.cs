using System;

namespace A24_Ex02_NeomiBashari_207087487_AvichaiGalOr_207051848
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Connect Four!\n");
            Game game = new Game();
            game.Start();
            Console.ReadKey();
        }
    }
}

