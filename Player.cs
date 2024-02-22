using System;
using System.Collections.Generic;

namespace A24_Ex02_NeomiBashari_207087487_AvichaiGalOr_207051848
{
    internal class Player
    {
        public string Name { get; private set; }
        public char Token { get; private set; }
        private int m_points;
        private bool m_wantsToPlay = true;

        public Player(string i_name, char i_token)
        {
            Name = i_name;
            Token = i_token;
            m_points = 0;
        }
        public bool GetWantsToPlay()
        {
            return m_wantsToPlay;
        }
        public void SetWantsToPlay(bool value)
        {
            m_wantsToPlay = value;
        }
        public int GetPlayerPoints()
        {
            return m_points;
        }
        public void IncreasePoints()
        {
            m_points++;
        }

        public virtual void MakeMove(Board i_board)
        {
            bool isValidMove = true;
            while (isValidMove)
            {
                m_wantsToPlay = true;
                Console.Write($"{Name}, enter your move (column):   ");
                Console.Write("\n");
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    m_wantsToPlay = false;
                    break;
                }

                int column;
                bool isNumeric = int.TryParse(input, out column);

                if (isNumeric && column >= 1 && column <= i_board.Columns)
                {
                    int row = i_board.FindLowestEmptyRow(column - 1);
                    if (row != -1)
                    {
                        i_board.PlaceToken(row, column - 1, Token);
                        isValidMove = false;
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
