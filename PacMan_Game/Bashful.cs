using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_Game
{
    internal class Bashful : Ghost
    {
        public Bashful(string name, ConsoleColor color, int speed = 1) => setSettings(name, color, speed);

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
