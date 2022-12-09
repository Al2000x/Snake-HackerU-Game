using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeGame_CSharp_OOP_Project
{
    internal class Movement : Head
    {
        public bool failState = false;
        //public void MoveRight()
        //{
        //    Console.SetCursorPosition(Head.X, head2.Y);
        //}
        public void MoveRight()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("*");
        }
    }
}
   
