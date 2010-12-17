﻿/*
 An item library for the IAPL
 
 This library will eventually contain every item in the game, 
 as well as some calculations for HP restoration and such.
 
Copyright (C) 2010  Int'l association of pokemon leagues

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 
Contributers-
 * Brenden Homan (aka, bigplrbear)
 * Darkkal
 * Ency Woz here
 * [insert contributer here]
 
 * If you see something in here that can cause a problem, PLEASE FOR THE LOVE OF GOD DONT JUST BITCH- FIX IT!
 * Also, let me know what it was and how you fixed it!
 * -bigplrbear
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using System.Threading; might be used to do some multithreading tasks later. Commented out because it's unnecessary atm.

namespace IAPL.itemlib
{
    public class Items
    {
        //contains global variables and maybe some other stuff :p

        /*
         * WARNING
         * BEFORE USING ANY METHODS IN THIS LIBRARY, BE SURE TO RUN did_it_work_check FIRST
         * OR ELSE BAD THINGS MAY HAPPEN.
         * FOR BEST RESULTS, MAKE IT THE FIRST THING THAT RUNS.
         */


        //Global variables.
        //bool is better Bear
        bool did_it_work;

        //Global methods.
        bool did_it_work_check (bool did_it_work)
            {
                //check to see if did_it_work is set to false
            
                //if not, change it
                
                //*WORK IN PROGRESS* VOTE NULL

                 if (did_it_work != false)
                 {
                     did_it_work = false;
                         return did_it_work;
                 }

                 else if (did_it_work == false)
                 {
                     return did_it_work;
                 }
                
                return did_it_work;
            }
                
        public class heal
        {
            

            /// <summary>
            /// Class for heal items, such as potions, paralyze heals, etc.
            /// </summary>
            /// <param name="pokemon_number">Each pokemon is assigned a number of 1-6. This represents that number</param>
            /// <param name="max_hp"> Represents the maximum hp of the pokemon</param>
            /// <param name="current_hp">Represents the current hp of the pokemon</param>
            /// <param name="potion_type">Type of potion used. 
            /// 1 = normal potion (20hp)
            /// 2 = super potion (50hp)
            /// 3 = hyper potion (200hp)
            /// 4 = max potion (restores all hp)
            /// 5 = full restore (restores all hp and status ailments)</param>
            /// <param name="pokemon_status">represents status ailments
            /// 0 = okay
            /// 1 = paralyzed
            /// 2 = poisoned
            /// 3 = sleeping
            /// 4 = burned
            /// 5 = frozen
            /// 6 = confused
            /// 7 = cursed
            /// 8 = leech seed
            /// 9 = trapped (caused by whirlwind, etc.)
            /// 10 = taunt
            /// 11 = torment
            /// 12 = can't escape (the *other* trap, caused by mean look)  
            /// 13 = fainted
            /// </param>
            /// 
            ///<param name="did_it_work">Returns 0 or null if it did, 1 if it didn't</param>
            /// <returns>current_hp, pokemon_status</returns>
            
            //EXAMPLE USAGE
            //potion (1, 20, 15, 1, 0, null);
            //1st pokemon, with 20 max hp, 15 current hp, potion type 1, no status ailment.            

            

            void potion(byte pokemon_number, int max_hp, out int current_hp, byte potion_type, byte pokemon_status, out bool did_it_work)
            {

                //Because C# is a bitch, and won't let me return multiple values in a method, I used the 'out' keyword instead of 'return'
                //From what I've read, it SHOULD work in the same way as return. If I'm wrong, let me know and help me fix it as I proceed 
                //to rage.

                int restore_hp;

                while (potion_type == 1)
                {
                    restore_hp = 20;// == is for comparison, = is assignment

                    if (current_hp == max_hp)
                    {
                        did_it_work = true; //it didn't work // == is for comparison, = is assignment
                        return;
                    }

                    current_hp = current_hp + restore_hp;

                    if (current_hp > max_hp)
                    {
                        current_hp = max_hp;// == is for comparison, = is assignment
                        return;
                    }

                    did_it_work = false; //it worked
                    return;
                }

                while (potion_type == 2)
                {
                    restore_hp = 50; // == is for comparison, = is assignment

                    if (current_hp == max_hp)
                    {
                        did_it_work = true; // see? Booleans are so much nicer
                        return;
                        
                    }

                    current_hp = current_hp + restore_hp;

                    if (current_hp > max_hp)
                    {
                        current_hp = max_hp;// == is for comparison, = is assignment
                        return;
                    }

                    did_it_work = false;
                    return;
                    
                }

                while (potion_type == 3)
                {
                    restore_hp == 200;

                    if (current_hp == max_hp)
                    {

                        did_it_work = true;
                        return;
                    }

                    current_hp = current_hp + restore_hp;

                    if (current_hp > max_hp)
                    {
                        current_hp = max_hp;
                        return;
                    }


                    did_it_work = false;
                }

                while (potion_type == 4)
                {
                    restore_hp = max_hp;

                    if (current_hp == max_hp)
                    {

                        did_it_work = true;
                        return;
                    }

                    current_hp = current_hp + restore_hp;

                    if (current_hp > max_hp)
                    {
                        current_hp = max_hp;
                        return;
                    }


                    did_it_work = false;
                    return;
                }

                while (potion_type == 5)
                {

                    restore_hp = max_hp;

                    if (current_hp == max_hp)
                    {

                       did_it_work = true;
                       return;
                    }

                    current_hp = current_hp + restore_hp;

                    if (current_hp > max_hp)
                    {
                        current_hp = max_hp;
                        return;
                    }

                    if (pokemon_status > 0)
                    {
                        pokemon_status = 0;
                        return;
                    }


                   did_it_work = false;
                   return;
                }
            }

            void par_heal (byte pokemon_number, out byte pokemon_status, out byte did_it_work)
            {
                //Paralyze heal

                if (pokemon_status != 1)
                {
                    pokemon_status = pokemon_status;
                       
                    did_it_work = true;
                    return;
                }

                else if (pokemon_status = 1)
                {
                    pokemon_status = 0;
                                               
                    did_it_work = false;
                    return;
                }
            }

            void antidote(byte pokemon_number, out byte pokemon_status, out byte did_it_work)
            {
                //heal poison
                if (pokemon_status != 2)
                {
                    did_it_work = true;
                    return;
                }

                else if (pokemon_status == 2)
                {
                    pokemon_status = 0;
                    did_it_work = false;
                    return;
                }
            }

            void wake(byte pokemon_number, out byte pokemon_status, out byte did_it_work)
            {
                //wake up pokemon
                if (pokemon_status != 3)
                {
                    did_it_work = true;
                    return;
                }

                else if (pokemon_status == 3)
                {
                    pokemon_status = 0;
                    did_it_work = false;
                    return;
                }
            }

            void brn_heal(byte pokemon_number, out byte pokemon_status, out byte did_it_work)
            {
                //burn heal

                if (pokemon_status != 4)
                {
                    did_it_work = true;
                    return;
                }

                else if (pokemon_status == 4)
                {
                    pokemon_status = 0;
                    did_it_work = false;
                    return;
                }
            }

            void frz_heal(byte pokemon_number, out byte pokemon_status, out byte did_it_work)
            {
                //Freeze heal

                if (pokemon_status != 5)
                {
                    did_it_work_ = true;
                    return;
                }

                else if (pokemon_status == 5)
                {
                    pokemon_status = 0;
                    did_it_work = false;
                    return;

                }
            }

            void full_heal (byte pokemon_number, out byte pokemon_status, out bool did_it_work)
            {
                //full heal
                
                //Also, I found a nicer, simpler way to do this with a 'while' loop. I'll change all of the methods to something
                //similar later. 

                while (pokemon_status != 0)
                {
                    pokemon_status = 0;
                    did_it_work = false;
                    return;
                }

                did_it_work = 1;
                return;
            }

            void revive (byte pokemon_number, out byte pokemon_status, int current_hp, out int max_hp, out byte did_it_work)
            {
                //normal revive

                while (pokemon_status = 13 && current_hp <= 0) //Checking for current_hp as well as status may eliminate some potential bugs (or add more. lol)
                {
                    heal_hp = max_hp / 2;
                    pokemon_status = 0;
                    current_hp = heal_hp;
                    did_it_work = false;
                    return;
                }

                did_it_work = 1;
                return;

            }

            void max_revive (byte pokemon_number, out byte pokemon_status, int current_hp, out int max_hp, out byte did_it_work)
            {
                //max revive

                while (pokemon_status = 13 && current_hp <= 0) //<= not =<
                {
                    heal_hp = max_hp;
                    pokemon_status = 0;
                    current_hp = heal_hp;
                    did_it_work = false;
                    return;
                }

                did_it_work = true;
                return;
            }

           }

        //I don't know how held items will work, so bleh
        //Stopped editing here - Ency

        public class hold
        {
            //class for held items

            /// <summary>
            /// doubles prize money
            /// </summary>
            /// <param name="pokemon_number">Represents pokemon number</param>
            /// <param name="prize_money">How much prize money you get</param>
            /// <param name="item_held">if 1, the item is being held. 0 or null means the item is not held.</param>
            /// <param name="sent_to_battle">if 1, the pokemon was sent in to battle. if 0 or null, the pokemon was not</param>
            /// 
                       
            
            int amulet_coin (byte pokemon_number, int prize_money, byte item_held, byte sent_to_battle)
            {
                
                if (item_held == 0) //No coin? NO EXTRA MONEY FOR YOU
                {
                    return prize_money;
                }

                else if (pokemon_number == 1 && item_held == 1) //if the first pokemon in your party is holding the item
                {
                    prize_money == prize_money * 2;         //automagically assume they're the first in battle

                    return prize_money;
                }

                else if (pokemon_number != 1 && sent_to_battle != 1)
                {
                    return prize_money; //no extra money if they're not sent to battle!
                }

                else if (pokemon_number != 1 && sent_to_battle == 1)
                {
                    prize_money == prize_money * 2; //extra money if sent to battle :p
                    return prize_money;
                }
            }



            }
        }


        public class key_items
        {
            //Class for key items, such as the GB player

            string gb_player (string sound_name, byte is_on)
            {
                while (is_on == 1)
                {
                    sound_name = "chiptune_" + sound_name; //append "chiptune" to the front of the song name to play.
                }
            return sound_name;
            }
            //derp


        }

        public class berries
        {
            //class for berries
        }

        public class balls
        {
            //Class for Pokeballs, ultraballs, etc
        }

       
        public class stones
        {
            //LETS ALL GET STONED
        }

        public class apricorns
        {
            //Class for apricorns (maybe should be included in berries?)
        }

             
    }
}