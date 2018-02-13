using System;
using System.Collections.Generic;
using System.Text;

namespace C17_Ex05_XMixDrixLogic
{
    public class Opponent
    {
        private readonly char r_OpponentCharachter;
        private string m_Name;
        private int m_Score;

        public Opponent(char i_Charchter)
        {
            r_OpponentCharachter = i_Charchter;
            m_Score = 0;
            m_Name = "Opponent";
        }

        public char Charachter
        {
            get { return r_OpponentCharachter; }
        }

        public int Score
        {
            get { return m_Score; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public void UpdateScore()
        {
            m_Score++;
        }
    }
}
