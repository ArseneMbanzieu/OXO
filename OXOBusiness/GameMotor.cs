using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXOBusiness
{
    public class GameMotor
    {

        public void StartGame(string[,] gameboard)
        {

            string player1 = string.Empty;
            string player2 = string.Empty;





            InitGameBoard(gameboard);
            ChoosePlayer(ref player1, ref player2);
            PlayGame(gameboard, player1, player2);
            
        }

        private void PlayGame(string[,] gameBoard, string player1, string player2)
        {
            string winner = string.Empty;
            string currentPlayer = player1;

            while (winner == string.Empty)
            {
                Console.WriteLine($"Veuillez entrer la l'abscisse de {currentPlayer} (entre 0 et 2)");
                int posX = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"Veuillez entrer la l'ordonnée de  {currentPlayer} (entre 0 et 2)");
                int posY = Int32.Parse(Console.ReadLine());
                if (gameBoard[posX, posY] == " ")
                {
                    gameBoard[posX, posY] = currentPlayer;
                }
                PrintGameboard(gameBoard);
                winner = CheckForVictory(gameBoard, currentPlayer);

                currentPlayer = currentPlayer == player1 ? player2 : player1;
            }
            if (winner != string.Empty)
            {
                Console.WriteLine($"le vainqueur est {winner}"); 
            }
            else
            {
                Console.WriteLine("Match nul !");
            }
        }

       

        private void PrintGameboard(string[,] gameboard)
        {
            for (int row = 0; row < gameboard.GetLength(0); row++) 
            {
                //Console.WriteLine("--------------------------------");
                for (int col = 0; col < gameboard.GetLength(0); col++) 
                {
                    Console.Write(gameboard[row, col]);
                }
                Console.WriteLine();
            }
        }

        private string CheckForVictory(string[,] gameboard, string currentPlayer)
        {
            int horizontalOccurrence = 0;
            int verticalOccurrence = 0;
            int diagonalOccurrence = 0;

            for (int row = 0; row < gameboard.GetLength(0); row++)
            {
                if (horizontalOccurrence == 3)
                {
                    break;
                }
                else
                    horizontalOccurrence = 0;
                for (int col = 0; col < gameboard.GetLength(0); col++)
                {
                    if (gameboard[row, col] == currentPlayer)
                    {
                        horizontalOccurrence++;
                    }
                }
            }
            for (int row = 0; row < gameboard.GetLength(0); row++)
            {
                if (verticalOccurrence == 3)
                {
                    break;
                }
                else
                    verticalOccurrence = 0;
                for (int col = 0; col < gameboard.GetLength(0); col++)
                {
                    if (gameboard[col, row] == currentPlayer)
                    {
                        verticalOccurrence++;
                    }
                }
            }
            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                if (gameboard[i ,i] == currentPlayer)
                {
                    diagonalOccurrence++;
                }
            }
            if (diagonalOccurrence != 3)
            {
                diagonalOccurrence = 0;
                for (int i = 0; i < gameboard.GetLength(0); i++)
                {
                    if (gameboard[(gameboard.GetLength(0) - 1) - i, (gameboard.GetLength(0) - 1) - i] == currentPlayer)
                    {
                        diagonalOccurrence++;
                    }
                }
            }
            return verticalOccurrence == 3 || horizontalOccurrence == 3 || diagonalOccurrence == 3 ? currentPlayer : string.Empty;

           
        }

        private void ChoosePlayer(ref string player1, ref string player2)
        {
            Console.WriteLine("Joueur 1 veux tu être X ou O ?");
            while (true)
            {
                if (true)
                {
                    player1 = Console.ReadLine().ToUpper();
                    if (player1 == "X" || player1 == "O")
                        break;
                }
            }
            player2 = player1.ToUpper() == "X" ?  "O" : "X";
            Console.WriteLine($"Le joueur 1 est {player1}, le joueur 2 est {player2}");

        }

        private void InitGameBoard(string[,] gameBoard)
        {
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                for (int col = 0; col < gameBoard.GetLength(0); col++)
                {
                    gameBoard[row, col] = " ";
                }
               
            }
        }
    }
}
