using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace PacMan_Game
{
    class Pacman : BaseEssence
    {
        public Pacman(string name, ConsoleColor color, int speed = 1)
        {
            options(name, color, speed);
            x = Pac_Man.heightField / 2; y = Pac_Man.widthField -2;
        }

        public override void Move()
        {
            char PacmanImage = '⮋';
            while (true)
            {
                this.showEssence(PacmanImage);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        this.clearEssence(x, y);
                        //if (y > 1 && checkBorder(x, y-1)) 
                        if (y > 1)
                        {
                            if (!isWall(x, y-1))
                            ////if(checkBorder(x, y-1))
                            {
                                y--;
                                PacmanImage = '⮋';
                                DirectionNow = Direction.up;
                            }
                        }
                        break;
                    case ConsoleKey.A:
                        this.clearEssence(x, y);
                        if (x > 1)
                        {
                            try
                            { 
                                    x--;
                                    PacmanImage = '⮊';
                                DirectionNow = Direction.left;

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                        break;
                    case ConsoleKey.S:
                        this.clearEssence(x, y);
                        if (y < Pac_Man.widthField - 2)
                        {
                            y++;
                            PacmanImage = '⮉';
                            DirectionNow = Direction.down;
                        }
                        break;
                    case ConsoleKey.D:
                        this.clearEssence(x, y);
                        if (x < Pac_Man.heightField - 2)
                        {
                            x++;
                            PacmanImage = '⮈';
                            DirectionNow = Direction.right;
                        }
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        private bool isWall(int x, int y)
        {
            if (x > 2 && x < Pac_Man.widthField && y > 2 && y < Pac_Man.heightField)
                return true;
            if (Pac_Man.field[x,y] == '█')
                return true;
            return false;
        }

        //private void showPacman(int speedX, int speedY)
        //{
        //    Console.WriteLine(" ");
        //    this.x += speedX; this.y += speedY;
        //    Console.ForegroundColor = color;
        //    Console.CursorTop = this.y;
        //    Console.CursorLeft = this.x;
        //    Console.WriteLine("@");
        //}
    }
}
