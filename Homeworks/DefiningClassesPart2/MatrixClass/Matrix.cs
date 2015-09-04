namespace MatrixClass
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public class Matrix<T> where T : struct
    {
        #region Fields
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
        }
        #endregion

        #region Properties
        public int Row { get; set; }

        public int Column { get; set; }

        private T[,] Array { get; set; }
        #endregion

        #region Indexer
        public T this[int row, int column]
        {
            get
            {
                ValidateIfNegative(row);
                ValidateIfNegative(column);

                return this.Array[row, column];
            }

            set
            {
                ValidateIfNegative(row);
                ValidateIfNegative(column);

                this.Array[row, column] = value;
            }
        }
        #endregion

        #region Methods
        private static void ValidateIfNegative(int param)
        {
            if (param < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public static Matrix<T> operator +(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            if (matrixA.Row != matrixB.Row || matrixA.Column != matrixB.Column)
            {
                throw new ArgumentException("The matrices not the same.");
            }

            // Declare the parameters
            var paramA = Expression.Parameter(typeof(T), "matrixA");
            var paramB = Expression.Parameter(typeof(T), "matrixB");

            // Add the parameters together
            BinaryExpression body = Expression.Add(paramA, paramB);

            // Compile it
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();

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
            if (matrixA.Row != matrixB.Row || matrixA.Column != matrixB.Column)
            {
                throw new ArgumentException("The matrices not the same.");
            }

            // Declare the parameters
            var paramA = Expression.Parameter(typeof(T), "matrixA");
            var paramB = Expression.Parameter(typeof(T), "matrixB");

            // Substract the parameters
            BinaryExpression body = Expression.Subtract(paramA, paramB);

            // Compile it
            Func<T, T, T> substract = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();

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
            if (matrixA.Column != matrixB.Row)
            {
                throw new ArgumentException("The matrices format isn't valid.");
            }

            // Declare the parameters
            var paramA = Expression.Parameter(typeof(T), "matrixA");
            var paramB = Expression.Parameter(typeof(T), "matrixB");

            // Add the parameters
            BinaryExpression addBody = Expression.Add(paramA, paramB);

            // Multiply the parameters
            BinaryExpression multiplyBody = Expression.Multiply(paramA, paramB);

            // Compile them
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(addBody, paramA, paramB).Compile();
            Func<T, T, T> multiply = Expression.Lambda<Func<T, T, T>>(multiplyBody, paramA, paramB).Compile();

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

        public static bool operator true(Matrix<T> matrixA)
        {
            bool isTrue = false;

            for (int i = 0; i < matrixA.Row; i++)
            {
                for (int j = 0; j < matrixA.Column; j++)
                {
                    if (matrixA[i, j].Equals(default(T)))
                    {
                        isTrue = true;
                        break;
                    }
                }
            }

            return isTrue;
        }

        public static bool operator false(Matrix<T> matrixA)
        {
            bool isTrue = true;

            for (int i = 0; i < matrixA.Row; i++)
            {
                for (int j = 0; j < matrixA.Column; j++)
                {
                    if (matrixA[i, j].Equals(default(T)))
                    {
                        continue;
                    }
                    else
                    {
                        isTrue = false;
                        break;
                    }
                }
            }

            return isTrue;
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

                sb.AppendLine();
                sb.AppendLine();
            }

            return sb.ToString();
        }
        #endregion
    }
}