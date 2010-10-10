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
 * Brenden Homan
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
        int pokemon_individual_value; //Different Pokemon of the same type have different stats
        int pokemon_effort_value; //Trained pokemon have higher stats. For every 4 levels, pokemon gains 2 EV
        int pokemon_level;
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
        int base_hp;
        int hp;
        int attack;
        int defense;
        int speed;
        int sp_defense;
        int sp_attack;
        int pokemon_accuracy; //some pokemon are klutzes
        string pokemon_nature;
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
        int move_sp_attack;
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



                public class calculations : Pokemon
                 {
                /*
                * Stat_calculations class
                * containing all calculations
                * from battles, stat calculations, etc.
                * 
                * Inherits stuff from the pokemon class
                */

                              
                    public static void calculate_pokemon_attack()
                    {
                        /*calculate the pokemons attack
                        * based on its base attack
                        * and level
                        */
                    
                    }

                    public int calculate_pokemon_HP(int pokemon_individual_value, int base_hp, int pokemon_effort_value, int pokemon_level)
                    {
                        /*
                        * Calculate the pokemons HP based 
                        * off of its base HP and level
                         * 
                         * HOW TO USE-
                         * calculate_pokemon
                        */

                        hp = (((pokemon_individual_value + (2 * base_hp) + (pokemon_effort_value / 4) + 100) * pokemon_level) / 4) + 10;
                        return hp;
                    }

                    public static void calculate_pokemon_defense()
                    {
                        //calcuate the pokemons defense
                    }

                    public static void calcuate_pokemon_sp_attack()
                    {
                        //calcuate the pokemons special attack
                    }

                    public static void calculate_pokemon_sp_defense()
                    {
                     //calculate the pokemons special defense
                    }


                    public static void calculate_move_damage()
                    {
                        /*
                        * Calculate the amount of damage that a 
                        * pokemon move does.
                        * 
                        * If the move doesn't do any damage
                        * calculate how much it raises the defense,
                        * speed, attack, etc. of the pokemon.
                        */
                     }

                    public static void main()
                    {
                        //not even sure if I need a main method or not. lol
                        //basically, it's just a placeholder
                        
                    }
                }


    }
}
