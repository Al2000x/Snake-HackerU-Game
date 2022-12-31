using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ShapeGame_CSharp_OOP_Project
//{
//    internal class Shape
//    {
//        protected readonly char filler;
//        protected List<(int x, int y)> points = new();
//        public bool HasPoint((int x,int y)? point)
//        {
//            if(point is null) { return false; }
//            return points.Contains(point.Value);
//        }

//        public void Draw()
//        {
//            foreach(var(x,y)in points)
//            {
//                Console.SetCursorPosition(x,y);
//                Console.WriteLine(filler);
//            }
//        }
//        public Shape(char filler, IEnumerable<(int x, int y)>?points=default)
//        {
//            this.filler=filler;
//            if(points is not null)
//            {
//                foreach (var item in points)
//                {
//                    this.points.Add(item);
//                }
//            } 
            
//        }
//        public static Shape CreateRandom()
//        {
//            Random rnd = new Random();
//            List<(int x, int y)> points = new();
//                char filler = ' ';
//            var top = rnd.Next(0, 25);
//            var left = rnd.Next(0, 80);
//            switch (rnd.Next(0, 2))
//            {
//                case 0:
//                  var length = rnd.Next(2, 11);
//                    for(int i = 2; i < length; i++)
//                    {
//                        points.Add((i + left, top));
//                    }
//                    filler = '=';
//                    break;
//                    case 1:
//                    var height = rnd.Next(2, 10);

//                    for(int y=top;y<height + top; y++)
//                    {
//                        for(int x = left; x<= height + left; x++)
//                        {
//                            points.Add(x, y);
//                        }
                        
//                    }
//                    break;
//            }
//            return new Shape(filler, points);

//        }
//    }
//}
