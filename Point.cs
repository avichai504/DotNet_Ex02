using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace A24_Ex02_NeomiBashari_207087487_AvichaiGalOr_207051848
{
    internal class Point
    {
        Board m_board;

        public Point(Board board)
        {
            m_board = board;
        }
        public bool CheckWinCondition(char token)
        {
            return CheckHorizontalWin(token) || CheckVerticalWin(token) || CheckDiagonalRightWin(token) || CheckDiagonalLeftWin(token);
        }

        public bool CheckHorizontalWin(char i_token)
        {
            for (int row = 0; row < m_board.Rows; row++)
            {
                for (int col = 0; col < m_board.Columns - 3; col++)
                {
                    if (m_board[row, col] == i_token &&
                    m_board[row, col + 1] == i_token &&
                    m_board[row, col + 2] == i_token &&
                        m_board[row, col + 3] == i_token)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckVerticalWin(char i_token)
        {
            for (int col = 0; col < m_board.Columns; col++)
            {
                for (int row = 0; row < m_board.Rows - 3; row++)
                {
                    if (m_board[row, col] == i_token &&
                        m_board[row + 1, col] == i_token &&
                        m_board[row + 2, col] == i_token &&
                        m_board[row + 3, col] == i_token)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckDiagonalRightWin(char i_token)
        {
            for (int row = 0; row < m_board.Rows - 3; row++)
            {
                for (int col = 0; col < m_board.Columns - 3; col++)
                {
                    if (m_board[row, col] == i_token &&
                        m_board[row + 1, col + 1] == i_token &&
                        m_board[row + 2, col + 2] == i_token &&
                        m_board[row + 3, col + 3] == i_token)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckDiagonalLeftWin(char i_token)
        {
            for (int row = 3; row < m_board.Rows; row++)
            {
                for (int col = 0; col < m_board.Columns - 3; col++)
                {
                    if (m_board[row, col] == i_token &&
                        m_board[row - 1, col + 1] == i_token &&
                        m_board[row - 2, col + 2] == i_token &&
                        m_board[row - 3, col + 3] == i_token)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
