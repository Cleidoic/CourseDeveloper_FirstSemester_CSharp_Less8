/* Задача 1: 

Задайте двумерный массив. 
Напишите программу, которая упорядочит по убыванию 
элементы каждой строки двумерного массива.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4

В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
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

int[,] GetArray(int rows, int columns) {
    int[,] array = new int[rows, columns];
    Random random = new Random();
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < columns; j++) {
            array[i, j] = random.Next(-100, 100);
        }
    }
    return array;
}

void PrintArray(int[,] array) {
    Console.WriteLine("\nПолучили матрицу:\n");
    int row = array.GetLength(0);
    int columns = array.GetLength(1);
    for (int i = 0; i < row; i++) {
        for (int j = 0; j < columns; j++) {
            Console.Write("{0,5}", array[i, j]);
        }
        Console.WriteLine();
    }
}

int[,] OrderArray(int[,] array) {
    Console.WriteLine("\nСортируем строки по убыванию...");
    for (int row = 0; row < array.GetLength(0); row++) {
        for (int i = 0; i < array.GetLength(1) - 1; i++) {
            for (int j = i + 1; j < array.GetLength(1); j++) {
                if (array[row, i] < array[row, j]) {
                    int tmp = array[row, i];
                    array[row, i] = array[row, j];
                    array[row, j] = tmp;
                }
            }
        }
    }
    return array;
}

int rows = GetNumber("Введите число строк матрицы: ");
int columns = GetNumber("Введите число столбцов матрицы: ");
int[,] array = GetArray(rows, columns);

PrintArray(array);
OrderArray(array);
PrintArray(array);