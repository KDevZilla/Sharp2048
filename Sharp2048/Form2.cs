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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        List<RoundLabel> listRoundLabel = new List<RoundLabel>();
        RoundLabel[,] arrRoundLabel = new RoundLabel[4,4];
        Dictionary<int, Color> dicForeColor = null;
        Dictionary<int, Color> dicTileColor = null;
        private void InitialUI()
        {
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

            Font tileFont = new System.Drawing.Font("Segoe UI", 56F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            int tileWidth = 160;
            int tileHigh = 160;
            int spaceBetweentile = 20;
            Color mainBackColor = Color.FromArgb(187, 173, 160);
            //  Color t0BackColor = Color.FromArgb(205, 193, 180);
            //  Color t16BackColor = Color.FromArgb(246, 150, 100);
            //  Color t16ForeColor = Color.White;

            pictureBox1.Width = tileWidth * 4 + (spaceBetweentile * 5);
            pictureBox1.Height = tileHigh * 4 + (spaceBetweentile * 5);
            pictureBox1.BackColor = Color.White;

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
        }
        Board board = null;
        private void InitialGame()
        {
            board = new Board();
            board.RandomPopupNewValue(2);

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            InitialUI();
            InitialGame();
            Render(board);

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            this.Text = e.KeyCode.ToString();
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
                return;
            }
            board.RandomPopupNewValue(1);
            Render(board);

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

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Transitions.Transition t = new Transitions.Transition
            // TransitionHelper.PopLabel(listRoundLabel[0], "32", Color.Black);
            TransitionHelper tHelper = new TransitionHelper();
            tHelper.MoveLabel(listRoundLabel[0],
                listRoundLabel[0].Top,
                listRoundLabel[3].Left);
            tHelper.MoveLabel(listRoundLabel[5],
    listRoundLabel[5].Top,
    listRoundLabel[7].Left);
            tHelper.MoveLabel(listRoundLabel[10],
    listRoundLabel[10].Top,
    listRoundLabel[11].Left);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransitionHelper tHelper = new TransitionHelper();
            tHelper.TransitionCompletedEvent += THelper_TransitionCompletedEvent;

            tHelper.MoveLabel(listRoundLabel[5],
listRoundLabel[3].Top,
listRoundLabel[5].Left);


        }

        private void THelper_TransitionCompletedEvent(object sender, Transitions.Transition.Args e)
        {
            //  throw new NotImplementedException();
            listRoundLabel[0].Text = "32";
            listRoundLabel[0].BackColor = Color.White;
            listRoundLabel[0].ForeColor = Color.Black;

            /*
            TransitionHelper tHelper = new TransitionHelper();
            tHelper.TransitionCompletedEvent += THelper_TransitionCompletedEvent;

            tHelper.ChangeLableApperance(listRoundLabel[0],
      Color.White,
      Color.Black,
      listRoundLabel [0].Text ,
      100);
      */
        }

    }
}

      
    