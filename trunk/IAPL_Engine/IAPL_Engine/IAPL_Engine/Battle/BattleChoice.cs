using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAPL.Moves;

namespace IAPL.Pokemon
{
    public class BattleChoice
    {
        private bool pRun; //true if player chooses to run
        public bool run { get { return pRun; } }
        
        //TODO add item

        private ActiveMove pMove; //not null if player chooses a move
        public ActiveMove move { get { return pMove; } }

        private int pSwitchTo; // number pokemon to switch to
        public int switchTo
        {
            get { return pSwitchTo; }
        }


        public BattleChoice(String action)
        {
            if (action == "Run")
            {
                pRun = true;
            }
            pMove = null;
            pSwitchTo = -1;
            //TODO null the item
        }

        public BattleChoice(ActiveMove move)
        {
            if (move != null)
            {
                pMove = move; ;
            }
            pRun = false;
            pSwitchTo = -1;
        }

        public BattleChoice(String word, int num)
        {
            if (word.ToLower() == "switch" && num >= 0 && num <= 6)
            {
                pSwitchTo = num;
            }
            pMove = null;
            pRun = false;
        }

        public object getChoice()
        {
            //I hate using multiple returns, but meh
            if (run == true)
            {
                return run;
            }
            else if (move != null)
            {
                return move;
            }
            //else item
            else if (switchTo != -1)
            {
                return switchTo;
            }
            else
            {
                return null;
            }
        }
    }
}
