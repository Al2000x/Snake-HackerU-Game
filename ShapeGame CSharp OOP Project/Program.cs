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
            bool startLevel = true;
            int[,] boardGrid = new int[80, 25];
            int sCtr = 1, fCounter = 0;
            string direction = "";
            bool failState = false;
            ConsoleDimensions();


            BeginGame(failState, boardGrid, sCtr, direction, startLevel, rnd);
        }

        static void BeginGame(bool failState, int[,] boardGrid, int sCtr, string direction, bool startLevel, Random rnd)
        {
            int x = 0;
            int y = 0;
            while (true)
            {

                if (startLevel == true)
                {
                    boardGrid = new int[80, 25];

                    x = rnd.Next(0, 80);
                    y = rnd.Next(0, 25);
                    Console.SetCursorPosition(x, y);
                    Console.Write("*");
                    boardGrid[x, y] = 1;
                    direction = "";
                    sCtr = 0;
                }
                startLevel = false;
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveUp(ref x, ref y, ref failState, ref boardGrid, ref sCtr, ref direction);
                        break;

                    case ConsoleKey.DownArrow:
                        MoveDown(ref x, ref y, ref failState, ref boardGrid, ref sCtr, ref direction);
                        break;
                    case ConsoleKey.RightArrow:

                        MoveRight(ref x, ref y, ref failState, ref boardGrid, ref sCtr, ref direction);
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveLeft(ref x, ref y, ref failState, ref boardGrid, ref sCtr, ref direction);
                        break;
                }
                FailStateCheck(ref failState, ref startLevel);
            }
        }
        static void MoveRight(ref int x, ref int y, ref bool failState, ref int[,] boardGrid, ref int sCtr, ref string direction)
        {
            x++;
            if (x >= 80 || direction == "left")
            {
                x--;
                return;
            }
            
            if (x >= 80 || boardGrid[x, y] == 1)
            {
                failState = true;
            }
            else
            {
                direction = "right";
                sCtr++;
                boardGrid[x, y] = 1;
                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void MoveLeft(ref int x, ref int y, ref bool failState, ref int[,] boardGrid, ref int sCtr, ref string direction)
        {
            x--;
            if (x < 0 || direction == "right")
            {
                x++;
                return;
            }
             
            if (x < 0 || boardGrid[x, y] == 1)
            {
                failState = true;
            }
            else
            {
                direction = "left";
                sCtr++;
                boardGrid[x, y] = 1;
                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void MoveDown(ref int x, ref int y, ref bool failState, ref int[,] boardGrid, ref int sCtr, ref string direction)
        {
            y++;
            if (y >= 25 || direction == "up")
            {
                y--;
                return;
            }
            
            if (boardGrid[x, y] == 1)
            {
                failState = true;
            }
            else
            {
                direction = "down";
                sCtr++;
                boardGrid[x, y] = 1;
                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
        }
        static void MoveUp(ref int x, ref int y, ref bool failState, ref int[,] boardGrid, ref int sCtr, ref string direction)
        {

            y--;
            if (direction == "down" || y<=0)
            {
                y++;
                return;
            }
            
            if (boardGrid[x,y]==1)
            {
                failState = true;
            }
            else
            {
                direction = "up";
                sCtr++;
                boardGrid[x,y] = 1;
                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
        }
        static void FailStateCheck(ref bool failState,ref bool startLevel)
        {
            if (failState == true)
            {
                Console.Clear();
                Console.WriteLine("you colided with something :(");
                startLevel = true;
                failState = false;
                Console.WriteLine("to start the next round press any button on your keyboard");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static void ConsoleDimensions()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WindowWidth = 80;
            Console.WindowHeight = 25;
        }
        //static void Rectangle(int[] boardGrid, int x, int y)
        //{
        //    bool posFound = false;
        //    int rNumX, rNumY;
        //    Random rnd = new Random();
        //    while (posFound == false)
        //    {
        //        rNumX = rnd.Next(0, 80);
        //        rNumY = rnd.Next(0, 25);
        //        if (boardGrid[rNumX, rNumY] == 0)
        //        {
        //            posFound = true;
        //        }
        //    }
        //    Console.SetCursorPosition(rNumX, rNumY);
        //    for (int i = 1; i <= rNum; i++)
        //    {
        //        rNumX++;
        //        Console.SetCursorPosition(rNumX, rNumY);
        //        for (int j = 1; j <= i; j++)
        //        {
        //            rNumY++;
        //            Console.SetCursorPosition(rNumX, rNumY);
        //            Console.Write("#");
        //            boardGrid[rNumX, rNumY] == 1;
        //        }
        //        Console.WriteLine();
        //    }
        //}
        //static void UpLine()
        //{
        //    Random random = new Random();
        //    int rNum = random.Next(3, 6);
        //    for (int i = 0; i < rNum; i++)
        //    {
        //        Console.WriteLine("║");
        //    }
        //}
    }
   
}