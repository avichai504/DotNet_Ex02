using System;

namespace A24_Ex02_NeomiBashari_207087487_AvichaiGalOr_207051848
{
    public class Player
    {
        public string Name { get; private set; }
        public char Token { get; private set; }

        public Player(string i_name, char i_token)
        {
            Name = i_name;
            Token = i_token;
        }

        public virtual void MakeMove(Board i_board)
        {
            bool validMove = false;
            while (!validMove)
            {
                Console.Write($"{Name}, enter your move (column):   ");
                string input = Console.ReadLine();
                Console.Write("\n");

                int column;
                bool isNumeric = int.TryParse(input, out column);

                if (isNumeric && column >= 1 && column <= i_board.Columns)
                {
                    int row = i_board.FindLowestEmptyRow(column - 1);
                    if (row != -1)
                    {
                        i_board.PlaceToken(row, column - 1, Token);
                        validMove = true;
                    }
                    else
                    {
                        Console.WriteLine("Column is full, try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }
        }
    }
}
