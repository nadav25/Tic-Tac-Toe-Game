using System;
using System.Collections.Generic;
using System.Text;

namespace C17_Ex05_XMixDrixLogic
{
    public struct Cell
    {
        private char m_CellValue;
        private bool m_IsCellAvailable;

        public char CellValue
        {
            get { return m_CellValue; }
            set { m_CellValue = value; }
        }

        public bool IsCellAvailable
        {
            get { return m_IsCellAvailable; }
            set { m_IsCellAvailable = value; }
        }
    }
}
