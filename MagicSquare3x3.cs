using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace parker_square
{
    class MagicSquare3x3
    {
        private Random rand = new Random();
        private HashSet<BigInteger> set = new HashSet<BigInteger>();

        public void Find()
        {
            var matrix = loadMatrix();

            var col1 = getColumnTotal(matrix, 0);
            var col2 = getColumnTotal(matrix, 1);

            if (col1 != col2)
            {
                //Console.WriteLine("fail");
                return;
            }

            var col3 = getColumnTotal(matrix, 2);
            var row1 = getRowTotal(matrix, 0);
            var row2 = getRowTotal(matrix, 1);
            var row3 = getRowTotal(matrix, 2);
            var diag1 = getDiagTotal(matrix, 1);
            var diag2 = getDiagTotal(matrix, 2);

            if (col1 == col2 && col2 == col3 && col3 == row1 && row1 == row2 && row2 == row3 && row3 == diag1 && diag1 == diag2)
            {
                Console.WriteLine("Success!!");
                foreach (var x in set)
                {
                    Console.WriteLine(x);
                }
                Console.ReadKey();
            }
            //else
            //{
            //    Console.WriteLine("fail");
            //}
        }

        private BigInteger getColumnTotal(BigInteger[,] matrix, int col)
        {
            var ans = new BigInteger();

            for (var i = 0; i < 3; i++)
            {
                ans += matrix[col, i];
            }

            return ans;
        }

        private BigInteger getRowTotal(BigInteger[,] matrix, int row)
        {
            var ans = new BigInteger();

            for (var i = 0; i < 3; i++)
            {
                ans += matrix[i, row];
            }

            return ans;
        }

        private BigInteger getDiagTotal(BigInteger[,] matrix, int diag) //1 lower left to upper right
        {
            var ans = new BigInteger();

            if (diag == 1)
            {
                ans += matrix[0, 2];
                ans += matrix[1, 1];
                ans += matrix[2, 0];
            }
            else if (diag == 2)
            {
                ans += matrix[0, 0];
                ans += matrix[1, 1];
                ans += matrix[2, 2];
            }

            return ans;
        }

        private BigInteger[,] loadMatrix()
        {
            var matrix = new BigInteger[3, 3]; //col, row

            set.Clear();

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var testRand = getRandom();
                    while (set.Contains(testRand) || testRand < 0)
                    {
                        testRand = getRandom();
                    }
                    set.Add(testRand);

                    matrix[i, j] = BigInteger.Pow(testRand, 2);
                }
            }

            return matrix;
        }

        /// <summary>
        /// int is 4 bytes.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private BigInteger getRandom()
        {
            byte[] data = new byte[1]; //4, 8, 16, 32...16 is 128bit
            rand.NextBytes(data);
            return new BigInteger(data);
        }
    }
}
