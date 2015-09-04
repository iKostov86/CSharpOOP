namespace ProgramsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MatrixClass;

    public class MatrixTest
    {
        internal static void Main()
        {
            var matrixA = new Matrix<int>(3, 3);
            var matrixB = new Matrix<int>(3, 6);
            var matrixC = new Matrix<int>(matrixA.Row, matrixA.Column);
            var matrixD = new Matrix<int>(1, 1);

            fillMatrix(matrixA);
            fillMatrix(matrixB);
            fillMatrix(matrixC);
            fillMatrix(matrixD);

            Console.WriteLine(matrixA);
            Console.WriteLine(matrixB);
            Console.WriteLine(matrixC);
            Console.WriteLine(matrixD);

            var sumAC = matrixA + matrixC;

            Console.WriteLine(sumAC);

            var subAC = matrixA - matrixC;

            Console.WriteLine(subAC);

            var productAB = matrixA * matrixB;

            Console.WriteLine(productAB);

            Console.WriteLine(matrixA ? true : false);
            Console.WriteLine(matrixD ? true : false);
        }

        public static void fillMatrix(Matrix<int> matrix)
        {
            var value = 0;

            for (var i = 0; i < matrix.Row; i++)
            {
                for (var j = 0; j < matrix.Column; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }
    }
}