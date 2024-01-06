using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Sharp2048
{
    public class Position
    {
        public int Row { get; set; } = -1;
        public int Column { get; set; } = -1;
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
    public class BoardUI : PictureBox
    {
        List<RoundLabel> listRoundLabel = new List<RoundLabel>();
        RoundLabel[,] arrRoundLabel = new RoundLabel[4, 4];
        Dictionary<int, Color> dicForeColor = null;
        Dictionary<int, Color> dicTileColor = null;
        Dictionary<int, Font> dicTileFont = null;
        Dictionary<int, Font> _dicFont = null;
        private Font GetFont(int size)
        {
            if (_dicFont == null)
            {
                _dicFont = new Dictionary<int, Font>();
            }
            if (!_dicFont.ContainsKey(size))
            {
                _dicFont.Add(size, CreateFont(size));
            }
            return _dicFont[size];
        }
        private Font CreateFont(float size)
        {
            return new System.Drawing.Font("Segoe UI", size, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        private RoundLabel CreateRoundLabel(Color _backColor, Label lblcovered)
        {
            RoundLabel newRoundLabel = new RoundLabel()
            {
                _BackColor = _backColor,
                ForeColor = Color.White,
                CorderRadius = 5,
                Text = lblcovered.Text,
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Visible = true,
                AutoSize = false,
                Height = lblcovered.Height,
                Width = lblcovered.Width,
                Top = lblcovered.Top,
                Left = lblcovered.Left,
                Cursor = Cursors.Hand

            };
            return newRoundLabel;
        }
        public Boolean IsUseAnimation { get; set; } = true;
        public Boolean IsFinishedRenderAnimation { get; private set; } = true;

        private void BlockUserInput()
        {
            this.IsUseAnimation = true;
        }
        private void UnBlockUserInput()
        {
            this.IsUseAnimation = false;
        }
        private Position fromPostion = null;
        public BoardUI MoveFrom(int row, int column)
        {
            fromPostion = new Position(row, column);
            return this;
        }
        public void To(int row, int column,Boolean isChange)
        {
            Position toPosition = new Position(row, column);
            MoveTile(fromPostion, toPosition);
            if(isChange)
            {
                ChangeValue(toPosition);
            }
            fromPostion = null;
        }
        public void To(int row, int column)
        {
            Position toPosition = new Position(row, column);
            MoveTile(fromPostion, toPosition);

            fromPostion = null;
        }
        public void ChangeValue(Position toPosition)
        {
            var lblOriginal = arrRoundLabel[toPosition.Row, toPosition.Column];
            var transition = new Transitions.Transition(new Transitions.TransitionType_EaseInEaseOut(120));
            //  var lblOriginal = arrRoundLabel[from.Row, from.Column];
            int originalHeight = lblOriginal.Height;
            int originalWidth = lblOriginal.Width;
            int originalLeft = lblOriginal.Left;
            int originalTop = lblOriginal.Top;

            int newHeight = 140;
            int newWidth = 140;
            int newLeft = originalLeft - (newWidth- originalWidth);
            int newTop = originalTop - (newHeight - originalHeight);

            transition.add(lblOriginal, "_BackColor", Color.FromArgb(237, 224, 200));
            transition.add(lblOriginal, "ForeColor", Color.FromArgb(119, 110, 101));
            transition.add(lblOriginal, "Width", newHeight );
            transition.add(lblOriginal, "Height", newWidth);
            transition.add(lblOriginal, "Top", newTop );
            transition.add(lblOriginal, "Left", newLeft);
            //transition.add(lblOriginal, "Text", lblOriginal.Left - 10);

            transition.TransitionCompletedEvent += (o, e2) =>
            {
                var tran2 = new Transitions.Transition(new Transitions.TransitionType_EaseInEaseOut(1));
                tran2.add(lblOriginal, "Text", "4");
                tran2.run();
                var tran3 = new Transitions.Transition(new Transitions.TransitionType_EaseInEaseOut(90));
                tran3.add(lblOriginal, "_BackColor", dicTileColor [4]);
                tran3.add(lblOriginal, "ForeColor", dicForeColor [4]);
                tran3.add(lblOriginal, "Width", originalWidth);
                tran3.add(lblOriginal, "Height", originalHeight);
                tran3.add(lblOriginal, "Top", originalTop);
                tran3.add(lblOriginal, "Left", originalLeft);
                tran3.run();

                //lblOriginal.Text = "4";
                // arrRoundLabel[toPosition.Row, toPosition.Column].Text = "4";
                /*
                var tempLabel = arrRoundLabel[to.Row, to.Column];
                arrRoundLabel[to.Row, to.Column] = arrRoundLabel[from.Row, from.Column];
                arrRoundLabel[from.Row, from.Column] = tempLabel;
                */
                UnBlockUserInput();
            };
            transition.run();
        }
        public void MoveTile(Position from, Position to)
        {
            int leftDestination = arrRoundLabel[to.Row, to.Column].Left;
            int topDestination = arrRoundLabel[to.Row, to.Column].Top;
            var transition = new Transitions.Transition(new Transitions.TransitionType_EaseInEaseOut(120));
            var lblOriginal = arrRoundLabel[from.Row, from.Column];

            transition.add(lblOriginal, "Left", leftDestination);
            transition.add(lblOriginal, "Top", topDestination);
            transition.TransitionCompletedEvent += (o, e2) =>
            {
                var tempLabel = arrRoundLabel[to.Row, to.Column];
                arrRoundLabel[to.Row, to.Column] = arrRoundLabel[from.Row, from.Column];
                arrRoundLabel[from.Row, from.Column] = tempLabel;
                UnBlockUserInput();
            };
            transition.run();
            /*
            t.run();
            t.TransitionCompletedEvent += (o, e2) => {
                Transitions.Transition.Args a2 = (Transitions.Transition.Args)e2;
                Transitions.Transition t2 = new Transitions.Transition(
                    new Transitions.TransitionType_EaseInEaseOut(75));

                //t2.add(listLabel[3], "Top", listLabel[3].Top);
                //t2.add(listLabel[3], "Text", "4");
                listLabel[3].Visible = false;
                t2.add(listLabel[4], "_BackColor", Color.FromArgb(237, 224, 200));
                t2.add(listLabel[4], "ForeColor", Color.FromArgb(119, 110, 101));
                t2.add(listLabel[4], "Width", 140);
                t2.add(listLabel[4], "Height", 140);
                t2.add(listLabel[4], "Top", listLabel[4].Top - 10);
                t2.add(listLabel[4], "Left", listLabel[4].Left - 10);

            }
            */
        }
        public void Render(Board board)
        {
            int i;
            int j;
            for (i = 0; i < board.RowSize; i++)
            {
                for (j = 0; j < board.ColSize; j++)
                {
                    int titleValue = board.Matrix[i, j];
                    arrRoundLabel[i, j].Font = dicTileFont[titleValue];
                    arrRoundLabel[i, j]._BackColor = dicTileColor[titleValue];
                    arrRoundLabel[i, j].ForeColor = dicForeColor[titleValue];
                    arrRoundLabel[i, j].Text = titleValue.ToString();
                }
            }
          

        }
        public void InitialUI()
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
                {4096,Color.White  }
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
                {4096,Color.Black  }

            };
            dicTileFont = new Dictionary<int, Font>()
            {
                 {0,GetFont (52)},
                {2,GetFont (52) },
                {4,GetFont (52) },
                {8,GetFont (52) },
                {16,GetFont (52) },
                {32,GetFont (52) },
                {64,GetFont (52) },
                {128,GetFont (40) },
                {256,GetFont (40) },
                {512,GetFont (40) },
                {1024,GetFont (36) },
                {2048,GetFont (36) },
                {4096,GetFont (36) }
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
                {4096,Color.Black  }

            };

            Font tileFont = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            int tileWidth = 120;
            int tileHigh = 120;
            int spaceBetweentile = 15;
            Color mainBackColor = Color.FromArgb(187, 173, 160);
            this.Width = tileWidth * 4 + (spaceBetweentile * 5);
            this.Height = tileHigh * 4 + (spaceBetweentile * 5);
            this.BackColor = Color.White ;
            //4 this.Width = pictureBox1.Width + 43;
           // this.Height = this.Height + this.Top + 55;
            RoundLabel RMain = new RoundLabel()
            {
                Top = 0,
                Left = 0,
                Visible = true,
                AutoSize = false,
                Width = this.Width,
                Height = this.Height,
                CorderRadius = 15,
                _BackColor = mainBackColor
            };
            
            this.Controls.Add(RMain);

            int i;
            int j;
            for (i = 0; i <= 3; i++)
            {
                for (j = 0; j <= 3; j++)
                {
                    RoundLabel lblTile = new RoundLabel()
                    {
                        BackColor = mainBackColor,
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
                    lblTile.BringToFront();
                    arrRoundLabel[i, j] = lblTile;

                   this.Controls.Add(lblTile);
                }
            }
            RMain.SendToBack();
            RMain.Update();
        }
    }

    
}
