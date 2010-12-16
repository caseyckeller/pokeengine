using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAPL.Pokemon;
using IAPL.Moves;
using IAPL.Moves.TypeStrengths;

namespace IAPL.Pokemon
{
    /// <summary>
    /// Major Status effects that last even outside battle. May only have one at a time.
    /// </summary>
    public enum MajorStatus { None, Poisoned, BadPoisoned, Paralyzed, Sleep, Burned, Frozen };
    public enum NatureType { Adamant, Bashful, Bold, Brave, Calm, Careful, Docile, Gentle, Hardy, Hasty, Impish, Jolly, Lax, Lonely, Mild, Modest, Naive, Naughty, Quiet, Quirky, Rash, Relaxed, Sassy, Serious, Timid };

    /// <summary>
    /// Is an active pokemon, held by a trainer or player. This information will probably be stored in a database when not actually active
    /// </summary>
    [Serializable]
    public class ActivePokemon
    {
        public int IVHP;
        public int IVAttack;
        public int IVDefense;
        public int IVSPAtk;
        public int IVSPDef;
        public int IVSpeed;

        public int EVHP;
        public int EVAttack;
        public int EVDefense;
        public int EVSPAtk;
        public int EVSPDef;
        public int EVSpeed;

        public int currentHP;
        public MajorStatus status;
        public String ability;

        //current stats are calculated from base stats, IVs, and EVs, can not be set
        public int attack
        {
            get { return calcStat(IVAttack, BasePoke.baseAttack, EVAttack, level, nature, "Attack"); }
        }
        public int defense
        {
            get { return calcStat(IVDefense, BasePoke.baseDefense, EVDefense, level, nature, "Defense"); }
        }
        public int SPAtk
        {
            get { return calcStat(IVSPAtk, BasePoke.baseSPAttack, EVSPAtk, level, nature, "SPAtk"); }
        }
        public int SPDef
        {
            get { return calcStat(IVSPDef, BasePoke.baseSPDefense, EVSPDef, level, nature, "SPDef"); }
        }
        public int Speed
        {
            get { return calcStat(IVSpeed, BasePoke.baseSpeed, EVSpeed, level, nature, "Speed"); }
        }
        public int HP
        {
            get { return calcStat(IVHP, BasePoke.baseHP, EVHP, level, nature, "HP"); }
        }
        public int nextLevelAt
        {
            get { return nextLevelExp(); }
        }
        public int toNextLevel
        {
            get { return nextLevelAt - currentExp; }
        }
        public bool isFainted
        {
            get { return (currentHP <= 0); }
        }

        public BasePokemon BasePoke;

        public bool isNamed;
        public String nickname;
        public int level;
        public NatureType nature;

        public int currentExp;

        public String hiddenPowerType
        {
            get { return calcHiddenPowerType(); }
        }

        public int hiddenPowerPower
        {
            get { return calcHiddenPowerPower(); }
        }

        public bool isShiny;

        //TODO find a way to randomly set these depending on level and basepokemon when creating a random instance
        public ActiveMove[] move;

        //TODO add a held item field

        /// <summary>
        /// Makes a new active pokemon from a base pokemon
        /// Ideally IVs and nature will be randomized.
        /// </summary>
        /// <param name="inBase">a reference to a base pokemon</param>
        public ActivePokemon( ref BasePokemon inBase )
        {
            //TODO these need to be randomized
            Random random = new Random();
            IVHP = random.Next(0,31);
            IVAttack = random.Next(0, 31);
            IVDefense = random.Next(0, 31);
            IVSPAtk = random.Next(0, 31);
            IVSPDef = random.Next(0, 31);
            IVSpeed = random.Next(0, 31);
            nature = (NatureType)random.Next(0, 24);

            EVHP = 0;
            EVAttack = 0;
            EVDefense = 0;
            EVSPAtk = 0;
            EVSPDef = 0;
            EVSpeed = 0;

            status = MajorStatus.None;
            BasePoke = inBase;

            isNamed = false;
            nickname = "";
            level = 1;

            currentHP = HP;

            move = new ActiveMove[4];
            move[0] = null;
            move[1] = null;
            move[2] = null;
            move[3] = null;
        }

        /// <summary>
        /// Adds exp to this pokemon, and handles level ups
        /// </summary>
        /// <param name="val">the number of experience points to add to this pokemon</param>
        public void addExp(int val)
        {
            currentExp += val;
            while (currentExp >= nextLevelAt)
            {
                level++;
                levelUp();
            }
        }

        /// <summary>
        /// adds evs to a particular stat
        /// </summary>
        /// <param name="stat">String representing the stat "Attack", "Defense", "SPAtk" etc...</param>
        /// <param name="val">number of EV points to add (or subtract I guess;</param>
        public void addEV(String stat, int val)
        {
            if ( 510 - EVHP - EVAttack - EVDefense - EVSPAtk - EVSPDef - EVSpeed > 0 )
            {
                switch (stat)
                {
                    case "HP":
                        EVHP += val;
                        if (EVHP >= 255) EVHP = 255;
                        break;
                    case "Attack":
                        EVAttack += val;
                        if (EVAttack >= 255) EVAttack = 255;
                        break;
                    case "Defense":
                        EVDefense += val;
                        if (EVDefense >= 255) EVDefense = 255;
                        break;
                    case "SPAtk":
                        EVSPAtk += val;
                        if (EVSPAtk >= 255) EVSPAtk = 255;
                        break;
                    case "SPDef":
                        EVSPDef += val;
                        if (EVSPDef >= 255) EVSPDef = 255;
                        break;
                    case "Speed":
                        EVSpeed += val;
                        if (EVSpeed >= 255) EVSpeed = 255;
                        break;
                    default:
                        //shouldn't really get here, but whatever
                        break;
                }
            }
        }

        /// <summary>
        /// Removes status effect, sets to none
        /// </summary>
        public void cureStatus()
        {
            status = MajorStatus.None;
        }

        /// <summary>
        /// Displays a nice level up message
        /// </summary>
        public void levelUp()
        {
            //TOTO display some nice level up message
        }

        /// <summary>
        /// Nicknames the pokemon, or removes the nickname if string is null or ""
        /// </summary>
        /// <param name="inName">string containing the new name</param>
        public void setNickname(String inName)
        {
            if (inName == null)
            {
                isNamed = false;
                nickname = "";
            }
            else if (inName == "")
            {
                isNamed = false;
                nickname = "";
            }
            else
            {
                nickname = inName;
            }
        }

        /// <summary>
        /// Calculates the current stat of a pokemon taking IVs EVs and Nature into account.
        /// Returns -1 if it fails
        /// </summary>
        /// <param name="IV">IV of the stat</param>
        /// <param name="baseStatm">Base value of the stat</param>
        /// <param name="EV">EV of the stat</param>
        /// <param name="level">Level of the pokemon</param>
        /// <param name="nature">Nature of the pokemon</param>
        /// <param name="stat">Type of stat you are calculating, as a string</param>
        /// <returns>Returns the current value of the stat as an integer</returns>
        private int calcStat(int IV, int baseStat, int EV, int level, NatureType nature, String stat)
        {

            //Don't look at this code for too long, it might make you go blind.
            //Just trust me that it works.
            int ret = -1;

            double temp;
            double dIV = Convert.ToDouble(IV);
            double dBase = Convert.ToDouble(baseStat);
            double dEV = Convert.ToDouble(EV);
            double dLevel = Convert.ToDouble(level);

            if (stat == "HP")
            {
                ret = Convert.ToInt32(Math.Floor((((dIV + (2 * dBase) + (dEV / 4) + 100) * dLevel) / 100) +10));
            }
            else if (stat == "Attack")
            {
                temp  = (((dIV + (2 * dBase) + (dEV / 4)) * dLevel) / 100) + 5;
                if (nature == NatureType.Lonely || nature == NatureType.Adamant || nature == NatureType.Naughty || nature == NatureType.Brave)
                {
                    temp = temp * 1.1;
                }
                else if (nature == NatureType.Bold || nature == NatureType.Modest || nature == NatureType.Calm || nature == NatureType.Timid)
                {
                    temp = temp * 0.9;
                }
                ret = Convert.ToInt32(Math.Floor(temp));
            }
            else if (stat == "Defense")
            {
                temp  = (((dIV + (2 * dBase) + (dEV / 4)) * dLevel) / 100) + 5;
                if (nature == NatureType.Bold || nature == NatureType.Impish || nature == NatureType.Lax || nature == NatureType.Relaxed)
                {
                    temp = temp * 1.1;
                }
                else if (nature == NatureType.Lonely || nature == NatureType.Mild || nature == NatureType.Gentle || nature == NatureType.Hasty)
                {
                    temp = temp * 0.9;
                }
                ret = Convert.ToInt32(Math.Floor(temp));
            }
            else if (stat == "SPAtk")
            {
                temp = (((dIV + (2 * dBase) + (dEV / 4)) * dLevel) / 100) + 5;
                if (nature == NatureType.Modest || nature == NatureType.Mild || nature == NatureType.Rash || nature == NatureType.Quiet)
                {
                    temp = temp * 1.1;
                }
                else if (nature == NatureType.Adamant || nature == NatureType.Impish || nature == NatureType.Careful || nature == NatureType.Jolly)
                {
                    temp = temp * 0.9;
                }
                ret = Convert.ToInt32(Math.Floor(temp));
            }
            else if (stat == "SPDef")
            {
                temp = (((dIV + (2 * dBase) + (dEV / 4)) * dLevel) / 100) + 5;
                if (nature == NatureType.Calm || nature == NatureType.Gentle || nature == NatureType.Careful || nature == NatureType.Sassy)
                {
                    temp = temp * 1.1;
                }
                else if (nature == NatureType.Naughty || nature == NatureType.Lax || nature == NatureType.Rash || nature == NatureType.Naive)
                {
                    temp = temp * 0.9;
                }
                ret = Convert.ToInt32(Math.Floor(temp));
            }
            else if (stat == "Speed")
            {
                temp = (((dIV + (2 * dBase) + (dEV / 4)) * dLevel) / 100) + 5;
                if (nature == NatureType.Timid || nature == NatureType.Hasty || nature == NatureType.Jolly || nature == NatureType.Naive)
                {
                    temp = temp * 1.1;
                }
                else if (nature == NatureType.Brave || nature == NatureType.Relaxed || nature == NatureType.Quiet || nature == NatureType.Sassy)
                {
                    temp = temp * 0.9;
                }
                ret = Convert.ToInt32(Math.Floor(temp));
            }

            return ret;
        }

        /// <summary>
        /// Calculates the total experience to get to the next level
        /// </summary>
        /// <returns>total experience to next level</returns>
        private int nextLevelExp()
        {
            int ret = -1;
            double temp = -1;

            if (BasePoke.EXP == EXPType.Erratic)
            {
                if ((Convert.ToDouble(level + 1)) < 50)
                {
                    temp = (Math.Pow((Convert.ToDouble(level + 1)), 3.0) * (100.0 - (Convert.ToDouble(level + 1)))) / 50.0;
                }
                else if ((Convert.ToDouble(level + 1)) >= 50 && (Convert.ToDouble(level + 1)) < 68)
                {
                    temp = (Math.Pow((Convert.ToDouble(level + 1)), 3.0) * (150.0 - (Convert.ToDouble(level + 1)))) / 100.0;
                }
                else if ((Convert.ToDouble(level + 1)) >= 68 && (Convert.ToDouble(level + 1)) < 98)
                {
                    temp = (Math.Pow((Convert.ToDouble(level + 1)), 3.0) * ((1911.0 - (10 * (Convert.ToDouble(level + 1)))) / 3.0)) / 100.0;
                }
                //TODO find if max (Convert.ToDouble(level + 1)) is 100 or not
                else if ((Convert.ToDouble(level + 1)) >= 98)
                {
                    temp = (Math.Pow((Convert.ToDouble(level + 1)), 3.0) * (160.0 - (Convert.ToDouble(level + 1)))) / 100.0;
                }
            }
            else if (BasePoke.EXP == EXPType.Fast)
            {
                temp = 4.0 * Math.Pow((Convert.ToDouble(level + 1)), 3);
            }
            else if (BasePoke.EXP == EXPType.MedFast)
            {
                temp = Math.Pow((Convert.ToDouble(level + 1)), 3);
            }
            else if (BasePoke.EXP == EXPType.MedSlow)
            {
                temp = (1.2 * Math.Pow((Convert.ToDouble(level + 1)), 3.0)) - (15.0 * Math.Pow((Convert.ToDouble(level + 1)), 2.0)) + (100.0 * (Convert.ToDouble(level + 1))) - 140.0;
            }
            else if (BasePoke.EXP == EXPType.Slow)
            {
                temp = (5.0 * Math.Pow((Convert.ToDouble(level + 1)), 3.0)) / 4.0;
            }
            else if (BasePoke.EXP == EXPType.Fluctuating)
            {
                if ((Convert.ToDouble(level + 1)) < 15)
                {
                    temp = Math.Pow((Convert.ToDouble(level + 1)), 3.0) * (((((Convert.ToDouble(level + 1)) + 1.0) / 3.0) + 24.0) / 50.0);
                }
                else if ((Convert.ToDouble(level + 1)) >= 15 && (Convert.ToDouble(level + 1)) < 36)
                {
                    temp = Math.Pow((Convert.ToDouble(level + 1)), 3.0) * (((Convert.ToDouble(level + 1)) + 14.0) / 50.0);
                }
                //TODO find if max (Convert.ToDouble(level + 1)) is 100 or not
                else if ((Convert.ToDouble(level + 1)) >= 36)
                {
                    temp = Math.Pow((Convert.ToDouble(level + 1)), 3.0) * (((((Convert.ToDouble(level + 1))) / 2.0) + 32.0) / 50.0);
                }
            }

            ret = Convert.ToInt32(Math.Floor(temp));
            return ret;
        }

        /// <summary>
        /// Calculates hidden power type based on IVs
        /// </summary>
        /// <returns>String of hidden power type</returns>
        private String calcHiddenPowerType()
        {
            int a = IVHP % 2;
            int b = IVAttack % 2;
            int c = IVDefense % 2;
            int d = IVSpeed % 2;
            int e = IVSPAtk % 2;
            int f = IVSPDef % 2;
            int hpTemp = 0;
            String hiddenPower;

            hpTemp = ((a+2*b+4*c+8*d+16*e+32*f)*15)/63;

            switch (hpTemp)
            {
                case 0:
                    hiddenPower = "Fighting";
                    break;
                case 1:
                    hiddenPower = "Flying";
                    break;
                case 2:
                    hiddenPower = "Poison";
                    break;
                case 3:
                    hiddenPower = "Ground";
                    break;
                case 4:
                    hiddenPower = "Rock";
                    break;
                case 5:
                    hiddenPower = "Bug";
                    break;
                case 6:
                    hiddenPower = "Ghost";
                    break;
                case 7:
                    hiddenPower = "Steel";
                    break;
                case 8:
                    hiddenPower = "Fire";
                    break;
                case 9:
                    hiddenPower = "Water";
                    break;
                case 10:
                    hiddenPower = "Grass";
                    break;
                case 11:
                    hiddenPower = "Electric";
                    break;
                case 12:
                    hiddenPower = "Psychic";
                    break;
                case 13:
                    hiddenPower = "Ice";
                    break;
                case 14:
                    hiddenPower = "Dragon";
                    break;
                case 15:
                    hiddenPower = "Dark";
                    break;
                default:
                    hiddenPower = "Blank";
                    break;
            }
            return hiddenPower;
        }

        /// <summary>
        /// Returns hidden power power
        /// </summary>
        /// <returns>int representing hidden power's power</returns>
        private int calcHiddenPowerPower()
        {
            int a = IVHP % 4;
            if (a == 2 || a == 3)
                a = 1;
            else a = 0;
            int b = IVAttack % 4;
            if (b == 2 || b == 3)
                b = 1;
            else b = 0;
            int c = IVDefense % 4;
            if (c == 2 || c == 3)
                c = 1;
            else c = 0;
            int d = IVSpeed % 4;
            if (d == 2 || d == 3)
                d = 1;
            else d = 0;
            int e = IVSPAtk % 4;
            if (e == 2 || e == 3)
                e = 1;
            else e = 0;
            int f = IVSPDef % 4;
            if (f == 2 || f == 3)
                f = 1;
            else f = 0;
            int hpTemp;

            hpTemp = 30 + ((a + 2 * b + 4 * c + 8 * d + 16 * e + 32 * f) * 40) / 63;
            return hpTemp;
        }
    }
}
