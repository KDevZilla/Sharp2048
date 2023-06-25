using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;
using static Transitions.Transition;

namespace Sharp2048
{
    class TransitionHelper
    {
        public  void PopLabel(Label plabel, String ptext, Color pforecolor)
        {
            PopLabel(plabel, ptext, pforecolor, 1500);
        }
        public event EventHandler<Args> TransitionCompletedEvent;
        TransitionExtend t = null;
        public  void MoveLabel(Label plabel,int top, int left)
        {
            //  plabel.ForeColor = pforecolor;
            bool isUsingTransition = false;
            if (!isUsingTransition)
            {
                plabel.Top = top;
                plabel.Left  = left;
                return;
            }

            int iTransactionTime = 120;
            var t = new TransitionExtend(new TransitionType_EaseInEaseOut(iTransactionTime));
            t.add(plabel, "Left", left);
            t.add(plabel, "Top", top);
            t.Tag = plabel;     
            t.run();
            t.TransitionCompletedEvent += T_TransitionCompletedEvent;

        }
        public  void PopLabel(Label plabel, String ptext, Color pforecolor, int iTransactionTime)
        {
         //   plabel.ForeColor = pforecolor;
            TransitionExtend t = new TransitionExtend(new TransitionType_EaseInEaseOut(iTransactionTime));

            int OriLeft = plabel.Left;
            int OriTop = plabel.Top;
            int OriHeight = plabel.Height;
            int OriWidth = plabel.Width;
            plabel.Left += 40;
            plabel.Top += 40;
            plabel.Height -= 80;
            plabel.Width -= 80;
            plabel.Text = ptext;
          //  plabel.ForeColor = Color.Black;
            plabel.Tag = OriLeft;
            t.add("plabel", "ForeColor", pforecolor);
            t.add(plabel, "Left", OriLeft);
            t.add(plabel, "Top", OriTop);
            t.add(plabel, "Width", OriWidth);
            t.add(plabel, "Height", OriHeight);
            t.Tag = plabel;

            t.run();
            t.TransitionCompletedEvent += T_TransitionCompletedEvent;


        }

        private  void T_TransitionCompletedEvent(object sender, Transition.Args e)
        {
            TransitionCompletedEvent?.Invoke(this, e);

            /*
            Label lbl = (Label)((TransitionExtend)sender).Tag;
            try
            {
                // AdjustLeftProperty(lbl, (int)lbl.Tag);
                 PopLabel(lbl, lbl.Text, Color.Black );

            }
            catch (Exception ex)
            {
                //Do nothing
            }
            */
        }

        private static void AdjustLeftProperty(Label plabel, int Left)
        {
            if (plabel.InvokeRequired)
            {
                plabel.Invoke(new Action<Label, int>(AdjustLeftProperty), plabel, Left);
            }
            else
            {
                plabel.Left = Left;
            }
        }

        public static void ChangeBackColor(Label plabel, Color ptoColor)
        {
            ChangeBackColor(plabel, ptoColor, 600);
        }
        public static void ChangeBackColor(Label plabel, Color ptoColor, int iTransitionTime)
        {
            TransitionExtend t = new TransitionExtend(new TransitionType_EaseInEaseOut(iTransitionTime));
            t.add(plabel, "BackColor", ptoColor);
            t.run();

        }
        public static void RunTransactionIn(Transition tran, int milisecond)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Tag = tran;
            timer1.Interval = milisecond;
            timer1.Tick += Timer1_Tick;
            timer1.Enabled = true;

        }

        private static void Timer1_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            System.Windows.Forms.Timer timer1 = (System.Windows.Forms.Timer)sender;
            Transition tran = (Transition)timer1.Tag;
            timer1.Enabled = false;
            tran.run();
        }

        public  void ChangeLableApperance(
            Label plabel, 
            Color pbackColor, 
            Color pforeColor, 
            String text,
            int iTransitionTime)
        {
            TransitionExtend t = new TransitionExtend(new TransitionType_EaseInEaseOut(iTransitionTime));
            if (pbackColor != null)
            {
                t.add(plabel, "_BackColor", pbackColor);

            }
            if (pforeColor != null)
            {
                t.add(plabel, "ForeColor", pforeColor);

            }
            if(text != null)
            {
                t.add(plabel, "Text", text);
            }

             t.run();
            t.TransitionCompletedEvent += T_TransitionCompletedEvent;

            // return t;
        }
    }
}

