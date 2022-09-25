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
                }

                updateBoard(board, request, currentPlayer);
                if (isGameOver(board, currentPlayer))
                {
                    ongoing = false;
                    currentPlayer = GetNextPlayer(currentPlayer);
                }
            }
            Console.WriteLine($"Congrats Player{currentPlayer}! You win!");


        }
        static void printBoard(List<string> board)
        {
            Console.WriteLine($"\n{board[0]}|{board[1]}|{board[2]}\n");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"\n{board[3]}|{board[4]}|{board[5]}\n");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"\n{board[6]}|{board[7]}|{board[8]}\n");
        }
        static int playerTurn(string player)
        {
            Console.Write($"\nPlayer {player}, it is your turn.\nPlease choose a valid square from 1-9: ");
            string answer = Console.ReadLine();

            int choice = int.Parse(answer);
            return choice;
        }
        static bool validateSquare(int squareNumber, List<string> board)
        {
            if (squareNumber == int.Parse(board[squareNumber]) - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void updateBoard(List<string> board, int request, string currentPlayer)
        {
            int index = request - 1;
            board[index] = currentPlayer;

        }
        static string GetNextPlayer(string current)
        {
            string next = "x";
            if (current == "x")
            {
                next = "o";
            }
            return next;

        }
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