using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048App
{
    internal class Program
    { /* name : Andrea Fontana
       * date : 20.11.2023
       * description : Le programme est un 2048 parfaitement fonctionnel
       */
        static void Main(string[] args)
        {
            int[,] tableVise = // initiation de la grille de jeu
            {
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
            };
            
            bool endGame = false;
            ConsoleKeyInfo consoleKey;
            initTable(tableVise);
            
            while (endGame == false) // évite de sortir du programme
            {
                printTable(tableVise);
                consoleKey = Console.ReadKey();
                switch(consoleKey.Key)
                {   
                    case ConsoleKey.UpArrow :
                        Console.WriteLine();
                        upTable(tableVise);
                        newNbr(tableVise);
                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine();
                        downTable(tableVise);
                        newNbr(tableVise);
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine();
                        leftTable(tableVise);
                        newNbr(tableVise);
                        break;
                    case ConsoleKey.RightArrow:
                        Console.WriteLine();
                        rightTable(tableVise);
                        newNbr(tableVise);
                        break;
                    default:
                        Console.WriteLine("vous n'avez pas pressé le bon bouton");
                        endGame = true;
                        break;

                }
            }
            Console.ReadLine();
        }
        static void leftTable(int[,] tableWork)
        {
            for (int i = 0; i < tableWork.GetLength(0); i++) // permet de déplacer les chiffres vers la gauche
            {
                if (tableWork[i, 2] == 0 && tableWork[i, 3] > 0) // si le 3 ème nombre = 0 et le 4 ème !=0 déplace le nombre du 4 au 3
                {
                    tableWork[i, 2] = tableWork[i, 3];
                    tableWork[i, 3] = 0;
                }
                if (tableWork[i, 1] == 0 && tableWork[i, 2] > 0) // si le 2ème nombre = 0 et 3ème nombre != 0 déplace le nombre du 3 au 2 
                {
                    tableWork[i, 1] = tableWork[i, 2];
                    tableWork[i, 2] = tableWork[i, 3];
                    tableWork[i, 3] = 0;
                }
                if (tableWork[i, 0] == 0 && tableWork[i, 1] > 0) // si le 1er nombre = 0 et le 2ème nombre !=0 déplace le nombre 2 au 1 
                {
                    tableWork[i, 0] = tableWork[i, 1];
                    tableWork[i, 1] = tableWork[i, 2];
                    tableWork[i, 2] = tableWork[i, 3];
                    tableWork[i, 3] = 0;
                }
            }

        }
        static void rightTable(int[,] tableWork)
        {
            for (int i = 0; i < tableWork.GetLength(0); i++) // permet de déplacer les chiffres vers la droite
            {
                if (tableWork[i, 1] == 0 && tableWork[i, 0] > 0) // si le 1 ème nombre = 0 et le 2 ème !=0 déplace le nombre du 1 au 2
                {
                    tableWork[i, 1] = tableWork[i, 0];
                    tableWork[i, 0] = 0;
                }
                if (tableWork[i, 2] == 0 && tableWork[i, 1] > 0) // si le 3ème nombre = 0 et 2ème nombre != 0 déplace le nombre du 2 au 3 
                {
                    tableWork[i, 2] = tableWork[i, 1];
                    tableWork[i, 1] = tableWork[i, 0];
                    tableWork[i, 0] = 0;
                }
                if (tableWork[i, 3] == 0 && tableWork[i, 2] > 0) // si le 4er nombre = 0 et le 3ème nombre !=0 déplace le nombre 3 au 4 
                {
                    tableWork[i, 3] = tableWork[i, 2];
                    tableWork[i, 2] = tableWork[i, 1];
                    tableWork[i, 1] = tableWork[i, 0];
                    tableWork[i, 0] = 0;
                }
            }
        }
        static void upTable(int[,] tableWork)
        {
            for (int i = 0; i < tableWork.GetLength(0); i++) // permet de déplacer les chiffres vers la haut
            {
                if (tableWork[2, i] == 0 && tableWork[3, i] > 0) // si le 1 ème nombre = 0 et le 2 ème !=0 déplace le nombre du 1 au 2
                {
                    tableWork[2, i] = tableWork[3, i];
                    tableWork[3, i] = 0;
                }
                if (tableWork[1, i] == 0 && tableWork[2, i] > 0) // si le 3ème nombre = 0 et 2ème nombre != 0 déplace le nombre du 2 au 3 
                {
                    tableWork[1, i] = tableWork[2, i];
                    tableWork[2, i] = tableWork[3, i];
                    tableWork[3, i] = 0;
                }
                if (tableWork[0, i] == 0 && tableWork[1, i] > 0) // si le 4er nombre = 0 et le 3ème nombre !=0 déplace le nombre 3 au 4 
                {
                    tableWork[0, i] = tableWork[1, i];
                    tableWork[1, i] = tableWork[2, i];
                    tableWork[2, i] = tableWork[3, i];
                    tableWork[3, i] = 0;
                }
            }
        }
        static void downTable(int[,] tableWork)
        {
            for (int i = 0; i < tableWork.GetLength(0); i++) // permet de déplacer les chiffres vers la haut
            {
                if (tableWork[1, i] == 0 && tableWork[0, i] > 0) // si le 1 ème nombre = 0 et le 2 ème !=0 déplace le nombre du 1 au 2
                {
                    tableWork[1, i] = tableWork[0, i];
                    tableWork[0, i] = 0;
                }
                if (tableWork[2, i] == 0 && tableWork[1, i] > 0) // si le 3ème nombre = 0 et 2ème nombre != 0 déplace le nombre du 2 au 3 
                {
                    tableWork[2, i] = tableWork[1, i];
                    tableWork[1, i] = tableWork[0, i];
                    tableWork[0, i] = 0;
                }
                if (tableWork[3, i] == 0 && tableWork[2, i] > 0) // si le 4er nombre = 0 et le 3ème nombre !=0 déplace le nombre 3 au 4 
                {
                    tableWork[3, i] = tableWork[2, i];
                    tableWork[2, i] = tableWork[1, i];
                    tableWork[1, i] = tableWork[0, i];
                    tableWork[0, i] = 0;
                }
            }
        }
        static void newNbr(int[,]tableWork)
        {   
            Random random = new Random();
            List<(int, int)> emptyPositions = new List<(int, int)>(); 
            for (int row = 0; row < 4; row++)                           // génère une liste à 2 dimensions qui contient les cases vides du tableau principal
            {
                for (int col = 0; col < 4; col++)
                {
                    if (tableWork[row, col] == 0)
                    {
                        emptyPositions.Add((row, col));
                    }
                }
            }

            if (emptyPositions.Count > 0) // si tout le tableau n'est pas remplis ajoute un 2 ou un 4 à l'intérieur
            {
                var (row, col) = emptyPositions[random.Next(emptyPositions.Count)];
                tableWork[row, col] = random.Next(0, 10) == 0 ? 4 : 2;
            }
        }
        static void initTable(int[,] tableWork)
        {
            Random random = new Random();
            for(int i = 0; i < 2; i++) // génère 2 nombres aléatoire soit 2 soit 4  
            {
             int ligne = random.Next(0, 4);
             int colonne = random.Next(0, 4);       
             tableWork[ligne, colonne] = random.Next(0,10) == 0 ? 4 : 2; // probabilité de 2% pour le 4              
            }
        }
        static void printTable(int[,] tableWork)
        {
            int tableColumn = tableWork.GetLength(0);
            int tableLine = tableWork.GetLength(0);
            for (int i = 0; i < tableColumn; i++) // permet d'afficher le tableau
            {
                for (int j = 0; j < tableLine; j++)
                {
                    Console.Write(tableWork[i, j] + " | ");
                }
                Console.WriteLine();
            }
        }
    }
}

