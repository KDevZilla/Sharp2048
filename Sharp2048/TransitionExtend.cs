using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transitions;

namespace Sharp2048
{
    public class TransitionExtend:Transitions.Transition
    {
        // public List<TransitionExtend> listChild = new List<TransitionExtend>();
        public TransitionExtend NextChain = null;
        public bool IsRunNextChainAfterFinish { get; set; } = true;
        public enum TransitionTypeEnum
        {
            Acceleration,
            Bounce,
            CriticalDamping,
            Deceleration,
            EaseInEaseOut,
            Linear
        }
        public static  TransitionExtend Create(int milisecond)
        {
            return  TransitionExtend.Create( TransitionTypeEnum.EaseInEaseOut , milisecond);
        }
        public static  TransitionExtend Create(TransitionTypeEnum transitionType, int milisecond)
        {
            ITransitionType ItransitionType = null;
            switch (transitionType)
            {
                case TransitionTypeEnum.Acceleration:
                    ItransitionType = new Transitions.TransitionType_Acceleration(milisecond);
                    break;
                case TransitionTypeEnum.Bounce:
                    ItransitionType = new Transitions.TransitionType_Bounce(milisecond);
                    break;
                case TransitionTypeEnum.CriticalDamping:
                    ItransitionType = new Transitions.TransitionType_CriticalDamping(milisecond);
                    break;
                case TransitionTypeEnum.Deceleration:
                    ItransitionType = new Transitions.TransitionType_Deceleration(milisecond);
                    break;
                case TransitionTypeEnum.EaseInEaseOut:
                    ItransitionType = new Transitions.TransitionType_EaseInEaseOut(milisecond);
                    break;
                case TransitionTypeEnum.Linear:
                    ItransitionType = new Transitions.TransitionType_Linear(milisecond);
                    break;
                
            }
            return new TransitionExtend(ItransitionType);
        }
       
        public TransitionExtend(ITransitionType transitionMethod) : base(transitionMethod)
        {
            if(this.IsRunNextChainAfterFinish)
            {
                this.TransitionCompletedEvent += (o, e2) =>
                {
                    if(this.NextChain == null)
                    {
                        return;
                    }
                    this.NextChain.run();
                };
            }
           // this.TransitionCompletedEvent += TransitionExtend_TransitionCompletedEvent1;
        }
    }
}
