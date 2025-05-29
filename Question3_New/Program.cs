namespace Question3_New
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("                     Drone Racing");
            
            Console.WriteLine("                 Let the race begin!");
            Console.WriteLine("==========================================================");
            Thread.Sleep(1500);
            List<drone> drones = new List<drone>();
            // Create 5 drones
            for (int i = 0; i < 5; i++)
            {
                drones.Add(new drone(i+1));
            }
            //A list of each thread (5 threads)
            List<Thread> threads = new List<Thread>();
            foreach (drone Drone in drones)
            {
                // Create a new thread for each drone and start it
                Thread thread = new Thread(Drone.StartRace);
                //Add the thread to the list of threads
                threads.Add(thread);
                thread.Start();
            }
            foreach (Thread thread in threads)
            {
                // Wait for each thread to finish
                thread.Join();
            }
            drone winner = drone.GetWinner();
            Console.WriteLine("==========================================================");
            Console.WriteLine($"\nThe winner is Drone {winner.Number}!");
            Console.WriteLine("All drones have completed the race!");  
            //Ensure all drones complete the race before exiting the program

        }
        
    }
}
