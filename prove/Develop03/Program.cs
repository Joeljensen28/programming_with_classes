using System;

class Program
{
    static void Main(string[] args)
    {
        // Make a new scripture reference
        Reference firstNephiOneRef = new Reference("1 Nephi", 1, 1);
        // Add the content into it as a new content class
        Content firstNephiOne = new Content(firstNephiOneRef, "I, Nephi, having been born of goodly parents, therefore I was taught somewhat in all the learning of my father; and having seen many afflictions in the course of my days, nevertheless, having been highly favored of the Lord in all my days; yea, having had a great knowledge of the goodness and the mysteries of God, therefore I make a record of my proceedings in my days.");

        Reference estherEightNineTenRef = new Reference("Esther", 8, 9, 10);
        Content estherEightNineTen = new Content(estherEightNineTenRef, "Then were the king's scribes called at that time in the third month, that is, the month Sivan, on the three and twentieth day thereof; and it was written according to all that Mordecai commanded unto the Jews, and to the lieutenants, and the deputies and rulers of the provinces which are from India unto Ethiopia, an hundred twenty and seven provinces, unto every province according to the writing thereof, and unto every people after their language, and to the Jews according to their writing, and according to their language. And he wrote in the king Ahasuerus' name, and sealed it with the king's ring, and sent letters by posts on horseback, and riders on mules, camels, and young dromedaries.");

        // Make a list of all scriptures in the program
        List<Content> scriptures = new();
        scriptures.Add(firstNephiOne);
        scriptures.Add(estherEightNineTen);

        // Choose a random scripture from that list to memorize
        Random random = new();
        int randScriptureIndex = random.Next(0, scriptures.Count);
        Content newCont = scriptures[randScriptureIndex];
        
        // Parse the content into word objects
        newCont.ParseContent();

        // Start a while loop to continue as long as there are unhidden words
        bool memorized = false;
        while (memorized == false)
        {
            // Check if all the words are hidden/memorized. If so, memorized becomes true and the program terminates at the end of this iteration of the loop
            memorized = newCont.CheckAllHidden();
            // Clear the console
            Console.Clear();
            // Write the reference and content as a list of word objects
            newCont.GetRef().DisplayRef();
            newCont.WriteWordsList();
            // Get user input
            Console.WriteLine("\nPress enter to continue, \"quit\" to quit");
            string userChoice = Console.ReadLine();
            // Checks if everything is memorized/hidden
            if (memorized == true)
            {
                // If true, exit the program
                Environment.Exit(0);
            }
            // Convert user input to lowercase (assuming the program hasn't been exited yet)
            userChoice.ToLower();
            if (userChoice == "quit")
            {
                // Exit program if user types quit
                Environment.Exit(0);
            }
            else if (string.IsNullOrEmpty(userChoice))
            {
                // Clear console and hide three words
                Console.Clear();
                newCont.HideWords();
            }
        }
    }
}