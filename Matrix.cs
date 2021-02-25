using System;
using System.Collections.Generic;
using System.Text;

namespace Cv3
{
    class Matrix
    {
        #region Attributes
        public double[,] Values;
        #endregion

        #region Constructor
        public Matrix(double[,] values)
        {
            this.Values = new double[values.GetLength(0), values.GetLength(1)];

            for (int row = 0; row <= values.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= values.GetUpperBound(1); column++)
                {
                    Values[row, column] = values[row, column];
                }
            }
        }
        #endregion

        #region Operators
        public static Matrix operator +(Matrix a, Matrix b)
        {
            try
            {
                double[,] results = new double[a.Values.GetLength(0), a.Values.GetLength(1)];

                for (int row = 0; row <= a.Values.GetUpperBound(0); row++)
                {
                    for (int column = 0; column <= a.Values.GetUpperBound(1); column++)
                    {
                        results[row, column] = a.Values[row, column] + b.Values[row, column];
                    }
                }

                return new Matrix(results);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Matrixes are not of the same size! Null returned.");
                return null;
            }
        }

        public static Matrix operator -(Matrix a)
        {
            double[,] results = new double[a.Values.GetLength(0), a.Values.GetLength(1)];

            for (int row = 0; row <= a.Values.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= a.Values.GetUpperBound(1); column++)
                {
                    results[row, column] = -a.Values[row, column];
                }
            }
            return new Matrix(results);
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            try
            {
                double[,] results = new double[a.Values.GetLength(0), a.Values.GetLength(1)];

                for (int row = 0; row <= a.Values.GetUpperBound(0); row++)
                {
                    for (int column = 0; column <= a.Values.GetUpperBound(1); column++)
                    {
                        results[row, column] = a.Values[row, column] - b.Values[row, column];
                    }
                }
                return new Matrix(results);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Matrixess are not of the same size! Null returned.");
                return null;
            }
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            try
            {
                double[,] values = new double[a.Values.GetLength(0), b.Values.GetLength(1)];
                for (int row = 0; row <= a.Values.GetUpperBound(0); row++)
                {
                    for (int column = 0; column <= b.Values.GetUpperBound(1); column++)
                    {
                        double value = 0;
                        for (int temp = 0; temp <= a.Values.GetUpperBound(1); temp++)
                        {
                            value = value + a.Values[row, temp] * b.Values[temp, column];
                        }
                        values[row, column] = value;
                    }
                }
                return new Matrix(values);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Number of columns in the first matrix is not the same as the number of rows in the second matrix! Null returned.");
                return null;
            }
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            if (ChkSize(a, b))
            {
                for (int row = 0; row <=a.Values.GetUpperBound(0); row++)
                {
                    for (int column = 0; column <= a.Values.GetUpperBound(1); column++)
                    {
                        if (a.Values[row,column] != b.Values[row,column])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else return false;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }
        #endregion

        #region Methods
        private static bool ChkSize(Matrix a, Matrix b)
        {
            if (a.Values.GetLength(0) == b.Values.GetLength(0) && a.Values.GetLength(1) == b.Values.GetLength(1))
            {
                return true;
            }
            else return false;
        }

        public double Determinant()
        {
            try
            {
                this.ChkDet();
                switch (this.Values.GetLength(0))
                {
                    case 1:
                        return this.Values[0, 0];
                    case 2:
                        return (this.Values[0, 0] * this.Values[1, 1] - this.Values[0, 1] * this.Values[1, 0]);
                    case 3:
                        return ((this.Values[0, 0] * this.Values[1, 1] * this.Values[2, 2])
                            + this.Values[1, 0] * this.Values[2, 1] * this.Values[0, 2]
                            + this.Values[2, 0] * this.Values[0, 1] * this.Values[1, 2]
                            - this.Values[0, 2] * this.Values[1, 1] * this.Values[2, 0]
                            - this.Values[1, 2] * this.Values[2, 1] * this.Values[0, 0]
                            - this.Values[2, 2] * this.Values[0, 1] * this.Values[1, 0]);
                    default:
                        return 0;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message + " 0 returned.");
                return 0;
            }
        }

        public void ToString()
        {
            for (int row = 0; row <= this.Values.GetUpperBound(0); row++)
            {
                string print = "";
                for (int column = 0; column <= this.Values.GetUpperBound(1); column++)
                {
                    print = print + Math.Round(this.Values[row, column], 3).ToString() + "  ";
                }
                Console.WriteLine(print);
            }
        }

        private bool ChkDet()
        {
            if (this.Values.GetLength(0) == this.Values.GetLength(1) && this.Values.GetLength(0) < 4)
            {
                return true;
            }
            else
            {
                throw new InvalidOperationException("Matrix is not square or it is bigger than 3x3!");
            }
        }
        #endregion
    }
}