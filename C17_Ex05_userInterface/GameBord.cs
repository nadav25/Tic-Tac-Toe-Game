using System;
using System.Collections.Generic;
using System.Text;

namespace C17_Ex05_XMixDrixLogic
{
    public class GameBord
    {
        private readonly int r_GameBordLength;
        private readonly int r_GameBordWidth;
        private readonly Cell[,] m_GameBordGamePlay;

        public GameBord()
        {
        }

        public GameBord(int i_GameBordLenght, int i_GameBordwidth)
        {
            r_GameBordLength = i_GameBordLenght;
            r_GameBordWidth = i_GameBordwidth;
            m_GameBordGamePlay = new Cell[r_GameBordLength, r_GameBordWidth];
        }

        public int GameBordLenght
        {
            get { return r_GameBordLength; }
        }

        public int GameBordWidth
        {
            get { return r_GameBordWidth; }
        }

        public Cell[,] GameBordGameArray
        {
            get { return m_GameBordGamePlay; }
        }

        public int GameBordGameSize
        {
            get { return r_GameBordLength * r_GameBordWidth; }
        }

        // $G$ CSS-013 (-5) Bad variable name (should be in the form of i_PascalCase).
        public void SetCell(int i_lenght, int i_GameBordWidth, char i_value)
        {
            m_GameBordGamePlay[i_lenght, i_GameBordWidth].CellValue = i_value;
            m_GameBordGamePlay[i_lenght, i_GameBordWidth].IsCellAvailable = true;
        }

        public bool IsFullRow(int i_Row)
        {
            bool isFullRow = true;
            for (int i = 0; i < r_GameBordWidth - 1; i++)
            {
                if (m_GameBordGamePlay[i_Row, i].CellValue != m_GameBordGamePlay[i_Row, i + 1].CellValue)
                {
                    isFullRow = false;
                    break;
                }
            }

            return isFullRow;
        }

        public bool IsFullColums(int i_column)
        {
            bool IsFullColumn = true;

            for (int i = 0; i < r_GameBordLength - 1; i++)
            {
                if (m_GameBordGamePlay[i, i_column].CellValue != m_GameBordGamePlay[i + 1, i_column].CellValue)
                {
                    IsFullColumn = false;
                    break;
                }
            }

            return IsFullColumn;
        }

        public bool IsFullDiagonalRightToLeftTopToDown()
        {
            bool isFullDiagonal = true;

            for (int i = 0; i < r_GameBordLength - 1; i++)
            {
                if (m_GameBordGamePlay[i, i].CellValue != m_GameBordGamePlay[i + 1, i + 1].CellValue)
                {
                    isFullDiagonal = false;
                    break;
                }
            }

            return isFullDiagonal;
        }

        public bool IsFullDiagonalRightToLeftDownToTop()
        {
            bool isFullDiagonal = true;
            int j = 0;

            for (int i = r_GameBordLength - 1; i > 0; i--)
            {
                if (m_GameBordGamePlay[i, j].CellValue != m_GameBordGamePlay[i - 1, j + 1].CellValue)
                {
                    isFullDiagonal = false;
                    break;
                }

                j++;
            }

            return isFullDiagonal;
        }
    }
}