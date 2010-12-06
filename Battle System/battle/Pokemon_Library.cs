using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAPL.Pokemon_Library
{
    class Pokemon
    {
        private int P_number;
        public int PokedexNumber { get { return P_number; } set { P_number = value; } }
        private string P_name;
        public string PokemonName { get { return P_name; } set { P_name = value; } }
        private string P_desc;
        public string PokedexDesc { get { return P_desc; } set { P_desc = value; } }
        private int B_Atk;
        public int BaseAttack { get { return B_Atk; } set { B_Atk = value; } }
        private int B_Def;
        public int BaseDefense { get { return B_Def; } set { B_Def = value; } }
        private int B_SpAtk;
        public int BaseSpAttack { get { return B_SpAtk; } set { B_SpAtk = value; } }
        private int B_SpDef;
        public int BaseSpDefense { get { return B_SpDef; } set { B_SpDef = value; } }
        private int B_Spd;
        public int BaseSpeed { get { return B_Spd; } set { B_Spd = value; } }
        private int B_Hp;
        public int BaseHealth { get { return B_Hp; } set { B_Hp = value; } }
        /*
        * Guide to Pokemon Types
        * 0 = Null 
        * 1 = Normal
        * 2 = Fire
        * 3 = Water
        * 4 = Electric
        * 5 = Grass
        * 6 = Ice
        * 7 = Fighting
        * 8 = Poison
        * 9 = Ground
        * 10 = Flying
        * 11 = Psychic
        * 12 = Bug
        * 13 = Rock
        * 14 = Ghost
        * 15 = Dragon
        * 16 = Dark
        * 17 = Steel
        */
        private int Primtype;
        public int Type1 { get { return Primtype; } set { Primtype = value; } }
        private int Sectype;
        public int Type2 { get { return Sectype; } set { Sectype = value; } }
        public Pokemon(int LocalPdexNumber)
        {
            this.PokedexNumber = LocalPdexNumber;
            switch (LocalPdexNumber)
            {
                case 1:
                    {
                        PokemonName = "Bulbasaur";
                        PokedexDesc = "A strange seed was planted on its back at birth. The plant sprouts and grows with this POKéMON.";
                        BaseAttack = 49;
                        BaseDefense = 49;
                        BaseSpAttack = 65;
                        BaseSpDefense = 65;
                        BaseSpeed = 45;
                        BaseHealth = 45;
                        Type1 = 5;
                        Type2 = 8;
                        break;
                    }
                case 2:
                    {
                        PokemonName = "Ivysaur";
                        PokedexDesc = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.";
                        BaseAttack = 62;
                        BaseDefense = 63;
                        BaseSpAttack = 80;
                        BaseSpDefense = 80;
                        BaseSpeed = 60;
                        BaseHealth = 60;
                        Type1 = 5;
                        Type2 = 8;
                        break;
                    }
                case 3:
                    {
                        PokemonName = "Venusaur";
                        PokedexDesc = "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.";
                        BaseAttack = 82;
                        BaseDefense = 83;
                        BaseSpAttack = 100;
                        BaseSpDefense = 100;
                        BaseSpeed = 80;
                        BaseHealth = 80;
                        Type1 = 5;
                        Type2 = 8;
                        break;
                    }
                case 4:
                    {
                        PokemonName = "Charmander";
                        PokedexDesc = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.";
                        BaseAttack = 52;
                        BaseDefense = 43;
                        BaseSpAttack = 60;
                        BaseSpDefense = 50;
                        BaseSpeed = 65;
                        BaseHealth = 39;
                        Type1 = 2;
                        Type2 = 0;
                        break;
                    }
                case 5:
                    {
                        PokemonName = "Charmeleon";
                        PokedexDesc = "When it swings its burning tail, it elevates the temperature to unbearably high levels.";
                        BaseAttack = 64;
                        BaseDefense = 58;
                        BaseSpAttack = 80;
                        BaseSpDefense = 65;
                        BaseSpeed = 80;
                        BaseHealth = 58;
                        Type1 = 2;
                        Type2 = 0;
                        break;
                    }
                case 6:
                    {
                        PokemonName = "Charizard";
                        PokedexDesc = "Spits fire that is hot enough to melt boulders. Known to cause forest fires unintentionally.";
                        BaseAttack = 84;
                        BaseDefense = 78;
                        BaseSpAttack = 109;
                        BaseSpDefense = 85;
                        BaseSpeed = 100;
                        BaseHealth = 78;
                        Type1 = 2;
                        Type2 = 10;
                        break;
                    }
                case 7:
                    {
                        PokemonName = "Squirtle";
                        PokedexDesc = "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.";
                        BaseAttack = 48;
                        BaseDefense = 65;
                        BaseSpAttack = 50;
                        BaseSpDefense = 64;
                        BaseSpeed = 43;
                        BaseHealth = 44;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 8:
                    {
                        PokemonName = "Wartortle";
                        PokedexDesc = "Often hides in water to stalk unwary prey. For swimming fast, it moves its ears to maintain balance.";
                        BaseAttack = 63;
                        BaseDefense = 80;
                        BaseSpAttack = 65;
                        BaseSpDefense = 80;
                        BaseSpeed = 58;
                        BaseHealth = 59;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 9:
                    {
                        PokemonName = "Blastoise";
                        PokedexDesc = "A brutal POKéMON with pressurized water jets on its shell. They are used for high speed tackles.";
                        BaseAttack = 83;
                        BaseDefense = 100;
                        BaseSpAttack = 85;
                        BaseSpDefense = 105;
                        BaseSpeed = 78;
                        BaseHealth = 79;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 10:
                    {
                        PokemonName = "Caterpie";
                        PokedexDesc = "Its short feet are tipped with suction pads that enable it to tirelessly climb slopes and walls.";
                        BaseAttack = 30;
                        BaseDefense = 35;
                        BaseSpAttack = 20;
                        BaseSpDefense = 20;
                        BaseSpeed = 45;
                        BaseHealth = 45;
                        Type1 = 12;
                        Type2 = 0;
                        break;
                    }
                case 11:
                    {
                        PokemonName = "Metapod";
                        PokedexDesc = "This POKéMON is vulnerable to attack while its shell is soft, exposing its weak and tender body.";
                        BaseAttack = 20;
                        BaseDefense = 55;
                        BaseSpAttack = 25;
                        BaseSpDefense = 25;
                        BaseSpeed = 30;
                        BaseHealth = 50;
                        Type1 = 12;
                        Type2 = 0;
                        break;
                    }
                case 12:
                    {
                        PokemonName = "Butterfree";
                        PokedexDesc = "In battle, it flaps its wings at high speed to release highly toxic dust into the air.";
                        BaseAttack = 45;
                        BaseDefense = 50;
                        BaseSpAttack = 80;
                        BaseSpDefense = 80;
                        BaseSpeed = 70;
                        BaseHealth = 60;
                        Type1 = 12;
                        Type2 = 10;
                        break;
                    }
                case 13:
                    {
                        PokemonName = "Weedle";
                        PokedexDesc = "Often found in forests, eating leaves. It has a sharp venomous stinger on its head.";
                        BaseAttack = 35;
                        BaseDefense = 30;
                        BaseSpAttack = 20;
                        BaseSpDefense = 20;
                        BaseSpeed = 50;
                        BaseHealth = 40;
                        Type1 = 12;
                        Type2 = 8;
                        break;
                    }
                case 14:
                    {
                        PokemonName = "Kakuna";
                        PokedexDesc = "Almost incapable of moving, this POKéMON can only harden its shell to protect itself from predators.";
                        BaseAttack = 25;
                        BaseDefense = 50;
                        BaseSpAttack = 25;
                        BaseSpDefense = 25;
                        BaseSpeed = 35;
                        BaseHealth = 45;
                        Type1 = 12;
                        Type2 = 8;
                        break;
                    }
                case 15:
                    {
                        PokemonName = "Beedrill";
                        PokedexDesc = "Flies at high speed and attacks using its large venomous stingers on its forelegs and tail.";
                        BaseAttack = 80;
                        BaseDefense = 40;
                        BaseSpAttack = 45;
                        BaseSpDefense = 80;
                        BaseSpeed = 75;
                        BaseHealth = 65;
                        Type1 = 12;
                        Type2 = 8;
                        break;
                    }
                case 16:
                    {
                        PokemonName = "Pidgey";
                        PokedexDesc = "A common sight in forests and woods. It flaps its wings at ground level to kick up blinding sand.";
                        BaseAttack = 45;
                        BaseDefense = 40;
                        BaseSpAttack = 35;
                        BaseSpDefense = 35;
                        BaseSpeed = 56;
                        BaseHealth = 40;
                        Type1 = 1;
                        Type2 = 10;
                        break;
                    }
                case 17:
                    {
                        PokemonName = "Pidgeotto";
                        PokedexDesc = "Very protective of its sprawling territorial area, this POKéMON will fiercely peck at any intruder.";
                        BaseAttack = 60;
                        BaseDefense = 55;
                        BaseSpAttack = 50;
                        BaseSpDefense = 50;
                        BaseSpeed = 71;
                        BaseHealth = 63;
                        Type1 = 1;
                        Type2 = 10;
                        break;
                    }
                case 18:
                    {
                        PokemonName = "Pidgeot";
                        PokedexDesc = "When hunting, it skims the surface of water at high speed to pick off unwary prey such as MAGIKARP.";
                        BaseAttack = 80;
                        BaseDefense = 75;
                        BaseSpAttack = 70;
                        BaseSpDefense = 70;
                        BaseSpeed = 91;
                        BaseHealth = 83;
                        Type1 = 1;
                        Type2 = 10;
                        break;
                    }
                case 19:
                    {
                        PokemonName = "Rattata";
                        PokedexDesc = "Bites anything when it attacks. Small and very quick, it is a common sight in many places.";
                        BaseAttack = 56;
                        BaseDefense = 35;
                        BaseSpAttack = 25;
                        BaseSpDefense = 35;
                        BaseSpeed = 72;
                        BaseHealth = 30;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 20:
                    {
                        PokemonName = "Radicate";
                        PokedexDesc = "It uses its whiskers to maintain its balance. It apparently slows down if they are cut off.";
                        BaseAttack = 81;
                        BaseDefense = 60;
                        BaseSpAttack = 50;
                        BaseSpDefense = 70;
                        BaseSpeed = 97;
                        BaseHealth = 55;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 21:
                    {
                        PokemonName = "Spearow";
                        PokedexDesc = "Eats bugs in grassy areas. It has to flap its short wings at high speed to stay airborne.";
                        BaseAttack = 60;
                        BaseDefense = 30;
                        BaseSpAttack = 31;
                        BaseSpDefense = 31;
                        BaseSpeed = 70;
                        BaseHealth = 40;
                        Type1 = 1;
                        Type2 = 10;
                        break;
                    }
                case 22:
                    {
                        PokemonName = "Fearow";
                        PokedexDesc = "With its huge and magnificent wings, it can keep aloft without ever having to land for rest.";
                        BaseAttack = 90;
                        BaseDefense = 65;
                        BaseSpAttack = 61;
                        BaseSpDefense = 61;
                        BaseSpeed = 100;
                        BaseHealth = 65;
                        Type1 = 1;
                        Type2 = 10;
                        break;
                    }
                case 23:
                    {
                        PokemonName = "Ekans";
                        PokedexDesc = "Moves silently and stealthily. Eats the eggs of birds, such as PIDGEY and SPEAROW, whole.";
                        BaseAttack = 60;
                        BaseDefense = 44;
                        BaseSpAttack = 40;
                        BaseSpDefense = 54;
                        BaseSpeed = 55;
                        BaseHealth = 35;
                        Type1 = 8;
                        Type2 = 0;
                        break;
                    }
                case 24:
                    {
                        PokemonName = "Arbok";
                        PokedexDesc = "It is rumored that the ferocious warning markings on its belly differ from area to area.";
                        BaseAttack = 85;
                        BaseDefense = 69;
                        BaseSpAttack = 65;
                        BaseSpDefense = 79;
                        BaseSpeed = 80;
                        BaseHealth = 60;
                        Type1 = 8;
                        Type2 = 0;
                        break;
                    }
                case 25:
                    {
                        PokemonName = "Pikachu";
                        PokedexDesc = "When several of these POKéMON gather, their electricity could build and cause lightning storms.";
                        BaseAttack = 55;
                        BaseDefense = 30;
                        BaseSpAttack = 50;
                        BaseSpDefense = 40;
                        BaseSpeed = 90;
                        BaseHealth = 35;
                        Type1 = 4;
                        Type2 = 0;
                        break;
                    }
                case 26:
                    {
                        PokemonName = "Raichu";
                        PokedexDesc = "Its long tail serves as a ground to protect itself from its own high voltage power.";
                        BaseAttack = 90;
                        BaseDefense = 55;
                        BaseSpAttack = 90;
                        BaseSpDefense = 80;
                        BaseSpeed = 100;
                        BaseHealth = 60;
                        Type1 = 4;
                        Type2 = 0;
                        break;
                    }
                case 27:
                    {
                        PokemonName = "Sandshrew";
                        PokedexDesc = "Burrows deep underground in arid locations far from water. It only emerges to hunt for food.";
                        BaseAttack = 75;
                        BaseDefense = 85;
                        BaseSpAttack = 20;
                        BaseSpDefense = 30;
                        BaseSpeed = 40;
                        BaseHealth = 50;
                        Type1 = 9;
                        Type2 = 0;
                        break;
                    }
                case 28:
                    {
                        PokemonName = "Sandslash";
                        PokedexDesc = "Curls up into a spiny ball when threatened. It can roll while curled up to attack or escape.";
                        BaseAttack = 100;
                        BaseDefense = 110;
                        BaseSpAttack = 45;
                        BaseSpDefense = 55;
                        BaseSpeed = 65;
                        BaseHealth = 75;
                        Type1 = 9;
                        Type2 = 0;
                        break;
                    }
                case 29:
                    {
                        PokemonName = "Nidoran";
                        PokedexDesc = "Although small, its venomous barbs render this POKéMON dangerous. The female has smaller horns.";
                        BaseAttack = 47;
                        BaseDefense = 52;
                        BaseSpAttack = 40;
                        BaseSpDefense = 40;
                        BaseSpeed = 41;
                        BaseHealth = 55;
                        Type1 = 8;
                        Type2 = 0;
                        break;
                    }
                case 30:
                    {
                        PokemonName = "Nidorina";
                        PokedexDesc = "The female's horn develops slowly. Prefers physical attacks such as clawing and biting.";
                        BaseAttack = 62;
                        BaseDefense = 67;
                        BaseSpAttack = 55;
                        BaseSpDefense = 55;
                        BaseSpeed = 56;
                        BaseHealth = 70;
                        Type1 = 8;
                        Type2 = 0;
                        break;
                    }
                case 31:
                    {
                        PokemonName = "Nidoqueen";
                        PokedexDesc = "Its hard scales provide strong protection. It uses its hefty bulk to execute powerful moves.";
                        BaseAttack = 82;
                        BaseDefense = 87;
                        BaseSpAttack = 75;
                        BaseSpDefense = 85;
                        BaseSpeed = 76;
                        BaseHealth = 90;
                        Type1 = 8;
                        Type2 = 9;
                        break;
                    }
                case 32:
                    {
                        PokemonName = "Nidoran";
                        PokedexDesc = "Stiffens its ears to sense danger. The larger its horns, the more powerful its secreted venom.";
                        BaseAttack = 57;
                        BaseDefense = 40;
                        BaseSpAttack = 40;
                        BaseSpDefense = 40;
                        BaseSpeed = 50;
                        BaseHealth = 46;
                        Type1 = 8;
                        Type2 = 0;
                        break;
                    }
                case 33:
                    {
                        PokemonName = "Nidorino";
                        PokedexDesc = "An aggressive POKéMON that is quick to attack. The horn on its head secretes a powerful venom.";
                        BaseAttack = 72;
                        BaseDefense = 57;
                        BaseSpAttack = 55;
                        BaseSpDefense = 55;
                        BaseSpeed = 65;
                        BaseHealth = 61;
                        Type1 = 8;
                        Type2 = 0;
                        break;
                    }
                case 34:
                    {
                        PokemonName = "Nidoking";
                        PokedexDesc = "It uses its powerful tail in battle to smash, constrict, then break the prey's bones.";
                        BaseAttack = 92;
                        BaseDefense = 77;
                        BaseSpAttack = 85;
                        BaseSpDefense = 75;
                        BaseSpeed = 85;
                        BaseHealth = 81;
                        Type1 = 8;
                        Type2 = 9;
                        break;
                    }
                case 35:
                    {
                        PokemonName = "Clefairy";
                        PokedexDesc = "Its magical and cute appeal has many admirers. It is rare and found only in certain areas.";
                        BaseAttack = 45;
                        BaseDefense = 48;
                        BaseSpAttack = 60;
                        BaseSpDefense = 65;
                        BaseSpeed = 35;
                        BaseHealth = 70;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 36:
                    {
                        PokemonName = "Clefable";
                        PokedexDesc = "A timid fairy POKéMON that is rarely seen. It will run and hide the moment it senses people.";
                        BaseAttack = 70;
                        BaseDefense = 73;
                        BaseSpAttack = 85;
                        BaseSpDefense = 90;
                        BaseSpeed = 60;
                        BaseHealth = 95;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 37:
                    {
                        PokemonName = "Vulpix";
                        PokedexDesc = "At the time of birth, it has just one tail. The tail splits from its tip as it grows older.";
                        BaseAttack = 41;
                        BaseDefense = 40;
                        BaseSpAttack = 50;
                        BaseSpDefense = 65;
                        BaseSpeed = 65;
                        BaseHealth = 38;
                        Type1 = 2;
                        Type2 = 0;
                        break;
                    }
                case 38:
                    {
                        PokemonName = "Ninetails";
                        PokedexDesc = "Very smart and very vengeful. Grabbing one of its many tails could result in a 1000-year curse.";
                        BaseAttack = 76;
                        BaseDefense = 75;
                        BaseSpAttack = 81;
                        BaseSpDefense = 100;
                        BaseSpeed = 100;
                        BaseHealth = 73;
                        Type1 = 2;
                        Type2 = 0;
                        break;
                    }
                case 39:
                    {
                        PokemonName = "Jigglytuff";
                        PokedexDesc = "When its huge eyes light up, it sings a mysteriously soothing melody that lulls its enemies to sleep.";
                        BaseAttack = 45;
                        BaseDefense = 20;
                        BaseSpAttack = 45;
                        BaseSpDefense = 25;
                        BaseSpeed = 20;
                        BaseHealth = 115;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 40:
                    {
                        PokemonName = "Wigglytuff";
                        PokedexDesc = "The body is soft and rubbery. When angered, it will suck in air and inflate itself to an enormous size.";
                        BaseAttack = 70;
                        BaseDefense = 45;
                        BaseSpAttack = 75;
                        BaseSpDefense = 50;
                        BaseSpeed = 45;
                        BaseHealth = 140;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 41:
                    {
                        PokemonName = "Zubat";
                        PokedexDesc = "Forms colonies in perpetually dark places. Uses ultrasonic waves to identify and approach targets.";
                        BaseAttack = 45;
                        BaseDefense = 35;
                        BaseSpAttack = 30;
                        BaseSpDefense = 40;
                        BaseSpeed = 55;
                        BaseHealth = 40;
                        Type1 = 8;
                        Type2 = 10;
                        break;
                    }
                case 42:
                    {
                        PokemonName = "Golbat";
                        PokedexDesc = "Once it strikes, it will not stop draining energy from the victim even if it gets too heavy to fly.";
                        BaseAttack = 80;
                        BaseDefense = 70;
                        BaseSpAttack = 65;
                        BaseSpDefense = 75;
                        BaseSpeed = 90;
                        BaseHealth = 75;
                        Type1 = 8;
                        Type2 = 10;
                        break;
                    }
                case 43:
                    {
                        PokemonName = "Oddish";
                        PokedexDesc = "During the day, it keeps its face buried in the ground. At night, it wanders around sowing its seeds.";
                        BaseAttack = 50;
                        BaseDefense = 55;
                        BaseSpAttack = 75;
                        BaseSpDefense = 65;
                        BaseSpeed = 30;
                        BaseHealth = 45;
                        Type1 = 5;
                        Type2 = 8;
                        break;
                    }
                case 44:
                    {
                        PokemonName = "Gloom";
                        PokedexDesc = "The fluid that oozes from its mouth isn't drool. It is a nectar that is used to attract prey.";
                        BaseAttack = 65;
                        BaseDefense = 70;
                        BaseSpAttack = 85;
                        BaseSpDefense = 75;
                        BaseSpeed = 40;
                        BaseHealth = 60;
                        Type1 = 5;
                        Type2 = 8;
                        break;
                    }
                case 45:
                    {
                        PokemonName = "Vileplume";
                        PokedexDesc = "The larger its petals, the more toxic pollen it contains. Its big head is heavy and hard to hold up.";
                        BaseAttack = 80;
                        BaseDefense = 85;
                        BaseSpAttack = 100;
                        BaseSpDefense = 90;
                        BaseSpeed = 50;
                        BaseHealth = 75;
                        Type1 = 5;
                        Type2 = 8;
                        break;
                    }
                case 46:
                    {
                        PokemonName = "Paras";
                        PokedexDesc = "Burrows to suck tree roots. The mushrooms on its back grow by drawing nutrients from the bug host.";
                        BaseAttack = 70;
                        BaseDefense = 55;
                        BaseSpAttack = 45;
                        BaseSpDefense = 55;
                        BaseSpeed = 25;
                        BaseHealth = 35;
                        Type1 = 12;
                        Type2 = 5;
                        break;
                    }
                case 47:
                    {
                        PokemonName = "Parasect";
                        PokedexDesc = "A host-parasite pair in which the parasite mushroom has taken over the host bug. Prefers damp places.";
                        BaseAttack = 95;
                        BaseDefense = 80;
                        BaseSpAttack = 60;
                        BaseSpDefense = 80;
                        BaseSpeed = 30;
                        BaseHealth = 60;
                        Type1 = 12;
                        Type2 = 5;
                        break;
                    }
                case 48:
                    {
                        PokemonName = "Venonat";
                        PokedexDesc = "Lives in the shadows of tall trees where it eats insects. It is attracted by light at night.";
                        BaseAttack = 55;
                        BaseDefense = 50;
                        BaseSpAttack = 40;
                        BaseSpDefense = 55;
                        BaseSpeed = 45;
                        BaseHealth = 60;
                        Type1 = 12;
                        Type2 = 8;
                        break;
                    }
                case 49:
                    {
                        PokemonName = "Venomoth";
                        PokedexDesc = "The dust-like scales covering its wings are color coded to indicate the kinds of poison it has.";
                        BaseAttack = 65;
                        BaseDefense = 60;
                        BaseSpAttack = 90;
                        BaseSpDefense = 75;
                        BaseSpeed = 90;
                        BaseHealth = 70;
                        Type1 = 12;
                        Type2 = 8;
                        break;
                    }
                case 50:
                    {
                        PokemonName = "Diglett";
                        PokedexDesc = "Lives about one yard underground where it feeds on plant roots. It sometimes appears above ground.";
                        BaseAttack = 55;
                        BaseDefense = 25;
                        BaseSpAttack = 35;
                        BaseSpDefense = 45;
                        BaseSpeed = 95;
                        BaseHealth = 10;
                        Type1 = 9;
                        Type2 = 0;
                        break;
                    }
                case 51:
                    {
                        PokemonName = "Dugtrio";
                        PokedexDesc = "A team of DIGLETT triplets. It triggers huge earthquakes by burrowing 60 miles underground.";
                        BaseAttack = 80;
                        BaseDefense = 50;
                        BaseSpAttack = 50;
                        BaseSpDefense = 70;
                        BaseSpeed = 120;
                        BaseHealth = 35;
                        Type1 = 9;
                        Type2 = 0;
                        break;
                    }
                case 52:
                    {
                        PokemonName = "Meowth";
                        PokedexDesc = "Adores circular objects. Wanders the streets on a nightly basis to look for dropped loose change.";
                        BaseAttack = 45;
                        BaseDefense = 35;
                        BaseSpAttack = 40;
                        BaseSpDefense = 40;
                        BaseSpeed = 90;
                        BaseHealth = 40;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 53:
                    {
                        PokemonName = "Persian";
                        PokedexDesc = "Although its fur has many admirers, it is tough to raise as a pet because of its fickle meanness.";
                        BaseAttack = 70;
                        BaseDefense = 60;
                        BaseSpAttack = 65;
                        BaseSpDefense = 65;
                        BaseSpeed = 115;
                        BaseHealth = 65;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 54:
                    {
                        PokemonName = "Psyduck";
                        PokedexDesc = "While lulling its enemies with its vacant look, this wily POKéMON will use psychokinetic powers.";
                        BaseAttack = 52;
                        BaseDefense = 48;
                        BaseSpAttack = 65;
                        BaseSpDefense = 50;
                        BaseSpeed = 55;
                        BaseHealth = 50;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 55:
                    {
                        PokemonName = "Golduck";
                        PokedexDesc = "Often seen swimming elegantly by lake shores. It is often mistaken for the Japanese monster, Kappa.";
                        BaseAttack = 82;
                        BaseDefense = 78;
                        BaseSpAttack = 95;
                        BaseSpDefense = 80;
                        BaseSpeed = 85;
                        BaseHealth = 80;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 56:
                    {
                        PokemonName = "Mankey";
                        PokedexDesc = "Extremely quick to anger. It could be docile one moment then thrashing away the next instant.";
                        BaseAttack = 80;
                        BaseDefense = 35;
                        BaseSpAttack = 35;
                        BaseSpDefense = 45;
                        BaseSpeed = 70;
                        BaseHealth = 40;
                        Type1 = 7;
                        Type2 = 0;
                        break;
                    }
                case 57:
                    {
                        PokemonName = "Primeape";
                        PokedexDesc = "Always furious and tenacious to boot. It will not abandon chasing its quarry until it is caught.";
                        BaseAttack = 105;
                        BaseDefense = 60;
                        BaseSpAttack = 60;
                        BaseSpDefense = 70;
                        BaseSpeed = 95;
                        BaseHealth = 65;
                        Type1 = 7;
                        Type2 = 0;
                        break;
                    }
                case 58:
                    {
                        PokemonName = "Growlithe";
                        PokedexDesc = "Very protective of its territory. It will bark and bite to repel intruders from its space.";
                        BaseAttack = 70;
                        BaseDefense = 45;
                        BaseSpAttack = 70;
                        BaseSpDefense = 50;
                        BaseSpeed = 60;
                        BaseHealth = 55;
                        Type1 = 2;
                        Type2 = 0;
                        break;
                    }
                case 59:
                    {
                        PokemonName = "Arcanine";
                        PokedexDesc = "A POKéMON that has been admired since the past for its beauty. It runs agilely as if on wings.";
                        BaseAttack = 110;
                        BaseDefense = 80;
                        BaseSpAttack = 100;
                        BaseSpDefense = 80;
                        BaseSpeed = 95;
                        BaseHealth = 90;
                        Type1 = 2;
                        Type2 = 0;
                        break;
                    }
                case 60:
                    {
                        PokemonName = "Poliwag";
                        PokedexDesc = "Its newly grown legs prevent it from running. It appears to prefer swimming than trying to stand.";
                        BaseAttack = 50;
                        BaseDefense = 40;
                        BaseSpAttack = 40;
                        BaseSpDefense = 40;
                        BaseSpeed = 90;
                        BaseHealth = 40;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 61:
                    {
                        PokemonName = "Poliwhirl";
                        PokedexDesc = "Capable of living in or out of water. When out of water, it sweats to keep its body slimy.";
                        BaseAttack = 65;
                        BaseDefense = 65;
                        BaseSpAttack = 50;
                        BaseSpDefense = 50;
                        BaseSpeed = 90;
                        BaseHealth = 65;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 62:
                    {
                        PokemonName = "Poliwrath";
                        PokedexDesc = "An adept swimmer at both the front crawl and breast stroke. Easily overtakes the best human swimmers.";
                        BaseAttack = 85;
                        BaseDefense = 95;
                        BaseSpAttack = 70;
                        BaseSpDefense = 90;
                        BaseSpeed = 70;
                        BaseHealth = 90;
                        Type1 = 3;
                        Type2 = 7;
                        break;
                    }
                case 63:
                    {
                        PokemonName = "Abra";
                        PokedexDesc = "Using its ability to read minds, it will identify impending danger and TELEPORT to safety.";
                        BaseAttack = 20;
                        BaseDefense = 15;
                        BaseSpAttack = 105;
                        BaseSpDefense = 55;
                        BaseSpeed = 90;
                        BaseHealth = 25;
                        Type1 = 11;
                        Type2 = 0;
                        break;
                    }
                case 64:
                    {
                        PokemonName = "Kadabra";
                        PokedexDesc = "It emits special alpha waves from its body that induce headaches just by being close by.";
                        BaseAttack = 35;
                        BaseDefense = 30;
                        BaseSpAttack = 120;
                        BaseSpDefense = 70;
                        BaseSpeed = 105;
                        BaseHealth = 40;
                        Type1 = 11;
                        Type2 = 0;
                        break;
                    }
                case 65:
                    {
                        PokemonName = "Alakazam";
                        PokedexDesc = "Its brain can outperform a supercomputer. Its intelligence quotient is said to be 5,000.";
                        BaseAttack = 50;
                        BaseDefense = 45;
                        BaseSpAttack = 135;
                        BaseSpDefense = 85;
                        BaseSpeed = 120;
                        BaseHealth = 55;
                        Type1 = 11;
                        Type2 = 0;
                        break;
                    }
                case 66:
                    {
                        PokemonName = "Machop";
                        PokedexDesc = "Loves to build its muscles. It trains in all styles of martial arts to become even stronger.";
                        BaseAttack = 80;
                        BaseDefense = 50;
                        BaseSpAttack = 35;
                        BaseSpDefense = 35;
                        BaseSpeed = 35;
                        BaseHealth = 70;
                        Type1 = 7;
                        Type2 = 0;
                        break;
                    }
                case 67:
                    {
                        PokemonName = "Machoke";
                        PokedexDesc = "Its muscular body is so powerful, it must wear a power save belt to be able to regulate its motions.";
                        BaseAttack = 100;
                        BaseDefense = 70;
                        BaseSpAttack = 50;
                        BaseSpDefense = 60;
                        BaseSpeed = 45;
                        BaseHealth = 80;
                        Type1 = 7;
                        Type2 = 0;
                        break;
                    }
                case 68:
                    {
                        PokemonName = "Machamp";
                        PokedexDesc = "Using its heavy muscles, it throws powerful punches that can send the victim clear over the horizon.";
                        BaseAttack = 130;
                        BaseDefense = 80;
                        BaseSpAttack = 65;
                        BaseSpDefense = 85;
                        BaseSpeed = 55;
                        BaseHealth = 90;
                        Type1 = 7;
                        Type2 = 0;
                        break;
                    }
                case 69:
                    {
                        PokemonName = "Bellsprout";
                        PokedexDesc = "A carnivorous POKéMON that traps and eats bugs. It uses its root feet to soak up needed moisture.";
                        BaseAttack = 75;
                        BaseDefense = 35;
                        BaseSpAttack = 70;
                        BaseSpDefense = 30;
                        BaseSpeed = 40;
                        BaseHealth = 50;
                        Type1 = 5;
                        Type2 = 8;
                        break;
                    }
                case 70:
                    {
                        PokemonName = "Weepinbell";
                        PokedexDesc = "It spits out POISONPOWDER to immobilize the enemy and then finishes it with a spray of ACID.";
                        BaseAttack = 90;
                        BaseDefense = 50;
                        BaseSpAttack = 85;
                        BaseSpDefense = 45;
                        BaseSpeed = 55;
                        BaseHealth = 65;
                        Type1 = 5;
                        Type2 = 8;
                        break;
                    }
                case 71:
                    {
                        PokemonName = "Victreebel";
                        PokedexDesc = "Said to live in huge colonies deep in jungles, although no one has ever returned from there.";
                        BaseAttack = 105;
                        BaseDefense = 65;
                        BaseSpAttack = 100;
                        BaseSpDefense = 60;
                        BaseSpeed = 70;
                        BaseHealth = 80;
                        Type1 = 5;
                        Type2 = 8;
                        break;
                    }
                case 72:
                    {
                        PokemonName = "Tentacool";
                        PokedexDesc = "Drifts in shallow seas. Anglers who hook them by accident are often punished by its stinging acid.";
                        BaseAttack = 40;
                        BaseDefense = 35;
                        BaseSpAttack = 50;
                        BaseSpDefense = 100;
                        BaseSpeed = 70;
                        BaseHealth = 40;
                        Type1 = 3;
                        Type2 = 8;
                        break;
                    }
                case 73:
                    {
                        PokemonName = "Tentacruel";
                        PokedexDesc = "The tentacles are normally kept short. On hunts, they are extended to ensnare and immobilize prey.";
                        BaseAttack = 70;
                        BaseDefense = 65;
                        BaseSpAttack = 80;
                        BaseSpDefense = 120;
                        BaseSpeed = 100;
                        BaseHealth = 80;
                        Type1 = 3;
                        Type2 = 8;
                        break;
                    }
                case 74:
                    {
                        PokemonName = "Geodude";
                        PokedexDesc = "Found in fields and mountains. Mistaking them for boulders, people often step or trip on them.";
                        BaseAttack = 80;
                        BaseDefense = 100;
                        BaseSpAttack = 30;
                        BaseSpDefense = 30;
                        BaseSpeed = 20;
                        BaseHealth = 40;
                        Type1 = 13;
                        Type2 = 9;
                        break;
                    }
                case 75:
                    {
                        PokemonName = "Graveler";
                        PokedexDesc = "Rolls down slopes to move. It rolls over any obstacle without slowing or changing its direction.";
                        BaseAttack = 95;
                        BaseDefense = 115;
                        BaseSpAttack = 45;
                        BaseSpDefense = 45;
                        BaseSpeed = 35;
                        BaseHealth = 55;
                        Type1 = 13;
                        Type2 = 9;
                        break;
                    }
                case 76:
                    {
                        PokemonName = "Golem";
                        PokedexDesc = "Its boulder-like body is extremely hard. It can easily withstand dynamite blasts without damage.";
                        BaseAttack = 110;
                        BaseDefense = 130;
                        BaseSpAttack = 55;
                        BaseSpDefense = 65;
                        BaseSpeed = 45;
                        BaseHealth = 80;
                        Type1 = 13;
                        Type2 = 9;
                        break;
                    }
                case 77:
                    {
                        PokemonName = "Ponyta";
                        PokedexDesc = "Its hooves are 10 times harder than diamonds. It can trample anything completely flat in little time.";
                        BaseAttack = 85;
                        BaseDefense = 55;
                        BaseSpAttack = 65;
                        BaseSpDefense = 65;
                        BaseSpeed = 90;
                        BaseHealth = 50;
                        Type1 = 2;
                        Type2 = 0;
                        break;
                    }
                case 78:
                    {
                        PokemonName = "Rapidash";
                        PokedexDesc = "Very competitive, this POKéMON will chase anything that moves fast in the hopes of racing it.";
                        BaseAttack = 100;
                        BaseDefense = 70;
                        BaseSpAttack = 80;
                        BaseSpDefense = 80;
                        BaseSpeed = 105;
                        BaseHealth = 65;
                        Type1 = 2;
                        Type2 = 0;
                        break;
                    }
                case 79:
                    {
                        PokemonName = "Slowpoke";
                        PokedexDesc = "Incredibly slow and dopey. It takes 5 seconds for it to feel pain when under attack.";
                        BaseAttack = 65;
                        BaseDefense = 65;
                        BaseSpAttack = 40;
                        BaseSpDefense = 40;
                        BaseSpeed = 15;
                        BaseHealth = 90;
                        Type1 = 3;
                        Type2 = 11;
                        break;
                    }
                case 80:
                    {
                        PokemonName = "Slowbro";
                        PokedexDesc = "The SHELLDER that is latched onto SLOWPOKE's tail is said to feed on the host's left over scraps.";
                        BaseAttack = 75;
                        BaseDefense = 110;
                        BaseSpAttack = 100;
                        BaseSpDefense = 80;
                        BaseSpeed = 30;
                        BaseHealth = 95;
                        Type1 = 3;
                        Type2 = 11;
                        break;
                    }
                case 81:
                    {
                        PokemonName = "Magnemite";
                        PokedexDesc = "Uses anti-gravity to stay suspended. Appears without warning and uses THUNDER WAVE and similar moves.";
                        BaseAttack = 35;
                        BaseDefense = 70;
                        BaseSpAttack = 95;
                        BaseSpDefense = 55;
                        BaseSpeed = 45;
                        BaseHealth = 25;
                        Type1 = 4;
                        Type2 = 17;
                        break;
                    }
                case 82:
                    {
                        PokemonName = "Magneton";
                        PokedexDesc = "Formed by several MAGNEMITEs linked together. They frequently appear when sunspots flare up.";
                        BaseAttack = 60;
                        BaseDefense = 95;
                        BaseSpAttack = 120;
                        BaseSpDefense = 70;
                        BaseSpeed = 70;
                        BaseHealth = 50;
                        Type1 = 4;
                        Type2 = 17;
                        break;
                    }
                case 83:
                    {
                        PokemonName = "Farfetch'd";
                        PokedexDesc = "The sprig of green onions it holds is its weapon. It is used much like a metal sword.";
                        BaseAttack = 65;
                        BaseDefense = 55;
                        BaseSpAttack = 58;
                        BaseSpDefense = 62;
                        BaseSpeed = 60;
                        BaseHealth = 52;
                        Type1 = 1;
                        Type2 = 10;
                        break;
                    }
                case 84:
                    {
                        PokemonName = "Doduo";
                        PokedexDesc = "A bird that makes up for its poor flying with its fast foot speed. Leaves giant footprints.";
                        BaseAttack = 85;
                        BaseDefense = 45;
                        BaseSpAttack = 35;
                        BaseSpDefense = 35;
                        BaseSpeed = 75;
                        BaseHealth = 35;
                        Type1 = 1;
                        Type2 = 10;
                        break;
                    }
                case 85:
                    {
                        PokemonName = "Dodrio";
                        PokedexDesc = "Uses its three brains to execute complex plans. While two heads sleep, one head stays awake.";
                        BaseAttack = 110;
                        BaseDefense = 70;
                        BaseSpAttack = 60;
                        BaseSpDefense = 60;
                        BaseSpeed = 100;
                        BaseHealth = 60;
                        Type1 = 1;
                        Type2 = 10;
                        break;
                    }
                case 86:
                    {
                        PokemonName = "Seel";
                        PokedexDesc = "The protruding horn on its head is very hard. It is used for bashing through thick ice.";
                        BaseAttack = 45;
                        BaseDefense = 55;
                        BaseSpAttack = 45;
                        BaseSpDefense = 70;
                        BaseSpeed = 45;
                        BaseHealth = 65;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 87:
                    {
                        PokemonName = "Dewgong";
                        PokedexDesc = "Stores thermal energy in its body. Swims at a steady 8 knots even in intensely cold waters.";
                        BaseAttack = 70;
                        BaseDefense = 80;
                        BaseSpAttack = 70;
                        BaseSpDefense = 95;
                        BaseSpeed = 70;
                        BaseHealth = 90;
                        Type1 = 3;
                        Type2 = 6;
                        break;
                    }
                case 88:
                    {
                        PokemonName = "Grimer";
                        PokedexDesc = "Appears in filthy areas. Thrives by sucking up polluted sludge that is pumped out of factories.";
                        BaseAttack = 80;
                        BaseDefense = 50;
                        BaseSpAttack = 40;
                        BaseSpDefense = 50;
                        BaseSpeed = 25;
                        BaseHealth = 80;
                        Type1 = 8;
                        Type2 = 0;
                        break;
                    }
                case 89:
                    {
                        PokemonName = "Muk";
                        PokedexDesc = "Thickly covered with a filthy, vile sludge. It is so toxic, even its footprints contain poison.";
                        BaseAttack = 105;
                        BaseDefense = 75;
                        BaseSpAttack = 65;
                        BaseSpDefense = 100;
                        BaseSpeed = 50;
                        BaseHealth = 105;
                        Type1 = 8;
                        Type2 = 0;
                        break;
                    }
                case 90:
                    {
                        PokemonName = "Shellder";
                        PokedexDesc = "Its hard shell repels any kind of attack. It is vulnerable only when its shell is open.";
                        BaseAttack = 65;
                        BaseDefense = 100;
                        BaseSpAttack = 45;
                        BaseSpDefense = 25;
                        BaseSpeed = 40;
                        BaseHealth = 30;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 91:
                    {
                        PokemonName = "Cloyster";
                        PokedexDesc = "When attacked, it launches its horns in quick volleys. Its innards have never been seen.";
                        BaseAttack = 95;
                        BaseDefense = 180;
                        BaseSpAttack = 85;
                        BaseSpDefense = 45;
                        BaseSpeed = 70;
                        BaseHealth = 50;
                        Type1 = 3;
                        Type2 = 6;
                        break;
                    }
                case 92:
                    {
                        PokemonName = "Gastly";
                        PokedexDesc = "Almost invisible, this gaseous POKéMON cloaks the target and puts it to sleep without notice.";
                        BaseAttack = 35;
                        BaseDefense = 30;
                        BaseSpAttack = 100;
                        BaseSpDefense = 35;
                        BaseSpeed = 80;
                        BaseHealth = 30;
                        Type1 = 14;
                        Type2 = 8;
                        break;
                    }
                case 93:
                    {
                        PokemonName = "Haunter";
                        PokedexDesc = "Because of its ability to slip through block walls, it is said to be from another dimension.";
                        BaseAttack = 50;
                        BaseDefense = 45;
                        BaseSpAttack = 115;
                        BaseSpDefense = 55;
                        BaseSpeed = 95;
                        BaseHealth = 45;
                        Type1 = 14;
                        Type2 = 8;
                        break;
                    }
                case 94:
                    {
                        PokemonName = "Gengar";
                        PokedexDesc = "Under a full moon, this POKéMON likes to mimic the shadows of people and laugh at their fright.";
                        BaseAttack = 65;
                        BaseDefense = 60;
                        BaseSpAttack = 130;
                        BaseSpDefense = 75;
                        BaseSpeed = 110;
                        BaseHealth = 60;
                        Type1 = 14;
                        Type2 = 8;
                        break;
                    }
                case 95:
                    {
                        PokemonName = "Onix";
                        PokedexDesc = "As it grows, the stone portions of its body harden to become similar to a diamond, but colored black.";
                        BaseAttack = 45;
                        BaseDefense = 160;
                        BaseSpAttack = 30;
                        BaseSpDefense = 45;
                        BaseSpeed = 70;
                        BaseHealth = 35;
                        Type1 = 13;
                        Type2 = 9;
                        break;
                    }
                case 96:
                    {
                        PokemonName = "Drowzee";
                        PokedexDesc = "Puts enemies to sleep then eats their dreams. Occasionally gets sick from eating bad dreams.";
                        BaseAttack = 48;
                        BaseDefense = 45;
                        BaseSpAttack = 43;
                        BaseSpDefense = 90;
                        BaseSpeed = 42;
                        BaseHealth = 60;
                        Type1 = 11;
                        Type2 = 0;
                        break;
                    }
                case 97:
                    {
                        PokemonName = "Hypno";
                        PokedexDesc = "When it locks eyes with an enemy, it will use a mix of PSI moves such as HYPNOSIS and CONFUSION.";
                        BaseAttack = 73;
                        BaseDefense = 70;
                        BaseSpAttack = 73;
                        BaseSpDefense = 115;
                        BaseSpeed = 67;
                        BaseHealth = 85;
                        Type1 = 11;
                        Type2 = 0;
                        break;
                    }
                case 98:
                    {
                        PokemonName = "Krabby";
                        PokedexDesc = "Its pincers are not only powerful weapons, they are used for balance when walking sideways.";
                        BaseAttack = 105;
                        BaseDefense = 90;
                        BaseSpAttack = 25;
                        BaseSpDefense = 25;
                        BaseSpeed = 50;
                        BaseHealth = 30;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 99:
                    {
                        PokemonName = "Kingler";
                        PokedexDesc = "The large pincer has 10000 hp of crushing power. However, its huge size makes it unwieldy to use.";
                        BaseAttack = 130;
                        BaseDefense = 115;
                        BaseSpAttack = 50;
                        BaseSpDefense = 50;
                        BaseSpeed = 75;
                        BaseHealth = 55;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 100:
                    {
                        PokemonName = "Voltorb";
                        PokedexDesc = "Usually found in power plants. Easily mistaken for a POKé BALL, they have zapped many people.";
                        BaseAttack = 30;
                        BaseDefense = 50;
                        BaseSpAttack = 55;
                        BaseSpDefense = 55;
                        BaseSpeed = 100;
                        BaseHealth = 40;
                        Type1 = 4;
                        Type2 = 0;
                        break;
                    }
                case 101:
                    {
                        PokemonName = "Electrode";
                        PokedexDesc = "It stores electric energy under very high pressure. It often explodes with little or no provocation.";
                        BaseAttack = 50;
                        BaseDefense = 70;
                        BaseSpAttack = 80;
                        BaseSpDefense = 80;
                        BaseSpeed = 140;
                        BaseHealth = 60;
                        Type1 = 4;
                        Type2 = 0;
                        break;
                    }
                case 102:
                    {
                        PokemonName = "Exeggcute";
                        PokedexDesc = "Often mistaken for eggs. When disturbed, they quickly gather and attack in swarms.";
                        BaseAttack = 40;
                        BaseDefense = 80;
                        BaseSpAttack = 60;
                        BaseSpDefense = 45;
                        BaseSpeed = 40;
                        BaseHealth = 60;
                        Type1 = 5;
                        Type2 = 11;
                        break;
                    }
                case 103:
                    {
                        PokemonName = "Exeggutor";
                        PokedexDesc = "Legend has it that on rare occasions, one of its heads will drop off and continue on as an EXEGGCUTE.";
                        BaseAttack = 95;
                        BaseDefense = 85;
                        BaseSpAttack = 125;
                        BaseSpDefense = 65;
                        BaseSpeed = 55;
                        BaseHealth = 95;
                        Type1 = 5;
                        Type2 = 11;
                        break;
                    }
                case 104:
                    {
                        PokemonName = "Cubone";
                        PokedexDesc = "Because it never removes its skull helmet, no one has ever seen this POKéMON's real face.";
                        BaseAttack = 50;
                        BaseDefense = 95;
                        BaseSpAttack = 40;
                        BaseSpDefense = 50;
                        BaseSpeed = 35;
                        BaseHealth = 50;
                        Type1 = 9;
                        Type2 = 0;
                        break;
                    }
                case 105:
                    {
                        PokemonName = "Marowak";
                        PokedexDesc = "The bone it holds is its key weapon. It throws the bone skillfully like a boomerang to KO targets.";
                        BaseAttack = 80;
                        BaseDefense = 110;
                        BaseSpAttack = 50;
                        BaseSpDefense = 80;
                        BaseSpeed = 45;
                        BaseHealth = 60;
                        Type1 = 9;
                        Type2 = 0;
                        break;
                    }
                case 106:
                    {
                        PokemonName = "Hitmonlee";
                        PokedexDesc = "When in a hurry, its legs lengthen progressively. It runs smoothly with extra long, loping strides.";
                        BaseAttack = 120;
                        BaseDefense = 53;
                        BaseSpAttack = 35;
                        BaseSpDefense = 110;
                        BaseSpeed = 87;
                        BaseHealth = 50;
                        Type1 = 7;
                        Type2 = 0;
                        break;
                    }
                case 107:
                    {
                        PokemonName = "Hitmonchan";
                        PokedexDesc = "While apparently doing nothing, it fires punches in lightning fast volleys that are impossible to see.";
                        BaseAttack = 105;
                        BaseDefense = 79;
                        BaseSpAttack = 35;
                        BaseSpDefense = 110;
                        BaseSpeed = 76;
                        BaseHealth = 50;
                        Type1 = 7;
                        Type2 = 0;
                        break;
                    }
                case 108:
                    {
                        PokemonName = "Lickitung";
                        PokedexDesc = "Its tongue can be extended like a chameleon's. It leaves a tingling sensation when it licks enemies.";
                        BaseAttack = 55;
                        BaseDefense = 75;
                        BaseSpAttack = 60;
                        BaseSpDefense = 75;
                        BaseSpeed = 30;
                        BaseHealth = 90;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 109:
                    {
                        PokemonName = "Koffing";
                        PokedexDesc = "Because it stores several kinds of toxic gases in its body, it is prone to exploding without warning.";
                        BaseAttack = 65;
                        BaseDefense = 95;
                        BaseSpAttack = 60;
                        BaseSpDefense = 45;
                        BaseSpeed = 35;
                        BaseHealth = 40;
                        Type1 = 8;
                        Type2 = 0;
                        break;
                    }
                case 110:
                    {
                        PokemonName = "Weezing";
                        PokedexDesc = "Where two kinds of poison gases meet, 2 KOFFINGs can fuse into a WEEZING over many years.";
                        BaseAttack = 90;
                        BaseDefense = 120;
                        BaseSpAttack = 85;
                        BaseSpDefense = 70;
                        BaseSpeed = 60;
                        BaseHealth = 65;
                        Type1 = 8;
                        Type2 = 0;
                        break;
                    }
                case 111:
                    {
                        PokemonName = "Rhyhorn";
                        PokedexDesc = "Its massive bones are 1000 times harder than human bones. It can easily knock a trailer flying.";
                        BaseAttack = 85;
                        BaseDefense = 95;
                        BaseSpAttack = 30;
                        BaseSpDefense = 30;
                        BaseSpeed = 25;
                        BaseHealth = 80;
                        Type1 = 9;
                        Type2 = 13;
                        break;
                    }
                case 112:
                    {
                        PokemonName = "Rhydon";
                        PokedexDesc = "Protected by an armor-like hide, it is capable of living in molten lava of 3,600 degrees.";
                        BaseAttack = 130;
                        BaseDefense = 120;
                        BaseSpAttack = 45;
                        BaseSpDefense = 45;
                        BaseSpeed = 40;
                        BaseHealth = 105;
                        Type1 = 9;
                        Type2 = 13;
                        break;
                    }
                case 113:
                    {
                        PokemonName = "Chansey";
                        PokedexDesc = "A rare and elusive POKéMON that is said to bring happiness to those who manage to get it.";
                        BaseAttack = 5;
                        BaseDefense = 5;
                        BaseSpAttack = 35;
                        BaseSpDefense = 105;
                        BaseSpeed = 50;
                        BaseHealth = 250;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 114:
                    {
                        PokemonName = "Tangela";
                        PokedexDesc = "The whole body is swathed with wide vines that are similar to seaweed. Its vines shake as it walks.";
                        BaseAttack = 55;
                        BaseDefense = 115;
                        BaseSpAttack = 100;
                        BaseSpDefense = 40;
                        BaseSpeed = 60;
                        BaseHealth = 65;
                        Type1 = 5;
                        Type2 = 0;
                        break;
                    }
                case 115:
                    {
                        PokemonName = "Kangaskhan";
                        PokedexDesc = "The infant rarely ventures out of its mother's protective pouch until it is 3 years old.";
                        BaseAttack = 95;
                        BaseDefense = 80;
                        BaseSpAttack = 40;
                        BaseSpDefense = 80;
                        BaseSpeed = 90;
                        BaseHealth = 105;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 116:
                    {
                        PokemonName = "Horsea";
                        PokedexDesc = "Known to shoot down flying bugs with precision blasts of ink from the surface of the water.";
                        BaseAttack = 40;
                        BaseDefense = 70;
                        BaseSpAttack = 70;
                        BaseSpDefense = 25;
                        BaseSpeed = 60;
                        BaseHealth = 30;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 117:
                    {
                        PokemonName = "Seadra";
                        PokedexDesc = "Capable of swimming backwards by rapidly flapping its wing-like pectoral fins and stout tail.";
                        BaseAttack = 65;
                        BaseDefense = 95;
                        BaseSpAttack = 95;
                        BaseSpDefense = 45;
                        BaseSpeed = 85;
                        BaseHealth = 55;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 118:
                    {
                        PokemonName = "Goldeen";
                        PokedexDesc = "Its tail fin billows like an elegant ballroom dress, giving it the nickname of the Water Queen.";
                        BaseAttack = 67;
                        BaseDefense = 60;
                        BaseSpAttack = 35;
                        BaseSpDefense = 50;
                        BaseSpeed = 63;
                        BaseHealth = 45;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 119:
                    {
                        PokemonName = "Seaking";
                        PokedexDesc = "In the autumn spawning season, they can be seen swimming powerfully up rivers and creeks.";
                        BaseAttack = 92;
                        BaseDefense = 65;
                        BaseSpAttack = 65;
                        BaseSpDefense = 80;
                        BaseSpeed = 68;
                        BaseHealth = 80;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 120:
                    {
                        PokemonName = "Staryu";
                        PokedexDesc = "An enigmatic POKéMON that can effortlessly regenerate any appendage it loses in battle.";
                        BaseAttack = 45;
                        BaseDefense = 55;
                        BaseSpAttack = 70;
                        BaseSpDefense = 55;
                        BaseSpeed = 85;
                        BaseHealth = 30;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 121:
                    {
                        PokemonName = "Starmie";
                        PokedexDesc = "Its central core glows with the seven colors of the rainbow. Some people value the core as a gem.";
                        BaseAttack = 75;
                        BaseDefense = 85;
                        BaseSpAttack = 100;
                        BaseSpDefense = 85;
                        BaseSpeed = 115;
                        BaseHealth = 60;
                        Type1 = 3;
                        Type2 = 11;
                        break;
                    }
                case 122:
                    {
                        PokemonName = "Mr. Mime";
                        PokedexDesc = "If interrupted while it is miming, it will slap around the offender with its broad hands.";
                        BaseAttack = 45;
                        BaseDefense = 65;
                        BaseSpAttack = 100;
                        BaseSpDefense = 120;
                        BaseSpeed = 90;
                        BaseHealth = 40;
                        Type1 = 11;
                        Type2 = 0;
                        break;
                    }
                case 123:
                    {
                        PokemonName = "Scyther";
                        PokedexDesc = "With ninja-like agility and speed, it can create the illusion that there is more than one.";
                        BaseAttack = 110;
                        BaseDefense = 80;
                        BaseSpAttack = 55;
                        BaseSpDefense = 80;
                        BaseSpeed = 105;
                        BaseHealth = 70;
                        Type1 = 12;
                        Type2 = 10;
                        break;
                    }
                case 124:
                    {
                        PokemonName = "Jynx";
                        PokedexDesc = "It seductively wiggles its hips as it walks. It can cause people to dance in unison with it.";
                        BaseAttack = 50;
                        BaseDefense = 35;
                        BaseSpAttack = 115;
                        BaseSpDefense = 95;
                        BaseSpeed = 95;
                        BaseHealth = 65;
                        Type1 = 6;
                        Type2 = 11;
                        break;
                    }
                case 125:
                    {
                        PokemonName = "Electabuzz";
                        PokedexDesc = "Normally found near power plants, they can wander away and cause major blackouts in cities.";
                        BaseAttack = 83;
                        BaseDefense = 57;
                        BaseSpAttack = 95;
                        BaseSpDefense = 85;
                        BaseSpeed = 105;
                        BaseHealth = 65;
                        Type1 = 4;
                        Type2 = 0;
                        break;
                    }
                case 126:
                    {
                        PokemonName = "Magmar";
                        PokedexDesc = "Its body always burns with an orange glow that enables it to hide perfectly among flames.";
                        BaseAttack = 95;
                        BaseDefense = 57;
                        BaseSpAttack = 100;
                        BaseSpDefense = 85;
                        BaseSpeed = 93;
                        BaseHealth = 65;
                        Type1 = 2;
                        Type2 = 0;
                        break;
                    }
                case 127:
                    {
                        PokemonName = "Pinsir";
                        PokedexDesc = "If it fails to crush the victim in its pincers, it will swing it around and toss it hard.";
                        BaseAttack = 125;
                        BaseDefense = 100;
                        BaseSpAttack = 55;
                        BaseSpDefense = 70;
                        BaseSpeed = 85;
                        BaseHealth = 65;
                        Type1 = 12;
                        Type2 = 0;
                        break;
                    }
                case 128:
                    {
                        PokemonName = "Tauros";
                        PokedexDesc = "When it targets an enemy, it charges furiously while whipping its body with its long tails.";
                        BaseAttack = 100;
                        BaseDefense = 95;
                        BaseSpAttack = 40;
                        BaseSpDefense = 70;
                        BaseSpeed = 110;
                        BaseHealth = 75;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 129:
                    {
                        PokemonName = "Magikarp";
                        PokedexDesc = "In the distant past, it was somewhat stronger than the horribly weak descendants that exist today.";
                        BaseAttack = 10;
                        BaseDefense = 55;
                        BaseSpAttack = 15;
                        BaseSpDefense = 20;
                        BaseSpeed = 80;
                        BaseHealth = 20;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 130:
                    {
                        PokemonName = "Gyarados";
                        PokedexDesc = "Rarely seen in the wild. Huge and vicious, it is capable of destroying entire cities in a rage.";
                        BaseAttack = 125;
                        BaseDefense = 79;
                        BaseSpAttack = 60;
                        BaseSpDefense = 100;
                        BaseSpeed = 81;
                        BaseHealth = 95;
                        Type1 = 3;
                        Type2 = 10;
                        break;
                    }
                case 131:
                    {
                        PokemonName = "Lapras";
                        PokedexDesc = "A POKéMON that has been overhunted almost to extinction. It can ferry people across the water.";
                        BaseAttack = 85;
                        BaseDefense = 80;
                        BaseSpAttack = 85;
                        BaseSpDefense = 95;
                        BaseSpeed = 60;
                        BaseHealth = 130;
                        Type1 = 3;
                        Type2 = 6;
                        break;
                    }
                case 132:
                    {
                        PokemonName = "Ditto";
                        PokedexDesc = "Capable of copying an enemy's genetic code to instantly transform itself into a duplicate of the enemy.";
                        BaseAttack = 48;
                        BaseDefense = 48;
                        BaseSpAttack = 48;
                        BaseSpDefense = 48;
                        BaseSpeed = 48;
                        BaseHealth = 48;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 133:
                    {
                        PokemonName = "Eevee";
                        PokedexDesc = "Its genetic code is irregular. It may mutate if it is exposed to radiation from element STONEs.";
                        BaseAttack = 55;
                        BaseDefense = 50;
                        BaseSpAttack = 45;
                        BaseSpDefense = 65;
                        BaseSpeed = 55;
                        BaseHealth = 55;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 134:
                    {
                        PokemonName = "Vaporeon";
                        PokedexDesc = "Lives close to water. Its long tail is ridged with a fin which is often mistaken for a mermaid's.";
                        BaseAttack = 65;
                        BaseDefense = 60;
                        BaseSpAttack = 110;
                        BaseSpDefense = 95;
                        BaseSpeed = 65;
                        BaseHealth = 130;
                        Type1 = 3;
                        Type2 = 0;
                        break;
                    }
                case 135:
                    {
                        PokemonName = "Jolteon";
                        PokedexDesc = "It accumulates negative ions in the atmosphere to blast out 10000volt lightning bolts.";
                        BaseAttack = 65;
                        BaseDefense = 60;
                        BaseSpAttack = 110;
                        BaseSpDefense = 95;
                        BaseSpeed = 130;
                        BaseHealth = 65;
                        Type1 = 4;
                        Type2 = 0;
                        break;
                    }
                case 136:
                    {
                        PokemonName = "Flareon";
                        PokedexDesc = "When storing thermal energy in its body, its temperature could soar to over 1600 degrees.";
                        BaseAttack = 130;
                        BaseDefense = 60;
                        BaseSpAttack = 95;
                        BaseSpDefense = 110;
                        BaseSpeed = 65;
                        BaseHealth = 65;
                        Type1 = 2;
                        Type2 = 0;
                        break;
                    }
                case 137:
                    {
                        PokemonName = "Porygon";
                        PokedexDesc = "A POKéMON that consists entirely of programming code. Capable of moving freely in cyberspace.";
                        BaseAttack = 60;
                        BaseDefense = 70;
                        BaseSpAttack = 85;
                        BaseSpDefense = 75;
                        BaseSpeed = 40;
                        BaseHealth = 65;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 138:
                    {
                        PokemonName = "Omanyte";
                        PokedexDesc = "Although long extinct, in rare cases, it can be genetically resurrected from fossils.";
                        BaseAttack = 40;
                        BaseDefense = 100;
                        BaseSpAttack = 90;
                        BaseSpDefense = 55;
                        BaseSpeed = 35;
                        BaseHealth = 35;
                        Type1 = 3;
                        Type2 = 13;
                        break;
                    }
                case 139:
                    {
                        PokemonName = "Omastar";
                        PokedexDesc = "A prehistoric POKéMON that died out when its heavy shell made it impossible to catch prey.";
                        BaseAttack = 70;
                        BaseDefense = 60;
                        BaseSpAttack = 125;
                        BaseSpDefense = 115;
                        BaseSpeed = 70;
                        BaseHealth = 55;
                        Type1 = 3;
                        Type2 = 13;
                        break;
                    }
                case 140:
                    {
                        PokemonName = "Kabuto";
                        PokedexDesc = "A POKéMON that was resurrected from a fossil found in what was once the ocean floor eons ago.";
                        BaseAttack = 80;
                        BaseDefense = 90;
                        BaseSpAttack = 55;
                        BaseSpDefense = 45;
                        BaseSpeed = 55;
                        BaseHealth = 30;
                        Type1 = 13;
                        Type2 = 3;
                        break;
                    }
                case 141:
                    {
                        PokemonName = "Kabutops";
                        PokedexDesc = "Its sleek shape is perfect for swimming. It slashes prey with its claws and drains the body fluids.";
                        BaseAttack = 115;
                        BaseDefense = 105;
                        BaseSpAttack = 65;
                        BaseSpDefense = 70;
                        BaseSpeed = 80;
                        BaseHealth = 60;
                        Type1 = 13;
                        Type2 = 3;
                        break;
                    }
                case 142:
                    {
                        PokemonName = "Aerodactyl";
                        PokedexDesc = "A ferocious, prehistoric POKéMON that goes for the enemy's throat with its serrated saw-like fangs.";
                        BaseAttack = 105;
                        BaseDefense = 65;
                        BaseSpAttack = 60;
                        BaseSpDefense = 75;
                        BaseSpeed = 130;
                        BaseHealth = 80;
                        Type1 = 13;
                        Type2 = 10;
                        break;
                    }
                case 143:
                    {
                        PokemonName = "Snorlax";
                        PokedexDesc = "Very lazy. Just eats and sleeps. As its rotund bulk builds, it becomes steadily more slothful.";
                        BaseAttack = 110;
                        BaseDefense = 65;
                        BaseSpAttack = 65;
                        BaseSpDefense = 110;
                        BaseSpeed = 30;
                        BaseHealth = 160;
                        Type1 = 1;
                        Type2 = 0;
                        break;
                    }
                case 144:
                    {
                        PokemonName = "Articuno";
                        PokedexDesc = "A legendary bird POKéMON that is said to appear to doomed people who are lost in icy mountains.";
                        BaseAttack = 85;
                        BaseDefense = 100;
                        BaseSpAttack = 95;
                        BaseSpDefense = 125;
                        BaseSpeed = 85;
                        BaseHealth = 90;
                        Type1 = 6;
                        Type2 = 10;
                        break;
                    }
                case 145:
                    {
                        PokemonName = "Zapdos";
                        PokedexDesc = "A legendary bird POKéMON that is said to appear from clouds while dropping enormous lightning bolts.";
                        BaseAttack = 90;
                        BaseDefense = 85;
                        BaseSpAttack = 125;
                        BaseSpDefense = 90;
                        BaseSpeed = 100;
                        BaseHealth = 90;
                        Type1 = 4;
                        Type2 = 10;
                        break;
                    }
                case 146:
                    {
                        PokemonName = "Moltres";
                        PokedexDesc = "Known as the legendary bird of fire. Every flap of its wings creates a dazzling flash of flames.";
                        BaseAttack = 100;
                        BaseDefense = 90;
                        BaseSpAttack = 125;
                        BaseSpDefense = 85;
                        BaseSpeed = 90;
                        BaseHealth = 90;
                        Type1 = 2;
                        Type2 = 10;
                        break;
                    }
                case 147:
                    {
                        PokemonName = "Dratini";
                        PokedexDesc = "Long considered a mythical POKéMON until recently when a small colony was found living underwater.";
                        BaseAttack = 64;
                        BaseDefense = 45;
                        BaseSpAttack = 50;
                        BaseSpDefense = 50;
                        BaseSpeed = 50;
                        BaseHealth = 41;
                        Type1 = 15;
                        Type2 = 0;
                        break;
                    }
                case 148:
                    {
                        PokemonName = "Dragonair";
                        PokedexDesc = "A mystical POKéMON that exudes a gentle aura. Has the ability to change climate conditions.";
                        BaseAttack = 84;
                        BaseDefense = 65;
                        BaseSpAttack = 70;
                        BaseSpDefense = 70;
                        BaseSpeed = 70;
                        BaseHealth = 61;
                        Type1 = 15;
                        Type2 = 0;
                        break;
                    }
                case 149:
                    {
                        PokemonName = "Dragonite";
                        PokedexDesc = "An extremely rarely seen marine POKéMON. Its intelligence is said to match that of humans.";
                        BaseAttack = 134;
                        BaseDefense = 95;
                        BaseSpAttack = 100;
                        BaseSpDefense = 100;
                        BaseSpeed = 80;
                        BaseHealth = 91;
                        Type1 = 15;
                        Type2 = 10;
                        break;
                    }
                case 150:
                    {
                        PokemonName = "Mewtwo";
                        PokedexDesc = "It was created by a scientist after years of horrific gene splicing and DNA engineering experiments.";
                        BaseAttack = 110;
                        BaseDefense = 90;
                        BaseSpAttack = 154;
                        BaseSpDefense = 90;
                        BaseSpeed = 130;
                        BaseHealth = 106;
                        Type1 = 11;
                        Type2 = 0;
                        break;
                    }
                case 151:
                    {
                        PokemonName = "Mew";
                        PokedexDesc = "So rare that it is still said to be a mirage by many experts. Only a few people have seen it worldwide.";
                        BaseAttack = 100;
                        BaseDefense = 100;
                        BaseSpAttack = 100;
                        BaseSpDefense = 100;
                        BaseSpeed = 100;
                        BaseHealth = 100;
                        Type1 = 11;
                        Type2 = 0;
                        break;
                    }
                default:
                    {
                        PokemonName = "Missingno";
                        PokedexDesc = "WHAT HAVE YOU DONE";
                        BaseAttack = 9001;
                        BaseDefense = 9001;
                        BaseSpAttack = 9001;
                        BaseSpDefense = 9001;
                        BaseSpeed = 9001;
                        BaseHealth = 9001;
                        Type1 = 0;
                        Type2 = 0;
                        break;
                    }
            }
        }

    }
    class Move
    {
        static int AttackDexNumber;
        public Move(int Adexnumber)
        {
            AttackDexNumber = Adexnumber;
        }
        public static void Main()
        {

        }
        public int getType()
        {
            return 0;
        }
        public int getPower()
        {
            return 35;
        }
        public int getAccuracy()
        {
            return 95;
        }
        public int getPP()
        {
            return 35;
        }
    }
}