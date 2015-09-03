namespace ProgramsTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MatrixClass;

    public class MatrixClassTest
    {
        internal static void Main()
        {
            Matrix<int> matrixA = new Matrix<int>(3, 3);
            Matrix<int> matrixB = new Matrix<int>(3, 6);
            Matrix<int> matrixC = new Matrix<int>(matrixA.Row, matrixA.Column);
            Matrix<int> matrixD = new Matrix<int>(1, 1);

            matrixA[0, 0] = 1;
            matrixA[0, 1] = 2;
            matrixA[0, 2] = 3;
            matrixA[1, 0] = 4;
            matrixA[1, 1] = 5;
            matrixA[1, 2] = 6;

            matrixB[0, 0] = 7;
            matrixB[0, 1] = 8;
            matrixB[1, 0] = 9;
            matrixB[1, 1] = 10;
            matrixB[2, 0] = 11;
            matrixB[2, 1] = 12;

            matrixC[0, 0] = 3;
            matrixC[0, 1] = 2;
            matrixC[0, 2] = 3;
            matrixC[1, 0] = 4;
            matrixC[1, 1] = 5;
            matrixC[1, 2] = 6;

            matrixD[0, 0] = 2;

            Console.WriteLine(matrixA);
            ////Console.WriteLine(matrixB);
            Console.WriteLine(matrixC);
            ////Console.WriteLine(matrixD);

            var sum = matrixA + matrixC;
            Console.WriteLine(sum);

            var sub = matrixA - matrixC;
            Console.WriteLine(sub);

            var product = matrixA * matrixB;
            Console.WriteLine(product);

            if (matrixA)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false); ;
            }
        }
    }
}