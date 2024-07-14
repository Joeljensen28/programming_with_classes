using System;

class Program
{
    static void Main(string[] args)
    {
        User user = new User(null);
        string userType = null;
        while (userType != "q")
        {
            Console.Clear();
            // Find out what type of user it is
            Console.WriteLine("Are you a student or teacher? (S/T or Q to quit)");
            userType = Console.ReadLine().ToLower();
            if (userType == "t")
            {
                user.SetUserType("teacher");
                string action = null;
                while (action != "q")
                {
                    // If a teacher, ask what they want to do
                    Console.Clear();
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Build a quiz");
                    Console.WriteLine("2. Give feedback/grade");
                    Console.WriteLine("Q. Quit");
                    action = Console.ReadLine().ToLower();
                    if (action == "1")
                    {
                        Console.Clear();
                        // Get data on the quiz
                        Console.WriteLine("What is the name of this quiz?");
                        string quizName = Console.ReadLine();
                        Console.WriteLine("How many questions will there be?");
                        int quizLength = int.Parse(Console.ReadLine());

                        List<Question> questions = new();

                        // Loop through a number of times equivalent to how many questions they want, making new questions each time
                        for (int i = 0; i < quizLength; i++)
                        {
                            // Find out what type of question it'll be
                            Console.Clear();
                            Console.WriteLine($"What type of question will question {i + 1} be?");
                            Console.WriteLine("1. Mutliple Choice");
                            Console.WriteLine("2. Select All");
                            Console.WriteLine("3. Free Response");
                            string questionType = Console.ReadLine();
                            
                            if (questionType == "1")
                            {
                                // Get required data for the object
                                Console.Clear();
                                Console.WriteLine("What is the question?");
                                string questionText = Console.ReadLine();

                                Console.WriteLine("How many points is it worth?");
                                int pts = int.Parse(Console.ReadLine());

                                // Gets the options for each choice
                                Console.WriteLine("Enter the choices, separated by commas and spaces (, ):");
                                string choicesInput = Console.ReadLine();
                                string[] choices = choicesInput.Split(", ");
                                string[] letters = ["A", "B", "C", "D"];

                                // Displays the choices they gave and asks which one is the correct answer
                                Console.Clear();
                                for (int j = 0; j < choices.Length; j++)
                                {
                                    string choice = choices[j];
                                    string letter = letters[j];
                                    Console.WriteLine($"{letter}. {choice}");
                                }

                                Console.WriteLine("Which letter is the correct answer?");
                                string answer = Console.ReadLine().ToLower();

                                List<string> answers = new() {answer};

                                MultipleChoice multipleChoice = new MultipleChoice(questionText, pts, answers, choices);

                                questions.Add(multipleChoice);
                            }
                            else if (questionType == "2")
                            {
                                Console.Clear();
                                Console.WriteLine("What is the question?");
                                string questionText = Console.ReadLine();

                                Console.WriteLine("How many points is it worth?");
                                int pts = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the choices, separated by commas and spaces (, ):");
                                string choicesInput = Console.ReadLine();
                                string[] choices = choicesInput.Split(", ");
                                string[] letters = ["A", "B", "C", "D"];

                                Console.Clear();
                                for (int j = 0; j < choices.Length; j++)
                                {
                                    string choice = choices[j];
                                    string letter = letters[j];
                                    Console.WriteLine($"{letter}. {choice}");
                                }

                                Console.WriteLine("Enter the correct answers separated by commas and spaces (i.e. B, C):");
                                string answer = Console.ReadLine().ToLower();

                                List<string> answers = new List<string>(answer.Split(", "));

                                SelectAll selectAll = new SelectAll(questionText, pts, answers, choices);

                                questions.Add(selectAll);
                            }
                            else if (questionType == "3")
                            {
                                Console.Clear();
                                Console.WriteLine("What is the question?");
                                string questionText = Console.ReadLine();

                                Console.WriteLine("How many points is it worth?");
                                int pts = int.Parse(Console.ReadLine());

                                FreeResponse freeResponse = new FreeResponse(questionText, pts);
                                questions.Add(freeResponse);
                            }
                        }
                        Quiz quiz = new Quiz(quizName, questions);
                        user.MakeQuiz(quiz);
                        Console.Clear();
                        Console.WriteLine("Quiz successfully saved.");
                        Thread.Sleep(2000);
                    }
                    else if (action == "2")
                    {
                        Console.Clear();
                        if (user.GetQuizzesNeedFeedback().Count() > 0)
                        {
                            List<Quiz> ungraded = new();
                            int numIndex = 1;
                            for (int i = 0; i < user.GetQuizzes().Count(); i++)
                            {
                                Quiz quiz = user.GetQuizzes()[i];
                                if (!quiz.HasFeedback() && quiz.IsComplete())
                                {
                                    Console.WriteLine($"{numIndex}. {quiz.GetQuizName()}");
                                    ungraded.Add(quiz);
                                    numIndex++;
                                }
                            }
                            Console.WriteLine("\nWhich quiz would you like to prodive feedback for?");
                            int quizIndex = int.Parse(Console.ReadLine()) - 1;
                            Quiz quizForFeedback = ungraded[quizIndex];

                            Console.Clear();
                            quizForFeedback.ReviewQuiz();
                            Console.WriteLine("\nEnter your feedback here:");
                            string feedback = Console.ReadLine();
                            quizForFeedback.SetFeedback(feedback);

                            foreach (Question question in quizForFeedback.GetQuestions())
                            {
                                if (question is FreeResponse freeResponse)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"How many points for the following? (Out of {freeResponse.GetPointValue()})");
                                    Console.WriteLine($"{freeResponse.GetResponse()}");
                                    freeResponse.SetPtsEarned(int.Parse(Console.ReadLine()));
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No quizzes to give feedback.");
                            Thread.Sleep(2000);
                        }
                    }
                }
            }
            else if (userType == "s")
            {
                user.SetUserType("teacher");
                string action = null;
                while (action != "q")
                {
                    // If a student, ask what they want to do
                    Console.Clear();
                    user.SetLetterGrade();
                    Console.WriteLine($"Current grade: {user.GetLetterGrade()}");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Take a quiz");
                    Console.WriteLine("2. Review Quizzes");
                    Console.WriteLine("Q. Quit");
                    action = Console.ReadLine().ToLower();
                    if (action == "1")
                    {
                        Console.Clear();
                        List<Quiz> incompleteQuizzes = new();
                        int numIndex = 1;
                        for (int i = 0; i < user.GetQuizzes().Count(); i++)
                        {
                            Quiz quiz = user.GetQuizzes()[i];
                            if (!quiz.IsComplete())
                            {
                                incompleteQuizzes.Add(quiz);
                                Console.WriteLine($"{numIndex}. {quiz.GetQuizName()}");
                                numIndex++;
                            }
                        }
                        if (incompleteQuizzes.Count() > 0)
                        {
                            Console.WriteLine("\nWhich quiz would you like to take?");
                            int quizIndex = int.Parse(Console.ReadLine()) - 1;

                            Quiz quizToTake = incompleteQuizzes[quizIndex];
                            quizToTake.TakeQuiz();
                        }
                        else
                        {
                            Console.WriteLine("No quizzes to take.");
                            Thread.Sleep(2000);
                        }
                    }
                    else if (action == "2")
                    {
                        if (user.GetCompleteQuizzes().Count() > 0)
                        {
                            Console.Clear();
                            for (int i = 0; i < user.GetCompleteQuizzes().Count(); i++)
                            {
                                Quiz quiz = user.GetCompleteQuizzes()[i];
                                quiz.CalculatePointsEarned();
                                Console.WriteLine($"{i + 1}. {quiz.GetQuizName()}: {quiz.CalculateScore() * 100}%");                            
                            }

                            Console.WriteLine("\nWhich quiz would you like to review?");
                            int quizIndex = int.Parse(Console.ReadLine()) - 1;

                            Quiz quizToReview = user.GetCompleteQuizzes()[quizIndex];
                            quizToReview.CalculatePointsEarned();
                            Console.Clear();
                            quizToReview.ReviewQuiz();

                            Console.WriteLine("\nPress enter to return.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("No quizzes to review.");
                            Thread.Sleep(2000);
                        }
                    }
                }
            }
        }  
    }
}