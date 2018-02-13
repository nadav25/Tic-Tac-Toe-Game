using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using C17_Ex05_XMixDrixLogic;

namespace C17_Ex05_XMixDrixUI
{
    public class GameSettingsForm : Form
    {
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox firstOpponentNameTB;
        private TextBox secondOpponentNameTB;
        private CheckBox isSecondOpponentCB;
        private NumericUpDown nUDRows;
        private NumericUpDown nUDCols;
        private Button startButton;

        private bool m_IsSecondOpponent = false;
        private string m_FirstOpponentName;
        private string m_SecondOpponentName = "Computer";
        private int m_numOfRows;
        private int m_numOfCols;

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public bool IsSecondOpponent
        {
            get { return m_IsSecondOpponent; }
        }

        public int NumOfRows
        {
            get { return m_numOfRows; }
        }

        public int NumOfCols
        {
            get { return m_numOfCols; }
        }

        public string FirstOpponentName
        {
            get { return m_FirstOpponentName; }
        }

        public string SecondOpponentName
        {
            get { return m_SecondOpponentName; }
        }

        private void nUD_ValueChanged(object sender, EventArgs e)
        {
            if (sender == nUDRows)
            {
                nUDCols.Value = nUDRows.Value;
            }
            else
            {
                nUDRows.Value = nUDCols.Value;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (firstOpponentNameTB.Text != string.Empty && secondOpponentNameTB.Text != string.Empty)
            {
                m_FirstOpponentName = firstOpponentNameTB.Text;

                if (isSecondOpponentCB.Checked)
                {
                    m_IsSecondOpponent = true;
                    m_SecondOpponentName = secondOpponentNameTB.Text;
                }

                m_numOfRows = (int)nUDRows.Value;
                m_numOfCols = (int)nUDCols.Value;

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please enter name!");
            }
        }

        private void isSecondOpponentCB_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                secondOpponentNameTB.Enabled = true;
                secondOpponentNameTB.Text = string.Empty;
                m_IsSecondOpponent = true;
            }
            else
            {
                secondOpponentNameTB.Enabled = false;
                secondOpponentNameTB.Text = "[Computer]";
                m_IsSecondOpponent = false;
            }
        }

        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.firstOpponentNameTB = new System.Windows.Forms.TextBox();
            this.secondOpponentNameTB = new System.Windows.Forms.TextBox();
            this.isSecondOpponentCB = new System.Windows.Forms.CheckBox();
            this.nUDRows = new System.Windows.Forms.NumericUpDown();
            this.nUDCols = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.startButton.Location = new System.Drawing.Point(16, 182);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(194, 24);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start Game!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "\'X\' Player:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(13, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Board Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Rows:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Colums:";
            // 
            // firstOpponentNameTB
            // 
            this.firstOpponentNameTB.Location = new System.Drawing.Point(110, 36);
            this.firstOpponentNameTB.Name = "firstOpponentNameTB";
            this.firstOpponentNameTB.Size = new System.Drawing.Size(100, 20);
            this.firstOpponentNameTB.TabIndex = 0;
            // 
            // secondOpponentNameTB
            // 
            this.secondOpponentNameTB.Enabled = false;
            this.secondOpponentNameTB.Location = new System.Drawing.Point(110, 67);
            this.secondOpponentNameTB.Name = "secondOpponentNameTB";
            this.secondOpponentNameTB.Size = new System.Drawing.Size(100, 20);
            this.secondOpponentNameTB.TabIndex = 2;
            this.secondOpponentNameTB.Text = "<Computer>";
            // 
            // isSecondOpponentCB
            // 
            this.isSecondOpponentCB.AutoSize = true;
            this.isSecondOpponentCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.isSecondOpponentCB.Location = new System.Drawing.Point(16, 70);
            this.isSecondOpponentCB.Name = "isSecondOpponentCB";
            this.isSecondOpponentCB.Size = new System.Drawing.Size(73, 17);
            this.isSecondOpponentCB.TabIndex = 1;
            this.isSecondOpponentCB.Text = "\'O\' Player:";
            this.isSecondOpponentCB.UseVisualStyleBackColor = true;
            this.isSecondOpponentCB.CheckedChanged += new System.EventHandler(this.isSecondOpponentCB_CheckedChanged);
            // 
            // nUDRows
            // 
            this.nUDRows.Location = new System.Drawing.Point(64, 139);
            this.nUDRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDRows.Name = "nUDRows";
            this.nUDRows.Size = new System.Drawing.Size(45, 20);
            this.nUDRows.TabIndex = 3;
            this.nUDRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDRows.ValueChanged += new System.EventHandler(this.nUD_ValueChanged);
            // 
            // nUDCols
            // 
            this.nUDCols.Location = new System.Drawing.Point(165, 139);
            this.nUDCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDCols.Name = "nUDCols";
            this.nUDCols.Size = new System.Drawing.Size(45, 20);
            this.nUDCols.TabIndex = 4;
            this.nUDCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDCols.ValueChanged += new System.EventHandler(this.nUD_ValueChanged);
            // 
            // GameSettingsForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::C17_Ex05_XMixDrixUI.Properties.Resources._משחק_איקס_מיקס_דריקס2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(230, 218);
            this.Controls.Add(this.nUDCols);
            this.Controls.Add(this.nUDRows);
            this.Controls.Add(this.isSecondOpponentCB);
            this.Controls.Add(this.secondOpponentNameTB);
            this.Controls.Add(this.firstOpponentNameTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.ShowIcon = false;
            this.Text = "Game Settings Form";
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
