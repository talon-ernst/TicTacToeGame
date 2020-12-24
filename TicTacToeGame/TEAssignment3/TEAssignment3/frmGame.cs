using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEAssignment3
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent();
        }

        string[,] gameArray = new string[3, 3];
        int whosTurn = 0;
        int arrayX;
        int arrayY;
        int gameNumber = 1;
        
        /// <summary>
        /// Sets some picturebox properties on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGame_Load(object sender, EventArgs e)
        {
            SetGame();
        }

        private void picBox1_Click(object sender, EventArgs e)
        {
            arrayX = 0;
            arrayY = 0;
            picBox1 = changePicure(picBox1);           
        }

        private void picBox2_Click(object sender, EventArgs e)
        {
            arrayX = 0;
            arrayY = 1;
            picBox2 = changePicure(picBox2);       
        }

        private void picBox3_Click(object sender, EventArgs e)
        {
            arrayX = 0;
            arrayY = 2;
            picBox3 = changePicure(picBox3);           
        }

        private void picBox4_Click(object sender, EventArgs e)
        {
            arrayX = 1;
            arrayY = 0;
            picBox4 = changePicure(picBox4);
        }

        private void picBox5_Click(object sender, EventArgs e)
        {
            arrayX = 1;
            arrayY = 1;
            picBox5 = changePicure(picBox5);
        }

        private void picBox6_Click(object sender, EventArgs e)
        {
            arrayX = 1;
            arrayY = 2;
            picBox6 = changePicure(picBox6);
        }

        private void picBox7_Click(object sender, EventArgs e)
        {
            arrayX = 2;
            arrayY = 0;
            picBox7 = changePicure(picBox7);
        }

        private void picBox8_Click(object sender, EventArgs e)
        {
            arrayX = 2;
            arrayY = 1;
            picBox8 = changePicure(picBox8);
        }

        private void picBox9_Click(object sender, EventArgs e)
        {
            arrayX = 2;
            arrayY = 2;
            picBox9 = changePicure(picBox9);
        }

        /// <summary>
        /// This function takes in a picturebox, checks if image is
        /// null and if it is decides wether to put an X or O image there
        /// and fills in array. Also calls for CheckEndGame
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        private PictureBox changePicure(PictureBox picture)
        {           
            if (picture.Image == null)
            {
                if (GameTurn())
                {
                    picture.Image = Properties.Resources.TicTacToeX;
                    gameArray[arrayX, arrayY] = "X";
                }
                else
                {
                    picture.Image = Properties.Resources.TicTacToeO;
                    gameArray[arrayX, arrayY] = "O";
                }
            }
            CheckEndGame();
            return picture;
        }

        /// <summary>
        /// Decides if it is X or Os turn.
        /// </summary>
        /// <returns></returns>
        public bool GameTurn()
        {
            if (whosTurn == 0)
            {
                lblWhosTurn.Text = "Currently O's Turn";
                whosTurn = 1;         
                return true;
            }
            else
            {
                lblWhosTurn.Text = "Currently X's Turn";
                whosTurn = 0;
                return false;
            }          
        }

        /// <summary>
        /// Checks for the end of the game.
        /// </summary>
        private void CheckEndGame()
        {
            int tieCounter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j< 3; j++)
                {
                    if (gameArray[i, 0] == "X" && gameArray[i, 1] == "X" && gameArray[i, 2] == "X" || gameArray[0, j] == "X" && gameArray[1, j] == "X" && gameArray[2, j] == "X")
                    {                      
                        MessageBox.Show("X Wins!");
                        i = 3;
                        rtbWinners.Text += $"X Won Game: {gameNumber}\n";
                        gameNumber++;
                        SetGame();
                        break;
                    }

                    else if (gameArray[i, 0] == "O" && gameArray[i, 1] == "O" && gameArray[i, 2] == "O" || gameArray[0, j] == "O" && gameArray[1, j] == "O" && gameArray[2, j] == "O")
                    {                       
                        MessageBox.Show("O Wins!");
                        rtbWinners.Text += $"O Won Game: {gameNumber}\n";
                        gameNumber++;
                        i = 3;
                        SetGame();
                        break;
                    }                      
                }             
            }
            if (gameArray[0, 0] == "X" && gameArray[1, 1] == "X" && gameArray[2, 2] == "X" || gameArray[0, 2] == "X" && gameArray[1, 1] == "X" && gameArray[2, 0] == "X")
            {
                MessageBox.Show("X Wins!");
                rtbWinners.Text += $"X Won Game: {gameNumber}\n";
                gameNumber++;
                SetGame();
            }
            else if (gameArray[0, 0] == "O" && gameArray[1, 1] == "O" && gameArray[2, 2] == "O" || gameArray[0, 2] == "O" && gameArray[1, 1] == "O" && gameArray[2, 0] == "O")
            {
                MessageBox.Show("O Wins!");
                rtbWinners.Text += $"O Won Game: {gameNumber}\n";
                gameNumber++;
                SetGame();
            }
            foreach(PictureBox picture in pnlGameBoard.Controls)
            {              
                if (picture.Image != null)
                {
                    tieCounter++;
                }
                if (tieCounter == 9)
                {
                    MessageBox.Show("Tie!");
                    rtbWinners.Text += $" Game: {gameNumber}, was a tie!\n";
                    gameNumber++;
                    SetGame();
                }
            }
        }

        /// <summary>
        /// Sets things for he game on form load.
        /// </summary>
        private void SetGame()
        {
            lblWhosTurn.Text = "Currently X's Turn";
            whosTurn = 0;
            foreach (PictureBox picture in pnlGameBoard.Controls)
            {                           
                picture.Image = null;
                picture.BorderStyle = BorderStyle.Fixed3D;
                picture.BackColor = Color.Orange;
            }
            for (int i = 0; i < gameArray.GetLength(0); i++)
            {
                for (int j = 0; j < gameArray.GetLength(1); j++)
                {
                    gameArray[i, j] = "";
                }
            }
        }
    }
}
