using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace C17_Ex05_XMixDrixUI
{
    internal class ButtonOnBoard : Button
    {
        private int m_X;
        private int m_Y;

        internal ButtonOnBoard()
            : base()
        {
        }

        internal ButtonOnBoard(int i_X, int i_Y)
        {
            m_X = i_X;
            m_Y = i_Y;
        }

        public int X
        {
            get { return m_X; }
        }

        public int Y
        {
            get { return m_Y; }
        }
    }
}
