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

            int[,] boardGrid = new int[80, 25];
            int x, y, sCtr=1;
            bool failState = false;
            x = rnd.Next(0, 80);
            y = rnd.Next(0, 25);
            boardGrid[x,y]=1;
            Snake head = new Head();
            Head head2 = (Head)head;
            head2.X = x;
            head2.Y = y;
            ConsoleDimensions();
            Console.SetCursorPosition(head2.X, head2.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(head.SnakeHead);
            BeginGame(failState, x, y, boardGrid, sCtr);
        }
        
        static void BeginGame(bool failState, int x, int y, int [,] boardGrid, int sCtr)
        {
            while (failState == false)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        y--;
                        if (boardGrid[x, y] == 1)
                        {
                            y++;
                            break;
                        }
                        MoveUp(ref x, ref y, ref failState, ref boardGrid, ref sCtr);
                        FailStateCheck(failState);
                        break;
                       
                    case ConsoleKey.DownArrow:
                       
                        MoveDown(ref x, ref y, ref failState, ref boardGrid, ref sCtr);                    
                        FailStateCheck(failState);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveRight(ref x, ref y, ref failState, ref boardGrid, ref sCtr);                      
                        FailStateCheck(failState);
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveLeft(ref x, ref y, ref failState, ref boardGrid, ref sCtr);
                        FailStateCheck(failState);
                        break;
                }                                       
            }
        }
        static void MoveRight(ref int x, ref int y, ref bool failState, ref int[,] boardGrid, ref int sCtr)
        {
            x++;
            if (x >= 80 || boardGrid[x, y] == 1)
            {
                failState = true;
            }
            else
            {

                sCtr++;
                boardGrid[x, y] = 1;
                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void MoveLeft(ref int x, ref int y, ref bool failState, ref int[,] boardGrid, ref int sCtr)
        {
            x--;
            if (x <= 0|| boardGrid[x, y] == 1)
            {
                failState = true;
            }
            else
            {
                
                sCtr++;
                boardGrid[x, y] = 1;
                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void MoveDown(ref int x, ref int y, ref bool failState, ref int[,] boardGrid, ref int sCtr)
        {
            y++;
            if (y >= 25 || boardGrid[x, y] == 1)
            {
                failState = true;
            }
            else
            {
               
                sCtr++;
                boardGrid[x, y] = 1;
                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void MoveUp(ref int x, ref int y, ref bool failState, ref int[,] boardGrid, ref int sCtr)
        {
            if (y < 0 || boardGrid[x,y]==1)
            {
                failState = true;
            }
            else
            {
                
                sCtr++;
                boardGrid[x,y] = 1;
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