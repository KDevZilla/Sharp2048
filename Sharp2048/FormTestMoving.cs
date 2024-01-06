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
    public partial class FormTestMoving : Form
    {
        public FormTestMoving()
        {
            InitializeComponent();
        }
        RoundLabel lblTile = null;
        List<RoundLabel> listLabel = new List<RoundLabel>();
        Color _BackColor = Color.FromArgb(119, 110, 101);
        Color _ForeColor = Color.FromArgb(238, 228, 218);
        Color mainBackColor = Color.FromArgb(187, 173, 160);
        Font tileFont = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        int tileWidth = 120;
        int tileHigh = 120;
        int spaceBetweentile = 15;

        private void FormTestMoving_Load(object sender, EventArgs e)
        {
           int i;
            for (i = 0; i <= 3; i++)
            {
                lblTile = new RoundLabel()
                {
                    BackColor = this.BackColor ,
                    _BackColor = _BackColor,
                    ForeColor = _ForeColor,
                    Text = "2",
                    Height = tileHigh,
                    Width = tileWidth,
                    Top = tileHigh * i + (spaceBetweentile * (i+1)),//tileHigh * i + (spaceBetweentile * (i + 1)),
                    Left = 10,//tileWidth * j + (spaceBetweentile * (j + 1)),
                    AutoSize = false,
                    Font = tileFont,
                    CorderRadius = 8
                };
                listLabel.Add(lblTile);
                this.Controls.Add(lblTile);
            }
            lblTile = new RoundLabel()
            {
                BackColor = this.BackColor,
                _BackColor = _BackColor,
                ForeColor = _ForeColor,
                Text = "2",
                Height = tileHigh,
                Width = tileWidth,
                Top = listLabel [3].Top,//tileHigh * i + (spaceBetweentile * (i + 1)),
                Left = 10 + tileWidth + spaceBetweentile, //tileWidth * j + (spaceBetweentile * (j + 1)),
                AutoSize = false,
                Font = tileFont,
                CorderRadius = 8
            };

            listLabel.Add(lblTile);
            this.Controls.Add(lblTile);
            //this.Controls.Add(lblTile);
        }
        Boolean isInputBlock = false;
        private void button1_Click(object sender, EventArgs e)
        {
            isInputBlock = true;
            Transitions.Transition t = new Transitions.Transition(new Transitions.TransitionType_EaseInEaseOut(70));
            int i;
            for (i = 0; i <= 3; i++)
            {

                t.add(listLabel [i], "Left", 300);
            }
            t.add(listLabel[4], "Left", 300);

            t.run();
            t.TransitionCompletedEvent += (o,e2) => {
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
                t2.add(listLabel[4], "Left", listLabel [4].Left - 10);

                //t2.add(listLabel[4], "Height", 100);
                t2.run();
                t2.TransitionCompletedEvent += (o2, e3) =>
                {
                    isInputBlock = false;
                    listLabel[4].Text = "4";
                    Transitions.Transition t3 = new Transitions.Transition(new Transitions.TransitionType_EaseInEaseOut(75));
                    t3.add(listLabel[4], "Width", 120);
                    t3.add(listLabel[4], "Height", 120);
                    t3.add(listLabel[4], "Top", listLabel[4].Top + 10);
                    t3.add(listLabel[4], "Left", listLabel[4].Left + 10);
                    t3.run();

                };
            };



        }

        private void T_TransitionCompletedEvent(object sender, Transitions.Transition.Args e)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.isInputBlock)
            {
                return;
            }
            this.Text = "Click";
            lblTile = new RoundLabel()
            {
                BackColor = this.BackColor,
                _BackColor = _BackColor,
                ForeColor = _ForeColor,
                Text = "2",
                Height = 30,
                Width = 30,
                Top = 55,//tileHigh * i + (spaceBetweentile * (i + 1)),
                Left = 55, //tileWidth * j + (spaceBetweentile * (j + 1)),
                AutoSize = false,
                Font = tileFont,
                CorderRadius = 8
            };
            var t = new Transitions.Transition(new Transitions.TransitionType_EaseInEaseOut(70));
            t.add(lblTile, "Height", tileHigh);
            t.add(lblTile, "Width", tileHigh);
            t.add(lblTile, "Top", 10);
            t.add(lblTile, "Left", 10);
            t.run();
            this.Controls.Add(lblTile);


        }
    }
}
