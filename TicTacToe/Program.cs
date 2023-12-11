using System;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define the game board
            int[,] board = new int[3, 3];

            // Print the game board to the console
            PrintGameBoard(board);
        }

        // Method to print the game board
        static void PrintGameBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
