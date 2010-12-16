using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAPL.Pokemon;

namespace IAPL.Trainers
{
    class Trainer
    {
        public ActivePokemon[] currentPokemon;
        public int money;
        public String name;
        //TODO add inventory
        public bool isMale; //false for female, true for male
        public int trainerID;
        public int numCurrentPokemon
        {
            get
            {
                int count = 0;
                foreach (ActivePokemon a in currentPokemon)
                {
                    if (a != null)
                    {
                        count++;
                    }
                }
                return count;
            }
        } //number of pokemon the trainer currently has

        public Trainer()
        {
            name = "Default Name";
            money = 0;
            isMale = true;
            Random random = new Random(Convert.ToInt32(DateTime.Now.Ticks));
            trainerID = Math.Abs(random.Next());
            currentPokemon = new ActivePokemon[6];
        }

        /// <summary>
        /// adds a pokemon to the player's current pokemon
        /// </summary>
        /// <param name="inPoke">pokemon you want to add</param>
        public void addPokemon(ActivePokemon inPoke)
        {
            if (numCurrentPokemon < 6)
            {
                int i = 0;
                bool done = false;
                while (done == false)
                {
                    if (currentPokemon[i] == null)
                    {
                        done = true;
                        currentPokemon[i] = inPoke;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        /// <summary>
        /// removes a pokemon from the player's current pokemon
        /// </summary>
        /// <param name="poke">pokemon you wish to remove</param>
        public void removePoke(ActivePokemon inPoke)
        {
            if(currentPokemon.Contains(inPoke))
            {
                int i = 0;
                bool done = false;
                while (done == false)
                {
                    if (currentPokemon[i] == inPoke)
                    {
                        done = true;
                        currentPokemon[i] = null;
                    }
                    else
                    {
                        i++;
                    }
                }                
            }
        }


    }
}
