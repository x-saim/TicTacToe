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
            bool gameEnd = false;

            while (!gameEnd)
            {
                // Print the game board to the console

                PrintGameBoard(board);

                
                PlayerMoveInput(currentPlayer, board);

                //Check for Win
                if (WinCheck(board))
                {
                    PrintGameBoard(board);

                    Console.WriteLine($"Player {currentPlayer} wins!");
                    gameEnd = true;
                }
                
                else
                {
                    // Check for a draw
                    if (DrawCheck(board))
                    {
                        PrintGameBoard(board);
                        Console.WriteLine("It's a draw!");
                        gameEnd = true;
                    }
                    else
                    {
                        // Switch Player
                        currentPlayer = (currentPlayer == 'X' ? 'O' : 'X');
                    }
                }


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

            if (board[row,col] == ' ' && row >= 0 && row < 3 && col >= 0 && col < 3)
            {
                //If cell is empty,or value is in the bounds then update it
                board[row, col] = player;
            }
            else
            {
                //Cell is occupied or value out of bounds. Inform player.
                Console.WriteLine("Your move was invalid as the selected cell is already occupied. Try Again.");
                PlayerMoveInput(player, board);
            }

        }

        static bool WinCheck(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                // Perform Hz. Check
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return true;

                // Perform Vert. Check
                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    return true;
            }

            // Perform Diagonal Check
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;

            // Reverse Diag. Check
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;

            return false;
        }


        // Method to check for a draw
        static bool DrawCheck(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false; // If there's an empty cell, the game is not a draw yet
                    }
                }
            }
            return true; // If all cells are filled, it's a draw
        }



    }
}
