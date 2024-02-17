using System;

namespace A24_Ex02_NeomiBashari_207087487_AvichaiGalOr_207051848
{
    public class Board
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        private char[,] m_board;

        public Board(int i_rows, int i_columns)
        {
            Rows = Math.Max(4, Math.Min(i_rows, 8));
            Columns = Math.Max(4, Math.Min(i_columns, 8));

            m_board = new char[Rows, Columns];
            initializeBoard();
        }

        private void initializeBoard()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    m_board[row, col] = '.';
                }
            }
        }

        public void Display()
        {
            for (int col = 0; col < Columns; col++)
            {
                Console.Write($" {col + 1}  ");
            }
            Console.WriteLine();

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Console.Write($"| {m_board[row, col]} ");
                }
                Console.WriteLine("|");
                Console.WriteLine(new string('=', Columns * 4));
            }
            Console.WriteLine("\n");
            Console.WriteLine("---------------");
            Console.WriteLine("\n");
        }

        public bool IsValidMove(int i_row, int i_column)
        {
            return i_row >= 0 && i_row < Rows && i_column >= 0 && i_column < Columns && m_board[i_row, i_column] == '.';
        }

        public void PlaceToken(int i_row, int i_column, char i_token)
        {
            if (IsValidMove(i_row, i_column))
            {
                m_board[i_row, i_column] = i_token;
            }
        }

        public int FindLowestEmptyRow(int i_column)
        {
            for (int row = Rows - 1; row >= 0; row--)
            {
                if (m_board[row, i_column] == '.')
                {
                    return row;
                }
            }
            return -1;
        }

        public bool IsFull()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (m_board[row, col] == '.')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public char this[int i_row, int i_col]
        {
            get { return m_board[i_row, i_col]; }
            set { m_board[i_row, i_col] = value; }
        }
    }
}
