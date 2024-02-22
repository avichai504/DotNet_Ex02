using Ex02.ConsoleUtils;
using System;

namespace A24_Ex02_NeomiBashari_207087487_AvichaiGalOr_207051848
{
    internal class Game
    {
        private Board m_board;
        private Player m_player1;
        private Player m_player2;
        private Player m_currentPlayer;
        private Point m_point;

        public void SetupGame()
        {
            const bool v_PlayWithFriend = true;

            int rows = 0;
            int columns = 0;
            bool isNotValidInput = true;

            while (isNotValidInput)
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
                        Console.WriteLine("Invalid board size. Please enter values between 4 and 8:");
                    }
                    else
                    {
                        isNotValidInput = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter numeric values:");
                }
            }

            m_board = new Board(rows, columns);

            isNotValidInput = true;
            while (isNotValidInput)
            {
                Console.WriteLine("Do you want to play with a friend? (Y/N)");
                string opponentChoice = Console.ReadLine().ToLower();
                bool playMode = opponentChoice == "y";

                if (playMode == v_PlayWithFriend)
                {
                    Console.WriteLine("What is your name?");
                    string player1Name = Console.ReadLine();
                    m_player1 = new Player(player1Name, 'X');
                    Console.WriteLine("What is your friend's name?");
                    string player2Name = Console.ReadLine();
                    m_player2 = new Player(player2Name, 'O');
                    isNotValidInput = false;
                }
                else if (playMode != v_PlayWithFriend)
                {
                    m_player1 = new Player("You", 'X');
                    m_player2 = new AIPlayer("AI Player", 'O');
                    isNotValidInput = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter (Y/N):");
                }
            }
            m_currentPlayer = m_player1;
        }

        public void Display()
        {
            for (int col = 0; col < m_board.Columns; col++)
            {
                Console.Write($"  {col + 1} ");
            }
            Console.WriteLine();

            for (int row = 0; row < m_board.Rows; row++)
            {
                for (int col = 0; col < m_board.Columns; col++)
                {
                    Console.Write($"| {m_board[row, col]} ");
                }
                Console.WriteLine("|");
                Console.WriteLine(new string('=', (m_board.Columns - 1) * 5));
            }
            Console.WriteLine("\n");
        }

        public void Start()
        {
            SetupGame();
            while (true)
            {
                Console.WriteLine("The game has started!\n");
                m_point = new Point(m_board);

                StartNewRound(m_board);
                Console.WriteLine("Do you want to play again? (Y/N)");
                string playAgainChoice = Console.ReadLine().ToLower();
                if (playAgainChoice != "y")
                {
                    Console.WriteLine($"Total points:");
                    Console.WriteLine($"{m_player1.Name}: {m_player1.GetPlayerPoints()}");
                    Console.WriteLine($"{m_player2.Name}: {m_player2.GetPlayerPoints()}");
                    Console.WriteLine("Thanks for playing!");
                    break;
                }
            }
        }

        private void StartNewRound(Board board)
        {
            board.ClearBoard();
            bool isGameOn = true;

            while (isGameOn)
            {
                Display();
                m_currentPlayer.MakeMove(m_board);
                if (m_currentPlayer.Name != "AI Player" && m_currentPlayer.GetWantsToPlay() == false)
                {
                    break;
                }
                char token = m_currentPlayer.Token;
                Screen.Clear();

                if (m_point.CheckWinCondition(token))
                {
                    isGameOn = false;
                    EndGame(m_currentPlayer.Name);
                }
                else if (m_board.IsFull())
                {
                    isGameOn = false;
                    EndGame(null);
                }
                else
                {
                    SwitchPlayer();
                }
            }
        }

        private void EndGame(string winnerName)
        {
            Display();
            if (winnerName != null)
            {
                Console.WriteLine($"{winnerName} won!");
                if (winnerName == m_player1.Name)
                {
                    m_player1.IncreasePoints();
                }
                else
                {
                    m_player2.IncreasePoints();
                }
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }

        private void SwitchPlayer()
        {
            m_currentPlayer = m_currentPlayer == m_player1 ? m_player2 : m_player1;
        }
    }
}
