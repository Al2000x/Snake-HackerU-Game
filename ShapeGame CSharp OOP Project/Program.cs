using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
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
            int currentLevel = 1;
            
            int[,] boardGrid = new int[80, 25];
            //int[,] currShape = new int[]

            int sCtr = 1, fCounter = 0,numOfShapes = 3;
            string direction = "";
            bool failState = false;
            ConsoleDimensions();


            BeginGame(failState, boardGrid, sCtr, direction, startLevel, fCounter, rnd,numOfShapes, /*shapes,*/currentLevel);
        }

        static void BeginGame(bool failState, int[,] boardGrid,  int sCtr, string direction, bool startLevel,
            int fCounter, Random rnd,int numOfShapes/*, List<(int ,int)> shapes */, int currentLevel)
        {
            int x = 0;
            int y = 0;
            while (true)
            {

                if (startLevel == true)
                {
                    int shapeStarter = 1;
                    boardGrid = new int[80, 25];
                    x = rnd.Next(0, 80);
                    y = rnd.Next(0, 25);
                    Console.SetCursorPosition(x, y);
                    Console.Write("*");
                    boardGrid[x, y] = 1;
                    direction = "";
                    sCtr = 0;
                    while(shapeStarter!= numOfShapes)
                    {
                        int j = rnd.Next(0, 80);
                        int k = rnd.Next(0, 25);
                        if (boardGrid[j, k] == 0)
                        {
                        Console.SetCursorPosition(j, k);
                        SelectShape(j,k/*,shapes*/);
                        shapeStarter++;
                        }

                    }
                    //shapes.Clear();
                    for (int i = 0; i < currentLevel; i++)
                    {
                        //shapes.Add(1,2);
                    }
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
                FailStateCheck(ref failState, ref startLevel ,ref fCounter);
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
            if (direction == "down" || y<0)
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
        static void FailStateCheck(ref bool failState, ref bool startLevel, ref int fCounter)
        {
            if (failState == true)
            {
                Console.Clear();
                Console.WriteLine("you colided with something :(");
                startLevel = true;
                failState = false;
                fCounter++;
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
            Console.WindowHeight = 28;
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡");
       
        }
        static void CheckIfSpotIsFreeForShape(int[,] boardGrid)
        {
            bool valid = false;
            while(valid = false)
            {
                
            }
        }
        static void PrntSquare(int j, int k/*, List<(int, int)> shapes*/)
        {
            int tempj, tempk;
            tempj = j;
            tempk = k;
            Random rnd = new Random();
            int size = rnd.Next(3, 5);
            for (int x = 0; x < size; x++)
            {
                tempj++;
                for (int y = 0; y < size; y++)
                {
                    tempk++;
                    Console.Write("#");
                    //shapes.Add(tempj, tempk);

                }
                Console.WriteLine();
            }
        }
        static void PrntTriangle()
        {
            Random rnd = new Random();
            int size = rnd.Next(3, 5);
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("#");

                }
                Console.WriteLine();
            }
        }
        static void PrntLine()
        {
            Random rnd = new Random();
            int size = rnd.Next(3, 5);
            for (int i = 0; i < size; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }
        static void SelectShape(int j, int k/*, List<(int , int )> shapes*/)
        {
            Random rnd = new Random();
            int randNum = rnd.Next(0, 2);                     
            switch (randNum)
            {
                case 0:
                    PrntSquare(j, k/*, shapes*/);
                    break;
                case 1:
                    PrntTriangle();
                    break;
                 case 2:
                    PrntLine();
                    break;
            }
        }
    }
}