
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

