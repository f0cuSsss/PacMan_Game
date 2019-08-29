using System;


namespace PacMan_Game
{
    abstract class BaseEssence
    {
        protected string name;
        protected ConsoleColor color;
        protected int speedX, speedY;
        protected int x, y;
        protected Direction DirectionNow;
        protected enum Direction { up, down, left, right };

        public void options(string name, ConsoleColor color, int speed)
        {
            this.name = name;
            this.color = color;
            this.speedX = speedY = speed;
        }

        public abstract void Move();

        public bool checkWall(int dx, int dy)
        {
            //|| Pac_Man.field[x + dx][y + dy] != '█'
           if ((x+dx) > 0 && (x + dx) < Pac_Man.widthField-1 && (y + dy) > 0 && (y + dy) < Pac_Man.heightField - 1 &&  Pac_Man.field[x + dx, y + dy] == ' ' )
                    return false;
            return true;
        }

        //public bool WallCheck(int x, int y)
        //{
        //    if (Pac_Man.field[x,y] == ' ')
        //        return false;
        //    return true;
        //}

        public bool checkBorder(int x, int y)
        {
            return x > 2 && x < this.x && y > 2 && y < this.y && Pac_Man.field[x,y] != '█' ? true : false;
        }

        public void clearEssence(int x, int y)
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.WriteLine(" ");
        }


        public void showEssence(char im)
        {
            Console.ForegroundColor = color;
            Console.CursorTop = y;
            Console.CursorLeft = this.x;
            Console.WriteLine(im.ToString());
        }

        public int getX()
        {
            return this.x;
        }


        public int getY()
        {
            return this.y;
        }
    }
}
