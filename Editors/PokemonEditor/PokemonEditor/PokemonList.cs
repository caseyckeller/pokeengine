using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAPL.Pokemon
{
    /// <summary>
    /// This is a list which holds every pokemon
    /// They can be added and removed etc
    /// </summary>
    [Serializable]
    public class PokemonList
    {
        public SortedList<int, BasePokemon> pokemon;
        public SortedList<string, int> names;

        public int numberOfPokemon
        {
            get { return pokemon.Count; }
        }

        public PokemonList()
        {
            //Keys for pokemon are integers representing the pokedex number
            pokemon = new SortedList<int, BasePokemon>();
            names = new SortedList<string, int>();
        }

        /// <summary>
        /// Adds the specified base pokemon to the pokemon list
        /// NOTE: Will overwrite any pokemon with the same name
        /// </summary>
        /// <param name="newMove">instance of base pokemon</param>
        public void addPokemon(BasePokemon newPokemon)
        {

            try
            {
                pokemon.Add(newPokemon.PDexNo, newPokemon);
                names.Add(newPokemon.Name, newPokemon.PDexNo);
            }
            catch (ArgumentException)
            {
                pokemon.Remove(newPokemon.PDexNo);
                names.Remove(newPokemon.Name);
                pokemon.Add(newPokemon.PDexNo, newPokemon);
                names.Add(newPokemon.Name, newPokemon.PDexNo);
            }
        }

        /// <summary>
        /// returns a BasePokemon object from the list with the given name
        /// </summary>
        /// <param name="moveName">integer of pokedex you wish to find</param>
        /// <returns>BasePokemon OR null if unsuccessful</returns>
        public BasePokemon getPokemon(int pokeNum)
        {
            BasePokemon temp = null;
            if (pokemon.ContainsKey(pokeNum))
            {
                temp = pokemon[pokeNum];
            }
            return temp;
        }

        public BasePokemon getPokemon(String pokeName)
        {
            BasePokemon temp = null;

            try
            {
                temp = pokemon[names[pokeName]];
            }
            catch (KeyNotFoundException)
            {
                temp = null;
            }

            return temp;
        }

        /// <summary>
        /// Removes a pokemon with the specified number
        /// </summary>
        /// <param name="moveName">int of pokedex number</param>
        public void removePokemon(int pokeNum)
        {
            if (pokemon.ContainsKey(pokeNum))
                pokemon.Remove(pokeNum);
        }

        /// <summary>
        /// Removes a pokemon with the specified name
        /// </summary>
        /// <param name="moveName">BasePokemon you wish to remove</param>
        public void removePokemon(String pokeName)
        {
            for(int i = 0; i < numberOfPokemon; i++)
            {
                if(pokemon[i].Name == pokeName)
                {
                    pokemon.Remove(pokemon[i].PDexNo);
                    break;
                }
            }
        }
    }
}
