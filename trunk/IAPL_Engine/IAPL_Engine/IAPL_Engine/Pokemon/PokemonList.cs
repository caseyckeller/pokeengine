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
        public SortedList<string, BasePokemon> pokemon;
        public int numberOfPokemon
        {
            get { return pokemon.Count; }
        }

        public PokemonList()
        {
            //Keys for pokemon are always in upper case, this is automatic
            pokemon = new SortedList<string, BasePokemon>();
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
                pokemon.Add(newPokemon.Name.ToUpper(), newPokemon);
            }
            catch (ArgumentException)
            {
                pokemon.Remove(newPokemon.Name.ToUpper());
                pokemon.Add(newPokemon.Name.ToUpper(), newPokemon);
            }
        }

        /// <summary>
        /// returns a BasePokemon object from the list with the given name
        /// </summary>
        /// <param name="moveName">string containing pokemon name you wish to find</param>
        /// <returns>BasePokemon OR null if unsuccessful</returns>
        public BasePokemon getPokemon(String pokemonName)
        {
            BasePokemon temp = null;
            if (pokemon.ContainsKey(pokemonName.ToUpper()))
            {
                temp = pokemon[pokemonName.ToUpper()];
            }
            return temp;
        }

        /// <summary>
        /// Removes a pokemon with the specified name
        /// </summary>
        /// <param name="moveName">string of the pokemon's name</param>
        public void removePokemon(String pokemonName)
        {
            if (pokemon.ContainsKey(pokemonName.ToUpper()))
                pokemon.Remove(pokemonName.ToUpper());
        }

        /// <summary>
        /// Removes a pokemon with the specified name
        /// </summary>
        /// <param name="moveName">BasePokemon you wish to remove</param>
        public void removePokemon(BasePokemon inPokemon)
        {
            if (pokemon.ContainsKey(inPokemon.Name.ToUpper()))
                pokemon.Remove(inPokemon.Name.ToUpper());
        }
    }
}
