using System;
using System.Threading.Tasks;

namespace MatrixMultiplication
{
    public class Matrix
    {
        public static void Start()
        {
            Console.WriteLine("Введите число n, определяющее размерность матрицы [n,n]");
            var size = Convert.ToInt32(Console.ReadLine());

            var task = new Task<int[,]>(() => Create(size));
            task.Start();
            var matrix_first = task.Result;

            var task2 = new Task<int[,]>(() => Create(size));
            task2.Start();

            var matrix_second = task2.Result;

            var task3 = new Task<int[,]>(() => MultiMatrix(matrix_first, matrix_second, size));
            var MultiplicationResult = task3.Result;
        }

        public static int[,] Create(int size) //создание матриц
        {
            int[,] matrix = new int[size, size];
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = r.Next(0, 10);
                }
            }
            return matrix;
        }

        public static int[,] MultiMatrix(int[,] Matrix1, int[,] Matrix2, int size) //перемножение матриц
        {
            int[,] ResultMatrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        ResultMatrix[i, j] += Matrix1[i, k] * Matrix2[k, j];
                    }
                }
            }
            return ResultMatrix;
        }


    }
}
