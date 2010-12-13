/*
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
 * Brenden Homan
 * Darkkal
 * [insert contributer here]
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; //might be used to do some multithreading tasks

namespace IAPL.itemlib
{
    public class Items
    {
        //contains global variables and maybe some other stuff :p

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
            /// </param>
            /// 
            ///<param name="did_it_work">Returns 0 or null if it did, 1 if it didn't</param>
            /// <returns>current_hp, pokemon_status</returns>
            
            void potion(out byte did_it_work, byte pokemon_number, int max_hp, out int current_hp, byte potion_type, byte pokemon_status)
            {

                //Because C# is a bitch, and won't let me return multiple values in a method, I used the 'out' keyword instead of 'return'
                //From what I've read, it SHOULD work in the same way as return. If I'm wrong, let me know and help me fix it as I proceed 
                //to rage.

                int restore_hp;
                               
                while (potion_type == 1)
                {
                    restore_hp == 20;

                    if (current_hp == max_hp)
                    {
                        did_it_work == 1; //it didn't work                       
                    }

                    current_hp = current_hp + restore_hp;

                    if (current_hp > max_hp)
                    {
                        current_hp == max_hp;
                    }

                    did_it_work == 0; //it worked
                }

                while (potion_type == 2)
                {
                    restore_hp == 50;

                    if (current_hp == max_hp)
                    {
                        did_it_work == 1;
                        
                    }

                    current_hp = current_hp + restore_hp;

                    if (current_hp > max_hp)
                    {
                        current_hp == max_hp;
                    }

                    did_it_work == 0;
                    
                }

                while (potion_type == 3)
                {
                    restore_hp == 200;

                    if (current_hp == max_hp)
                    {

                        did_it_work == 1;
                    }

                    current_hp = current_hp + restore_hp;

                    if (current_hp > max_hp)
                    {
                        current_hp == max_hp;
                    }


                    did_it_work == 0;
                }

                while (potion_type == 4)
                {
                    restore_hp == max_hp;

                    if (current_hp == max_hp)
                    {

                        did_it_work == 1;
                    }

                    current_hp = current_hp + restore_hp;

                    if (current_hp > max_hp)
                    {
                        current_hp == max_hp;
                    }


                    did_it_work == 0;
                }

                while (potion_type == 5)
                {

                    restore_hp == max_hp;

                    if (current_hp == max_hp)
                    {

                       did_it_work == 1;
                    }

                    current_hp = current_hp + restore_hp;

                    if (current_hp > max_hp)
                    {
                        current_hp == max_hp;
                    }

                    if (pokemon_status > 0)
                    {
                        pokemon_status == 0;
                    }


                   did_it_work == 0;
                }
            }

            void par_heal (byte pokemon_number, out byte pokemon_status, out byte did_it_work)
            {
                //Paralyze heal

                if (pokemon_status != 1)
                {
                    pokemon_status = pokemon_status;
                       
                    did_it_work == 1;
                }

                else if (pokemon_status = 1)
                {
                    pokemon_status = 0;
                                               
                    did_it_work == 0;
                }
            }

            void poison_heal(byte pokemon_number, out byte pokemon_status, out byte did_it_work)
            {
                //heal poison
                if (pokemon_status != 2)
                {
                    did_it_work == 1;
                }

                else if (pokemon_status == 2)
                {
                    pokemon_status = 0;
                    did_it_work == 0;
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
                    sound_name = "chiptune_%s", sound_name; //append "chiptune" to the front of the song name to play.
                }
            return sound_name;
            }


        }

        public class berries
        {
            //class for berries
        }

        public class balls
        {
            //Class for Pokeballs, ultraballs, etc
        }

        public class hold
        {
            //Class for held items
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
