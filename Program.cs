using System;

namespace Cv3
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new Matrix(new double[,] { { 1, 1, 1 }, { 3, 3, 3 }, { 2, 2, 2 } });
            Matrix b = new Matrix(new double[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } });

            (a + b).ToString();
            (a - b).ToString();
            (-a).ToString();
            (a * b).ToString();

            if (a == b)
            {
                Console.WriteLine("a is the same as b");
            }
            if (a != b)
            {
                Console.WriteLine("a is not the same as b");
            }

            Console.WriteLine(a.Determinant().ToString());
        }
    }
}
