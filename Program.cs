
int[,] RandomMatrix(int rows, int cols)
{
    Random random = new Random();
    int[,] array = new int[rows, cols];
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
        {
            array[i, j] = random.Next(1, 10);
        }
    return array;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

void SquareEvenIndexedElements(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if ((i % 2 == 0) && (j % 2 == 0))
                matrix[i, j] *= matrix[i, j];
        }
    }
}

int SumOfDiagonalElements(int[,] matrix)
{
    int sum = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i == j)
                sum += matrix[i, j];
        }
    }
    return sum;
}

int[] AverageElementsInRowArray(int[,] matrix)
{
    int[] averages = new int[matrix.GetLength(0)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i, j];
        }
        averages[i] = sum / matrix.GetLength(1);
    }

    return averages;
}

void PrintElementOnPosition(int[,] matrix, int row, int col)
{
    if (row < 0 || col < 0)
    {
        Console.WriteLine("Rows and Columns should be >= 0");
        return;
    }
    if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
    {
        Console.WriteLine("There is no such position in the matrix!");
        return;
    }

    Console.WriteLine($"Element on position [{row}, {col}] is {matrix[row, col]}.");
}

void ChangeFirstRowToLastInMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        int temp = matrix[0, i];
        matrix[0, i] = matrix[matrix.GetLength(0) - 1, i];
        matrix[matrix.GetLength(0) - 1, i] = temp;
    }
}

int MinSumElementsInRow(int[,] matrix)
{
    int minSum = int.MaxValue;
    int minRowIndex = -1;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int rowSum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
            rowSum += matrix[i, j];

        if (rowSum < minSum)
        {
            minSum = rowSum;
            minRowIndex = i;
        }
    }

    return minRowIndex;
}

// Задайте двумерный массив. Найдите элементы, у которых оба
// индекса чётные, и замените эти элементы на их квадраты.

int[,] userMatrix = RandomMatrix(3, 3);
PrintMatrix(userMatrix);
SquareEvenIndexedElements(userMatrix);
Console.WriteLine();
PrintMatrix(userMatrix);

// Задайте двумерный массив. Найдите сумму элементов,
// находящихся на главной диагонали (с индексами (0,0); (1;1) и
// т.д.

int total = SumOfDiagonalElements(userMatrix);
Console.WriteLine();
Console.WriteLine(total);


// Задайте двумерный массив из целых чисел. Сформируйте новый
// одномерный массив, состоящий из средних арифметических
// значений по строкам двумерного массива. 

int[] userArray = AverageElementsInRowArray(userMatrix);
for (int i = 0; i < userArray.Length; i++)
{
    Console.Write($"{userArray[i]} ");
}

// Задача 1: Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет.

int[,] newMatrix = RandomMatrix(4, 5);

Console.WriteLine();
PrintMatrix(newMatrix);
Console.WriteLine();
PrintElementOnPosition(newMatrix, 3, 3);
PrintElementOnPosition(newMatrix, -1, 2);
PrintElementOnPosition(newMatrix, 5, 5);

// Задача 2: Задайте двумерный массив. 
// Напишите программу, которая поменяет местами первую и последнюю строку массива.

ChangeFirstRowToLastInMatrix(newMatrix);
Console.WriteLine();
PrintMatrix(newMatrix);

// Задача 3: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int[,] taskMatrix = RandomMatrix(4, 4);
PrintMatrix(taskMatrix);
int minRow = MinSumElementsInRow(taskMatrix);
Console.WriteLine($"Row with the minimum sum is: {minRow}");

// Задача 4*(не обязательная): Задайте двумерный массив из целых чисел. 
// Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива. 
// Под удалением понимается создание нового двумерного массива без строки и столбца

int[,] forthMatrix = RandomMatrix(6, 6);
PrintMatrix(forthMatrix);

int[,] MatrixWithRemovedRowsAndCols(int[,] matrix, int[] position)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    int[,] newMatrix = new int[rows - 1, cols - 1];

    int newRow = 0;
    for (int i = 0; i < rows; i++)
    {
        if (i == position[0]) continue; // Пропуск строки с минимальным элементом

        int newCol = 0;
        for (int j = 0; j < cols; j++)
        {
            if (j == position[1]) continue; // Пропуск столбца с минимальным элементом

            newMatrix[newRow, newCol] = matrix[i, j];
            newCol++;
        }
        newRow++;
    }
    return newMatrix;
}

int[] FindPositionOfMinElement(int[,] matrix)
{
    int minElement = int.MaxValue;
    int[] array = new int[2];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (minElement > matrix[i, j])
            {
                minElement = matrix[i, j];
                array[0] = i;
                array[1] = j;
            }
        }
    }
    return array;
}

int[] position = FindPositionOfMinElement(forthMatrix);
Console.WriteLine($"{position[0]}, {position[1]}");
int[,] fixedMatrix = MatrixWithRemovedRowsAndCols(forthMatrix, position);
Console.WriteLine();
PrintMatrix(fixedMatrix);