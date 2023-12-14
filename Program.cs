
int[,] RandomMatrix(int rows, int cols) //Функция создания матрицы из рандомных чисел от 1 до 9, где указываем количество строк и столбцов
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

void PrintMatrix(int[,] matrix) //Функция вывода матрицы в терминал
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

void PrintElementOnPosition(int[,] matrix, int row, int col) //Функция, которая выводит элемент по введенным позициям. Применяется в первой задаче
{
    if (row < 0 || col < 0) //проверка, что пользователь не ввел отрицательные числа
    {
        Console.WriteLine("Rows and Columns should be >= 0");
        return;
    }
    if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1)) //проверка, что не выходим за границы матрицы
    {
        Console.WriteLine("There is no such position in the matrix!");
        return;
    }

    Console.WriteLine($"Element on position [{row}, {col}] is {matrix[row, col]}.");
}

void ChangeFirstRowToLastInMatrix(int[,] matrix) //Функция, которая меняет первый и последний ряды матрицы. Применяется во второй задаче
{
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        int temp = matrix[0, i];
        matrix[0, i] = matrix[matrix.GetLength(0) - 1, i];
        matrix[matrix.GetLength(0) - 1, i] = temp;
    }
}

int MinSumElementsInRow(int[,] matrix) //Функция, которая находит строку с минимальной суммой элементов. Применяется в третьей задаче
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

int[,] MatrixWithRemovedRowsAndCols(int[,] matrix, int[] position) //Функция, которая удаляет строку и столбец по элементу, который вводим.
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

int[] FindPositionOfMinElement(int[,] matrix) // Функция, которая определяет минимальный элемент в матрице, и возвращает массив с положением этого элемента
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


// Задача 1: Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет.

Console.WriteLine("First task. Find Element on position.");
int[,] firstMatrix = RandomMatrix(4, 5);
PrintMatrix(firstMatrix);
Console.WriteLine();
PrintElementOnPosition(firstMatrix, 3, 3);
PrintElementOnPosition(firstMatrix, -1, 2);
PrintElementOnPosition(firstMatrix, 5, 5);

// Задача 2: Задайте двумерный массив. 
// Напишите программу, которая поменяет местами первую и последнюю строку массива.

int[,] secondMatrix = RandomMatrix(5,5);
Console.WriteLine();
Console.WriteLine("Second task. Swap first row with last row.");
PrintMatrix(secondMatrix);
ChangeFirstRowToLastInMatrix(secondMatrix);
Console.WriteLine();
PrintMatrix(secondMatrix);

// Задача 3: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int[,] thirdMatrix = RandomMatrix(4, 4);
Console.WriteLine();
Console.WriteLine("Third task. Find row with minimum sum of elements in it");
PrintMatrix(thirdMatrix);
int minRow = MinSumElementsInRow(thirdMatrix);
Console.WriteLine();
Console.WriteLine($"Row with the minimum sum is: {minRow}");

// Задача 4*(не обязательная): Задайте двумерный массив из целых чисел. 
// Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива. 
// Под удалением понимается создание нового двумерного массива без строки и столбца

Console.WriteLine();
Console.WriteLine("Forth task. Delete row and column there min element is");
int[,] forthMatrix = RandomMatrix(6, 6);
PrintMatrix(forthMatrix);
int[] position = FindPositionOfMinElement(forthMatrix);
Console.WriteLine($"Min Element is on position: [{position[0]}, {position[1]}]");
int[,] fixedMatrix = MatrixWithRemovedRowsAndCols(forthMatrix, position);
Console.WriteLine();
PrintMatrix(fixedMatrix);