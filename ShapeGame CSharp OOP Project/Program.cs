using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml;

namespace ShapeGame_CSharp_OOP_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();
            int[] xArr = new int[80];
            int[] yArr = new int[25];
            int x, y, sCtr=1;
            bool failState = false;
            x = rnd.Next(0, 80);
            y = rnd.Next(0, 25);
            xArr[x]=1;
            yArr[y]=1;
            Snake head = new Head();
            Head head2 = (Head)head;
            head2.X = x;
            head2.Y = y;
            ConsoleDimensions();
            Console.SetCursorPosition(head2.X, head2.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(head.SnakeHead);
            BeginGame(failState, x, y,xArr, sCtr);


        }
        
        static void BeginGame(bool failState, int x, int y,int[] xArr,int sCtr)
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
                        MoveRight(ref x, ref y, ref failState,ref xArr, ref sCtr);                       
                        FailStateCheck(failState);
                        break;
                    case ConsoleKey.LeftArrow:
                        break;
                }
                Console.SetCursorPosition(0, 0);
                Console.Write(sCtr);
                Console.SetCursorPosition(x, y);
            }
            foreach(int j in xArr)
            {
                Console.Write(j);
            }
        }
        static void MoveRight(ref int x, ref int y, ref bool failState,ref int[]xArr,ref int sCtr)
        {
            if (x >= 79)
            {
                failState = true;
            }
            else
            {
                x++;
                sCtr++;
                xArr[x] = 1;
                Console.Write("*");
            }
            Console.ForegroundColor = ConsoleColor.White;
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