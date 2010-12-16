using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAPL.Pokemon;
using IAPL.Trainers;

namespace IAPL.Battle
{
    class PokeBattle
    {
        //TODO this
        public Player player;
        public Trainer opponent;

        public BattlePokemon[] playerPokemon;
        public BattlePokemon[] opponentPokemon;
        public int turnNumber;

        public PokeBattle(ref Player inPlayer, ref Trainer inOpponent)
        {
            turnNumber = 0;
            player = inPlayer;
            playerPokemon = new BattlePokemon[6];
            int i = 0;
            //create battlepokemon for both players
            foreach (ActivePokemon poke in player.currentPokemon)
            {
                playerPokemon[i] = new BattlePokemon(ref player.currentPokemon[i]);
                i++;
            }
            opponent = inOpponent;
            i = 0;
            foreach (ActivePokemon poke in player.currentPokemon)
            {
                playerPokemon[i] = new BattlePokemon(ref player.currentPokemon[i]);
                i++;
            }
            ////
        }

        public void start()
        {
            bool battleOver = false;
            while (battleOver == false)
            {

                battleOver = nextTurn();
            }

            declareVictory();
        }

        public bool nextTurn()
        {
            bool battleOver = false;
            //do scripts that run at the beginning of a turn
            //get move choices for each player
            //do item choices if any
            //switch player chosen pokemon
            //do pokemon actions based on speed and priority (removing status effects, status problems, move choice)
            //do status effect stuff (burn, poison)
            //wear off temporary status effects
            //check whether the battle is over
            //switch fainted etc pokemon
            //do scripts that run at the end of a turn

            return battleOver;
        }

        public void declareVictory()
        {
            //announce who won, and reward with items, badges, money
            //though maybe that should not be done here
        }
        
    }
}
