using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml;


namespace ShapeGame_CSharp_OOP_Project
{
    internal class Program
    {
        private static string neck;

        static void Main(string[] args)
        {

            Random rnd = new Random();
            bool startLevel = true;
            int[,] boardGrid = new int[80, 25];
            int x, y, sCtr=1,fCounter = 0;
            string direction = "";
            bool failState = false;
            x = rnd.Next(0, 80);
            y = rnd.Next(0, 25);
            boardGrid[x,y]=1;          
            ConsoleDimensions();
            Console.SetCursorPosition(x, y);
            Console.Write("*");
            BeginGame(failState, x, y, boardGrid, sCtr,direction, startLevel);
        }
        
        static void BeginGame(bool failState, int x, int y, int [,] boardGrid, int sCtr, string direction, bool startLevel)
        {
            while (failState == false)
            {
                if(startLevel == true)
                {

                }
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                      
                        y--;
                        if (y <= 0 || boardGrid[x, y] == 1 && direction == "down")
                        {
                            y++;
                            break;
                        }
                        direction = "up"; 
                        MoveUp(ref x, ref y, ref failState, ref boardGrid, ref sCtr,ref direction);
                        FailStateCheck(failState);

                        break;
                       
                    case ConsoleKey.DownArrow:
                        y++;
                        if (y >= 25 || boardGrid[x, y] == 1 && direction == "up")
                        {
                            y--;
                            break;
                        }
                        direction = "down";
                        MoveDown(ref x, ref y, ref failState, ref boardGrid, ref sCtr, ref direction);                    
                        FailStateCheck(failState);
                        break;
                    case ConsoleKey.RightArrow:
                        x++;
                        if (x >= 80 || boardGrid[x, y] == 1 && direction == "left")
                        {
                            x--;
                            break;
                        }
                        direction = "right";
                        MoveRight(ref x, ref y, ref failState, ref boardGrid, ref sCtr, ref direction);                      
                        FailStateCheck(failState);
                        break;
                    case ConsoleKey.LeftArrow:
                        x--;
                        if ( x<=0 || boardGrid[x, y] == 1 && direction == "right")
                        { 
                            x++;
                            break;
                        }
                        direction = "left";
                        MoveLeft(ref x, ref y, ref failState, ref boardGrid, ref sCtr, ref direction);
                        FailStateCheck(failState);
                        break;
                }                                       
            }
            Console.ReadLine();
        }
        static void MoveRight(ref int x, ref int y, ref bool failState, ref int[,] boardGrid, ref int sCtr, ref string direction)
        {
      
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
        static void MoveLeft(ref int x, ref int y, ref bool failState, ref int[,] boardGrid, ref int sCtr, ref string direction)
        {
            
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
        static void MoveDown(ref int x, ref int y, ref bool failState, ref int[,] boardGrid, ref int sCtr, ref string direction)
        {
           
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
        }
        static void MoveUp(ref int x, ref int y, ref bool failState, ref int[,] boardGrid, ref int sCtr ,ref string direction)
        {
            if (y <= 0 || boardGrid[x,y]==1)
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
        }
        static void FailStateCheck(bool failState)
        {
            if (failState == true)
            {
                Console.Clear();
                Console.WriteLine("you colided with something :(");
               
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