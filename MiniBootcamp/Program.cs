using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBootcamp
{
    public class Program
    {
        static char[] array = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static bool gameOver = false;

        static bool turnX = true;

        static bool isLocal;

        public static void Main()
        {
            isLocal = Menu();

            while (gameOver == false)
            {
                Board();
                
                if(isLocal == true)
                {
                    LUserSelection();
                }
                else
                {
                    CUserSelection();
                }

                char x = CheckWinner();

                if(x != '0')
                {
                    Console.Clear();
                    Board();
                    Console.WriteLine();
                    Console.WriteLine($"{x} has won Tic Tac Toe!");
                }

                if (gameOver == false)
                {
                    CheckForTie();
                }
                else
                {
                    char y = ExitMenu();

                    if (y == 'Y')
                    {
                        array[1] = '1';
                        array[2] = '2';
                        array[3] = '3';
                        array[4] = '4';
                        array[5] = '5';
                        array[6] = '6';
                        array[7] = '7';
                        array[8] = '8';
                        array[9] = '9';

                        gameOver = false;
                    }
                    else if (y == 'N')
                    {
                        return;
                    }
                    else if (y == 'E')
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid Selection. Press Enter to Exit.");
                        Console.ReadLine();
                    }
                }
            }
        }

        public static bool Menu()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine();
            Console.WriteLine("Choose an Option:");
            Console.WriteLine("[1] Play Locally");
            Console.WriteLine("[2] Play Computer");
            Console.WriteLine();

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    return true;
                    break;

                case "2":
                    return false;
                    break;

                default:
                    return false;
                    break;
            }
        }

        public static void Board()
        {
            Console.Clear();

            Console.WriteLine(" {0}  | {1}  | {2}  ", array[1], array[2], array[3]);
            Console.WriteLine("____|____|____");
            Console.WriteLine(" {0}  | {1}  | {2}   ", array[4], array[5], array[6]);
            Console.WriteLine("____|____|____");
            Console.WriteLine(" {0}  | {1}  | {2}  ", array[7], array[8], array[9]);
            Console.WriteLine("    |    |    ");
        }

        public static void LUserSelection()
        {
            Console.WriteLine();
            Console.WriteLine("- - - - - - - - - -");
            Console.WriteLine();

            Console.WriteLine("Enter Square Number:");

            string userInput = Console.ReadLine();

            int num;

            bool success = int.TryParse(userInput, out num);

            if (success)
            {
                if (turnX == true)
                {
                    array[num] = 'X';

                    turnX = false;
                }
                else
                {
                    array[num] = 'O';

                    turnX = true;
                }
            }
        }
        public static void CUserSelection()
        {
            if(turnX == true)
            {
                Console.WriteLine();
                Console.WriteLine("- - - - - - - - - -");
                Console.WriteLine();

                Console.WriteLine("Enter Square Number:");

                string userInput = Console.ReadLine();

                int num;

                bool success = int.TryParse(userInput, out num);

                if (success)
                {
                    array[num] = 'X';

                    turnX = false;
                }
            }
            else
            {
                List<char> choices = new();

                foreach(char choice in array)
                {
                    if (choice != 'X' && choice != 'O' && choice != '0')
                    {
                        choices.Add(choice);
                    }
                }

                int numberOfOptions = choices.Count;

                Random random = new Random();

                int randomSelection = random.Next(1, numberOfOptions);

                string selection = choices[randomSelection].ToString();

                array[int.Parse(selection)] = 'O';

                turnX = true;

            }
        }

        static void CheckForTie()
        {
            foreach(char choice in array)
            {
                if (choice != 'X' && choice != 'O' && choice != '0')
                {
                    gameOver = false;
                    return;
                }
                else
                {
                    gameOver = true;
                }
            }
        }

        static char CheckWinner()
        {
            if (array[1] == array[2] && array[2] == array[3])
            {
                gameOver = true;

                return array[1];

            }
            else if (array[4] == array[5] && array[5] == array[6])
            {
                gameOver = true;

                return array[4];
            }
            else if (array[7] == array[8] && array[8] == array[9])
            {
                gameOver = true;

                return array[7];
            }
            else if (array[1] == array[4] && array[4] == array[7])
            {
                gameOver = true;

                return array[1];
            }
            else if (array[2] == array[5] && array[5] == array[8])
            {
                gameOver = true;

                return array[2];
            }
            else if (array[3] == array[6] && array[6] == array[9])
            {
                gameOver = true;

                return array[3];
            }
            else if (array[4] == array[5] && array[5] == array[6])
            {
                gameOver = true;

                return array[4];
            }
            else if (array[1] == array[5] && array[5] == array[9])
            {
                gameOver = true;

                return array[1];
            }
            else if (array[3] == array[5] && array[5] == array[7])
            {
                gameOver = true;

                return array[3];
            }
            else
            {
                return array[0];    
            }
        }

        static char ExitMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("- - - - - - - - - - - -");

            Console.WriteLine("Would you like to play again? (Y / N)");
            string userInput = Console.ReadLine();

                if (userInput.ToUpper() == "Y")
                {
                    return 'Y';
                }
                else if (userInput.ToUpper() == "N")
                {
                    return 'N';
                }
                else
                {
                    return 'E';
                }
        }

    }
}