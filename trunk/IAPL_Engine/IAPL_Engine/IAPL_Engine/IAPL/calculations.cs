namespace IAPL.Pokemon_Library
{

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

        public int calculate_pokemon_HP()
        {
            /*
            * Calculate the pokemons HP based
            * off of its base HP and level
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