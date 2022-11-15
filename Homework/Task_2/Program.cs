/* Задача 2: 

Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку 
с наименьшей суммой элементов.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке 
и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

int GetNumber(string message) {
    bool isCorrect = false;
    int result = 0;
    Console.WriteLine(message);
    while (!isCorrect) {
        isCorrect = int.TryParse(Console.ReadLine(), out result);
        if (!isCorrect)
            Console.WriteLine("\nВвели не число или оно слишком большое. Введите заново: ");
    }
    return result;
}

int[,] GetArray (int rows, int columns) {
    Random rnd = new Random();
    int[,] array = new int[rows, columns];
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
            array[i, j] = rnd.Next(-100, 100);
    return array;
}

void PrintArray (int[,] array) {
    Console.WriteLine("\nПолучили матрицу:\n");
    for (int i = 0; i < array.GetLength(0); i++) {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write("{0, 5}", array[i, j]);
        Console.WriteLine();
    }
}

int RowMinSum (int[,] array) {
    int result = 0;
    int min = 0;
    int sum = 0;
    for (int i = 0; i < array.GetLength(1); i++)
        min = min + array[0, i];
    for (int row = 0; row < array.GetLength(0); row++) {
        for (int i = 0; i < array.GetLength(1); i++)
            sum = sum + array[row, i];
        if (sum < min) {
            min = sum;
            result = row + 1;
        }
    }
    return result;
}

int rows = GetNumber("Введите число строк матрицы: ");
int columns = GetNumber("Введите число столбцов матрицы: ");
int[,] array = GetArray(rows, columns);

PrintArray(array);

Console.WriteLine("\nНомер строки с наименьшей суммой элементов: {0}", RowMinSum(array));