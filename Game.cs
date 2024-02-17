using System;

namespace A24_Ex02_NeomiBashari_207087487_AvichaiGalOr_207051848
{
    public class Game
    {
        private Board m_board;
        private Player m_player1;
        private Player m_player2;
        private Player m_currentPlayer;

        public void SetupGame()
        {
            Console.WriteLine("Do you want to play with a friend? (Y/N)");
            string opponentChoice = Console.ReadLine().ToLower();

            int rows = 0;
            int columns = 0;
            bool validInput = true;

            while (validInput)
            {
                try
                {
                    Console.WriteLine("Board size? (Minimum 4x4, Maximum 8x8)");
                    Console.WriteLine("Enter rows:");
                    rows = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter columns:");
                    columns = int.Parse(Console.ReadLine());

                    if (rows < 4 || rows > 8 || columns < 4 || columns > 8)
                    {
                        Console.WriteLine("Invalid board size. Please enter values between 4 and 8.");
                    }
                    else
                    {
                        validInput = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter numeric values.");
                }
            }

            rows = Math.Max(4, Math.Min(rows, 8));
            columns = Math.Max(4, Math.Min(columns, 8));

            m_board = new Board(rows, columns);

            Console.WriteLine("What is your name?");
            string player1Name = Console.ReadLine();
            m_player1 = new Player(player1Name, 'X');

            if (opponentChoice == "y")
            {
                Console.WriteLine("What is your friend's name?");
                string player2Name = Console.ReadLine();
                m_player2 = new Player(player2Name, 'O');
            }
            else
            {
                m_player2 = new AIPlayer("AI Player", 'O');
            }

            m_currentPlayer = m_player1; // Player 1 starts
        }

        public void Start()
        {
            SetupGame();
            Console.WriteLine("The game has started!\n");
            bool isGameOver = false;

            while (!isGameOver)
            {
                m_board.Display();
                m_currentPlayer.MakeMove(m_board);

                if (CheckWinCondition())
                {
                    isGameOver = true;
                    EndGame(m_currentPlayer.Name); // EndGame method displays the winner
                }
                else if (m_board.IsFull())
                {
                    isGameOver = true;
                    EndGame(null); // No winner, it's a draw
                }
                else
                {
                    SwitchPlayer();
                }
            }
        }

        private void EndGame(string winnerName)
        {
            m_board.Display();
            if (winnerName != null)
            {
                Console.WriteLine($"{winnerName} wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            Console.WriteLine("Game Over!");
        }
        private bool CheckWinCondition()
        {
            char token = m_currentPlayer.Token;
            return CheckHorizontalWin(token) || CheckVerticalWin(token) || CheckDiagonalRightWin(token) || CheckDiagonalLeftWin(token);
        }

        private bool CheckHorizontalWin(char i_token)
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

        private bool CheckVerticalWin(char i_token)
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

        private bool CheckDiagonalRightWin(char i_token)
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

        private bool CheckDiagonalLeftWin(char i_token)
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


        private void SwitchPlayer()
        {
            m_currentPlayer = m_currentPlayer == m_player1 ? m_player2 : m_player1;
        }
    }
}
