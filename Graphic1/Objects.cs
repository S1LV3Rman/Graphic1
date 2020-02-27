using System.Drawing;
using System;

namespace Graphic1
{
    interface IDrawObject
    {
        void Draw(Graphics g, Pen p);
        bool InMoveArea(Point2D point);
        bool InResizeArea(Point2D point);
        object Clone();
        void Move(float dX, float dY);
        void Move(Point2D d);
        void Resize(Point2D sP, Point2D eP);
        void Transform(TransformMatrix trans);
    }

    public class Line : IDrawObject
    {
        public Point2D startP;
        public Point2D endP;

        public void Draw(Graphics g, Pen p)
        {
            g.DrawLine(p, startP.X, startP.Y, endP.X, endP.Y);
        }

        public bool InMoveArea(Point2D point)
        {
            return false;
        }

        public bool InResizeArea(Point2D point)
        {
            return false;
        }

        public void Move(float dX, float dY)
        {
            var trans = new TransformMatrix(dX, dY);
            startP *= trans;
            endP *= trans;
        }

        public void Move(Point2D d)
        {
            var trans = new TransformMatrix(d);
            startP *= trans;
            endP *= trans;
        }

        public void Resize(Point2D sP, Point2D eP)
        {

        }

        public void Transform(TransformMatrix trans)
        {
            startP *= trans;
            endP *= trans;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public Line()
        {
            startP = new Point2D();
            endP = new Point2D();
        }

        public Line(Point2D startPoint, Point2D endPoint)
        {
            startP = startPoint;
            endP = endPoint;
        }

        public Line(float x1, float y1, float x2, float y2)
        {
            startP = new Point2D(x1, y1);
            endP = new Point2D(x2, y2);
        }
    }

    public class Circle : IDrawObject
    {
        public Point2D center;
        public float radius;

        public void Draw(Graphics g, Pen p)
        {
            g.DrawEllipse(p, center.X - 1, center.Y - 1, 2, 2);
            g.DrawEllipse(p, center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }

        public bool InMoveArea(Point2D point)
        {
            return Math.Pow(point.X - center.X, 2) + Math.Pow(point.Y - center.Y, 2) <= 5;
        }

        public bool InResizeArea(Point2D point)
        {
            return Math.Pow(point.X - center.X, 2) + Math.Pow(point.Y - center.Y, 2) <= Math.Pow(radius + 1, 2) &&
                   Math.Pow(point.X - center.X, 2) + Math.Pow(point.Y - center.Y, 2) >= Math.Pow(radius - 1, 2);
        }

        public void Move(float dX, float dY)
        {
            center *= new TransformMatrix(dX, dY);
        }

        public void Move(Point2D d)
        {
            center *= new TransformMatrix(d);
        }

        public void Resize(Point2D sP, Point2D eP)
        {
            var deltaS = center - sP;
            var deltaE = center - eP;
            var d = deltaE.abs() - deltaS.abs();

            radius += d;
        }

        public void Transform(TransformMatrix trans)
        {
            center *= trans;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public Circle(Point2D c, float r)
        {
            center = c;
            radius = r;
        }
    }
}
