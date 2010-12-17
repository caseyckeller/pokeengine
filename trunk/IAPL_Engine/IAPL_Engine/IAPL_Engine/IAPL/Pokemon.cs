
//Hey guys, this has been depreciated as of 12/17/2010
//So, you might wanna grab some of these variables (if you're using them) and stick 'em somewhere else
//For items, use IAPL.items.[item type].[item name], eg, IAPL.items.heal.potion
//also, see items.cs
//-bigplrbear

/*
* Main Pokemon Library for the IAPL
*
* -Contains-
* Pokemon names, stats, natures, attacks/moves.
* Items and their effects
* Trainer stuff
* Calculations for battles and other misc. stuff
* ----------
*
* Written in C# and .net 4.0 w/ VS2010
* Should work with Visual Basic as well, as long as you include it and call the classes right
*
* By
* bigplrbear
* [insert contributer name here]
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; //for Parallel.For

namespace IAPL.Pokemon_Library
{

    public class Pokemon
    {
        /*
         * Container class, containing other classes
         */

        //Global Variables

        //Pokemon stuff
        string pokemon_name;
        string pokemon_description; //for the pokedex
        public int pokemon_individual_value; //Different Pokemon of the same type have different stats
        public int pokemon_effort_value; //Trained pokemon have higher stats. For every 4 levels, pokemon gains 2 EV
        public int pokemon_level;
        int pokemon_type_1;
        int pokemon_type_2; //Some pokemon have two types
        /*
        * Guide to pokemon and move types
        * 1 = normal
        * 2 = fire
        * 3 = water
        * 4 = electric
        * 5 = Grass
        * 6 = Ice
        * 7 = Fighting
        * 8 = Poison
        * 9 = Ground
        * 10 = Flying
        * 11 = Psychic
        * 12 = Bug
        * 13 = Rock
        * 14 = Ghost
        * 15 = Dragon
        * 16 = Dark
        * 17 = Steel
        */
        int base_attack;
        int base_defense;
        int base_speed;
        int base_sp_defense;
        int base_sp_attack;
        public int base_hp;
        public int hp;
        int attack;
        int defense;
        int speed;
        int sp_defense;
        int sp_attack;
        int pokemon_accuracy; //some pokemon are klutzes
        string pokemon_nature; //pokemons nature. Not sure if we should keep it a string or change it to an int...
        //int pokemon_nature;
        //string pokemon_nature_name;
        string pokemon_nature_description;
        int pokemon_gender; //0 for male, 1 for female, 2 for genderless

        /*
         * Guide to Pokemon Natures
         * 1 - Adamant
         * 2 - Bashful
         * 3 - Bold
         * 4 - Brave
         * 5 - Calm
         * 6 - Careful
         * 7 - Docile
         * 8 - Gentle
         * 9 - Hardy
         * 10 - Hasty
         * 11 - Impish
         * 12 - Jolly
         * 13 - Lax
         * 14 - Lonely
         * 15 - Mild
         * 16 - Modest
         * 17 - Naive
         * 18 - Naughty
         * 19 - Quiet
         * 20 - Quirky
         * 21 - Rash
         * 22 - Relaxed
         * 23 - Sassy
         * 24 - Serious (why so serious?)
         * 25 - Timid
         */

        //Move stuff
        string move_name;
        int move_attack;
        int move_defense;
        int move_sp_attack;
        //int move_sp_attack;            <----------- a double?
        int move_speed; //used for moves such as agility, that up your speed
        int move_accuracy;

        //Item stuff
        string item_name;
        string item_description;
        int item;

        //Pokeballs
        int pokeball_type;
        /*
         * Pokeball type guide
         * 1 - Pokeball
         * 2 - Greatball
         * 3 - Ultraball
         * 4 - Masterball
         * IMO, that's all we should need for a game.
         * Other pokeballs can be implemented later
         */

        //Trainer stuff
        string trainer_name;
        string trainer_nature_name; //yes, trainers have natures, at least in Pokemon B/W
        int trainer_nature;
        int trainer_gender; //0 for male, 1 for female, 2 for flying speghetti monster

    }
}