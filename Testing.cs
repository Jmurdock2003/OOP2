using CMP1903M_A01_2223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Schema;

// Declaring Testing class
class Testing
{
    // Initializing pack
    public static Pack pack = new Pack();

    // Method to bring cards to this class
    public static List<Card> bringing_cards_to_this_class()
    {
        // Get cards list from Pack class
        List<Card> number_cards = pack.cards;
        return number_cards;
    }

    // Method to run the main menu
    public static void RunMenu()
    {

        // Display menu options to user
        Console.WriteLine("\nWelcome to the card Lincode Math Tutor!");
        Tutorial.Write();

        // Boolean variable to control the loop
        bool loop = true;
        Console.WriteLine("\nChoose a difficulty: \n1:Easy \n2:Hard \n3:Quit");
        // Loop through menu options until user chooses to end the program
        while (loop)
        {



            // Get user selection from input
            string userSelection = Console.ReadLine();

            // Switch statement to perform action based on user selection
            switch (userSelection)
            {
                // This code is executed when the user selects option "1" for the easy mode
                case "1":
                    try
                    {
                        // Create a list to hold cards
                        List<Card> number_cards = bringing_cards_to_this_class();

                        // Initialize variables
                        int correct = 0;

                        // Loop through 20 times
                        for (int i = 0; i < 20; i++)
                        {
                            // Shuffle the cards
                            pack.fisherYatesShuffle(number_cards);

                            // Deal three cards
                            Card number1 = pack.deal_number(number_cards);
                            Card number2 = pack.deal_number(number_cards);
                            Card operator1 = pack.deal_number(number_cards);

                            // Make sure the larger number is always on the left
                            if (int.Parse(number2.Numbers) > int.Parse(number1.Numbers))
                            {
                                Card temp = number1;
                                number1 = number2;
                                number2 = temp;
                            }

                            // Display the expression to the user
                            Console.WriteLine(number1.Numbers + operator1.Operators + number2.Numbers);
                            Console.WriteLine("Answer:");
                            string User_answer = Console.ReadLine();

                            // Determine the expected answer based on the operator
                            string symbol = operator1.Operators;
                            int answer = 0;
                            switch (symbol)
                            {
                                case "+":
                                    answer = AddOperator.Compute(int.Parse(number1.Numbers), int.Parse(number2.Numbers));
                                    break;
                                case "-":
                                    answer = SubtractOperator.Compute(int.Parse(number1.Numbers), int.Parse(number2.Numbers));
                                    break;
                                case "*":
                                    answer = MultiplyOperator.Compute(int.Parse(number1.Numbers), int.Parse(number2.Numbers));
                                    break;
                                case "/":
                                    answer = DivideOperator.Compute(int.Parse(number1.Numbers), int.Parse(number2.Numbers));
                                    break;
                            }

                            // Check if the user's answer is correct
                            if (User_answer == answer.ToString())
                            {
                                Console.WriteLine("Well Done! Answer Correct!");
                                correct = correct + 1;

                                // If it's the last question, show the user's score
                                if (i > 19)
                                    Tutorial.score(correct);

                            }
                            else
                            {
                                Console.WriteLine("Unlucky Wrong answer");
                                Console.WriteLine("The answer was," + answer);

                                // If it's the last question, show the user's score
                                if (i > 19)
                                    Tutorial.score(correct);
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                    break;


                // This code is executed when the user selects option "2" for the hard mode
                case "2":
                    try
                    {
                        List<Card> number_cards = bringing_cards_to_this_class();
                        int correct = 0;
                        for (int i = 0; i < 20; i++)
                        {
                            pack.fisherYatesShuffle(number_cards);
                            // output a problem                   
                            Card number1 = pack.deal_number(number_cards);
                            Card number2 = pack.deal_number(number_cards);
                            Card number3 = pack.deal_number(number_cards);
                            Card operator1 = pack.deal_number(number_cards);
                            Card operator2 = pack.deal_number(number_cards);

                            if (int.Parse(number2.Numbers) > int.Parse(number1.Numbers))
                            {
                                // swap them
                                Card temp = number1;
                                number1 = number2;
                                number2 = temp;
                            }

                            if (int.Parse(number3.Numbers) > int.Parse(number2.Numbers))
                            {
                                // swap them
                                Card temp = number2;
                                number2 = number3;
                                number3 = temp;
                            }

                            Console.WriteLine($"(({number1.Numbers}) {operator1.Operators} ({number2.Numbers})) {operator2.Operators} ({number3.Numbers})");
                            Console.WriteLine("Answer:");
                            string User_answer = Console.ReadLine();

                            int answer = 0;
                            if (operator1.Operators == "+" || operator1.Operators == "-")
                            {
                                // Add or subtract first
                                int intermediate_answer = operator1.Operators == "+" ? int.Parse(number1.Numbers) + int.Parse(number2.Numbers) : int.Parse(number1.Numbers) - int.Parse(number2.Numbers);
                                if (operator2.Operators == "+" || operator2.Operators == "-")
                                {
                                    // Add or subtract second
                                    answer = operator2.Operators == "+" ? intermediate_answer + int.Parse(number3.Numbers) : intermediate_answer - int.Parse(number3.Numbers);
                                }
                                else
                                {
                                    // Multiply or divide second
                                    int intermediate_answer2 = operator2.Operators == "*" ? intermediate_answer * int.Parse(number3.Numbers) : intermediate_answer / int.Parse(number3.Numbers);
                                    answer = intermediate_answer2;
                                }
                            }
                            else
                            {
                                // Multiply or divide first
                                int intermediate_answer = operator1.Operators == "*" ? int.Parse(number1.Numbers) * int.Parse(number2.Numbers) : int.Parse(number1.Numbers) / int.Parse(number2.Numbers);
                                if (operator2.Operators == "+" || operator2.Operators == "-")
                                {
                                    // Add or subtract second
                                    int intermediate_answer2 = operator2.Operators == "+" ? intermediate_answer + int.Parse(number3.Numbers) : intermediate_answer - int.Parse(number3.Numbers);
                                    answer = intermediate_answer2;
                                }
                                else
                                {
                                    // Multiply or divide second
                                    answer = operator2.Operators == "*" ? intermediate_answer * int.Parse(number3.Numbers) : intermediate_answer / int.Parse(number3.Numbers);
                                }
                            }

                            // Check if the user's answer is correct
                            if (User_answer == answer.ToString())
                            {
                                Console.WriteLine("Well Done! Answer Correct!");
                                correct = correct + 1;

                                // If it's the last question, show the user's score
                                if (i < 19)
                                    Tutorial.score(correct);
                            }
                            else
                            {
                                Console.WriteLine("Unlucky Wrong answer");
                                Console.WriteLine("The answer was," + answer);

                                // If it's the last question, show the user's score
                                if (i < 19)
                                    Tutorial.score(correct);
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                    break;


                // Case 3: End program
                case "3":
                    Console.WriteLine("Thankyou for using the Lincode Math Tutor see you again soon!");
                    Thread.Sleep(2000); // wait for 5 seconds
                    loop = false;
                    break;

                // Default case: Invalid selection
                default:
                    Console.WriteLine("Error: Invalid selection. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

}
