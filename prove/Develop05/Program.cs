using System;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        string menuChoice = "";
        while (menuChoice != "4")
        {
            Console.Clear();
            // Menu options
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Breathing Activity");
            Console.WriteLine("\t2. Reflecting");
            Console.WriteLine("\t3. Listing Activity");
            Console.WriteLine("\t4. Quit");
            Console.Write("Select a choice from the menu: ");
            menuChoice = Console.ReadLine();

            // User input checks //
            // Breathing:
            if (menuChoice == "1")
            {
                Breathing breathing = new Breathing();
                breathing.Description();
                breathing.GetReady();
                breathing.PerformBreathing();
                breathing.Congradulate();
                breathingCount++;

                Console.WriteLine($"You have now completed the Breathing Activity {breathingCount} times this session!");
                Activity.Animation(3);
            }

            // Reflecting
            else if (menuChoice == "2")
            {
                Reflecting reflecting = new Reflecting();
                reflecting.Description();
                reflecting.GetReady();
                reflecting.PerformReflecting();
                reflecting.Congradulate();
                reflectingCount++;

                Console.WriteLine($"You have now completed the Reflecting Activity {reflectingCount} times this session!");
                Activity.Animation(3);
            }

            // Listing
            else if (menuChoice == "3")
            {
                Listing listing = new Listing();
                listing.Description();
                listing.GetReady();
                listing.PerformListing();
                listing.Congradulate();
                listingCount++;

                Console.WriteLine($"You have now completed the Listing Activity {listingCount} times this session!");
                Activity.Animation(3);
            }

            // Quit
            else if (menuChoice == "4")
            {
                Console.WriteLine("Goodbye!");
                Activity.Animation(3);
                Environment.Exit(1);
            }

            else
            {
                Console.WriteLine("Please enter an option between 1-4.");
                Activity.Animation(3);
            }
        }
    }
}

// This program meets and exceeds expectations in a few ways. The most notable is the employment of a Timer class, allowing the user to create new instances of timers, track the start time of the timer, and check if the timer is done whenever they want. This is incredibly useful as it has a function that returns true while the timer is still going, and false when it's done, making it drop-dead easy to time while loops. The other way in which this exceeds requirements is by counting how many of each activity the user has done in a session.