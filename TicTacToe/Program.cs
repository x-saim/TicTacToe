using System;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define the game board
            char[,] board = new char[3, 3];

            // Initialize or Reset game board

            ResetBoard(board);

            //Tracking current player (X or 0)
            char currentPlayer = 'X';


            while (true)
            {
                // Print the game board to the console

                PrintGameBoard(board);
                PlayerMoveInput(currentPlayer, board);

                //Switch Player
                currentPlayer = (currentPlayer == 'X' ? '0' : 'X');


            }
        }

        // Method to print the game board
        static void PrintGameBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($" | {board[i, j]}  ");
                    if (j == board.GetLength(1)  - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();

                // Add horizontal separation lines between rows
                if (i < board.GetLength(0) - 1)
                {
                    Console.WriteLine("--------------------");
                }
            }
        }

        //Method to reset or initialize game board.
        static void ResetBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        static void PlayerMoveInput(char player, char[,] board)
        {
            //Need to request row and column input from player.
            Console.WriteLine($"Player {player}, please enter your move (row and column): ");
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            Console.WriteLine(row);

            if (board[row,col] == ' ')
            {
                //If cell is empty, update it
                board[row, col] = player;
            }
            else
            {
                //Cell is occupied. Inform player.
                Console.WriteLine("Your move was invalid as the selected cell is already occupied. Try Again.");
                PlayerMoveInput(player, board);
            }

        }
        


    }
}
