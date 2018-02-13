using System;
using System.Collections.Generic;
using System.Text;

namespace C17_Ex05_XMixDrixLogic
{
    // $G$ NTT-999 (-2) You could have just used the Point class.
    public struct LocationOnBoard
    {
        private int m_Column;
        private int m_Row;

        public int Row
        {
            get { return m_Row; }
            set { m_Row = value; }
        }

        public int Column
        {
            get { return m_Column; }
            set { m_Column = value; }
        }

        public LocationOnBoard(int i_row, int i_column)
        {
            m_Row = i_row;
            m_Column = i_column;
        }
    }
}
