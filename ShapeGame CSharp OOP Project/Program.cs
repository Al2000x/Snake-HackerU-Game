using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml;

namespace ShapeGame_CSharp_OOP_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int x, y;
            bool failState = false;
            x = rnd.Next(0, 80);
            y = rnd.Next(0, 25);
            Snake head = new Head();
            Head head2 = (Head)head;
            head2.X = x;
            head2.Y = y;
            ConsoleDimensions();
            Console.SetCursorPosition(head2.X, head2.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(head.SnakeHead);
            BeginGame(failState,x,y);
           
           
        }   
        
        static void BeginGame(bool failState, int x, int y)
        {
            while (failState == false)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.RightArrow:
                        MoveRight(ref x, ref y, ref failState);
                        FailStateCheck(failState);
                        break;
                    case ConsoleKey.LeftArrow:
                        break;
                }
            }
        }
        static void MoveRight(ref int x, ref int y,ref bool failState)
        {
            if (x >= 79)
            {
                failState = true;
            }
            else
            {
                x++;
                Console.Write("*");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
           
        }
        static void FailStateCheck(bool failState)
        {
            if (failState == true)
            {
                Console.Clear();
                Console.WriteLine("you colided with something :(");
                Console.ReadLine();
            }
        }
        static void ConsoleDimensions()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WindowWidth = 80;
            Console.WindowHeight = 25;
        }
    }
}