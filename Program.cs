#nullable disable

Console.Clear();

HomeWork8();


void HomeWork8()
{
    while (true)
    {
        System.Console.Write("Введите номер задачи(54, 56, 58, 60 или 0 для выхода): ");

        int tusk = int.Parse(Console.ReadLine());

        switch (tusk)
        {
            case 54:
                Console.Clear();
                System.Console.WriteLine("Tusk 54  Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");
                int numRows = NumConsole("Enter Rows: ");
                int numColums = NumConsole("Enter Colums: ");

                int Min = NumConsole("Enter min: ");
                int Max = NumConsole("Enter max: ");
                System.Console.WriteLine();

                var matrixInt = GetIntMatrix(numRows, numColums, Min, Max);

                PrintInt(matrixInt);
                Descending(matrixInt);
                System.Console.WriteLine();
                PrintInt(matrixInt);
                break;

            
            case 56:
                Console.Clear();
                System.Console.WriteLine("Tusk 56  Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
                int NumRows = NumConsole("Enter Rows: ");
                int NumColums = NumConsole("Enter Colums: ");

                int NumMin = NumConsole("Enter min: ");
                int NumMax = NumConsole("Enter max: ");
                System.Console.WriteLine();

                var matrixInt2 = GetIntMatrix(NumRows, NumColums, NumMin, NumMax);

                PrintInt(matrixInt2);

                System.Console.WriteLine();
                System.Console.WriteLine($"Минимальаня сумма находится в строке {StringMin(matrixInt2)}");
                break;


            case 58:
                Console.Clear();
                System.Console.WriteLine("Tusk 58  Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
                System.Console.WriteLine("Matrix ONE");
                int MatrixOneRows = NumConsole("Enter Rows: ");
                int MatrixOneColums = NumConsole("Enter Colums: ");

                int MatrixOneNumMin = NumConsole("Enter min: ");
                int MatrixOneNumMax = NumConsole("Enter max: ");
                System.Console.WriteLine();

                var MatrixOne = GetIntMatrix(MatrixOneRows, MatrixOneColums, MatrixOneNumMin, MatrixOneNumMax);

                PrintInt(MatrixOne);
                System.Console.WriteLine();

                System.Console.WriteLine("Matrix Two");
                int MatrixTwoRows = NumConsole("Enter Rows: ");
                int MatrixTwoColums = NumConsole("Enter Colums: ");

                int MatrixTwoNumMin = NumConsole("Enter min: ");
                int MatrixTwoNumMax = NumConsole("Enter max: ");
                System.Console.WriteLine();

                var MatrixTwo = GetIntMatrix(MatrixTwoRows, MatrixTwoColums, MatrixTwoNumMin, MatrixTwoNumMax);

                PrintInt(MatrixOne);
                System.Console.WriteLine();
                if (MatrixOne.GetLength(1) != MatrixTwo.GetLength(0)) Console.WriteLine("Для умножение должно совпадать ко-во строк в 1 матрице с кол-во столбцов во 2й матрице!");
                else PrintInt(MixMatrixOneAndtwo(MatrixOne, MatrixTwo));
                break;


            case 60:
                Console.Clear();
                System.Console.WriteLine("Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.");
                int XsizeMatrix = NumConsole("размер XMatrix");
                int YsizeMatrix = NumConsole("размер YMatrix");
                int ZsizeMatrix = NumConsole("размер ZMatrix");
                int[,,] matrix60 = CubeMatrix(XsizeMatrix, YsizeMatrix, ZsizeMatrix);
                Print3dMatrix(matrix60);
                break;


            case 0:
                return;
                break;

            default:
                Console.Clear();
                System.Console.WriteLine("Неверное значение");
                break;
        }
    }
}

int NumConsole(string NumberName)                        //Просим Пользователя ввести число
{
    System.Console.WriteLine($"{NumberName}");
    int Number = int.Parse(Console.ReadLine());
    return Number;
}


int[,] GetIntMatrix(int Rows, int Colums, int min, int max)        //рандомная интовая матрица
{
    int[,] matrix = new int[Rows, Colums];
    for (int i = 0; i < Rows; i++)
    {
        for (int j = 0; j < Colums; j++)
        {
            matrix[i, j] = new Random().Next(min, max + 1);
        }
    }
    return matrix;
}


void PrintInt(int[,] matrixInt)               // Выводим нашу матрицу инт
{
    for (int i = 0; i < matrixInt.GetLength(0); i++)
    {
        for (int j = 0; j < matrixInt.GetLength(1); j++)
        {
            System.Console.Write(matrixInt[i, j] + " ");
        }
        System.Console.WriteLine();
    }
}

void Descending(int[,] matrix)         //Делает числа по убыванию
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int k = 0; k < matrix.GetLength(1)-1; k++)
            {
                if (matrix[i, k] < matrix[i, k + 1])
                {
                    int temp = matrix[i, k + 1];
                    matrix[i, k+1] = matrix[i, k];
                    matrix[i, k] = temp;
                }
            }
        }
    }
}



int StringMin(int[,] matrixInt2)                               //Минимальная сумма в строке i, про нахлждение про мин=null, подсмотрел
{
    int row = 0;
    int? min = null;

    for (int i = 0; i < matrixInt2.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j <matrixInt2.GetLength(1); j++)
        {
            sum = sum + matrixInt2[i, j];
        }
        if (min == null) min = sum;
        else if (sum < min)
        {
            min = sum;
            row = i;
        }
        System.Console.WriteLine($"Сумма в строке {i}  равна {sum}");
        
    }
    System.Console.WriteLine();
    return row;
}



int[,] MixMatrixOneAndtwo(int[,] matrix1, int[,] matrix2)                    // Умножаем матрицы
{
    int[,] resultMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            for (int l = 0; l < matrix2.GetLength(0); l++)
            {
                resultMatrix[i, j] += matrix1[i, l] * matrix2[l, j];
            }
        }
    }
    return resultMatrix;
}



void PutOrder(int[] Numbers)  //  Метод заполнение одномерного массива по порядку
{
    int length = Numbers.Length;

    for (int i = 0; i < length; i++)
    {
        Numbers[i] = i + 10;
    }
    return;
}

int[] Shuffle(int[] matrix)      // мешаем числа
{
    Random rand = new Random();

    for (int i = matrix.Length - 1; i >= 1; i--)
    {
        int j = rand.Next(i + 1);

        int temp = matrix[j];
        matrix[j] = matrix[i];
        matrix[i] = temp;
    }
    return matrix;
}

int[,,] CubeMatrix(int valueX, int valueY, int valueZ)  // Метод для заполнения матрицы неповторяющимися случайными целыми числами от 10 до 99
{
    int[,,] matrix = new int[valueX, valueY, valueZ];

    if ((valueX * valueY * valueZ) > 90) Console.WriteLine("Слишком большой размер. Количество значений не должно превышать 90");
    int[] array = new int[90];
    PutOrder(array);
    Shuffle(array);

    for (int i = 0; i < valueX * valueY * valueZ;)
    {
        for (int x = 0; x < valueX; x++)
        {
            for (int y = 0; y < valueY; y++)
            {
                for (int z = 0; z < valueZ; z++)
                {
                    matrix[x, y, z] = array[i];
                    i++;
                }

            }
        }
    }
    return matrix;
}

void Print3dMatrix(int[,,] matrix)  //  Метод для вывода в консоль 3d матрицы
{
    for (int x = 0; x < matrix.GetLength(0); x++)
    {
        for (int y = 0; y < matrix.GetLength(1); y++)
        {
            for (int z = 0; z < matrix.GetLength(2); z++)
            {
                System.Console.Write($"{matrix[x, y, z]} ({x}, {y}, {z}) ");
            }
            System.Console.WriteLine();
        }
    }
}