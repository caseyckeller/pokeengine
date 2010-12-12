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
 * [insert contributer here]
 
 */

/*EXPLANATION OF CONFUSING VARIABLES THAT MAY BE CONFUSING
 * byte pokemon_status = status of pokemon
 * 0 = okay
 * 1 = paralyzed
 * 2 = poisoned
 * 3 = sleeping
 * 4 = burned
 * 5 = frozen
 * 6 = confused
 * 7 = cursed
 * 8 = leech seed
 * 9 = trapped (ITS A TRAP)
 * 10 = taunt
 * 11 = torment
 * 12 = can't escape (the *other* trap, caused by mean look)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAPL.itemlib
{
    public class Items
    {
        //contains global variables and maybe some other stuff :p

        public class heal
        {
            //Class for healing items, such as potions

            int potion (int restore_hp, int max_hp, int current_hp, byte potion_type, byte pokemon_status)
            {
                /*Variables-
                 * int restore_hp = amount of hp to be restored
                 * int max_hp = represents the pokemons maximum hp
                 * int current_hp = represents the pokemons current hp
                 * byte potion_type = type of potion used (explanation below)
                 * byte pokemon_status = whether or not the pokemon is posioned, par, etc. if = 0, then the
                 * pokemon is okay
                 */

               /* Potion types
                * 1- potion
                * 2- super potion
                * 3- hyper potion
                * 4- max potion
                * 5- full restore
                */

                while (potion_type == 1) 
                {
                    restore_hp == 20;
                    
                    current_hp = current_hp + restore_hp;
                    
                    if (current_hp > max_hp) 
                    {
                        current_hp == max_hp;
                    }

                    return current_hp;
                }

                while (potion_type == 2) 
                {
                    restore_hp == 50;
                    
                    current_hp = current_hp + restore_hp;
                    
                    if (current_hp > max_hp) 
                    {
                        current_hp == max_hp;
                    }

                    return current_hp;
                }

                while (potion_type == 3) 
                {
                    restore_hp == 200;
                    
                    current_hp = current_hp + restore_hp;
                    
                    if (current_hp > max_hp) 
                    {
                        current_hp == max_hp;
                    }

                    return current_hp;
                }

                while (potion_type == 4) 
                {
                    restore_hp == max_hp;
                    
                    current_hp = current_hp + restore_hp;
                    
                    if (current_hp > max_hp) 
                    {
                        current_hp == max_hp;
                    }

                    return current_hp;
                }

                while (potion_type == 5) 
                {
                    restore_hp == max_hp;
                    
                    current_hp = current_hp + restore_hp;
                    
                    if (current_hp > max_hp) 
                    {
                        current_hp == max_hp;
                    }

                    if (pokemon_status > 0)
                    {
                        pokemon_status == 0
                    }

                    return current_hp, pokemon_status;
                }

                int par_heal (byte pokemon_status)
                {
                    //Paralyze heal

                    if pokemon_status != 1
                    {
                        pokemon_status = pokemon_status;
                        return pokemon_status;
                    }

                    else if (pokemon_status = 1)
                    {
                        pokemon_status == 0);

                        return pokemon_status;
                    }
                }

        }

        public class key_items
        {
            //Class for key items, such as the GB player
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


        public class calculations
        {
            //Calculations for hp restoration, etc.
        }


    }
}
