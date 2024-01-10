using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp2048
{
    public class Bot
    {
        /*
        public double Expectimax(GameState state, bool isMaximizingPlayer)
        {
            if (state.IsTerminal())
            {
                return state.Evaluate();
            }

            if (isMaximizingPlayer)
            {
                double bestValue = double.MinValue;
                foreach (GameState child in state.GetPossibleMoves())
                {
                    bestValue = Math.Max(bestValue, Expectimax(child, false));
                }
                return bestValue;
            }
            else
            {
                // Chance node
                double expectedValue = 0;
                foreach (GameState child in state.GetPossibleOutcomes())
                {
                    expectedValue += child.Probability * Expectimax(child, true);
                }
                return expectedValue;
            }
        }
        */

    }
}
