using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp2048
{
    public class MovePosition
    {
        public Position FromPosition { get; private set; } = Position.Empty;
        public Position ToPosition { get; private set; } = Position.Empty;
        public const int NoNewValue = int.MinValue;
        public int NewValue { get; private set; } = NoNewValue ;
        public MovePosition(int fromRow, int fromColumn, int toRow, int toPosition, int newValue)
        {
            ExplicitConstructor(new Position(fromRow, fromColumn), new Position(toRow, toPosition), newValue);
        }

        public MovePosition (Position fromPosition, Position toPosition, int newValue)
        {
            ExplicitConstructor(fromPosition, toPosition, newValue);
        }
        private void ExplicitConstructor(Position fromPosition, Position toPosition, int newValue)
        {
            FromPosition = fromPosition.Clone();
            ToPosition = toPosition.Clone();
            this.NewValue = newValue;
        }
        public int Row { get; private set; } = -1;
        public int Column { get; private set; } = -1;
        

    }
}
