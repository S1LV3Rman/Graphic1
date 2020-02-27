using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Drawing2D;

namespace Graphic1
{
    enum Selection
    {
        None,
        Move,
        Resize
    }

    public partial class Form1 : Form
    {
        bool isPressed = false; // Клавиша мыши зажата
        Point2D StartMouse, EndMouse;
        Graphics g; // Графический элемент.
        Pen realPen = new Pen(Color.Black, 1); // Перо для нарисованных объектов
        Pen previewPen = new Pen(Color.Gray, 1); // Перо для предпоказа изменения объектов
        List<IDrawObject> RealDrawable = new List<IDrawObject>(); // Список отображаемых объектов
        List<IDrawObject> PreviewDrawable = new List<IDrawObject>(); // Список объектов предпросмотра
        IDrawObject selectedObj; // Выбранный объект
        Selection sel = Selection.None; // Тип выборки
        Bitmap bmp; // Холст
        Circle circle1, circle2; // Окружности
        Line tangent; // Касательная

        Matrix matrix = new Matrix();

        public Form1()
        {
            InitializeComponent();
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                     .SetValue(panel1, true, null);
            bmp = new Bitmap(panel1.Width, panel1.Height);
            g = Graphics.FromImage(bmp);

            init();
        }

        void init()
        {
            circle1 = new Circle(new Point2D(150, 150), 75);
            circle2 = new Circle(new Point2D(450, 300), 25);

            RealDrawable.Add(circle1);
            RealDrawable.Add(circle2);
            RealDrawable.Add(new Line(-1000, 0, 1000, 0));
            RealDrawable.Add(new Line(0, -1000, 0, 1000));

            UpdateTangent();
            UpdateBitmap();
        }

        private void UpdateBitmap()
        {
            g.Clear(Color.White);
            g.Transform = matrix;
            foreach (IDrawObject objectToDraw in RealDrawable)
                objectToDraw.Draw(g, realPen);

            panel1.Invalidate();
        }

        private void UpdateTangent()
        {
            RealDrawable.Remove(tangent);

            tangent = CalculateTangent();
            RealDrawable.Add(tangent);
        }

        private Point2D ToLocal(Point2D p)
        {
            var temp = new PointF[] { p };
            var invert = matrix.Clone();
            invert.Invert();
            invert.TransformPoints(temp);

            return temp[0];
        }

        private Line CalculateTangent()
        {
            Circle c1, c2;

            if (circle1.radius < circle2.radius)
            { c1 = circle1; c2 = circle2; }
            else
            { c1 = circle2; c2 = circle1; }

            // Сдвиг начала координат в центр меньшей окружности
            TransformMatrix translate = new TransformMatrix(-c1.center.X, -c1.center.Y);
            c1.Transform(translate);
            c2.Transform(translate);

            float circlDist = (c1.center - c2.center).abs();
            float tangDist = (float)Math.Sqrt(Math.Pow(circlDist, 2) - Math.Pow(c2.radius - c1.radius, 2));

            // Выравнивание окружностей для проведения касательной
            TransformMatrix rotate = new TransformMatrix((float)(Math.Acos(tangDist / circlDist) - Math.Atan(c2.center.Y / c2.center.X) + (c2.center.X < 0 ? Math.PI : 0)));
            c2.Transform(rotate);

            Line t = new Line(0, -c1.radius, c2.center.X, -c1.radius);

            // Возвращаем координатные оси
            TransformMatrix inverse = translate.inverse() * rotate.inverse();
            c1.Transform(inverse);
            c2.Transform(inverse);
            t.Transform(inverse);

            return t;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
            e.Graphics.Transform = matrix;
            foreach (IDrawObject objectToDraw in PreviewDrawable)
                objectToDraw.Draw(e.Graphics, previewPen);
        }

        private void Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!char.IsDigit(number) && !char.IsControl(number))
            {
                e.Handled = true;
            }
        }

        private void Box1_TextChanged(object sender, EventArgs e)
        {
            if(Box1.Text.Length != 0)
                circle1.center.X = float.Parse(Box1.Text);
            UpdateBitmap();
        }

        private void Box2_TextChanged(object sender, EventArgs e)
        {
            if (Box2.Text.Length != 0)
                circle1.center.Y = float.Parse(Box2.Text);
            UpdateBitmap();
        }

        private void Box3_TextChanged(object sender, EventArgs e)
        {
            if (Box3.Text.Length != 0)
                circle1.radius = float.Parse(Box3.Text);
            UpdateBitmap();
        }

        private void Box4_TextChanged(object sender, EventArgs e)
        {
            if (Box4.Text.Length != 0)
                circle2.center.X = float.Parse(Box4.Text);
            UpdateBitmap();
        }

        private void Box5_TextChanged(object sender, EventArgs e)
        {
            if (Box5.Text.Length != 0)
                circle2.center.Y = float.Parse(Box5.Text);
            UpdateBitmap();
        }

        private void Box6_TextChanged(object sender, EventArgs e)
        {
            if (Box6.Text.Length != 0)
                circle2.radius = float.Parse(Box6.Text);
            UpdateBitmap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RealDrawable.Remove(tangent);

            tangent = CalculateTangent();
            RealDrawable.Add(tangent);

            UpdateBitmap();
        }

        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            var k = e.Delta < 0 ? 0.98f : 1.02f;
            var p = ToLocal(e.Location);

            matrix.Translate(p.X, p.Y);
            matrix.Scale(k, k);
            matrix.Translate(-p.X, -p.Y);

            UpdateBitmap();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
            Point2D Location = ToLocal(e.Location);

            switch (sel)
            {
                case Selection.Move:
                    PreviewDrawable.Clear();

                    EndMouse = e.Location;
                    selectedObj.Move(ToLocal(StartMouse) - Location);

                    sel = Selection.None;
                    UpdateTangent();
                    break;

                case Selection.Resize:
                    PreviewDrawable.Clear();

                    EndMouse = e.Location;
                    selectedObj.Resize(ToLocal(StartMouse), Location);

                    sel = Selection.None;
                    UpdateTangent();
                    break;

                case Selection.None:
                    break;

                default:
                    break;
            }

            UpdateBitmap();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Point2D Location = ToLocal(e.Location);

            if (isPressed)
            {
                switch (sel)
                {
                    case Selection.Move:
                        EndMouse = e.Location;

                        IDrawObject moveObj = (IDrawObject)selectedObj.Clone();
                        moveObj.Move(ToLocal(StartMouse) - Location);

                        PreviewDrawable.Clear();
                        PreviewDrawable.Add(moveObj);
                        break;

                    case Selection.Resize:
                        EndMouse = e.Location;

                        IDrawObject resizeObj = (IDrawObject)selectedObj.Clone();
                        resizeObj.Resize(ToLocal(StartMouse), Location);

                        PreviewDrawable.Clear();
                        PreviewDrawable.Add(resizeObj);
                        break;

                    case Selection.None:
                        if (MouseButtons == MouseButtons.Right)
                        {
                            var p = ToLocal(StartMouse);
                            matrix.Translate(Location.X - p.X, Location.Y - p.Y);
                            StartMouse = e.Location;
                            UpdateBitmap();
                        }
                        break;

                    default:
                        break;
                }
            }
            else
            {
                bool defCur = true;
                foreach (IDrawObject obj in RealDrawable)
                    if (obj.InMoveArea(Location))
                    {
                        defCur = false;
                        Cursor.Current = Cursors.SizeAll;
                    }
                    else if (obj.InResizeArea(Location))
                    {
                        defCur = false;
                        Cursor.Current = Cursors.SizeNESW;
                    }
                if (defCur)
                    Cursor.Current = Cursors.Default;
            }

            Box1.Text = circle1.center.X.ToString();
            Box2.Text = circle1.center.Y.ToString();
            Box3.Text = circle1.radius.ToString();

            Box4.Text = circle2.center.X.ToString();
            Box5.Text = circle2.center.Y.ToString();
            Box6.Text = circle2.radius.ToString();

            panel1.Invalidate();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            Point2D Location = ToLocal(e.Location);

            if (MouseButtons == MouseButtons.Left)
            {
                foreach (IDrawObject obj in RealDrawable)
                    if (obj.InMoveArea(Location))
                    {
                        selectedObj = obj;
                        sel = Selection.Move;
                        StartMouse = e.Location;
                        Cursor.Current = Cursors.SizeAll;
                    }
                    else if (obj.InResizeArea(Location))
                    {
                        selectedObj = obj;
                        sel = Selection.Resize;
                        StartMouse = e.Location;
                        Cursor.Current = Cursors.SizeNESW;
                    }
            }
            else if (MouseButtons == MouseButtons.Right)
                StartMouse = e.Location;
        }
    }
}
