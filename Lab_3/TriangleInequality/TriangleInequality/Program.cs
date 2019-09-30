using System;

namespace TriangleInequality
{
    public class Program
    {
        public static bool TriangleInequalityMethod(double x, double y, double z)
        {
            if (x + y > z && x < y + z && y < x + z && x != 0 && y != 0 && z != 0)
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {

        }
    }
}