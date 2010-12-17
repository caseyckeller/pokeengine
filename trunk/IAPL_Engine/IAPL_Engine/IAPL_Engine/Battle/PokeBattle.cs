using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using IAPL.Pokemon;
using IAPL.Trainers;
using System.Reflection;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace IAPL.Battle
{
    public class PokeBattle
    {
        //TODO this
        public String outcome;
        public Player player;
        public Trainer opponent;

        public BattlePokemon[] playerPokemon;
        public BattlePokemon[] opponentPokemon;
        public BattlePokemon currentPlayerPokemon;
        public BattlePokemon currentOpponentPokemon;
        public int turnNumber;

        public PokeBattle(ref Player inPlayer, ref Trainer inOpponent)
        {
            turnNumber = 0;
            player = inPlayer;
            playerPokemon = new BattlePokemon[6];
            opponentPokemon = new BattlePokemon[6];
            int i = 0;
            //create battlepokemon for both players
            foreach (ActivePokemon poke in player.currentPokemon)
            {
                playerPokemon[i] = new BattlePokemon(ref player.currentPokemon[i]);
                i++;
            }
            opponent = inOpponent;
            i = 0;
            foreach (ActivePokemon poke in opponent.currentPokemon)
            {
                opponentPokemon[i] = new BattlePokemon(ref opponent.currentPokemon[i]);
                i++;
            }
            currentPlayerPokemon = null;
            currentOpponentPokemon = null;
            ////
        }

        public String start()
        {
            outcome = "Lose";
            bool battleOver = false;
            //do scripts that run at the beginning of a battle
            //send out first pokemon of opponent
            for (int i = 0; i < 6; i++)
            {
                if (opponentPokemon[i] != null )
                {
                    if (opponentPokemon[i].currentHealth > 0)
                    {
                        currentOpponentPokemon = opponentPokemon[i];
                        break;
                    }
                }
            }
            //send out first pokemon of player
            for (int i = 0; i < 6; i++)
            {
                if (playerPokemon[i] != null)
                {
                    if (playerPokemon[i].currentHealth > 0)
                    {
                        currentPlayerPokemon = playerPokemon[i];
                        break;
                    }
                }
            }

            while (battleOver == false)
            {
                debugShowHealths();
                battleOver = nextTurn();
            }

            declareVictory();
            return outcome;
        }

        /// <summary>
        /// Run all the steps of the next turn
        /// </summary>
        /// <returns>boolean representing whether the battle is over or not</returns>
        public bool nextTurn()
        {
            bool battleOver = false;
            //do scripts that run at the beginning of a turn
            //get move choices for each player
            BattleChoice OpponentChoice = getAIChoice();
            BattleChoice PlayerChoice = getPlayerChoice();
            
            //do run
            //do item choices if any
            
            //switch player chosen pokemon
            doSwitch(PlayerChoice, OpponentChoice);
            //do pokemon actions based on speed and priority (removing status effects, status problems, move choice)
            doMoves(PlayerChoice, OpponentChoice);
            //do status effect stuff (burn, poison)
            doStatus(currentPlayerPokemon);
            doStatus(currentOpponentPokemon);
            //do leechseed
            //wear off temporary status effects
            wearOffTemp(currentPlayerPokemon);
            wearOffTemp(currentOpponentPokemon);           
            //check whether the battle is over
            battleOver = checkOver();
            //switch fainted etc pokemon
            //do scripts that run at the end of a turn

            //finish turn
            turnNumber++;
            return battleOver;
        }

        /// <summary>
        /// returns a random move as the AI choice, doesn't run or use items at the moment
        /// </summary>
        /// <returns></returns>
        private BattleChoice getAIChoice()
        {
            Random random = new Random();
            BattleChoice choice = null;
            while (choice == null)
            {
                int num = random.Next(0, 3);
                if (currentOpponentPokemon.move[num] != null)
                {
                    choice = new BattleChoice(currentOpponentPokemon.move[num]);
                }
            }
            return choice;

        }

        /// <summary>
        /// TEMPORARY implementation of getting the player's choice
        /// </summary>
        /// <returns></returns>
        private BattleChoice getPlayerChoice()
        {
            //display prompt to ask for choice
            //TODO this is a testing implementation
            BattleChoice bChoice = null;
            Console.Write("Enter Choice\n1. Run\n2. Attack\n\n");
            String choice = Console.In.ReadLine();
            if (choice == "1")
            {
                bChoice = new BattleChoice("Run");
            }
            else if (choice == "2")
            {
                try { Console.WriteLine("1 " + currentPlayerPokemon.move[0].bMove.name); }
                catch (NullReferenceException) { }
                try { Console.WriteLine("2 " + currentPlayerPokemon.move[1].bMove.name); }
                catch (NullReferenceException) { }
                try { Console.WriteLine("3 " + currentPlayerPokemon.move[2].bMove.name); }
                catch (NullReferenceException) { }
                try { Console.WriteLine("4 " + currentPlayerPokemon.move[3].bMove.name); }
                catch (NullReferenceException) { }
                Console.Write("\nenter move: ");
                int moveNo = Convert.ToInt32(Console.ReadLine());
                bChoice = new BattleChoice(currentPlayerPokemon.move[moveNo - 1]);
            }
            else bChoice = getPlayerChoice();

            return bChoice;
        }

        /// <summary>
        /// Switch pokemon if the trainers choose to
        /// </summary>
        /// <param name="PlayerChoice"></param>
        /// <param name="OpponentChoice"></param>
        public void doSwitch(BattleChoice PlayerChoice, BattleChoice OpponentChoice)
        {
            //TODO wear off volatile effects
            //if player is faster than opponent switch theirs first
            if (currentPlayerPokemon.effectiveSpeed > currentOpponentPokemon.effectiveSpeed)
            {
                if (PlayerChoice.switchTo != -1)
                {
                    //play animation hopefully
                    currentPlayerPokemon = playerPokemon[PlayerChoice.switchTo];
                }
                if (OpponentChoice.switchTo != -1)
                {
                    //play animation hopefully
                    currentOpponentPokemon = opponentPokemon[PlayerChoice.switchTo];
                }
            }
            //if player is not faster than opponent switch theirs second
            else
            {
                if (OpponentChoice.switchTo != -1)
                {
                    //play animation hopefully
                    currentOpponentPokemon = opponentPokemon[PlayerChoice.switchTo];
                }
                if (PlayerChoice.switchTo != -1)
                {
                    //play animation hopefully
                    currentPlayerPokemon = playerPokemon[PlayerChoice.switchTo];
                }              
            }
        }

        /// <summary>
        /// does various after turn status effects such as burn and perish song
        /// </summary>
        /// <param name="inPoke">pokemon to run status effects for</param>
        public void doStatus(BattlePokemon inPoke)
        {
            if (inPoke.pokemon.status == MajorStatus.Poisoned)
            {
                inPoke.doSetDamage(inPoke.maxHealth / 8, inPoke);
                //show poison damage message
            }
            if (inPoke.pokemon.status == MajorStatus.BadPoisoned)
            {
                inPoke.doSetDamage((inPoke.badPoisonLevel * inPoke.maxHealth) / 16, inPoke);
                //make poison worse
                inPoke.badPoisonLevel++;
                //show bad poison damage message
            }
            if (inPoke.pokemon.status == MajorStatus.Burned)
            {
                inPoke.doSetDamage(inPoke.maxHealth / 8, inPoke);
                //show burn damage message
            }
            if (inPoke.partialTrapRemaining > 0)
            {
                inPoke.doSetDamage(inPoke.maxHealth / 16, inPoke);
                inPoke.partialTrapRemaining--;
                if (inPoke.partialTrapRemaining == 0)
                { inPoke.partialTrapRemaining = -1; }
            }
            if (inPoke.cursed)
            {
                inPoke.doSetDamage(inPoke.maxHealth / 4, inPoke);
                //show cursed message
            }
            if (inPoke.nightmared && inPoke.pokemon.status == MajorStatus.Sleep)
            {
                inPoke.doSetDamage(inPoke.maxHealth / 4, inPoke);
                //show nightmare message
            }
            if (inPoke.perishSongRemaining != -1)
            {
                if (inPoke.perishSongRemaining == 0)
                {
                    inPoke.doSetDamage(inPoke.maxHealth, inPoke);
                    inPoke.perishSongRemaining = -1;
                    //show perish death message
                }
                else
                {
                    inPoke.perishSongRemaining--;
                    //show perish remaining
                }
            }
            if (inPoke.tauntRemaining > 0)
            {
                inPoke.tauntRemaining--;
            }
            if (inPoke.lightScreenRemaining > 0)
            {
                inPoke.lightScreenRemaining--;
            }
            if (inPoke.reflectRemaining > 0)
            {
                inPoke.reflectRemaining--;
            }

        }

        public void wearOffTemp(BattlePokemon inPoke)
        {
            inPoke.flinched = false;
            inPoke.definiteHit = false;
            if (inPoke.pokemon.status != MajorStatus.Sleep)
            {
                inPoke.nightmared = false;
            }

        }

        private bool checkOver()
        {
            bool over = false;
            if (isBeaten(player) && isBeaten(opponent))
            {
                outcome = "Draw";
                over = true;               
            }
            else if (isBeaten(player) && !isBeaten(opponent))
            {
                outcome = "Lose";
                over = true;
            }
            else if (!isBeaten(player) && isBeaten(opponent))
            {
                outcome = "Win";
                over = true;
            }
            return over;
        }

        private bool isBeaten(Trainer inTrainer)
        {
            bool beaten = true;
            foreach (ActivePokemon poke in inTrainer.currentPokemon)
            {
                if (poke != null)
                {
                    if (poke.currentHP > 0)
                    {
                        beaten = false;
                    }
                }
            }
            return beaten;
        }

        /// <summary>
        /// Does the pokemon move scripts
        /// </summary>
        /// <param name="PlayerChoice"></param>
        /// <param name="OpponentChoice"></param>
        public void doMoves(BattleChoice PlayerChoice, BattleChoice OpponentChoice)
        {
            //TODO add different priority moves
            //TODO check for status effects which will prevent moves
            //if player is faster, use their move first
            if (currentPlayerPokemon.effectiveSpeed > currentOpponentPokemon.effectiveSpeed)
            {
                if (PlayerChoice.move != null)
                {
                    runMoveScript(PlayerChoice, currentPlayerPokemon, currentOpponentPokemon);

                }
                //TODO check faint
                if (OpponentChoice.move != null)
                {
                    runMoveScript(OpponentChoice, currentOpponentPokemon, currentPlayerPokemon);
                }
            }
            //else the opponent goes first
            else
            {
                if (OpponentChoice.move != null)
                {
                    runMoveScript(OpponentChoice, currentOpponentPokemon, currentPlayerPokemon);
                }
                //TODO check faint
                if (PlayerChoice.move != null)
                {
                    runMoveScript(PlayerChoice, currentPlayerPokemon, currentOpponentPokemon);

                }
            }

        }

        public void runMoveScript(BattleChoice choice, BattlePokemon inAttacker, BattlePokemon inDefender)
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptRuntime runtime = engine.Runtime;
            ScriptScope scope = engine.CreateScope();
            ScriptSource source;
            String rootDir = AppDomain.CurrentDomain.BaseDirectory;
            ////////////
            String scriptPath = Path.Combine(rootDir, "Moves\\Scripts\\" + choice.move.bMove.name + ".py");
            AddAssemblies(runtime);
            scope.SetVariable("attacker", inAttacker);
            scope.SetVariable("defender", inDefender);
            scope.SetVariable("move", choice.move);
            source = engine.CreateScriptSourceFromFile(scriptPath);
            source.Execute(scope);
        }

        /// <summary>
        /// Part of the scripting stuff
        /// </summary>
        /// <param name="runtime"></param>
        private void AddAssemblies(ScriptRuntime runtime)
        {
            String path = Assembly.GetExecutingAssembly().Location;
            String dir = Directory.GetParent(path).FullName;
            String ActivePokemonPath = Path.Combine(dir, "ScriptingDLL\\IAPLScripting.dll");

            Assembly assemblyPokemon = Assembly.LoadFile(ActivePokemonPath);
            runtime.LoadAssembly(assemblyPokemon);;
        }

        public void declareVictory()
        {
            //announce who won, and reward with items, badges, money
            //though maybe that should not be done here
        }

        public void debugShowHealths()
        {
            Console.WriteLine("your health: " + currentPlayerPokemon.currentHealth);
            Console.WriteLine("enemy health: " + currentOpponentPokemon.currentHealth);
        }
        
    }
}
