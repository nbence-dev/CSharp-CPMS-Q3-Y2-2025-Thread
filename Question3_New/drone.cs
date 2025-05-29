using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3_New
{
    internal class drone
    {
        // Drone gets assigned a number
        public int Number { get; }

        // Only a drone can access its own distance travelled
        public int DistanceTravelled { get; private set; } = 0;
        // A static variable to keep track of the winner - a shared flag. I've learned that static variables are shared across all instances of a class.
        private static drone winner = null;
        // lock object - this ensures no thread can win at the same time, announcing inacurate results. This ensures for one winner only
        private static object lockObj = new object();
        public drone(int number)
        {
            Number = number;

        }

        public void StartRace()
        {

            Random rand = new Random();

            while (DistanceTravelled < 25)
            {

                {
                    DistanceTravelled += rand.Next(1, 6); // Randomly move between 1 and 5 km
                    Console.WriteLine($"Drone {Number} has travelled {DistanceTravelled} km.");

                    

                    // Announcing the winner (locking the object)
                    lock (lockObj)
                    {
                        if (winner == null && DistanceTravelled >= 25)
                        {
                            winner = this;
                        }

                    }
                    Thread.Sleep(1500);


                }
            }
            Console.WriteLine("==========================================================");
            Console.WriteLine($"Drone {Number} finished the race!");
            Console.WriteLine("==========================================================");
        }
        public static drone GetWinner()
        {
            // Return the winner
            return winner;
        }
        


    }
}

