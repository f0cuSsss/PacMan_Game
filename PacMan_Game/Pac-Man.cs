using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PacMan_Game
{
    class Pac_Man
    {
        public static char[,] field;
        public static int widthField, heightField;
        public static int numberOfCoins;

        Pacman pacman;
        Shadow shadow;
        Speedy speedy;
        Bashful bashful;
        Pockey pockey;


        public Pac_Man(int width, int height)
        {
            numberOfCoins = 50;
            Console.CursorVisible = false;
            widthField = width;
            heightField = height; 
            Console.SetWindowSize(widthField+1, heightField+2);
            field = new char[heightField, widthField];
            fillField();
            //fillRandomCoins();
            pacman = new Pacman("Pacman", ConsoleColor.Yellow);
            this.shadow = new Shadow("Shadow", ConsoleColor.Red);
            //this.speedy = new Speedy("Speedy", ConsoleColor.Green); // pink
            //this.bashful = new Bashful("Bashful", ConsoleColor.Blue);
            //this.pockey = new Pockey("Pockey", ConsoleColor.Gray); // orange
            
            
        }
        
        private void fillField()
        {
            for (int i = 0; i < heightField; i++)
            {
                //field[i] = new char[heightField];
                for (int j = 0; j < widthField; j++)
                {
                    #region fillField
                    if (i == 0)
                        field[i,j] = '▓'; //field[i,j] = '_';
                    else if (i == heightField - 1)
                        field[i,j] = '▓'; // field[i,j] = '̅';
                    else if (j == 0 || j == widthField - 1)
                        field[i,j] = '░';
                    ////else if (i % 4 == 0 && j > 3 && j < widthField - 3)
                    //// field[i,j] = '֍';
                    //else if (((i == 2 || i == widthField - 2) || (i == heightField - 3 || i == widthField - 2))
                    //    && ((j > 3 && j < 12) || (j > widthField - 12 && j < widthField - 3)))
                    //    field[i,j] = '█';
                    //else if ((i == heightField - 5 || i == widthField - 3) && (j >= 15 && j <= widthField - 15))
                    //    field[i,j] = '█';

                    //else if (i > 3 && i < heightField - 4 && (j == 10 || j == 5 || j == 30 || j == 35))
                    //    field[i,j] = '█';

                    //else if (i == 5 && ((j > 2 && j < 13) || (j > 27 && j < 38)))
                    //    field[i,j] = '█';

                    //else if ((i == widthField - 8 || i == widthField - 3) && (j >= 15 && j <= widthField - 15 && j != 18 && j != 19 && j != 20 && j != 21 && j != 22))
                    //    field[i,j] = '█';
                    //else if ((!(i > heightField - 3 || i < heightField - 7) && (j == 15 || j == widthField - 15)))
                    //    field[i,j] = '█';
                    //else if ((i == heightField - 3) && (j > 16 && j < widthField - 16))
                    //    field[i,j] = '█';

                    else
                        field[i,j] = ' ';
#endregion fillField
                }
            }
        }
        // ⮋ ⮊ ⮉ ⮈
        // ☻☻☻☻
        private void showField()
        {
            for (int i = 0; i < widthField; i++)
            {
                for (int j = 0; j < heightField; j++)
                {
                    if (field[i, j] == '֍')
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    else if(field[i,j] == '▄')
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if(field[i,j] == '•')
                            Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    
                    Console.Write(field[i,j]);

                }
                Console.WriteLine();
            }
        }

        public void doPlay()
        {
            Task tPacman = new Task(this.pacman.Move, new CancellationToken());
            Task tShadow = new Task(this.shadow.Move, new CancellationToken());
            
            showField();
            tPacman.Start();
            tShadow.Start();

            while (amountOfCoint()) //!tPacman.IsCompleted
            {
                //showStatistics();
                //Console.SetCursorPosition(14, 5);
                //Console.WriteLine($"x: {pacman.getX()} y: {pacman.getY() }");




            }

            Console.WriteLine("Game over");
        }

        private void fillRandomCoins()
        {
            Random r = new Random();
            int x, y;
            for (int i = 0; i < numberOfCoins;)
            {
                x = r.Next(1, widthField - 1);
                y = r.Next(1, heightField - 1);
                if (field[x, y] == ' ')
                { 
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    field[x, y] = '•';
                    i++;
                }
            }
            //field[4][5] = coint;
        }

        private bool amountOfCoint()
        {
            if(numberOfCoins == 0)
            {
                Console.WriteLine("You win!");
                return false;
            }
            return true;
        }

        private void showStatistics()
        {
            Console.SetCursorPosition(heightField+1, widthField+2); //(height + 1, width + 2);
            Console.WriteLine("Coins: ");
        }

        private void doStep()
        {
            
        }


    }
}
