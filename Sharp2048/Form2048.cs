using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharp2048
{
    public partial class Form2048 : Form
    {
        public Form2048()
        {
            InitializeComponent();
        }
        List<RoundLabel> listRoundLabel = new List<RoundLabel>();
        RoundLabel[,] arrRoundLabel = new RoundLabel[4,4];
        Dictionary<int, Color> dicForeColor = null;
        Dictionary<int, Color> dicTileColor = null;
        private void InitialUI()
        {
            panelAbout.Height  = 0;
            panelAbout.Visible = false;
            panelAbout.BringToFront();

            dicForeColor = new Dictionary<int, Color>()
            {
                {0,Color.FromArgb (204,192,179) },
                {2,Color.FromArgb (119,110,101) },
                {4,Color.FromArgb (119,110,101) },
                {8,Color.White  },
                {16,Color.White },
                {32,Color.White },
                {64,Color.White },
                {128,Color.White },
                {256,Color.White },
                {512,Color.White },
                {1024,Color.White },
                {2048,Color.White },

            };
            dicTileColor = new Dictionary<int, Color>()
            {
                {0,Color.FromArgb (204,192,179) },
                {2,Color.FromArgb (238,228,218) },
                {4,Color.FromArgb (237,224,200) },
                {8,Color.FromArgb (242,177,121) },
                {16,Color.FromArgb (245,149,99) },
                {32,Color.FromArgb (246,124,95) },
                {64,Color.FromArgb (246,94,59) },
                {128,Color.FromArgb (237,207,114) },
                {256,Color.FromArgb (237,204,97) },
                {512,Color.FromArgb (237,200,80) },
                {1024,Color.FromArgb (237,197,63) },
                {2048,Color.FromArgb (237,194,46) },

            };

            Font tileFont = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            int tileWidth = 120;
            int tileHigh = 120;
            int spaceBetweentile = 15;
            Color mainBackColor = Color.FromArgb(187, 173, 160);
            pictureBox1.Width = tileWidth * 4 + (spaceBetweentile * 5);
            pictureBox1.Height = tileHigh * 4 + (spaceBetweentile * 5);
            pictureBox1.BackColor = Color.White;
           //4 this.Width = pictureBox1.Width + 43;
            this.Height = pictureBox1.Height + pictureBox1.Top + 55;
            RoundLabel RMain = new RoundLabel()
            {
                Top = 0,
                Left = 0,
                Visible = true,
                AutoSize = false,
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                CorderRadius = 15,
                _BackColor = mainBackColor
            };

            //RMain.Text = "Hello";
            int i;
            int j;
            for (i = 0; i <= 3; i++)
            {
                for (j = 0; j <= 3; j++)
                {
                    RoundLabel lblTile = new RoundLabel()
                    {
                        BackColor = mainBackColor,
                        //BackColor = Color.FromArgb(187, 173, 160),
                        _BackColor = dicTileColor[0],
                        ForeColor = dicForeColor[0],
                        Text = "0",
                        Height = tileHigh,
                        Width = tileWidth,
                        Top = tileHigh * i + (spaceBetweentile * (i + 1)),
                        Left = tileWidth * j + (spaceBetweentile * (j + 1)),
                        AutoSize = false,
                        Font = tileFont,
                        CorderRadius = 8

                    };
                    arrRoundLabel[i, j] = lblTile;
                    //listRoundLabel.Add(lblTile);
                    this.pictureBox1.Controls.Add(lblTile);
                }
            }

            this.pictureBox1.Controls.Add(RMain);
            this.KeyPreview = true;
            this.KeyDown += Form2_KeyDown;
            RoundLabel roundlblNewGame = new RoundLabel()
            {
                _BackColor = Color.FromArgb(143, 122, 102),
                ForeColor = Color.White,
                CorderRadius = 5,
                Text = "New Game",
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Visible = true,
                AutoSize = false,
                Height = lblNewGame.Height ,
                Width = lblNewGame.Width ,
                Top = lblNewGame.Top ,
                Left=lblNewGame.Left ,
                Cursor = Cursors.Hand
               
            };
            RoundLabel roundlblAbout = new RoundLabel()
            {
                _BackColor = Color.FromArgb(143, 122, 102),
                ForeColor = Color.White,
                CorderRadius = 5,
                Text = lblAbout.Text,
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Visible = true,
                AutoSize = false,
                Height = lblAbout.Height ,
                Width = lblAbout.Width ,
                Top =lblAbout.Top ,
                Left =lblAbout.Left ,
                Cursor = Cursors.Hand

            };

            RoundLabel roundlblOKAbout = new RoundLabel()
            {
                _BackColor = Color.FromArgb(143, 122, 102),
                ForeColor = Color.White,
                CorderRadius = 5,
                Text = lblAboutOK.Text,
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Visible = true,
                AutoSize = false,
                Height = lblAboutOK.Height,
                Width = lblAboutOK.Width,
                Top = lblAboutOK.Top,
                Left = lblAboutOK.Left,
                Cursor = Cursors.Hand

            };
            RoundLabel roundlblScoreBack = new RoundLabel()
            {
                _BackColor = Color.FromArgb(187, 173, 160),
                ForeColor = Color.White,
                CorderRadius = 5,
                Text = "",
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Visible = true,
                AutoSize = false,
                Height = lblScoreBack.Height ,
                Width = lblScoreBack.Width ,
                Top =lblScoreBack.Top ,
                Left =lblScoreBack.Left 

            };

            RoundLabel roundlblScoreBestBack = new RoundLabel()
            {
                _BackColor = Color.FromArgb(187, 173, 160),
                ForeColor = Color.White,
                CorderRadius = 5,
                Text = "",
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Visible = true,
                AutoSize = false,
                Height = lblScoreBestBack.Height,
                Width = lblScoreBestBack.Width,
                Top = lblScoreBestBack.Top,
                Left = lblScoreBestBack.Left

            };
            roundlblNewGame.Click += (o, e) =>
            {
                InitialGame();
                Render(board);
            };

            roundlblAbout.Click += (o, e) =>
            {
                panelAbout.Height  = 564;
                panelAbout.Visible = true;
            };

            roundlblOKAbout.Click += (o, e) =>
            {
                panelAbout.Height  = 0;
                panelAbout.Visible = false;
            };

            this.panelAbout.Controls.Add(roundlblOKAbout);
            this.Controls.Add(roundlblAbout);
            this.Controls.Add(roundlblNewGame);
            this.Controls.Add(roundlblScoreBack);

            lblAboutOK.Visible = false;
            lblNewGame.Visible = false;
            lblAbout.Visible = false;
            lblScoreBack.Visible = false;
            lblScore.AutoSize = false;

            lblScore.Width = roundlblScoreBack.Width;
            lblScore.Left  = roundlblScoreBack.Left;
            lblScore.BackColor = roundlblScoreBack._BackColor;

            lblScoreText.Width = roundlblScoreBack.Width;
            lblScoreText.Left = roundlblScoreBack.Left;
            lblScoreText.BackColor = roundlblScoreBack._BackColor;

            lblScoreBest.Width = roundlblScoreBestBack.Width;
            lblScoreBest.Left = roundlblScoreBestBack.Left;
            lblScoreBest.BackColor = roundlblScoreBestBack._BackColor;

            lblScoreBestText.Width = roundlblScoreBestBack.Width;
            lblScoreBestText.Left = roundlblScoreBestBack.Left;
            lblScoreBestText.BackColor = roundlblScoreBestBack._BackColor;



            //lblNewGame.Visible = false;

        }
        Board board = null;
        private void InitialGame()
        {
            board = new Board();
            /*
            board.SetRowTileValue(0, new int[] { 2, 4, 8, 16 });
            board.SetRowTileValue(1, new int[] { 16, 8, 4, 2 });
            board.SetRowTileValue(2, new int[] { 2, 4, 8, 16 });
            board.SetRowTileValue(3, new int[] { 16, 8, 4, 0 });
            // board.Matrix []
            board.RandomPopupNewValue(1);
            */

            board.RandomPopupInitial();
          

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            InitialUI();
            InitialGame();
            Render(board);
            // this.Text = this.pictureBox1.Width.ToString ();
           // this.Text = this.Height.ToString();

          //  this.Text = this.Width.ToString ();

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
           // this.Text = e.KeyCode.ToString();
            Board.Direction direction = Board.Direction.Up;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    direction = Board.Direction.Up;
                    break;
                case Keys.Down:
                    direction = Board.Direction.Down;
                    break;
                case Keys.Left:
                    direction = Board.Direction.Left;
                    break;
                case Keys.Right:
                    direction = Board.Direction.Right;
                    break;
                default:
                    return;
            }
            bool IsThisDirectionValid=  board.Move(direction);
            if(!IsThisDirectionValid)
            {
                if(!board.CanMove())
                {
                    MessageBox.Show("Game over");
                }
                return;
            }
            if(board.Score > Util.BestScore())
            {
                Util.UpdateBestScore(board.Score);
            }
            Render(board);
            if (board.IsGameFinished())
            {
                MessageBox.Show("Congreatulation, you have cleared the game");
            }


            board.RandomPopUpNext ();
            Render(board);
            if (!board.CanMove())
            {
                MessageBox.Show("Game over");
                return;
            }
            //throw new NotImplementedException();
        }

        private void Render(Board board)
        {
            int i;
            int j;
            for (i = 0; i < board.RowSize; i++)
            {
                for (j = 0; j < board.ColSize; j++)
                {
                    int titleValue = board.Matrix[i, j];
                    arrRoundLabel[i, j]._BackColor = dicTileColor[titleValue];
                    arrRoundLabel[i, j].ForeColor = dicForeColor[titleValue];
                    arrRoundLabel[i, j].Text = titleValue.ToString ();
                }
            }
            this.lblScore.Text = board.Score.ToString ();
            this.lblScoreBest.Text = Util.BestScore().ToString ();

        }

        private void linkNewGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InitialGame();
            Render(board);
        }

        private void linkGabriel_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://gabrielecirulli.com/");

        }

        private void linkCode_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = @"https://github.com/kdevzilla/Sharp2048";
            System.Diagnostics.Process.Start(link);


        }

        private void linkOnline_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = @"https://play2048.co";
            System.Diagnostics.Process.Start(link);

        }
    }
}

      
    