using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapSim
{
    class RollDice
    {
        public int DiceRoll()
            {
            int die1 = 0;
            int die2 = 0;
            int roll = 0;
            Random die = new Random();

            die1 = die.Next(1, 7);
            die2 = die.Next(1, 7);
            roll = die1 + die2;
            return(roll);
            }
            
    }
}
