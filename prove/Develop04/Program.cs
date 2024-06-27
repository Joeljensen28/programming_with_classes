using System;
using TimerSpace;

class Program
{
    static void Main(string[] args)
    {
        // Create new instance of the User class
        User disciple = new User();

        string userChoice = "0";
        // Main menu loop
        while (userChoice != "6")
        {
            Console.Clear();
            Console.WriteLine($"Points: {disciple.GetPts()} -- Level: {disciple.GetLevel()}\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Create New Goal");
            Console.WriteLine("\t2. List Goals");
            Console.WriteLine("\t3. Save Goals");
            Console.WriteLine("\t4. Load Goals");
            Console.WriteLine("\t5. Record Event");
            Console.WriteLine("\t6. Quit");
            Console.WriteLine("Select a choice from the menu:");
            userChoice = Console.ReadLine();
//  111111111111111111111111111111
            if (userChoice == "1")
            {
                Console.Clear();
                // Gather data about their goal
                Console.WriteLine("\nThe types of goals are:");
                Console.WriteLine("\t1. Simple Goal");
                Console.WriteLine("\t2. Eternal Goal");
                Console.WriteLine("\t3. Checklist Goal");
                string goalChoice = Console.ReadLine();
                Console.WriteLine("What is the name of your goal?");
                string goalName = Console.ReadLine();
                Console.WriteLine("What is a short description of it?");
                string goalDescription = Console.ReadLine();
                Console.WriteLine("What is the amount of points associated with this goal?");
                int goalPoints = int.Parse(Console.ReadLine());
                // Create and append a new goal accordingly
                if (goalChoice == "1")
                {
                    Goal newGoal = new Goal(goalName, goalDescription, goalPoints);
                    disciple.AddGoal(newGoal);
                }
                else if (goalChoice == "2")
                {
                    EternalGoal newEternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);
                    disciple.AddGoal(newEternalGoal);
                }
                else if (goalChoice == "3")
                {
                    // If it is a checklist goal, gather additional data before appending it
                    Console.WriteLine("How many times does this need to be accomplished for a bonus?");
                    int goalCompletionTimes = int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the bonus for accomplishing it that many times?");
                    int goalBonusPoints = int.Parse(Console.ReadLine());
                    ChecklistGoal newChecklistGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, goalBonusPoints, goalCompletionTimes);
                    disciple.AddGoal(newChecklistGoal);
                }
                Console.WriteLine("New goal successfully added.");
                TimerSpace.Timer.Animation(2);
            }
//  22222222222222222222222222222222222
            else if (userChoice == "2")
            {
                Console.Clear();
                // Display all the goals and their completion status
                Console.WriteLine("The goals are:");
                disciple.ShowGoals();
                Console.WriteLine("Press enter to return.");
                Console.ReadLine();
                Console.WriteLine("\n");
            }
// 333333333333333333333333333333333333
            else if (userChoice == "3")
            {
                Console.Clear();
                // Saves the users goals along with all their data to a file
                Console.WriteLine("What is the name for this file?");
                string fileName = Console.ReadLine();
                disciple.SaveState(fileName);
                Console.WriteLine("File successfully saved.");
                TimerSpace.Timer.Animation(2);
            }
//  44444444444444444444444444444444444
            else if (userChoice == "4")
            {
                Console.Clear();
                // Allows the user to enter the name of a file to load
                Console.WriteLine("What is the name of the file you would like to load?");
                string fileName = Console.ReadLine();
                disciple.LoadState(fileName);
                Console.WriteLine("File successfully loaded.");
                TimerSpace.Timer.Animation(2);
            }
// 555555555555555555555555555555555555
            else if (userChoice == "5")
            {
                Console.Clear();
                // Get the current list of goals
                List<Goal> currentGoals = disciple.GetGoals();

                // Write out all the goals' titles
                Console.WriteLine("The goals are:");
                for (int i = 0; i < currentGoals.Count; i++)
                {
                    Goal tempGoal = currentGoals[i];
                    if (tempGoal.IsComplete() == false)
                    {
                        Console.Write($"{i + 1}. ");
                        Console.WriteLine(tempGoal.GetTitle());
                    }
                }

                // Get the goal the accomplished's index
                Console.WriteLine("Which one did you accomplish?");
                int accomplishedIndex = int.Parse(Console.ReadLine()) - 1;
                // Grab that index from the list
                Goal accomplishedGoal = currentGoals[accomplishedIndex];
                // Record event
                accomplishedGoal.RecordEvent();
                // Award the user the points allotted
                int pointsAwarded = accomplishedGoal.GetPts();
                disciple.SetPts(pointsAwarded);
                Console.WriteLine($"You won {pointsAwarded} points!! Great job!\n");
                TimerSpace.Timer.Animation(2);
            }
// 666666666666666666666666666666666666
            else if (userChoice == "6")
            {
                Environment.Exit(1);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please select a valid option.");
                TimerSpace.Timer.Animation(2);
            }
        }
    }
}

// This program exceeds requirements in several ways. The most notable is that it has a "Level" feature which uses a simple 
// square root function to assign a level to the user based on how many points they have, meaning the more points they have the 
// longer it takes to level up to the next level. The next most notable is that it employs a reference to the previous project, 
// accessing the animaation function. This is then used to make the UI much cleaner and more navigatable, as it allows the user
// to read messages for a second or two before clearing the console screen and returning to the main menu. The next way it 
// exceeds expectations is by reducing the number of classes by making eternal and checklist goals inherit from the simple goal, 
// thereby making the code overall more concise and cleaner with less redundancies.