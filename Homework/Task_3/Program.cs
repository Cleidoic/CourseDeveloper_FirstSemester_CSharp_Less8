/* Задача 3: 

Задайте две матрицы. 
Напишите программу, которая будет находить произведение двух матриц.

Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3

Результирующая матрица будет:
18 20
15 18
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
            array[i, j] = random.Next(-10, 10);
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
            Console.Write("{0,4}", array[i, j]);
        }
        Console.WriteLine();
    }
}

int[,] MultiplyArrays (int[,] firstArray, int[,] secondArray) {
    int multiply = 0;
    int[,] result = new int[firstArray.GetLength(0), secondArray.GetLength(1)];
    for (int row = 0; row < firstArray.GetLength(0); row++){
        for (int col = 0; col < secondArray.GetLength(1); col++){
            for (int i = 0; i < firstArray.GetLength(1); i++){
                multiply = multiply + firstArray[row, i] * secondArray[i, col];
            }
            result[row, col] = multiply;
            multiply = 0;
        }
    }
    return result;
}

int rows = GetNumber("Введите число строк первой матрицы: ");
int rowsColumns = GetNumber("Введите число столбцов первой матрицы и число строк второй: ");
int columns = GetNumber("Введите число столбцов второй матрицы: ");

int[,] firstArray = GetArray(rows, rowsColumns);
PrintArray(firstArray);

int[,] secondArray = GetArray(rowsColumns, columns);
PrintArray(secondArray);

int[,] resultArray = MultiplyArrays(firstArray, secondArray);
PrintArray(resultArray);


