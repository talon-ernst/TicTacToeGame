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

        private const string PLAYER_ONE_MOVE = "X";
        private const string PLAYER_TWO_MOVE = "O";

        string[,] gameArray = new string[3, 3];
        int whosTurn = 0;
        int arrayX;
        int arrayY;
        int gameNumber = 1;
        int amountOfGames = 0;
        int xWins = 0;
        int oWins = 0;
        
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
            picBox1 = ChangePicure(picBox1);           
        }

        private void picBox2_Click(object sender, EventArgs e)
        {
            arrayX = 0;
            arrayY = 1;
            picBox2 = ChangePicure(picBox2);       
        }

        private void picBox3_Click(object sender, EventArgs e)
        {
            arrayX = 0;
            arrayY = 2;
            picBox3 = ChangePicure(picBox3);           
        }

        private void picBox4_Click(object sender, EventArgs e)
        {
            arrayX = 1;
            arrayY = 0;
            picBox4 = ChangePicure(picBox4);
        }

        private void picBox5_Click(object sender, EventArgs e)
        {
            arrayX = 1;
            arrayY = 1;
            picBox5 = ChangePicure(picBox5);
        }

        private void picBox6_Click(object sender, EventArgs e)
        {
            arrayX = 1;
            arrayY = 2;
            picBox6 = ChangePicure(picBox6);
        }

        private void picBox7_Click(object sender, EventArgs e)
        {
            arrayX = 2;
            arrayY = 0;
            picBox7 = ChangePicure(picBox7);
        }

        private void picBox8_Click(object sender, EventArgs e)
        {
            arrayX = 2;
            arrayY = 1;
            picBox8 = ChangePicure(picBox8);
        }

        private void picBox9_Click(object sender, EventArgs e)
        {
            arrayX = 2;
            arrayY = 2;
            picBox9 = ChangePicure(picBox9);
        }

        /// <summary>
        /// This function takes in a picturebox, checks if image is
        /// null and if it is decides wether to put an X or O image there
        /// and fills in array. Also calls for CheckEndGame
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        private PictureBox ChangePicure(PictureBox picture)
        {           
            if (picture.Image == null)
            {
                if (WhosTurnIsIt())
                {
                    picture.Image = Properties.Resources.TicTacToeX;
                    gameArray[arrayX, arrayY] = PLAYER_ONE_MOVE;
                }
                else
                {
                    picture.Image = Properties.Resources.TicTacToeO;
                    gameArray[arrayX, arrayY] = PLAYER_TWO_MOVE;
                }
            }
            CheckEndGame();
            IsMatchOver();
            return picture;
        }

        /// <summary>
        /// Decides if it is X or Os turn.
        /// </summary>
        /// <returns></returns>
        public bool WhosTurnIsIt()
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
                    if (gameArray[i, 0] == PLAYER_ONE_MOVE && gameArray[i, 1] == PLAYER_ONE_MOVE && gameArray[i, 2] == PLAYER_ONE_MOVE || gameArray[0, j] == PLAYER_ONE_MOVE && gameArray[1, j] == PLAYER_ONE_MOVE && gameArray[2, j] == PLAYER_ONE_MOVE)
                    {                      
                        MessageBox.Show("X Wins!");
                        i = 3;
                        rtbWinners.Text += $"X Won Game: {gameNumber}\n";
                        xWins += 1;
                        gameNumber++;
                        SetGame();
                        break;
                    }

                    else if (gameArray[i, 0] == "O" && gameArray[i, 1] == PLAYER_TWO_MOVE && gameArray[i, 2] == PLAYER_TWO_MOVE || gameArray[0, j] == PLAYER_TWO_MOVE && gameArray[1, j] == PLAYER_TWO_MOVE && gameArray[2, j] == PLAYER_TWO_MOVE)
                    {                       
                        MessageBox.Show("O Wins!");
                        rtbWinners.Text += $"O Won Game: {gameNumber}\n";
                        oWins += 1;
                        gameNumber++;
                        i = 3;
                        SetGame();
                        break;
                    }                      
                }             
            }
            if (gameArray[0, 0] == PLAYER_ONE_MOVE && gameArray[1, 1] == PLAYER_ONE_MOVE && gameArray[2, 2] == PLAYER_ONE_MOVE || gameArray[0, 2] == PLAYER_ONE_MOVE && gameArray[1, 1] == PLAYER_ONE_MOVE && gameArray[2, 0] == PLAYER_ONE_MOVE)
            {
                MessageBox.Show("X Wins!");
                rtbWinners.Text += $"X Won Game: {gameNumber}\n";
                xWins += 1;
                gameNumber++;
                SetGame();
            }
            else if (gameArray[0, 0] == "O" && gameArray[1, 1] == PLAYER_TWO_MOVE && gameArray[2, 2] == PLAYER_TWO_MOVE || gameArray[0, 2] == PLAYER_TWO_MOVE && gameArray[1, 1] == PLAYER_TWO_MOVE && gameArray[2, 0] == PLAYER_TWO_MOVE)
            {
                MessageBox.Show("O Wins!");
                rtbWinners.Text += $"O Won Game: {gameNumber}\n";
                oWins += 1;
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{txtAmountOfGames.Text.ToString()} matches is needed to win!");
            amountOfGames = Convert.ToInt32(txtAmountOfGames.Text);
        }

        private void IsMatchOver()
        {
            if (amountOfGames != 0)
            {
                if (amountOfGames == xWins)
                {
                    MessageBox.Show("Player X has won the entire match!");
                    SetGame();
                }
                else if (String.Equals(amountOfGames, oWins))
                {
                    MessageBox.Show("Player O has won the entire match!");
                    SetGame();
                }
            }
        }

    }
}
