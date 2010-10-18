using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IAPL.Pokemon_Library.Moves;

namespace IAPL.BattleSystem
{
    class Battle
    {
        public static void Main()
        {
            Boolean runaway = false;
            Random randPoke = new Random();
            int rand_Pdex = randPoke.Next(1, 151); // Get random wild pokemon and random own pokemon.
            int rand_Level = randPoke.Next(1, 100); // Use a random level for both Pokemon.
            Pokemon Opponent = new Pokemon(rand_Pdex, rand_Level);
            rand_Pdex = randPoke.Next(1, 151);
            Pokemon Own = new Pokemon(rand_Pdex, rand_Level);
            Console.Write("Wild " + Opponent.Name + " appeared!\n");
            Console.Write("Go " + Own.Name + "! They're both level " + Own.Level + "!\n");
            //Calculate each stat for each pokemon by generating IVs and then using statCalc method.
            int[] IVs = { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 5; i++)
            {
                IVs[i] = randPoke.Next(1, 31);
            }
            Opponent.statCalc(IVs[0], IVs[1], IVs[2], IVs[3], IVs[4], IVs[5]);
            for (int i = 0; i < 5; i++)
            {
                IVs[i] = randPoke.Next(1, 31);
            }
            Own.statCalc(IVs[0], IVs[1], IVs[2], IVs[3], IVs[4], IVs[5]);
            Console.Write(Own.Name + " has " + Own.Health + " HP!\n");
            // Create health for keeping track of and creating percentages as well.
            double OpMaxHp = Opponent.Health;
            double OpCurrentHp = Opponent.Health;
            double OwnMaxHp = Own.Health;
            double OwnCurrentHp = Own.Health;
            // Number of tries for running away.
            int tries = 0;
            while (OpCurrentHp > 0 && OwnCurrentHp > 0 && !runaway)
            {
                Console.Write("What will " + Own.Name + " do? (Attack, Bag, Run, Pokemon(Which doesn't work yet) It's case sensitive.)\n");
                string choice = Console.ReadLine();
                bool fail = false; // Check if there is an input error on the user's part.
                switch (choice) // Check which choice is given by user.
                {
                    case "Attack":
                        {
                            // Create moveset for pokemon that's hardcoded, this is temporary until we complete a database or have a trainer that owns Pokemon.
                            Own.Moveset = new Move[] { MoveList.Absorb, MoveList.AerialAce, MoveList.AquaJet, MoveList.Avalanche };
                            Console.Write("Which of the 4 moves should {0} use?\n", Own.Name);
                            Console.Write("{0}, {1}, {2}, or {3}.\n(Remember it's case sensitive)\n", Own.Moveset[0].Name, Own.Moveset[1].Name, Own.Moveset[2].Name, Own.Moveset[3].Name);
                            string move = Console.ReadLine();
                            if (move == Own.Moveset[0].Name) // Check which move was chosen by the trainer.
                            {
                                // Calculate entire damage done.
                                double damagedone = CalculateDamage(Own.Level, Own.Attack, Opponent.Defense, Own.Moveset[0].Power, CalculateModifier(Own.Moveset[0].Type, Own.Type1, Own.Type2, Opponent.Type1, Opponent.Type2, 1));
                                OpCurrentHp = OpCurrentHp - damagedone; // Subtract said damage but don't allow to go below 0
                                if (OpCurrentHp < 0)
                                {
                                    OpCurrentHp = 0;
                                }
                                // Announce remaining health %
                                Console.Write("{0} has {1}% HP remaining.\nSparks are flying in this battle!\n", Opponent.Name, Math.Round((OpCurrentHp / OpMaxHp * 100)));
                            }
                            else if (move == Own.Moveset[1].Name) // Repeat for each move.
                            {
                                double damagedone = CalculateDamage(Own.Level, Own.Attack, Opponent.Defense, Own.Moveset[1].Power, CalculateModifier(Own.Moveset[1].Type, Own.Type1, Own.Type2, Opponent.Type1, Opponent.Type2, 1));
                                OpCurrentHp = OpCurrentHp - damagedone;
                                if (OpCurrentHp < 0)
                                {
                                    OpCurrentHp = 0;
                                }
                                Console.Write("{0} has {1}% HP remaining.\nSparks are flying in this battle!\n", Opponent.Name, Math.Round((OpCurrentHp / OpMaxHp * 100)));
                            }
                            else if (move == Own.Moveset[2].Name)
                            {
                                double damagedone = CalculateDamage(Own.Level, Own.Attack, Opponent.Defense, Own.Moveset[2].Power, CalculateModifier(Own.Moveset[2].Type, Own.Type1, Own.Type2, Opponent.Type1, Opponent.Type2, 1));
                                OpCurrentHp = OpCurrentHp - damagedone;
                                if (OpCurrentHp < 0)
                                {
                                    OpCurrentHp = 0;
                                }
                                Console.Write("{0} has {1}% HP remaining.\nSparks are flying in this battle!\n", Opponent.Name, Math.Round((OpCurrentHp / OpMaxHp * 100)));
                            }
                            else if (move == Own.Moveset[3].Name)
                            {
                                double damagedone = CalculateDamage(Own.Level, Own.Attack, Opponent.Defense, Own.Moveset[3].Power, CalculateModifier(Own.Moveset[3].Type, Own.Type1, Own.Type2, Opponent.Type1, Opponent.Type2, 1));
                                OpCurrentHp = OpCurrentHp - damagedone;
                                if (OpCurrentHp < 0)
                                {
                                    OpCurrentHp = 0;
                                }
                                Console.Write("{0} has {1}% HP remaining.\nSparks are flying in this battle!\n", Opponent.Name, Math.Round((OpCurrentHp / OpMaxHp * 100)));
                            }
                            else
                            {
                                // Catch Error.
                                Console.Write("Please write one of those 4 moves in the proper case\n"); 
                                fail = true;
                            }
                            break;
                        }
                    case "Bag":
                        {
                            // Place holder.
                            Console.Write("Not Implemented yet\n");
                            fail = true;
                            break;
                        }
                    case "Run":
                        {
                            tries++; //Increase tries first for formula includes the current try.
                            double success = ((Own.Speed*32)/Opponent.Speed) + 30 * tries; // Formula for running away.
                            if (success > 255) // if it's greater than 255, then Pokemon automatically runs away
                            {
                                runaway = true;
                            }
                            else // Otherwise roll for success.
                            {
                                int chance = randPoke.Next(0 , 255);
                                if (chance < success)
                                {
                                    runaway = true;
                                }
                                else
                                {
                                    Console.Write("You failed to get away.\n");
                                }
                            }
                            break;
                        }
                    case "Pokemon":
                        {
                            // Place holder.
                            Console.Write("Not Implemented yet\n");
                            fail = true;
                            break;
                        }
                    default:
                        {
                            // Catch for errors
                            Console.Write("Please choose one of the valid options.\n");
                            fail = true;
                            break;
                        }
                }
                if (fail)
                {
                    // The user messed up, don't have Opponent attack.
                }
                else if (OpCurrentHp != 0) // Opponent doesn't have health means it can't attack.
                {
                    //Create Moveset for Opponent since move database is not complete.
                    Opponent.Moveset = new Move[] { MoveList.AuroraBeam, MoveList.Astonish, MoveList.AirSlash, MoveList.Acid };
                    Random move = new Random();
                    int whichmove = move.Next(0, 3); // Pick a random move from the moveset.
                    Console.Write("{0} used {1}!\n", Opponent.Name, Opponent.Moveset[whichmove].Name);
                    // Calculate the damage done as before
                    double damagedone = CalculateDamage(Opponent.Level, Opponent.Attack, Own.Defense, Opponent.Moveset[whichmove].Power, CalculateModifier(Opponent.Moveset[whichmove].Type, Opponent.Type1, Opponent.Type2, Own.Type1, Own.Type2, 1));
                    OwnCurrentHp = OwnCurrentHp - damagedone;
                    if (OwnCurrentHp < 0) // catch if own Health is below 0 and reset.
                    {
                        OwnCurrentHp = 0;
                    }
                    // Report remaining health.
                    Console.Write("{0} has {1} HP remaining!\n", Own.Name, OwnCurrentHp);
                }
                if (OpCurrentHp <= 0) // Victory Case
                {
                    Console.Write("Congrats, you are victorious!\n");
                }
                if (OwnCurrentHp <= 0) // Defeat Case
                {
                    Console.Write("Sucks to be you, you lost hard.\n");
                }
                if (runaway) // Successful Escape.
                {
                    Console.Write("Got away safely!\n");
                }
            }
        }
        private static double CalculateDamage(int Level, double Attack, double Defense, int Power, double Modifier)
        {
            // Damage Formula.
            double damage = Math.Round((((2 * Level + 10) * .004) * (Attack / Defense) * Power + 2) * Modifier);
            return damage;
        }
        // int crithit is in form of steps, 1, 2, 3, 4 where 1 is normal or 6.25%, etc...
        private static double CalculateModifier(MoveType M_Type, int a_type1, int a_type2, int d_type1, int d_type2, int crithit)
        {
            // Effectivity chart matching types in a 18x18 array where the 0 place doesn't do anything.
            // -1 means not very effective, 0 means normal, 1 means Super Effective.
            int[,] effectivity = new int[,] 
            {   // Defense
                //nu, n , f , w , e , g , i , fi, po, gr, fl, ps, b , r , gh, dr, da, st
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0}, //null Attack
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,-1 ,-4 , 0 , 0 ,-1}, //normal
                { 0 , 0 ,-1 ,-1 , 0 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 1 ,-1 , 0 ,-1 , 0 , 1}, //fire
                { 0 , 0 , 1 ,-1 , 0 ,-1 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 1 , 0 ,-1 , 0 , 0}, //water
                { 0 , 0 , 0 , 1 ,-1 ,-1 , 0 , 0 , 0 ,-4 , 1 , 0 , 0 , 0 , 0 ,-1 , 0 , 0}, //electric
                { 0 , 0 ,-1 , 1 , 0 ,-1 , 0 , 0 ,-1 , 1 ,-1 , 0 ,-1 , 1 , 0 ,-1 , 0 ,-1}, //grass
                { 0 , 0 ,-1 ,-1 , 0 , 1 ,-1 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 0 , 1 , 0 ,-1}, //ice
                { 0 , 1 , 0 , 0 , 0 , 0 , 1 , 0 ,-1 , 0 ,-1 ,-1 ,-1 , 1 ,-4 , 0 , 1 , 1}, //fighting
                { 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 ,-1 ,-1 , 0 , 0 , 0 ,-1 ,-1 , 0 , 0 ,-4}, //poison
                { 0 , 0 , 1 , 0 , 1 ,-1 , 0 , 0 , 1 , 0 ,-4 , 0 ,-1 , 1 , 0 , 0 , 0 , 1}, //ground
                { 0 , 0 , 0 , 0 ,-1 , 1 , 0 , 1 , 0 , 0 , 0 , 0 , 1 ,-1 , 0 , 0 , 0 ,-1}, //flying
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1 , 0 , 0 ,-1 , 0 , 0 , 0 , 0 ,-4 ,-1}, //psychic
                { 0 , 0 ,-1 , 0 , 0 , 1 , 0 ,-1 ,-1 , 0 ,-1 , 1 , 0 , 0 ,-1 , 0 , 1 ,-1}, //bug
                { 0 , 0 , 1 , 0 , 0 , 0 , 1 ,-1 , 0 ,-1 , 1 , 0 , 1 , 0 , 0 , 0 , 0 ,-1}, //rock
                { 0 ,-4 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 1 , 0 ,-1 ,-1}, //ghost
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 ,-1}, //dragon
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 ,-1 , 0 , 0 , 0 , 1 , 0 , 0 , 1 , 0 ,-1 ,-1}, //dark
                { 0 , 0 ,-1 ,-1 ,-1 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 ,-1}, //steel
            };       
            // Define a dictionary to turn move types to match pokemon types for comparing.
            Dictionary<MoveType, int> movetypechart = new Dictionary<MoveType, int>();
                movetypechart.Add( MoveType.Normal   , 1 );
                movetypechart.Add( MoveType.Fire     , 2 );
                movetypechart.Add( MoveType.Water    , 3 );
                movetypechart.Add( MoveType.Electric , 4 );
                movetypechart.Add( MoveType.Grass    , 5 );
                movetypechart.Add( MoveType.Ice      , 6 );
                movetypechart.Add( MoveType.Fighting , 7 );
                movetypechart.Add( MoveType.Poison   , 8 );
                movetypechart.Add( MoveType.Ground   , 9 );
                movetypechart.Add( MoveType.Flying   , 10);
                movetypechart.Add( MoveType.Psychic  , 11);
                movetypechart.Add( MoveType.Bug      , 12);
                movetypechart.Add( MoveType.Rock     , 13);
                movetypechart.Add( MoveType.Ghost    , 14);
                movetypechart.Add( MoveType.Dragon   , 15);
                movetypechart.Add( MoveType.Dark     , 16);
                movetypechart.Add( MoveType.Steel    , 17);
            int Mtype_num = 0;
            // Compare given type to the dictionary, for later use in Type Effective chart.
            foreach (KeyValuePair< MoveType , int> kvp in movetypechart)
            {
                int counter = 0;
                if (M_Type == kvp.Key)
                {
                    Mtype_num = movetypechart[kvp.Key];
                }
                counter++;
            }
            // Get effectivity from chart based off type of defending pokemon and type of the attack.
            int Effectivity = effectivity[Mtype_num , d_type1] + effectivity[Mtype_num , d_type2];
            // Create a random number between 0 and 1000, chance to crit is 6.25% per step where steps are effected
            // by move or held item.
            Random crit = new Random();
            int critcheck = crit.Next(0, 1000);
            double Criticalhit = 1;
            if (critcheck <= (625 * crithit))
            {
                Console.Write("It's a critical hit!\n");
                Criticalhit = 2;
            }
            double modifier;
            double STAB = 1; // Default STAB, if the Attack type matches the attacking pokemon, give STAB bonus.
            if (a_type1 == Mtype_num || a_type2 == Mtype_num)
            {
                STAB = 1.5;
            }
            if (Effectivity < -2) // Check how effective the attack is < -2 means it does nothing.
            {
                Console.Write("It's not effective.\n");
                modifier = 0;
            }
            else
            {
                if (Effectivity > 0) // if the attack is > 0 it's super effective.
                {
                    Console.Write("It's super effective!\n");
                }
                else if (Effectivity > -2 && Effectivity < 0) // if the attack is less than 0 but not uneffective entirely, say it's noth very effective.
                {
                    Console.Write("It's not very effective\n");
                }
                Random number = new Random();
                int rand = number.Next(85, 100); //rand number used in formula which creats a min and max for the damage.
                // Effectivity is dealth with by 2^ it's power meaning 2^-1 is *.5, 2*0 is *1, etc...
                modifier = Math.Round(STAB * Math.Pow(2,Effectivity) * Criticalhit * (rand * .01)); 
            }
            return modifier;
        }
    }
    class Pokemon
    {
        // Initiate all the private internal variables
        private string name;
        private double atk;
        private double def;
        private double spatk;
        private double spdef;
        private double spd;
        private double hp;
        private int t1;
        private int t2;
        private int level;
        private int p_number;
        private Move[] m_set;
        // Allow all the internal variables to be edited as properties.
        public string Name { get { return name; } set { name = value; } }
        public double Attack { get { return atk; } set { atk = value; } }
        public double Defense { get { return def; } set { def = value; } }
        public double SpAttack { get { return spatk; } set { spatk = value; } }
        public double SpDefense { get { return spdef; } set { spdef = value; } }
        public double Speed { get { return spd; } set { spd = value; } }
        public double Health { get { return hp; } set { hp = value; } }
        public int Type1 { get { return t1; } set { t1 = value; } }
        public int Type2 { get { return t2; } set { t2 = value; } }
        public int Level { get { return level; } set { level = value; } }
        public int PokeNumber { get { return p_number; } set { p_number = value; } }
        public Move[] Moveset { get { return m_set; } set { m_set = value; } }
        public Pokemon(int Pdexnumber, int pokemonlevel)
        {
            //Retreive Data from Pokemon Library based on Pokedex number and Level.
            IAPL.Pokemon_Library.Pokemon CurrentPokemon = new IAPL.Pokemon_Library.Pokemon(Pdexnumber);
            this.Name = CurrentPokemon.PokemonName;
            this.t1 = CurrentPokemon.Type1;
            this.t2 = CurrentPokemon.Type2;
            PokeNumber = Pdexnumber;
            Level = pokemonlevel;
        }
        // Calculate all the stats for the Pokemon based off IVs, probably be randomized when found and serialized from there.
        public void statCalc(int HIV, int AIV, int DIV, int SAIV, int SDIV, int SIV)
        {
            IAPL.Pokemon_Library.Pokemon CurrentPokemon = new IAPL.Pokemon_Library.Pokemon(PokeNumber);
            Attack = Math.Floor((AIV + 2 * CurrentPokemon.BaseAttack) * Level * .01 + 5); // Get base attack from DLL
            Defense = Math.Floor((DIV + 2 * CurrentPokemon.BaseDefense) * Level * .01 + 5);
            SpAttack = Math.Floor((SAIV + 2 * CurrentPokemon.BaseSpAttack) * Level * .01 + 5);
            SpDefense = Math.Floor((SDIV + 2 * CurrentPokemon.BaseSpDefense) * Level * .01 + 5);
            Speed = Math.Floor((SIV + 2 * CurrentPokemon.BaseSpeed) * Level * .01 + 5);
            Health = Math.Floor(((HIV + (2 * CurrentPokemon.BaseHealth)) * (Level * .01 )) + 10 + Level);
        }
    }
}
