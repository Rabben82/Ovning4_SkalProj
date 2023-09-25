using System;
using System.Net.WebSockets;
using System.Runtime.InteropServices;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>

        #region Questions ExamineList
        //2. Listan ökar ner den närmar sig dess aktuella kapacitetgräns, vilket som standard verkar vara 4:a.
        //3. Kapaciteten ökar med att fördubbla sig i värde alltså gånger 2.
        //4. För att undvika onödig minnesallokering och deallokering vid varje enskild operation, detta förbättrar prestandan.
        //5. Nej! Detta görs för att undvika onödig minnesallokering när element tas bort och senare läggs till igen.
        //6. När du vet storleken på arrayen.
        //Det ger dig mer kontroll över hur minnet hanteras och kan vara användbart i prestandakänsliga applikationer

        #endregion
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            bool isTrue = false;
            List<string> theList = new List<string>();
            string userInput;

            try
            {
                do
                {
                    Console.Clear();

                    Console.WriteLine("Hi and welcome!" +
                                      "\nDo you wanna add or remove a name to the list?" +
                                      "\nPress (+) to add name to list or (-) to remove name from list" +
                                      "\nPress (E) to exit to main menu.");
                    string input = Console.ReadLine()!;
                    char nav = input[0];
                    string value = input.Substring(1).Trim();

                    switch (nav)
                    {
                        case '+':
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                Console.Write("Enter name to add: ");
                                userInput = Console.ReadLine()!.ToLower();
                                theList.Add(userInput);
                            }
                            else
                            {
                                theList.Add(value);
                            }


                            foreach (var name in theList)
                            {
                                Console.WriteLine($"Name in list: {name}");
                            }

                            Console.WriteLine(theList.Capacity);
                            Console.ReadKey();
                            break;
                        case '-':
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                Console.Write("Enter Name to remove: ");
                                userInput = Console.ReadLine()!.ToLower();
                                theList.Remove(userInput);
                            }
                            else
                            {
                                theList.Remove(value);
                            }

                            foreach (var name in theList)
                            {
                                Console.WriteLine($"Name in list: {name}");
                            }
                            Console.WriteLine(theList.Capacity);
                            Console.ReadKey();

                            break;
                        case 'e':
                            isTrue = true;
                            break;
                        default:
                            Console.Clear();
                            throw new ArgumentException("You can only use + to add a name or - to remove a name" +
                                                        "\nPress any key to try again!");
                    }


                } while (!isTrue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                ExamineList();

            }
        }
        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
             */
            try
            {
                Queue<string> personList = new Queue<string>();
                bool isTrue = false;

                string userInput;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Ica has opened and the que to the cashier is empty" +
                                      "\nYou are gonna simulate this particular case!" +
                                      "\nKalle is entering the queue" +
                                      "\nGreta is entering the queue" +
                                      "\nKalle is being expedited and are leaving the queue" +
                                      "\nStina is entering the que" +
                                      "\nGreta is being expedited and are leaving the queue" +
                                      "\nOlle is entering the queue\n");
                    Console.WriteLine("To add person to queue press (+)" +
                                      "\nTo remove a person from the queue press (-)" +
                                      "\nTo exit to main menu press (E)");
                    ConsoleKey userInputKey = Console.ReadKey(true).Key;

                    switch (userInputKey)
                    {
                        case ConsoleKey.Add:
                            Console.Write("Enter person to add to queue: ");
                            userInput = Console.ReadLine()!.ToLower();
                            personList.Enqueue(userInput);

                            foreach (var person in personList)
                            {
                                Console.Write($"Person: {person} is entering the queue\n");

                            }

                            Console.WriteLine("\nPress any key to continue!");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.Subtract:

                            Console.WriteLine($"{personList.ToArray().GetValue(0)!.ToString()} is being expedited and are leaving the queue");
                            personList.Dequeue();
                            foreach (var person in personList)
                            {
                                Console.WriteLine($"{person} is still in the queue");
                            }

                            Console.ReadKey();
                            break;
                        case ConsoleKey.E:
                            isTrue = true;
                            break;
                        default:
                            Console.Clear();
                            throw new ArgumentException("Invalid input, enter (+) to add or (-) to remove" +
                                                        "\nPress any key to try again.");

                    }

                } while (!isTrue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                ExamineQueue();
            }


        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            try
            {
                Stack<string> personList = new Stack<string>();
                bool isTrue = false;
                string userInput;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Ica has opened and the que to the cashier is empty" +
                                      "\nYou are gonna simulate this particular case!" +
                                      "\nKalle is entering the queue" +
                                      "\nGreta is entering the queue" +
                                      "\nKalle is being expedited and are leaving the queue" +
                                      "\nStina is entering the que" +
                                      "\nGreta is being expedited and are leaving the queue" +
                                      "\nOlle is entering the queue\n");
                    Console.WriteLine("To add person to queue press (+)" +
                                      "\nTo remove a person from the queue press (-)" +
                                      "\nTo ReverseText press (R)" +
                                      "\nTo exit to main menu press (E)");

                    ConsoleKey userInputKey = Console.ReadKey(true).Key;

                    switch (userInputKey)
                    {
                        case ConsoleKey.Add:
                            Console.Write("Enter person to add to queue: ");
                            userInput = Console.ReadLine()!.ToLower();
                            personList.Push(userInput);

                            foreach (var person in personList)
                            {
                                Console.Write($"Person: {person} is entering the queue\n");

                            }

                            Console.WriteLine("\nPress any key to continue!");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.Subtract:

                            Console.WriteLine($"{personList.ToArray().GetValue(0)!.ToString()} is being expedited and are leaving the queue");
                            personList.Pop();
                            foreach (var person in personList)
                            {
                                Console.WriteLine($"{person} is still in the queue");
                            }

                            Console.ReadKey();
                            break;
                        case ConsoleKey.E:
                            isTrue = true;
                            break;
                        case ConsoleKey.R:
                            ReverseText();
                            break;
                        default:
                            Console.Clear();
                            throw new ArgumentException("Invalid input, enter (+) to add or (-) to remove" +
                                                        "\nPress any key to try again.");
                    }
                } while (!isTrue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                ExamineQueue();
            }
        }

        #region Questions ExamineStack

        //1. Att använda en stack i simuleringen av en ICA-kö skulle inte vara särskilt smart
        //eftersom stacken följer principen "Först In Sist Ut" (FILO).
        //Det betyder att det element som stoppas in först i stacken är det som kommer att tas bort sist.
        //I en kö, å andra sidan, används principen "Först In Först Ut" (FIFO),
        //vilket innebär att det element som kommer in först i kön är det som tas ut först.
        //Om du skulle använda en stack för att simulera en kö, skulle du inte uppnå rätt beteende
        //för en kö, och det skulle vara problematiskt att hantera elementen i rätt ordning.

        #endregion
        static void ReverseText()
        {
            Stack<char> charStack = new Stack<char>();

            Console.WriteLine("Write a text you wanna reverse!");
            string userInput = Console.ReadLine()!;


            foreach (char c in userInput) //use a foreach loop to add each character to the character list
            {
                charStack.Push(c);
            }

            char[] reversedChars = new char[userInput.Length]; // creates a new character array with the size of the original characters in the userInput text

            for (int i = 0; i < userInput.Length; i++) //Then, it uses a for loop to pop characters from the stack (charStack)
                                                       //and place them into the empty array (reversedChars) in reverse order.
                                                       //Since a stack follows the "First In Last Out" (FILO) principle
            {
                reversedChars[i] = charStack.Pop();
            }

            Console.WriteLine(reversedChars);

            Console.ReadKey();
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            Stack<char> stack = new Stack<char>();

            Console.Clear();
            Console.WriteLine("Use this method to check if the parenthesis in a string are correct or incorrect" +
                              "\nEnter a text!");

            string userInput = Console.ReadLine()!;

            foreach (char character in userInput)
            {
                if (IsOpeningParenthesis(character)) //If the character is an opening parenthesis '(', '{', '[' it is pushed onto the stack.
                {
                    stack.Push(character);
                }
                else if (IsClosingParenthesis(character))//If the character is a closing parenthesis ')', '}', ']', the code checks if the string have an valid end parenthesis and if it is a match or a miss match
                {
                    if (stack.Count == 0 || !IsMatchingPair(stack.Pop(), character)) //IsMatchingPair(stack.Pop(), character): if the string has an valid end parenthesis, it checks if it miss matches with the current opening one. If it does miss match it enters the if, if it doesn't its a match and enters the else 
                    {
                        Console.WriteLine("You have an end Parenthesis but it's a miss match!");
                        Console.ReadKey();
                        return; // Exit the method when a mismatch is found.
                    }
                    else
                    {
                        Console.WriteLine("It matches, the parenthesis is well formed!!");
                        Console.ReadKey();
                        return;
                    }
                }
            }

            if (stack.Count != 0)// this checks if the list still has an opening Parenthesis in the list, it means the user hasn't entered an end Parenthesis
            {
                Console.WriteLine("You don't have an end Parenthesis!");
            }
            else
            {
                Console.WriteLine("You don't have any Parenthesis");
            }
            Console.ReadKey();
        }
        static bool IsOpeningParenthesis(char c)
        {
            return c == '(' || c == '{' || c == '[';
        }

        static bool IsClosingParenthesis(char c)
        {
            return c == ')' || c == '}' || c == ']';
        }

        static bool IsMatchingPair(char opening, char closing)
        {
            return (opening == '(' && closing == ')') ||
                   (opening == '{' && closing == '}') ||
                   (opening == '[' && closing == ']');
        }

    }

    #region Exercise 4, Questions
    //1. Stacken används för att lagra value type typer i en strikt ordning som kallas "last in first out".
    //Stacken är självunderhållande dvs hanterar att rensa minnet själv.

    //Heapen lagrar data utan någon specifik ordning. Allokering och deallokering är något som måste skötas manuellt,
    //det finns ingen automatisk hantering av minnet så som stacken.

    //2. Value types är värdestyper, lagrar själva värdet av data direkt i variabeln eller objektet.
    //Detta innebär att när du kopierar en värdestypvariabel till en annan, kopieras själva värdet, och de är oberoende av varandra.
    //De lagras på stacken beroende på var du deklarera den, och hanterar att rensa minnet själv.

    //Reference types, lagrar en referens (adress) till data i minnet istället för själva värdet så som value types.
    //När du kopierar en referenstypvariabel, kopierar du referensen, vilket innebär att de pekar på samma dataobjekt.
    //De lagras på heapen, detta gör det möjligt att hantera dynamiskt allokerat minne och att dela data mellan flera variabler.

    //3. I det första exemplet så används value types, detta innebär att när du kopierar en värdestypvariabel till en annan,
    //kopieras själva värdet, och de är oberoende av varandra. Du kopierar alltså egentligen bara värdet ifrån x och sätter det i en ny variabel.
    //Därav kvarstår värdet utav x, alltså 3.

    //I det andra exemplet används reference types, när du kopierar en referenstypvariabel, kopierar du referensen, vilket innebär att de pekar på samma dataobjekt.
    //eftersom du koierar x värdet till y, så pekar dem mot samma objekt och när du då ändrar värdet på y så ändrar du samtidigt värde på x, därav svaret y=4.


    #endregion
}

