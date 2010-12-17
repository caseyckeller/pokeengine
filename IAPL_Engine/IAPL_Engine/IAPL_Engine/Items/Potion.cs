/*
 *This has been depreciated. Please use items.heal.potion instead
 *-bigplrbear
 *dec. 17 2010
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAPL_Engine.Items
{
    class Potion
    {

        public enum Type { Potion, SuperPotion, HyperPotion, MaxPotion, FullRestore }

        private byte pokemon_number;
        private int max_hp;
        private int current_hp;
        private byte pokemon_status;

        public Potion(byte pokemon_number, int max_hp, int current_hp, byte potion_type, byte pokemon_status)
        {

            int restore_hp;

            /*Variables-
                * byte pokemon_number = each pokemon in your party is assigned a number of 1-6. This represents
                * that number.
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

            /*
            while (potion_type == 1) 
            {
                restore_hp == 20;

                if (current_hp == max_hp)
                {
                       
                    return current_hp;
                }
                    
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

                    if (current_hp == max_hp)
                {
                        
                    return current_hp;
                }
                    
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

                    if (current_hp == max_hp)
                {
                        
                    return current_hp;
                }
                    
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

                    if (current_hp == max_hp)
                {
                        
                    return current_hp;
                }
                    
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

                    if (current_hp == max_hp)
                {
                        
                    return current_hp;
                }
                    
                current_hp = current_hp + restore_hp;
                    
                if (current_hp > max_hp) 
                {
                    current_hp == max_hp;
                }

                if (pokemon_status > 0)
                {
                    pokemon_status == 0
                }

                 
                return current_hp;
            }
            */
        }
    }
}
