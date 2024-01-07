using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Sharp2048
{
    public class TransitionHelper
    {
        public class TaskObservor
        {
            private HashSet<int> HashNotFinishObject = new HashSet<int>();
            public event EventHandler TaskStatusUpdate;
            public void RegisterTransition(TransitionExtend transition)
            {
                var currentTransition = transition;
                while (currentTransition != null)
                {
                    HashNotFinishObject.Add(currentTransition.GetHashCode());
                    currentTransition.TransitionCompletedEvent += (o, e2) =>
                    {
                        TransitionExtend fireEventTransition = (TransitionExtend)o;
                        HashNotFinishObject.Remove(fireEventTransition.GetHashCode());
                        TaskStatusUpdate?.Invoke(this, new EventArgs());
                    };

                    currentTransition = currentTransition.NextChain;
                }
            }
            public bool IsAllTaskFinsish => HashNotFinishObject.Count == 0;
        }
        public static void PopToNewValue(RoundLabel label, String newText
            , Color newBackColor, Color newFoneColor, TaskObservor observer)
        {

            var transitionBigSize = TransitionExtend.Create(TransitionExtend.TransitionTypeEnum.EaseInEaseOut, 75);

            //  var lblOriginal = arrRoundLabel[from.Row, from.Column];
            int originalHeight = label.Height;
            int originalWidth = label.Width;
            int originalLeft = label.Left;
            int originalTop = label.Top;

            int newHeight = 140;
            int newWidth = 140;
            int newLeft = originalLeft - ((newWidth - originalWidth) / 2);
            int newTop = originalTop - ((newHeight - originalHeight) / 2);


            transitionBigSize.add(label, "Width", newHeight);
            transitionBigSize.add(label, "Height", newWidth);
            transitionBigSize.add(label, "Top", newTop);
            transitionBigSize.add(label, "Left", newLeft);

            var transitionSetText = TransitionExtend.Create(1);
            observer.RegisterTransition(transitionSetText);

            transitionSetText.add(label, "Text", newText);


            var transitionBacktoOrignalSize = TransitionExtend.Create(TransitionExtend.TransitionTypeEnum.EaseInEaseOut, 90);
            observer.RegisterTransition(transitionBacktoOrignalSize);

            transitionBacktoOrignalSize.add(label, "_BackColor", newBackColor);
            transitionBacktoOrignalSize.add(label, "ForeColor", newFoneColor);
            transitionBacktoOrignalSize.add(label, "Width", originalWidth);
            transitionBacktoOrignalSize.add(label, "Height", originalHeight);
            transitionBacktoOrignalSize.add(label, "Top", originalTop);
            transitionBacktoOrignalSize.add(label, "Left", originalLeft);

            transitionBigSize.NextChain = transitionSetText;
            transitionSetText.NextChain = transitionBacktoOrignalSize;

            
            observer.RegisterTransition(transitionBigSize);
            observer.RegisterTransition(transitionSetText);
            observer.RegisterTransition(transitionBacktoOrignalSize);

            transitionBigSize.run();

            /*
            transitionBigSize.TransitionCompletedEvent += (o, e2) =>
                {
                    //Actually we don't get the benefit from using transitionSetText
                    //but we have to use this method instead of set text directry to
                    //Avoid the problem that this control is belong to UI thread
                    //Program will not allow this control to be set on this TransitionCompletedEvent() directly
                    
                    var transitionSetText = TransitionExtend.Create(1);
                    observer.RegisterTransition(transitionSetText);

                    transitionSetText.add(label, "Text", newText);
                    transitionSetText.run();


                    // transit to original position
                    var transitionBacktoOrignalSize = TransitionExtend.Create(TransitionExtend.TransitionTypeEnum.EaseInEaseOut, 90);
                    observer.RegisterTransition(transitionBacktoOrignalSize);

                    transitionBacktoOrignalSize.add(label, "_BackColor", newBackColor );
                    transitionBacktoOrignalSize.add(label, "ForeColor", newFoneColor );
                    transitionBacktoOrignalSize.add(label, "Width", originalWidth);
                    transitionBacktoOrignalSize.add(label, "Height", originalHeight);
                    transitionBacktoOrignalSize.add(label, "Top", originalTop);
                    transitionBacktoOrignalSize.add(label, "Left", originalLeft);
                    transitionBacktoOrignalSize.run();                 
                };
                */

            //transitionBigSize.run();

        }
    }
}
