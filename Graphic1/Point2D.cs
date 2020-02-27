using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Graphic1
{
    public class Point2D
    {
        public float X, Y, Z = 1;

        public Point2D()
        {
            X = 0;
            Y = 0;
        }

        public Point2D(Point2D p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Point2D(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public float abs()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public static Point2D operator -(Point2D first, Point2D second)
        {
            return new Point2D(second.X - first.X, second.Y - first.Y);
        }

        public static implicit operator Point2D(Point p)
        {
            return new Point2D(p.X, p.Y);
        }

        public static implicit operator Point2D(PointF p)
        {
            return new Point2D(p.X, p.Y);
        }

        public static implicit operator Point(Point2D p)
        {
            return new Point((int)p.X, (int)p.Y);
        }

        public static implicit operator PointF(Point2D p)
        {
            return new PointF(p.X, p.Y);
        }
    }
}
