using System;

namespace Factory
{
    public class Point
    {
        double x, y;

        Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public readonly static Point Origin = new Point(0, 0);

        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }

    class Demo
    {
        static void Main()
        {
            var p2 = Point.Factory.NewCartesianPoint(1, 2);
            var origin = Point.Origin;
        }
    }
}
