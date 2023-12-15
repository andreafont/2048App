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
        static int score = 0;
        static bool controleMove = false;

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

            for (int i = 0; i < 2; i++)
            {
                newNbr(tableVise);
            }

            while (endGame == false) // évite de sortir du programme
            {
                controleMove = false;
                printTable(tableVise);
                consoleKey = Console.ReadKey();
                switch (consoleKey.Key) // gère les différentes commandes de l'utilisateur
                {
                    case ConsoleKey.UpArrow:
                        Console.WriteLine();
                        for (int i = 0; i < tableVise.GetLength(0); i++)
                        {
                            int[] tableWork = mooveTable(tableVise[0, i], tableVise[1, i], tableVise[2, i], tableVise[3, i]);   // définit les paramêtres pour faire le déplacement vers le haut
                            tableVise[0, i] = tableWork[0];
                            tableVise[1, i] = tableWork[1];
                            tableVise[2, i] = tableWork[2];
                            tableVise[3, i] = tableWork[3];
                        }
                        if (controleMove)
                        {
                            newNbr(tableVise);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine();
                        for (int i = 0; i < tableVise.GetLength(0); i++)
                        {
                            int[] tableWork = mooveTable(tableVise[3, i], tableVise[2, i], tableVise[1, i], tableVise[0, i]);  // définit les paramêtres pour faire le déplacement vers le bas
                            tableVise[3, i] = tableWork[0];
                            tableVise[2, i] = tableWork[1];
                            tableVise[1, i] = tableWork[2];
                            tableVise[0, i] = tableWork[3];
                        }
                        if (controleMove)
                        {
                            newNbr(tableVise);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine();
                        for (int i = 0; i < tableVise.GetLength(0); i++)
                        {
                            int[] tableWork = mooveTable(tableVise[i, 0], tableVise[i, 1], tableVise[i, 2], tableVise[i, 3]);  // définit les paramêtres pour faire le déplacement vers la gauche
                            tableVise[i, 0] = tableWork[0];
                            tableVise[i, 1] = tableWork[1];
                            tableVise[i, 2] = tableWork[2];
                            tableVise[i, 3] = tableWork[3];
                        }
                        if (controleMove)
                        {
                            newNbr(tableVise);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        Console.WriteLine();
                        for (int i = 0; i < tableVise.GetLength(0); i++)
                        {
                            int[] tableWork = mooveTable(tableVise[i, 3], tableVise[i, 2], tableVise[i, 1], tableVise[i, 0]);  // définit les paramêtres pour faire le déplacement vers la droite
                            tableVise[i, 3] = tableWork[0];
                            tableVise[i, 2] = tableWork[1];
                            tableVise[i, 1] = tableWork[2];
                            tableVise[i, 0] = tableWork[3];
                        }

                        if (controleMove)
                        {
                            newNbr(tableVise);
                        }
                        break;
                    case ConsoleKey.Q:                                                       // ferme le programme
                        endGame = true;
                        break;
                    default:                                                                // gère les mauvaises commandes
                        Console.WriteLine("vous n'avez pas pressé le bon bouton");
                        break;
                }

            }
        }/// <summary>
        /// Permet de déplacer les nombres et de fusionner les nombres s'ils sont équivalents
        /// </summary>
        /// <param name="nbr1"></param>
        /// <param name="nbr2"></param>
        /// <param name="nbr3"></param>
        /// <param name="nbr4"></param>
        /// <returns>Retourne ligne par le tableau après déplacement</returns>
        static int[] mooveTable(int nbr1, int nbr2, int nbr3, int nbr4)
        {
            if (nbr3 == 0 && nbr4 > 0) // si le 3 ème nombre = 0 et le 4 ème !=0 déplace le nombre du 4 au 3
            {
                nbr3 = nbr4;
                nbr4 = 0;
                controleMove = true;
            }
            if (nbr2 == 0 && nbr3 > 0) // si le 2ème nombre = 0 et 3ème nombre != 0 déplace le nombre du 3 au 2 
            {
                nbr2 = nbr3;
                nbr3 = nbr4;
                nbr4 = 0;
                controleMove = true;
            }
            if (nbr1 == 0 && nbr2 > 0) // si le 1er nombre = 0 et le 2ème nombre !=0 déplace le nombre 2 au 1 
            {
                nbr1 = nbr2;
                nbr2 = nbr3;
                nbr3 = nbr4;
                nbr4 = 0;
                controleMove = true;
            }
            if (nbr1 == nbr2 && nbr1 != 0) // additionne les 2 premiers nombres s'ils sont égaux et ordonne les nombres
            {
                nbr1 *= 2;
                score = score + nbr1;
                nbr2 = nbr3;
                nbr3 = nbr4;
                nbr4 = 0;
                controleMove = true;
            }
            if (nbr2 == nbr3 && nbr2 != 0) // additionnes les deux nombres du centre et ordonne les nombres
            {
                nbr2 *= 2;
                score = score + nbr2;
                nbr3 = nbr4;
                nbr4 = 0;
                controleMove = true;
            }
            if (nbr3 == nbr4 && nbr3 != 0) // additionne les deux derniers nombres 
            {
                nbr3 *= 2;
                score = score + nbr3;
                nbr4 = 0;
                controleMove = true;
            }
            int[] result = { nbr1, nbr2, nbr3, nbr4 };

            return result;
        }/// <summary>
        /// Génère un nouveau nombre soit 2 soit 4 à un emplacement vide de la grille
        /// </summary>
        /// <param name="tableWork"></param>
        static void newNbr(int[,] tableWork)
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
                tableWork[row, col] = random.Next(0, 9) == 0 ? 4 : 2;
            }
        }/// <summary>
        /// Permet d'afficher la grille, le score et l'écran de fin de jeu si besoin
        /// </summary>
        /// <param name="tableWork"></param>
        static void printTable(int[,] tableWork)
        {
            Console.Clear();
            int tableColumn = tableWork.GetLength(0);
            int tableLine = tableWork.GetLength(0);
            for (int i = 0; i < tableColumn; i++) // permet d'afficher le tableau
            {
                for (int j = 0; j < tableLine; j++)
                {
                    colorNbr(tableWork[i, j]);
                    Console.Write(tableWork[i, j] + "\t");
                    Console.ResetColor();
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("score :" + score); // affiche le score
            if (theEnd(tableWork))                  // affiche l'écran de fin et ferme le programme en cas de défaite
            {
                Console.WriteLine("t'es nul, t'as perdu");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }/// <summary>
        /// Vérifie si la grille est pleine et si aucun nombre n'est fusionnable
        /// </summary>
        /// <param name="tableWork"></param>
        /// <returns>Retourne faux si 2 nombres sont fusionnables ou si la grille n'est pas pleine</returns>
        static bool theEnd(int[,] tableWork) // vérifie si la grille est complète et si il n'y a plus rien à assembler. 
        {
            bool varEnd = true; //initie la variable pour voir si la grille est pleine
            for (int i = 0; i < 4; i++) // Parcourt tout le tableau
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tableWork[i, j] == 0)
                    {
                        varEnd = false;
                    }
                }
                if (ifEnd(tableWork[i, 0], tableWork[i, 1], tableWork[i, 2], tableWork[i, 3]))// vérifie pour la ligne
                {
                    varEnd = false;
                }
                if (ifEnd(tableWork[0, i], tableWork[1, i], tableWork[2, i], tableWork[3, i])) // vérifie pour la colonne
                {
                    varEnd = false;
                }
            }
            return varEnd;
        }/// <summary>
        /// La fonction vérifie ligne par ligne si deux nombres adjacents sont fusionnnables
        /// </summary>
        /// <param name="nbr1"></param>
        /// <param name="nbr2"></param>
        /// <param name="nbr3"></param>
        /// <param name="nbr4"></param>
        /// <returns>Retourne vrai si au moins 1 paire de nombre est fusionnable</returns>
        static bool ifEnd(int nbr1, int nbr2, int nbr3, int nbr4)
        {
            if (nbr1 == nbr2 && nbr1 != 0) 
            {
                return true;
            }
            if (nbr2 == nbr3 && nbr2 != 0)
            {
                return true;
            }
            if (nbr3 == nbr4 && nbr3 != 0)
            {
                return true;
            }
            return false;
        }/// <summary>
        /// La fonction permet de changer la couleur du nombre suivant la valeur de ce dernier
        /// </summary>
        /// <param name="nbr"></param>
        static void colorNbr(int nbr)
        {
            switch (nbr) // définit les différentes couleurs à appliquer aux nombres 
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 16:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 32:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 64:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 128:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 256:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 512:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 1024:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 2048:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;

            }
        }
    }
}


