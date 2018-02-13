using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace C17_Ex05_XMixDrixLogic
{
    public class GameModel
    {
        private const int k_MaxGameBordLength = 10;
        private const int k_MinGameBordLength = 4;
        private GameBord m_GameGameBord;
        private LocationOnBoard m_LastMove;
        private Opponent m_OpponentX, m_OpponentO, m_LastOpponent;
        private StringBuilder m_WinnerAndScroeInfo = new StringBuilder();
        private int m_MovesCounter = 0;
        private string m_ComputerOpponentName = "Computer";
        private Random m_Random = new Random();
        private bool m_IsWin = false;

        public GameModel(int i_NumOfRows, int i_NumOfCols)
        {
            m_OpponentX = new Opponent('X');
            m_OpponentO = new Opponent('O');
            m_GameGameBord = new GameBord(i_NumOfRows, i_NumOfCols);
        }

        public int GameBordLenght
        {
            get { return m_GameGameBord.GameBordLenght; }
        }

        public int GameBordWidth
        {
            get { return m_GameGameBord.GameBordWidth; }
        }

        public Opponent OpponentX
        {
            get { return m_OpponentX; }
        }

        public Opponent OpponentO
        {
            get { return m_OpponentO; }
        }

        public string WinnerMsg
        {
            get { return m_WinnerAndScroeInfo.ToString(); }
        }

        public string ComputerOpponentName
        {
            get { return m_ComputerOpponentName; }
        }

        public bool IsWin
        {
            get { return m_IsWin; }
        }

        public void NewGame(int i_GameBordLength)
        {
            m_WinnerAndScroeInfo = new StringBuilder();
            m_MovesCounter = 0;
            CreateGameBordGame(i_GameBordLength, this.OpponentX , this.OpponentO);
        }

        public void CreateGameBordGame(int i_GameBordLength, Opponent i_X, Opponent i_O)
        {
            this.m_OpponentX = i_X;
            this.m_OpponentO = i_O;
            m_GameGameBord = new GameBord(i_GameBordLength, i_GameBordLength);
        }

        public void UpdateCell(int i_GameBordlenght, int i_GameBordWidth, Opponent io_LastOpponent)
        {
            m_GameGameBord.SetCell(i_GameBordlenght, i_GameBordWidth, io_LastOpponent.Charachter);
            m_LastMove.Row = i_GameBordlenght;
            m_LastMove.Column = i_GameBordWidth;
            m_LastOpponent = io_LastOpponent;
            m_MovesCounter++;
        }

        public bool IsAvailableOnGameBordGame(int i_GameBordlenght, int i_GameBordWidh)
        {
            return !m_GameGameBord.GameBordGameArray[i_GameBordlenght, i_GameBordWidh].IsCellAvailable;
        }

        // $G$ DSN-003 (-3) This method is too long. Should be split into several methods.
        public bool IsGameOver()
        {
            bool isGameOver = m_GameGameBord.IsFullRow(m_LastMove.Row) || m_GameGameBord.IsFullColums(m_LastMove.Column);
            int center = m_GameGameBord.GameBordLenght / 2;

            if (m_LastMove.Column == m_LastMove.Row || m_LastMove.Column + m_LastMove.Row == GameBordLenght - 1)
            {
                if (GameBordLenght % 2 == 1)
                {
                    if (((m_LastMove.Row > center) && (m_LastMove.Column < center)) || ((m_LastMove.Row < center) && (m_LastMove.Column > center)))
                    {
                        isGameOver = isGameOver || m_GameGameBord.IsFullDiagonalRightToLeftDownToTop();
                    }
                    else if (((m_LastMove.Row > center) && (m_LastMove.Column > center)) || ((m_LastMove.Row < center) && (m_LastMove.Column < center)))
                    {
                        isGameOver = isGameOver || m_GameGameBord.IsFullDiagonalRightToLeftTopToDown();
                    }
                    else if ((m_LastMove.Row == center) && (m_LastMove.Column == center))
                    {
                        isGameOver = isGameOver || m_GameGameBord.IsFullDiagonalRightToLeftTopToDown() || m_GameGameBord.IsFullDiagonalRightToLeftDownToTop();
                    }
                }
                else
                {
                    if (((m_LastMove.Row >= center) && (m_LastMove.Column < center)) || ((m_LastMove.Row < center) && (m_LastMove.Column >= center)))
                    {
                        isGameOver = isGameOver || m_GameGameBord.IsFullDiagonalRightToLeftDownToTop();
                    }
                    else if (((m_LastMove.Row >= center) && (m_LastMove.Column >= center)) || ((m_LastMove.Row < center) && (m_LastMove.Column < center)))
                    {
                        isGameOver = isGameOver || m_GameGameBord.IsFullDiagonalRightToLeftTopToDown();
                    }
                }
            }

            if (isGameOver)
            {
                if (m_LastOpponent == m_OpponentX)
                {
                    m_OpponentO.UpdateScore();
                    m_WinnerAndScroeInfo.AppendFormat("The Winner is: {0} {1}", m_OpponentO.Name, Environment.NewLine);
                }
                else
                {
                    m_OpponentX.UpdateScore();
                    m_WinnerAndScroeInfo.AppendFormat("The Winner is: {0} {1}", m_OpponentX.Name, Environment.NewLine);
                }

                m_IsWin = true;
            }
            else
            {
                if (m_MovesCounter == m_GameGameBord.GameBordLenght * m_GameGameBord.GameBordWidth)
                {
                    isGameOver = true;
                    m_WinnerAndScroeInfo.AppendFormat("Tie! {0}", Environment.NewLine);
                    m_IsWin = false;
                }
            }

            return isGameOver;
        }

        public void InitFirstOpponent(string io_OpponentName)
        {
            m_OpponentX.Name = io_OpponentName;
        }

        public void InitSecondOpponent(string io_OpponentName)
        {
            m_OpponentO.Name = io_OpponentName;
        }

        public Point ComputerMove()
        {
            m_Random = new Random();
            int row, column;

            do
            {
                row = (int)m_Random.Next(0, GameBordLenght);
                column = (int)m_Random.Next(0, GameBordWidth);
            }
            while (!IsAvailableOnGameBordGame(row, column));

            UpdateCell(row, column, m_OpponentO);

            return new Point(row, column);
        }
    }
}
