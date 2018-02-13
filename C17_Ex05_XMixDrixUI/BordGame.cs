using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using C17_Ex05_XMixDrixLogic;

namespace C17_Ex05_XMixDrixUI
{
    internal class BoardGame : Form
    {
        private readonly int r_SpaceBetweenButtons = 10;
        private readonly ButtonOnBoard[,] r_ButtonsArray;
        private readonly int r_NumOfRows;
        private readonly int r_NumOfCols;
        private Label firstOpponentScoreLabel;
        private Label secondOpponentScoreLabel;
        // $G$ NTT-999 (-5) This member should have been readonly.
        private GameSettingsForm m_GameSettingsForm;
        private GameModel m_GameModel;
        private Opponent m_CurrentOpponent;
        private bool m_IsAgainstComputer;

        internal BoardGame()
        {
            InitializeComponent();

            m_GameSettingsForm = new GameSettingsForm();
            if (m_GameSettingsForm.ShowDialog() != DialogResult.Cancel)
            {
                r_NumOfRows = (int)m_GameSettingsForm.NumOfRows;
                r_NumOfCols = (int)m_GameSettingsForm.NumOfCols;
                r_ButtonsArray = new ButtonOnBoard[r_NumOfRows, r_NumOfCols];
                start();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void start()
        {
            m_GameModel = new GameModel(r_NumOfRows, r_NumOfCols);
            buildBoard();
            m_CurrentOpponent = m_GameModel.OpponentX;
            m_IsAgainstComputer = !m_GameSettingsForm.IsSecondOpponent;
        }

        private void newGame()
        {
            foreach (ButtonOnBoard currentButton in r_ButtonsArray)
            {
                currentButton.Enabled = true;
                currentButton.Text = string.Empty;
            }

            setScoreLabels();
            m_GameModel.NewGame(r_NumOfCols);
        }

        private void buildBoard()
        {
            int x = r_SpaceBetweenButtons;
            int y = r_SpaceBetweenButtons;
            int width = 80;
            int hight = 80;

            for (int i = 0; i < r_NumOfRows; i++)
            {
                for (int j = 0; j < r_NumOfCols; j++)
                {
                    ButtonOnBoard newButton = new ButtonOnBoard(i, j);
                    r_ButtonsArray[i, j] = newButton;
                    newButton.Size = new Size(width, hight);
                    newButton.Location = new Point(x, y);
                    newButton.Click += new EventHandler(this.boardButton_click);
                    this.Controls.Add(newButton);
                    x += (int)(width + r_SpaceBetweenButtons);
                }

                y += (int)(hight + r_SpaceBetweenButtons);
                x = r_SpaceBetweenButtons;
            }

            this.Size = new Size(this.Size.Width, this.Size.Height + hight);

            m_GameModel.InitFirstOpponent(m_GameSettingsForm.FirstOpponentName);
            m_GameModel.InitSecondOpponent(m_GameSettingsForm.SecondOpponentName);
            m_CurrentOpponent = m_GameModel.OpponentX;
            setScoreLabels();
        }

        private void setScoreLabels()
        {
            firstOpponentScoreLabel.Text = string.Format("X-{0} : {1}", m_GameModel.OpponentX.Name, m_GameModel.OpponentX.Score);
            secondOpponentScoreLabel.Text = string.Format("O-{0} : {1}", m_GameModel.OpponentO.Name, m_GameModel.OpponentO.Score);
        }

        private void boardButton_click(object sender, EventArgs e)
        {
            ButtonOnBoard currentButton = sender as ButtonOnBoard;
            currentButton.Text = m_CurrentOpponent.Charachter.ToString();
            currentButton.Enabled = false;
            m_GameModel.UpdateCell(currentButton.X, currentButton.Y, m_CurrentOpponent);

            if (!isGameOverOrNewTurn())
            {
                if (m_IsAgainstComputer)
                {
                    computerMove();
                }
            }
        }

        private bool isGameOverOrNewTurn()
        {
            bool isGameOver;

            if (isGameOver = m_GameModel.IsGameOver())
            {
                string winOrTie;

                if (m_GameModel.IsWin)
                {
                    winOrTie = "A Win!";
                }
                else
                {
                    winOrTie = "A Tie!";
                }

                DialogResult isAnotherGame = MessageBox.Show(string.Format("{0}Would you like to play another round?", m_GameModel.WinnerMsg), winOrTie, MessageBoxButtons.YesNo);
                if (isAnotherGame == DialogResult.Yes)
                {
                    m_CurrentOpponent = m_GameModel.OpponentX;
                    newGame();
                }
                else
                {
                    DialogResult isNewGameBord = MessageBox.Show(string.Format("Do you want to play a New Game with other players or a different board size?"), "New Game or Exit", MessageBoxButtons.YesNo);
                    if (isNewGameBord == DialogResult.Yes)
                    {
                        this.Dispose();
                        BoardGame newBoardGame = new BoardGame();
                        newBoardGame.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Thank you for playing X Mix Drix!");
                        Application.Exit();
                    }
                }
            }
            else
            {
                updateTurn();
            }

            return isGameOver;
        }

        private void updateTurn()
        {
            if (m_CurrentOpponent == m_GameModel.OpponentX)
            {
                m_CurrentOpponent = m_GameModel.OpponentO;
            }
            else
            {
                m_CurrentOpponent = m_GameModel.OpponentX;
            }
        }

        private void computerMove()
        {
            Point cellLocation = m_GameModel.ComputerMove();
            ButtonOnBoard buttonToUpdate = r_ButtonsArray[cellLocation.X, cellLocation.Y];
            buttonToUpdate.Enabled = false;
            buttonToUpdate.Text = m_CurrentOpponent.Charachter.ToString();
            isGameOverOrNewTurn();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoardGame));
            this.firstOpponentScoreLabel = new System.Windows.Forms.Label();
            this.secondOpponentScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstOpponentScoreLabel
            // 
            resources.ApplyResources(this.firstOpponentScoreLabel, "firstOpponentScoreLabel");
            this.firstOpponentScoreLabel.BackColor = System.Drawing.SystemColors.Control;
            this.firstOpponentScoreLabel.Name = "firstOpponentScoreLabel";
            // 
            // secondOpponentScoreLabel
            // 
            resources.ApplyResources(this.secondOpponentScoreLabel, "secondOpponentScoreLabel");
            this.secondOpponentScoreLabel.Name = "secondOpponentScoreLabel";
            // 
            // BoardGame
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::C17_Ex05_XMixDrixUI.Properties.Resources.GT61051;
            this.Controls.Add(this.secondOpponentScoreLabel);
            this.Controls.Add(this.firstOpponentScoreLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BoardGame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.BoardGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BoardGame_Load(object sender, EventArgs e)
        {

        }
    }
}
