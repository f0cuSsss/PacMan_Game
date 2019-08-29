using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_Game
{

    abstract class Ghost : BaseEssence
    {
        protected void setSettings(string name, ConsoleColor color, int speed = 1)
        {
            this.x = (Pac_Man.heightField / 2);
            this.y = (Pac_Man.widthField - 2) - 5;
            options(name, color, speed);
        }


    }
}
