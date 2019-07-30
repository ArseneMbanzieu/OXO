using OXOBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXO_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] gameboard = new string[3, 3];
            GameMotor motor = new GameMotor();
            motor.StartGame(gameboard);
            Console.Read();
        }
    }
}
