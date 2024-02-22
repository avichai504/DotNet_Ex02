using System;

namespace A24_Ex02_NeomiBashari_207087487_AvichaiGalOr_207051848
{
    internal class AIPlayer : Player
    {
        private Random m_random;
        private int m_points;

        public AIPlayer(string i_name, char i_token) : base(i_name, i_token)
        {
            m_random = new Random();
        }



        public override void MakeMove(Board i_board)
        {
            bool moveMade = false;
            while (!moveMade)
            {
                int column = m_random.Next(i_board.Columns);
                int row = i_board.FindLowestEmptyRow(column);
                if (row != -1)
                {
                    i_board.PlaceToken(row, column, Token);
                    moveMade = true;
                }
            }
        }
    }
}
