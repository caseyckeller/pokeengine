/*
Multicore utilization in C#
About the same performance with 2 cores as Threadpool, better performance with 3 or 4 cores. Performance plateaus from there (theoretically).

Originally written in June 2008, Revised on September 27th, 2010
Written by Brenden Homan (aka bigplrbear)

NOTE- This is for .net 3.x and earlier- Youu don't need this if you have .net 4.0! Parallel.For (which may or may not be more efficient) is your friend ;)

*************************
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*************************
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pokemon.Core
{
       public delegate void Task(); //This represents a work item

   
    public static class Parallelizer //distribute work amongst multiple cores
    {
       
        static List<Task> allTasks = new List<Task>(); //list of tasks that aren't assigned a thread

       
        static List<Thread> threads = new List<Thread>(); //list of threads; should be one per core (should support Hyperthreading as well, although untested since I don't have a computer with a processor that has hyperthreading)

    
        static ManualResetEvent signal = new ManualResetEvent(false); //When Set signals that more work is to be done

        
        static bool shuttingDown = false; //used to tell threads to quit/stop working


       
        public static void Initialize(int cores) //Creates high-priority threads for performing work. Hopefully the OS will assign each thread to a separate core
//<param name="cores"></param>
        {
            for (int i = 0; i < cores; ++i)
            {
                Thread t = new Thread(ThreadMain);
                // This system is not designed to play well with others
                t.Priority = ThreadPriority.Highest;
                threads.Add(t);
                t.Start();
            }
        }

    
        public static void ReleaseThreads() //indicates to all threads that there's work to be done
        {
            signal.Set();
        }


        public static void BlockThreads() //indicates that there's no more work to be done by unsetting the signal
//!Won't work if shutting down!
        {
            if (!shuttingDown)
                signal.Reset();
        }

 
        public static Task GetTask() //Returns any tasks queued up to perform.
//Returns Null if there's no more work
//Resets the global signal effectively blocking all threads if there's no more work
//<returns></returns>
        {
            lock (allTasks)
            {
                if (allTasks.Count == 0)
                {
                    BlockThreads();
                    return null;
                }
                Task t = allTasks.Peek();
                allTasks.Pop();
                return t;
            }
        }

       
        public static void ThreadMain() //Primary function for each thread
        {
            while (!shuttingDown)
            {
               
                signal.WaitOne(); //wait for available work

               
                Task task = GetTask(); //now get a task

                
                while (task != null) //a task may still be null because another thread may have gotten to it first
                {
                    
                    task(); //DO IT

                    task = GetTask(); //NOW DO THE NEXT TASK DAMMIT
                }
            }
        }

    
        public static void DistributeWork(List<Task> localTasks) //This distributes the work across the number of threads equivalent to the number of cores
//all tasks will be run on the number of available cores
//<param name-"localTasks"></param>
        {
            
            WaitHandle[] handles = new WaitHandle[localTasks.Count]; //Create a list of handles, indicating what the main thread should wait for

            lock (allTasks)
            {
               
                for (int i = 0; i < localTasks.Count; ++i) //Iterate over the list of localTasks, creating a new task that will signal when it's done
                {
                    Task t = localTasks[i];

                    ManualResetEvent e = new ManualResetEvent(false); //Create an event used to signal that the task is finished

                    Task signalingTask = () => { t(); e.Set(); }; //create a new signaling task and add it to the list
                    allTasks.Add(signalingTask);

                 
                    handles[i] = e; //set the corresponding wait handler 
                }
            }

            
            ReleaseThreads(); //THERE'S WORK TO DO. DO IT.

            Semaphore.WaitAll(handles); //wait until all of the work items are done doing their thing
        }

 
        public static void CleanUp() //tell the system that the threads should be terminated and unblock them
        {
            shuttingDown = true;
            ReleaseThreads();
        }
    }    
}