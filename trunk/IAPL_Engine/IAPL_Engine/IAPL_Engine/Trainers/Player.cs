﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAPL.Trainers
{
    public class Player : Trainer
    {
        //TODO add some way to hold badges
        //TODO add more complex inventory
        //TODO maybe story variables?
        //TODO add boxxed pokemon
        public char player_name; //seriously, has nobody even thought of this yet?
        public int secretID;
        public int secretIDTwo;
        public String pDexType; //for national and regional pokedexes if you wanna use them

        public Player() : base()
        {
            Random random = new Random();
            //TODO replace this random stuff
            secretID = Math.Abs(random.Next());
            secretIDTwo = Math.Abs(random.Next());
            pDexType = "Regional";
        }
    }
}
