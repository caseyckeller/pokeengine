using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace IAPL_Engine.IAPL
{

    public class RNG : IDisposable
    {

        //Variables
        private Random _rand;
        private Random _rand2;
        private List<double> _seeds;
        private bool _dispose = false;

        private System.Threading.Thread _regen;
        /// <summary>
        /// Gets or Sets the seeds that the RNG uses.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<double> Seeds
        {
            get { return _seeds; }
            set { _seeds = value; }
        }

        /// <summary>
        /// Seeds the RNG's
        /// </summary>
        /// <remarks></remarks>

        private void SeedGenerators()
        {
            //Take a few random variables from the array list
            Random _tempRNG = new Random(System.DateTime.Now.Millisecond);

            //Reseed the initial generator.
            _tempRNG = new Random(System.DateTime.Now.Millisecond + _tempRNG.Next(1, 500) + System.DateTime.Now.Second * _tempRNG.Next(0, 400));

            //Grab a random value
            double _randomVal = GetRandomSeed(_tempRNG);

            //Seed one of the RNG's
            _rand = new Random(Convert.ToInt32(Math.Abs(Math.Pow(_tempRNG.Next(1, 5), Math.Log(_randomVal)) + GetRandomSeed(_tempRNG))));

            //RNG seeded, seed the next one.
            _rand2 = new Random(Convert.ToInt32(Factoral(_rand.Next(0, 5)) + GetRandomSeed(_tempRNG)));

        }

        /// <summary>
        /// Seeds the RNG's
        /// </summary>
        /// <param name="randomNumber">Pass in a number that will be used in seeding the initial generator.</param>
        /// <remarks></remarks>

        private void SeedGenerators(int randomNumber)
        {
            //Create the initial Random Number Generator.
            Random _iRNG = new Random(System.DateTime.Now.Millisecond + randomNumber);

            //Create a temporary array to hold some other numbers.
            List<int> _list = new List<int>();

            //Grab a random number
            double _randomVal = GetRandomSeed(_iRNG);

            //Combine the two numbers
            double _newNumber = randomNumber * Math.Pow(randomNumber / 2, Math.Pow(Math.E, (Math.Round((_randomVal / 16) + 1, 0))));

            //Reseed the initial RNG
            _iRNG = new Random(Convert.ToInt32(System.DateTime.Now.Millisecond + _iRNG.Next(1, 501)));

        }

        /// <summary>
        /// Seeds the RNG's
        /// </summary>
        /// <param name="seedList">A list of random numbers to use.</param>
        /// <remarks></remarks>

        private void SeedGenerators(List<int> seedList)
        {
            //Seed the initial generator
            Random _iRNG = new Random(System.DateTime.Now.Second * seedList[seedList[_rand.Next(0, seedList.Count - 1)] > 1000 ? _rand.Next(0, seedList.Count) : _rand2.Next(0, seedList.Count)]);

            //Remove a few seeds from the seed list.
            _seeds.RemoveRange(0, _iRNG.Next(1, _seeds.Count - 1));

            //Add a few seeds to the global seed list.

            for (int i = 0; i <= _iRNG.Next(5, 11); i++)
            {
                //Add them to the list
                _seeds.Add(_iRNG.Next(1, _iRNG.Next(2, 80)));

            }

            //Reseed the main generators? Flip a coin to find out.
            int _coin = _iRNG.Next(1);

            //See if it's 'heads'

            if (_coin.Equals(0))
            {
                //Reseed them.
                _rand = new Random(Convert.ToInt32(Math.Pow(2, _iRNG.Next(4, _rand.Next(5, 11))) / 2));
                _rand2 = new Random(Convert.ToInt32(GetRandomSeed(_rand2) * Math.Exp(_iRNG.Next(0, _rand.Next(3, _rand2.Next(5, 14))))));

            }

        }

        /// <summary>
        /// Generates a new RNG
        /// </summary>
        /// <remarks></remarks>

        public RNG()
        {
            //We are not disposed
            _dispose = false;

            //We don't have our own list to start out with. We're gonna have to make our own. >.<
            Random _rnd = new Random(System.DateTime.Now.Millisecond * Math.Abs((System.DateTime.Now.Year - (System.DateTime.Now.Month + System.DateTime.Now.Hour))));

            //OK, now should I reseed myself? Fuck it I don't care. Give me 100 numbers randomly.
            for (int i = 1; i <= 100; i++)
            {
                int _num = _rnd.Next(3, 100);
                _seeds.Add(_num < 30 ? Factoral(_num) : _num);
            }

            //Get the Generators ready.
            this.SeedGenerators();

            //Everything seeded, start the thread that reseeds everything.
            _regen = new System.Threading.Thread(this.ConstantRNG) { IsBackground = true };
            _regen.Start();

        }

        /// <summary>
        /// Generates a new RNG
        /// </summary>
        /// <param name="_arr">The List(Of Double) to use in the seed determination.</param>
        /// <remarks></remarks>

        public RNG(List<double> _arr)
        {
            //We are not disposed
            _dispose = false;

            //Take a few random variables from the array list
            Random _tempRNG = new Random(System.DateTime.Now.Millisecond);

            //See if the List is empty.

            if (_arr.Count.Equals(0))
            {
                //Well that's freaking lovely. We need some bullshit data.
                for (int i = 1; i <= 50; i++)
                {
                    _arr.Add(_tempRNG.Next(1, 900));
                }

            }

            //Assign the seeds to use for later
            _seeds = _arr;

            //Get the Generators ready.
            this.SeedGenerators();

            //Everything seeded, start the thread that reseeds everything.
            _regen = new System.Threading.Thread(this.ConstantRNG) { IsBackground = true };
            _regen.Start();

        }

        /// <summary>
        /// Gets the next number.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public double Advance()
        {

            //Throw an ObjectDisposedException if we have been disposed.
            if (_dispose)
                throw new ObjectDisposedException("RNG");

            //Get another Random object.
            Random _rand3 = new Random(_rand.Next(1, 16) * _rand.Next(1, 5) + _rand2.Next(32, 100));

            //Determine a number.
            double _number = (Math.Pow(Math.E, _rand3.Next(0, 13))) / Math.Round(Math.Sqrt(GetRandomSeed(_rand3)) * 100);

            //DEBUG
            Debug.WriteLine(string.Format("Number 1: {0}", _number));

            //Get another number.
            double _number2 = Math.Round(Math.Log(GetRandomSeed(_rand2)) + _rand3.Next(0, Convert.ToInt32(GetRandomSeed(_rand) + 1)), 0);

            //DEBUG
            Debug.WriteLine(string.Format("Number 2: {0}", _number2));

            //Perform modifications.
            _number = Math.Pow(_number, _rand.Next(_rand3.Next(1, 4), _rand2.Next(3, 5)) / _rand.Next(1, 5));

            //DEBUG
            Debug.WriteLine(string.Format("Number 1: {0}", _number));

            //Return
            return Math.Abs(Math.Round(_number, 0) * _rand.Next(2, _rand3.Next(4, 8)) - _number2);

        }

        /// <summary>
        /// Gets the next number with the specified bounds.
        /// </summary>
        /// <param name="min">The minimum value that the number can be.</param>
        /// <param name="max">The maximum value that the number can be.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public double Advance(int min, int max)
        {

            //Throw an ObjectDisposedException if we have been disposed.
            if (_dispose)
                throw new ObjectDisposedException("RNG");

            //If the minimum is lower then the maximum.

            if (min < max)
            {
                //Get another Random object.
                Random _rand3 = new Random(Convert.ToInt32((_rand.Next(1, 16) + _rand2.Next(32, 52)) / (GetRandomSeed(_rand) / 2)));

                //Seed it again
                _rand3 = new Random(Convert.ToInt32(_rand.Next(15, 300) / _rand3.Next(2, 9)));
                _rand3 = new Random(Convert.ToInt32(GetRandomSeed(_rand3) + Math.Pow(Math.E, _rand3.Next(1, _rand.Next(1, 20)))));

                //Return a new value.
                return _rand3.Next(min, max + 1);


            }
            else
            {
                //Throw an error
                throw new ArgumentException(string.Format("{0} is not less then {1}!", min, max), min.ToString());

            }

        }

        /// <summary>
        /// Gets a List of random numbers with the specified bounds.
        /// </summary>
        /// <param name="min">The minimum value that the number can be.</param>
        /// <param name="max">The maximum value that the number can be.</param>
        /// <param name="count">The length of the list of numbers.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<double> AdvanceRange(int min, int max, int count)
        {

            //Create the return list
            List<double> _list = new List<double>();

            //Setup a loop to generate the numbers!
            for (int i = 1; i <= count; i++)
            {
                _list.Add(this.Advance(min, max));
            }

            //Return the list
            return _list;

        }

        /// <summary>
        /// Returns a Random object.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private Random GetRandom()
        {

            //Create a new random.
            Random _random = new Random(Convert.ToInt32(System.DateTime.Now.Ticks / (System.DateTime.Now.Millisecond / 8)));

            //Find out what number was selected.
            switch (_random.Next(1, 4))
            {
                case 1:
                    return _rand;
                case 2:
                    return _rand2;
                default:
                    return _random;
            }

        }

        /// <summary>
        /// Gets a random seed.
        /// </summary>
        /// <param name="rnd">The Random Number Generator to use.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private double GetRandomSeed(Random rnd)
        {


            try
            {
                //Return a Random value from the seed list.
                return _seeds[rnd.Next(0, _seeds.Count - 1)];


            }
            catch (ArgumentOutOfRangeException)
            {
                //ERROR
                return rnd.Next(0, 5000);

            }

        }

        /// <summary>
        /// Performs a factoral operation on a number.
        /// </summary>
        /// <param name="start">The beginning number.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private double Factoral(int start)
        {

            //Create the return value.
            double _retVal = 1;

            //If we start at 0, 0! = 1, generic math rule.
            if (start == 0)
            {
                return 1;
            }
                else if (start > 0)
            {
                //Setup the for loop
                for (int i = start; i >= 1; i += -1)
                {
                    //Multiply the return value by the term.
                    _retVal *= i;

                }

            }

            else
            {

                //Throw an exception.
                throw new ArgumentException("You cannot have a negative number!", "start");

            }
            
            //Return it.
            return _retVal;

        }

        /// <summary>
        /// Runs on a background thread to constantly reseed the Random Number Generators.
        /// </summary>
        /// <remarks></remarks>

        private void ConstantRNG()
        {
            //Infinitely loop this.
            do
            {
                //Rest anywhere from 10 to 52 seconds before doing this.
                System.Threading.Thread.Sleep(_rand.Next(10000, 52001));

                //Debug
                Debug.WriteLine("Beginning to re-seed the RNG. Method being selected.");

                //Setup a try to catch any thread exceptions.

                try
                {
                    //Generate a number between 1 and 3
                    int _number = Convert.ToInt32(this.Advance(1, 3));

                    //Figure out what method to use.
                    switch (_number)
                    {

                        case 1:
                            Debug.WriteLine("Method 1 was selected.");
                            //Method one; same method used when the system is initialized.
                            this.SeedGenerators();

                            break;
                        case 2:
                            Debug.WriteLine("Method 2 was selected.");
                            //Method two; alternate method.
                            this.SeedGenerators(_rand.Next(501));

                            break;
                        case 3:
                            //Method three; generates new seeders and RNG's
                            Debug.WriteLine("Method 3 was selected.");
                            //Create a new List of random values.
                            List<int> _seeds = new List<int>();
                            for (int i = 0; i <= _rand.Next(8, 50); i++)
                            {
                                _seeds.Add(_rand.Next(1, 2000));
                            }


                            //Call method three.
                            this.SeedGenerators(_seeds);

                            break;
                    }

                    Debug.WriteLine("The RNG has been re-seeded!");

                    //Catch that exception!

                }
                catch (System.Threading.ThreadAbortException tae)
                {
                    //Write out the debug information.
                    Debug.WriteLine(tae.ExceptionState.ToString());

                    //Exit the Do Loop
                    break; // TODO: might not be correct. Was : Exit Do

                }

            } while (!_dispose);

        }

        /// <summary>
        /// Disposes the RNG
        /// </summary>
        /// <remarks></remarks>

        public void Dispose()
        {
            //Set the internal flag to true
            _dispose = true;

            //Abort the thread.
            _regen.Abort("Disposing the Thread");

            //Set the generators to nothing.
            _rand = null;
            _rand2 = null;

            //Clear the seeds list
            _seeds.Clear();

            //Force a garbage collection
            GC.Collect();

        }

    }

}
