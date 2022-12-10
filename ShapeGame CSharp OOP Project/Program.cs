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
            BeginGame(failState, x, y,xArr, yArr, sCtr);
        }
        
        static void BeginGame(bool failState, int x, int y,int[] xArr, int[] yArr, int sCtr)
        {
            while (failState == false)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveUp(ref x, ref y, ref failState, ref xArr, ref yArr, ref sCtr);
                        FailStateCheck(failState);
                        break;
                    case ConsoleKey.DownArrow:
                        MoveDown(ref x, ref y, ref failState, ref xArr, ref yArr, ref sCtr);
                        FailStateCheck(failState);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveRight(ref x, ref y, ref failState,ref xArr,ref yArr, ref sCtr);                       
                        FailStateCheck(failState);
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveLeft(ref x, ref y, ref failState, ref xArr, ref yArr, ref sCtr);
                        FailStateCheck(failState);
                        break;
                }                                       
            }
            foreach(int j in xArr)
            {
                Console.Write(j);
            }
        }
        static void MoveRight(ref int x, ref int y, ref bool failState,ref int[]xArr,ref int[] yArr, ref int sCtr)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (x >= 79|| xArr[x + 1] == 1 && yArr[y] == 1)
            {
                failState = true;
            }
            else
            {
                x++;
                sCtr++;
                xArr[x] = 1;
                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
        }
        static void MoveLeft(ref int x, ref int y, ref bool failState, ref int[] xArr, ref int[] yArr, ref int sCtr)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (x <= 0 || xArr[x] + 1 == 1 && yArr[y] + 1 == 1)
            {
                failState = true;
            }
            else
            {
                x--;
                sCtr++;
                xArr[x] = 1;
                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
        }
        static void MoveDown(ref int x, ref int y, ref bool failState, ref int[] xArr, ref int[] yArr, ref int sCtr)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (y >= 25 || xArr[x] + 1 == 1 && yArr[y] + 1 == 1)
            {
                failState = true;
            }
            else
            {
                y++;
                sCtr++;
                xArr[y] = 1;
                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
        }
        static void MoveUp(ref int x, ref int y, ref bool failState, ref int[] xArr, ref int[] yArr, ref int sCtr)
        {
            if (y <= 0 || xArr[x]+1 == 1 && yArr[y]+1 == 1)
            {
                failState = true;
            }
            else
            {
                y--;
                sCtr++;
                yArr[y] = 1;
                Console.SetCursorPosition(x, y);
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