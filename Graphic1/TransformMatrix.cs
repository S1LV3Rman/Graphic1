using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphic1
{
    public class TransformMatrix
    {
        private float[,] M;

        // Матрица без преобразования
        public TransformMatrix()
        {
            M = new float[3, 3] { { 1, 0, 0 },
                                  { 0, 1, 0 },
                                  { 0, 0, 1 } };
        }

        // Матрица сдвига
        public TransformMatrix(float dx, float dy)
        {
            M = new float[3,3] { { 1,  0,  0 },
                                 { 0,  1,  0 },
                                 { dx, dy, 1  } };
        }

        // Матрица сдвига
        public TransformMatrix(Point2D p)
        {
            M = new float[3, 3] { { 1,   0,   0   },
                                  { 0,   1,   0   },
                                  { p.X, p.Y, p.Z } };
        }

        // Матрица поворота
        public TransformMatrix(float q)
        {
            M = new float[3, 3] { {  (float)Math.Cos(q), (float)Math.Sin(q), 0 },
                                  { -(float)Math.Sin(q), (float)Math.Cos(q), 0 },
                                  {  0,                  0,                  1 } };
        }

        public TransformMatrix transpose()
        {
            TransformMatrix result = new TransformMatrix();

            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    result.M[j, i] = M[i, j];

            return result;
        }

        public TransformMatrix inverse()
        {
            TransformMatrix result = new TransformMatrix();

            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    result.M[i, j] = minor(i, j);

            result = result.transpose() / determ();

            return result;
        }

        private float determ()
        {
            float d = 0;

            for (int i = 0; i < 3; ++i)
                d += M[i, 0] * minor(i, 0);

            return d;
        }

        private float minor(int i, int j)
        {
            float[,] matrix = new float[2, 2];
            for (int k = 0, n = 0; k < 3; ++k)
            {
                for (int l = 0, m = 0; l < 3; ++l)
                    if (k != i && l != j)
                        matrix[n, m++] = M[k, l];

                if (k != i)
                    n++;
            }

            return ((i+j) % 2 == 0 ? 1 : -1) * (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]);
        }

        public static TransformMatrix operator *(TransformMatrix first, TransformMatrix second)
        {
            TransformMatrix trMatr = new TransformMatrix();

            for(int i = 0; i < 3; ++i)
                for(int j = 0; j < 3; ++j)
                    trMatr.M[i, j] = first.M[0, j] * second.M[i, 0] +
                                     first.M[1, j] * second.M[i, 1] +
                                     first.M[2, j] * second.M[i, 2];
            return trMatr;
        }

        public static TransformMatrix operator /(TransformMatrix matrix, float mult)
        {
            TransformMatrix matr = new TransformMatrix();

            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    matr.M[i, j] = matrix.M[i, j] / mult;

            return matr;
        }

        public static Point2D operator *(Point2D p, TransformMatrix M)
        {
            Point2D point = new Point2D();

            point.X = M.M[0, 0] * p.X +
                      M.M[1, 0] * p.Y +
                      M.M[2, 0] * p.Z;

            point.Y = M.M[0, 1] * p.X +
                      M.M[1, 1] * p.Y +
                      M.M[2, 1] * p.Z;

            point.Z = M.M[0, 2] * p.X +
                      M.M[1, 2] * p.Y +
                      M.M[2, 2] * p.Z;

            return point;
        }
    }
}
