/* Задача 5: 

Напишите программу, которая заполнит спирально массив 4 на 4.

Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

int GetNumber (string message) {
    bool isCorrect = false;
    int result = 0;
    Console.WriteLine(message);
    while (!isCorrect) {
        isCorrect = int.TryParse(Console.ReadLine(), out result);
        if (!isCorrect)
            Console.WriteLine("Это не число. Введите снова: ");
    }
    return result;
}

int size = GetNumber("Задайте размер матрицы: ");

int[,] GetMatrix (int size) {
    int[,] matrix = new int[size, size];
    int count = 1;
    for (int level = 0; level <= size / 2; level++) {
        for (int top = level; top < size - level; top++) {
            matrix[level, top] = count++;
        }
        for (int rigth = level + 1; rigth < size - level; rigth++) {
            matrix[rigth, size - level - 1] = count++;
        }
        for (int bot = size - level - 2; bot >= level; bot--) {
            matrix[size - level - 1, bot] = count++;
        }
        for (int left = size - level - 2; left > level; left--) {
            matrix[left, level] = count++;
        }
    }
    return matrix;
}

int Symbols (int size) {
    int zeros = 1;
    int count = size * size / 10;
    while (count != 0) {
        count /= 10;
        zeros++;
    }
    return zeros;
}

void PrintMatrix (int[,] matrix) {
    Console.WriteLine("\nПолучили матрицу:\n");
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write("{0," + (Symbols(size)+1) + ":D" +
                Symbols(size) + "}", matrix[i, j]);
        Console.WriteLine();
    }
}

int[,] matrix = GetMatrix(size);
PrintMatrix(matrix);