using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //set the variables
            List<string> board = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool ongoing = true;
            string currentPlayer = "x";
            int request = 0;

            //game loop
            while (ongoing)
            {
                printBoard(board);
                request = playerTurn(currentPlayer);

                bool validSquare = false;
                while (!validSquare)
                {
                    validSquare = validateSquare(request, board);
                    if (!validSquare)
                    {
                        Console.WriteLine("Please enter a valid square.");
                        request = playerTurn(currentPlayer);
                    }
                }

                updateBoard(board, request, currentPlayer);
                if (isGameOver(board, currentPlayer))
                {
                    ongoing = false;
                }
                else
                {
                    currentPlayer = GetNextPlayer(currentPlayer);
                }
            }
            printBoard(board);
            Console.WriteLine($"Congrats Player {currentPlayer}! You win!");


        }
        //prints the board
        static void printBoard(List<string> board)
        {
            Console.Write($"\n{board[0]}|{board[1]}|{board[2]}\n");
            Console.Write("-+-+-");
            Console.Write($"\n{board[3]}|{board[4]}|{board[5]}\n");
            Console.Write("-+-+-");
            Console.Write($"\n{board[6]}|{board[7]}|{board[8]}\n");
        }
        //player selects a square
        static int playerTurn(string player)
        {
            Console.Write($"\nPlayer {player}, it is your turn.\nPlease choose a valid square from 1-9: ");
            string answer = Console.ReadLine();

            int choice = int.Parse(answer);
            return choice;
        }
        //check that the square isn't already taken
        static bool validateSquare(int squareNumber, List<string> board)
        {
            /*if (squareNumber == (int.Parse(board[squareNumber]) - 1))
            {
                return true;
            }
            else
            {
                return false;
            }*/
            if (board[squareNumber - 1] == "x")
            {
                return false;
            }
            else if (board[squareNumber - 1] == "o")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //updates the board for the next round
        static void updateBoard(List<string> board, int request, string currentPlayer)
        {
            int index = request - 1;
            board[index] = currentPlayer;

        }
        //switch to the next player
        static string GetNextPlayer(string current)
        {
            string next = "x";
            if (current == "x")
            {
                next = "o";
            }
            return next;

        }
        //check if the game is over
        static bool isGameOver(List<string> board, string player)
        {
            bool gameEnd = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
            || (board[3] == player && board[4] == player && board[5] == player)
            || (board[6] == player && board[7] == player && board[8] == player)
            || (board[0] == player && board[3] == player && board[6] == player)
            || (board[1] == player && board[4] == player && board[7] == player)
            || (board[2] == player && board[5] == player && board[8] == player)
            || (board[0] == player && board[4] == player && board[8] == player)
            || (board[2] == player && board[4] == player && board[6] == player)
            )
            {
                gameEnd = true;
            }

            return gameEnd;

        }

    }
}