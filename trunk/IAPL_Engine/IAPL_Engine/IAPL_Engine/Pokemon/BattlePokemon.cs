using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAPL.Pokemon;
using IAPL.Moves;

namespace IAPL.Pokemon
{
    /// <summary>
    /// Contains all the information needed for a battle
    /// WARNING: LOTS OF VARIABLES!!!
    /// </summary>
    public class BattlePokemon
    {
        #region class_fields
        public ActivePokemon pokemon;
        public int confusedRemaining; // number of turns left till confusion wears off automatically, -1 for NA
        public bool cursed; // whether the pokemon is cursed (1/4 health removed every turn)
        public bool flinched; // whether the pokemon has flinched
        public bool identified; //evasion will be ignored if true, caused by odor sluth, foresight etc
        public bool canHitGhost; //whether normal and fighting moves can hit a ghost pokemon, irrelevant for other types
        public bool canHitDark; //whether psychic moves can hit a dark pokemon, irrelevant for other types
        public bool infatuated; //whether the pokemon is infatuated, will be unable to attack 50% of the time
        public bool leechSeeded; //whether the pokemon is leech seeded, 1/16 of health drained each turn
        public bool definiteHit; //whether next attack will definitely land, caused by mind reader, lock on etc
        public bool nightmared; //whether the pokemon has nightmare, 1/4 health removed every turn, removed when woken
        public int partialTrapRemaining; // number of turns till partial trap wears off automatically, -1 for NA
        public int perishSongRemaining; // number of turns till perish song kills pokemon, -1 for NA
        public int tauntRemaining; //number of turns till taunt wears off, -1 for NA
        public bool tormented; //whether the pokemon is tormented, may not use same move twice in a row

        private int atk;
        public double atkModifier = 1.0;
        public int attackLevel //how many attack raises or lowers there are, max 6 up or down
        {
            get
            {
                return atk; 
            }
            set
            {
                atk = value;
                if (atk >= 6)
                    atk = 6;
                else if (atk <= -6)
                    atk = -6;
            }
        }
        public int effectiveAtk // how much attack the pokemon has after all modifiers
        {
            get { return Convert.ToInt32(Convert.ToDouble(levelCalc(pokemon.attack, attackLevel)) * atkModifier); }
        }
        private int def;
        public double defModifier = 1.0;
        public int defenseLevel //how many defense raises or lowers there are, max 6 up or down
        {
            get
            {
                return def;
            }
            set
            {
                def = value;
                if (def >= 6)
                    def = 6;
                else if (def <= -6)
                    def = -6;
            }
        }
        public int effectiveDef // how much defense the pokemon has after all modifiers
        {
            get { return Convert.ToInt32(Convert.ToDouble(levelCalc(pokemon.defense, defenseLevel)) * defModifier); }
        }
        private int spAtk;
        public double spAtkModifier = 1.0;
        public int spAtkLevel //how many spAtk raises or lowers there are, max 6 up or down
        {
            get
            {
                return spAtk;
            }
            set
            {
                spAtk = value;
                if (spAtk >= 6)
                    spAtk = 6;
                else if (spAtk <= -6)
                    spAtk = -6;
            }
        }
        public int effectiveSpAtk // how much Special attack the pokemon has after all modifiers
        {
            get { return Convert.ToInt32(Convert.ToDouble(levelCalc(pokemon.SPAtk, spAtkLevel)) * spAtkModifier); }
        }
        private int spDef;
        public double spDefModifier = 1.0;
        public int spDefLevel //how many spDefense raises or lowers there are, max 6 up or down
        {
            get
            {
                return spDef;
            }
            set
            {
                spDef = value;
                if (spDef >= 6)
                    spDef = 6;
                else if (spDef <= -6)
                    spDef = -6;
            }
        }
        public int effectiveSpDef // how much Special defense the pokemon has after all modifiers
        {
            get { return Convert.ToInt32(Convert.ToDouble(levelCalc(pokemon.SPDef, spDefLevel)) * spDefModifier); }
        }
        private int speed;
        public double speedModifier = 1.0;
        public int speedLevel //how many speed raises or lowers there are, max 6 up or down
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
                if (speed >= 6)
                    speed = 6;
                else if (speed <= -6)
                    speed = -6;
            }
        }
        private int evasion;
        public int effectiveSpeed // how much speed the pokemon has after all modifiers
        {
            get { return Convert.ToInt32(Convert.ToDouble(levelCalc(pokemon.Speed, speedLevel)) * speedModifier); }
        }
        public double evasionModifier = 1.0;
        public int evasionLevel //how many evasion raises or lowers there are, max 6 up or down
        {
            get
            {
                return evasion;
            }
            set
            {
                evasion = value;
                if (evasion >= 6)
                    evasion = 6;
                else if (evasion <= -6)
                    evasion = -6;
            }
        }
        private int accuracy;
        public double accuracyModifier = 1.0;
        public int accuracyLevel //how many accuracy raises or lowers there are, max 6 up or down
        {
            get
            {
                return accuracy;
            }
            set
            {
                accuracy = value;
                if (accuracy >= 6)
                    accuracy = 6;
                else if (accuracy <= -6)
                    accuracy = -6;
            }
        }

        public int currentHealth
        {
            get { return pokemon.currentHP; }

            set
            {
                pokemon.currentHP = value;
                if (pokemon.currentHP > pokemon.HP)
                    pokemon.currentHP = pokemon.HP;
            }
 
        } //get or set the current health of the pokemon
        public int maxHealth
        {
            get { return pokemon.HP; }
        } // get the max health of the pokemon
        #endregion

        /// <summary>
        /// Constructor which makes a battle pokemon from an active pokemon
        /// These are default settings
        /// </summary>
        /// <param name="inPoke">Active Pokemon</param>
        public BattlePokemon(ref ActivePokemon inPoke)
        {
            pokemon = inPoke;

            confusedRemaining = -1;
            cursed = false;
            flinched = false;
            identified = false;
            canHitGhost = false;
            canHitDark = false;
            infatuated = false;
            leechSeeded = false;
            definiteHit = false;
            nightmared = false;
            partialTrapRemaining = -1;
            perishSongRemaining = -1;
            tauntRemaining = -1;
            tormented = false;

            attackLevel = 0;
            defenseLevel = 0;
            spAtkLevel = 0;
            spDefLevel = 0;
            speedLevel = 0;
            evasionLevel = 0;
            accuracyLevel = 0;
        }

        public void perish()
        {
            perishSongRemaining = 3;
        }

        /// <summary>
        /// returns a double representing the chance to hit this pokemon
        /// Over 1 means a sure hit, less than one represents a percentage chance to hit
        /// </summary>
        /// <param name="inPoke">pokemon using the move</param>
        /// <param name="inMove">move being used</param>
        /// <returns></returns>
        public double chanceToHit(BattlePokemon inPoke, BaseMove inMove)
        {
            double chance = 0.0;
            double acc = 0.0;
            double eva = 0.0;
            if (accuracyLevel >= 0)
            {
                acc = (Convert.ToDouble(inPoke.accuracyLevel) + 3.0) / 3.0;
                acc *= inPoke.accuracyModifier;
            }
            if (accuracyLevel < 0)
            {
                acc = 3.0 / (3.0 + Convert.ToDouble(inPoke.accuracyLevel));
                acc *= inPoke.accuracyModifier;
            }
            if (evasionLevel >= 0)
            {
                eva = (Convert.ToDouble(evasionLevel) + 3.0) / 3.0;
                eva *= evasionModifier;
            }
            if (evasionLevel < 0)
            {
                eva = 3.0 / (3.0 + Convert.ToDouble(evasionLevel));
                eva *= evasionModifier;
            }

            //if the accuracy is set to -1 it will always hit
            if (inMove.accuracy == -1)
            {
                chance = 1.0;
            }
            else
            {
                chance = (Convert.ToDouble(inMove.accuracy) / 100) * (acc / eva);
            }
            return chance;
        }

        /// <summary>
        /// returns percentage that stat is affected by stat increases and decreases
        /// </summary>
        /// <param name="inStat"></param>
        /// <param name="inLevel"></param>
        /// <returns></returns>
        private int levelCalc(int inStat, int inLevel)
        {
            double temp = 1.0;
            int val = 0;

            if (inLevel >= 0)
            {
                temp = Math.Floor((2.0 + Convert.ToDouble(inLevel)) / 2.0);
                val = Convert.ToInt32(Convert.ToDouble(inStat) * temp);
            }
            else
            {
                temp = Math.Floor(2.0 / (2.0 + Convert.ToDouble(inLevel)));
                val = Convert.ToInt32(Convert.ToDouble(inStat) * temp);
            }

            return val;
        }
    }
}
