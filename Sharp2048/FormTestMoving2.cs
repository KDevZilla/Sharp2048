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
    public partial class FormTestMoving2 : Form
    {
        public FormTestMoving2()
        {
            InitializeComponent();
        }
        Board board = null;
        BoardUI boardUI = null;
        private void FormTestMoving2_Load(object sender, EventArgs e)
        {

            this.BackColor = Color.White;
            boardUI = new BoardUI();
          //  boardUI.BackColor = mainBackColor;
            boardUI.InitialUI();
            this.Controls.Add(boardUI);

            InitialGame();
            boardUI.Render(board);
        }

        private void InitialGame()
        {
            board = new Board();
            board.SetRowTileValue(0, new int[] { 2, 0, 0, 0 });
          //  board.SetRowTileValue(1, new int[] { 16, 8, 4, 2 });
            board.SetRowTileValue(2, new int[] { 2, 0, 0, 0 });
          //  board.SetRowTileValue(3, new int[] { 16, 8, 4, 0 });

            /*
            //For test render
            board.SetRowTileValue(0, new int[] { 2, 4, 8, 16 });
            board.SetRowTileValue(1, new int[] { 16, 8, 4, 2 });
            board.SetRowTileValue(2, new int[] { 2, 4, 8, 16 });
            board.SetRowTileValue(3, new int[] { 16, 8, 4, 0 });

            */
            /*
            board.SetRowTileValue(0, new int[] { 2, 4, 8, 16 });
            board.SetRowTileValue(1, new int[] { 32, 64, 128, 256 });
            board.SetRowTileValue(2, new int[] { 512, 1024, 2048, 2048 });
            */
            /*
            board.SetRowTileValue(0, new int[] { 2048, 2048, 2048, 2048 });
            board.SetRowTileValue(1, new int[] { 2048, 2048, 2048, 2048 });
            board.SetRowTileValue(2, new int[] { 2048, 2048, 2048, 2048 });
            board.SetRowTileValue(3, new int[] { 2048, 2048, 2048, 2048 });
            */
           // board.RandomPopupInitial();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            boardUI.MoveTile(new Position(0, 0), new Position(0, 3));
            boardUI.MoveTile(new Position(2, 0), new Position(2, 3));
            board.SwapTileValueFrom(row: 0, column: 0).To(row: 0, column: 3);
            board.SwapTileValueFrom(row: 2, column: 0).To(row: 2, column: 3);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            boardUI.MoveFrom(row: 2, column: 3).To(row: 0, column: 3,isChange :true);
            board.SwapTileValueFrom(row: 2, column: 3).To(row: 0, column: 3);
           // boardUI.Render(board);

            //boardUI.MoveTile(new Position(2, 3), new Position(0, 3));
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
