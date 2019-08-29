using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
   
            Pac_Man p = new Pac_Man(40, 11);
            p.doPlay();
        }
    }
}
