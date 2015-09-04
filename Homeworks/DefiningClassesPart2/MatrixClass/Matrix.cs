namespace MatrixClass
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public class Matrix<T> where T : struct
    {
        #region Fields
        private readonly bool isNumeric;
        private int row;
        private int column;
        #endregion

        #region Constructors
        public Matrix()
            : this(0, 0)
        {
        }

        public Matrix(int row, int column)
        {
            this.Row = row;
            this.Column = column;
            this.Array = new T[this.Row, this.Column];
            this.isNumeric = IsNumeric();
        }
        #endregion

        #region Properties
        public int Row
        {
            get
            {
                return this.row;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Rows must be more than zero (0)!");
                }

                this.row = value;
            }
        }

        public int Column
        {
            get
            {
                return this.column;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Columns must be more than zero (0)!");
                }

                this.column = value;
            }
        }

        private T[,] Array { get; set; }
        #endregion

        #region Indexer
        public T this[int row, int column]
        {
            get
            {
                ValidateIndexesRange(row, column);

                return this.Array[row, column];
            }

            set
            {
                ValidateIndexesRange(row, column);

                this.Array[row, column] = value;
            }
        }
        #endregion

        #region Methods
        private static void ValidateIfNumeric(bool isNumeric)
        {
            if (!isNumeric)
            {
                throw new ArgumentException("The type must be a number!");
            }
        }

        public static Matrix<T> operator +(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            ValidateIfNumeric(matrixA.isNumeric);

            if (matrixA.Row != matrixB.Row || matrixA.Column != matrixB.Column)
            {
                throw new ArgumentException("The matrices not the same.");
            }

            // Declare the parameters
            ParameterExpression x = Expression.Parameter(typeof(T), "x");
            ParameterExpression y = Expression.Parameter(typeof(T), "y");

            // Add the parameters together
            BinaryExpression body = Expression.Add(x, y);

            // Compile it
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, x, y).Compile();

            int row = matrixA.Row;
            int column = matrixA.Column;

            Matrix<T> result = new Matrix<T>(row, column);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    result[i, j] = add(matrixA[i, j], matrixB[i, j]);
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            ValidateIfNumeric(matrixA.isNumeric);

            if (matrixA.Row != matrixB.Row || matrixA.Column != matrixB.Column)
            {
                throw new ArgumentException("The matrices not the same.");
            }

            // Declare the parameters
            ParameterExpression x = Expression.Parameter(typeof(T), "x");
            ParameterExpression y = Expression.Parameter(typeof(T), "y");

            // Substract the parameters
            BinaryExpression body = Expression.Subtract(x, y);

            // Compile it
            Func<T, T, T> substract = Expression.Lambda<Func<T, T, T>>(body, x, y).Compile();

            int row = matrixA.Row;
            int column = matrixA.Column;

            Matrix<T> result = new Matrix<T>(row, column);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    result[i, j] = substract(matrixA[i, j], matrixB[i, j]);
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            ValidateIfNumeric(matrixA.isNumeric);

            if (matrixA.Column != matrixB.Row)
            {
                throw new ArgumentException("The matrices format isn't valid.");
            }

            // Declare the parameters
            ParameterExpression x = Expression.Parameter(typeof(T), "x");
            ParameterExpression y = Expression.Parameter(typeof(T), "y");

            // Add the parameters
            BinaryExpression addBody = Expression.Add(x, y);

            // Multiply the parameters
            BinaryExpression multiplyBody = Expression.Multiply(x, y);

            // Compile them
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(addBody, x, y).Compile();
            Func<T, T, T> multiply = Expression.Lambda<Func<T, T, T>>(multiplyBody, x, y).Compile();

            int row = matrixA.Row;
            int column = matrixB.Column;

            Matrix<T> product = new Matrix<T>(row, column);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    for (int k = 0; k < matrixB.Row; k++)
                    {
                        product[i, j] = add(product[i, j], multiply(matrixA[i, k], matrixB[k, j]));
                    }
                }
            }

            return product;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Column; j++)
                {
                    if (!matrix[i, j].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return !matrix;
        }

        public static bool operator !(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Column; j++)
                {
                    if (!matrix[i, j].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void ValidateIndexesRange(int row, int column)
        {
            if (row < 0 || row >= this.Row ||
                column < 0 || column >= this.Column)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private bool IsNumeric()
        {
            var type = typeof(T);
            var set = new HashSet<Type>()
            {
                typeof(sbyte), typeof(byte), typeof(short), typeof(ushort),
                typeof(int), typeof(uint), typeof(sbyte), typeof(long),
                typeof(ulong), typeof(float), typeof(double), typeof(decimal),
            };

            foreach (var item in set)
            {
                if (type == item)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int r = 0; r < this.Row; r++)
            {
                for (int c = 0; c < this.Column; c++)
                {
                    sb.AppendFormat("{0, 3} ", this.Array[r, c]);
                }

                sb.AppendLine(Environment.NewLine);
            }

            return sb.ToString();
        }
        #endregion
    }
}