/* Задача 4: 

Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, 
добавляя индексы каждого элемента.

Массив размером 2 x 2 x 2

66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

int GetNumber (string message) {
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

int[,,] GetArray (int rows, int columns, int dimensionThree) {
    int[,,] array = new int[dimensionThree, rows, columns];
    Random random = new Random();
    for (int i = 0; i < dimensionThree; i++) {
        for (int j = 0; j < rows; j++) {
            for (int k = 0; k < columns; k++)
                array[i, j, k] = random.Next(-100, 100);
        }
    }
    return array;
}

void PrintArray(int[,,] array, string message) {
    Console.WriteLine(message);
    int dimensionThree = array.GetLength(0);
    int rows = array.GetLength(1);
    int columns = array.GetLength(2);
    for (int i = 0; i < dimensionThree; i++) {
        for (int j = 0; j < rows; j++) {
            for (int k = 0; k < columns; k++) {
                Console.Write("{0,4}({1}, {2}, {3})", array[i, j, k], i, j, k);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int rows = GetNumber("Введите число строк массива: ");
int columns = GetNumber("Введите число столбцов масива: ");
int dimensionThree = GetNumber("Введите третью размерность массива: ");
int[,,] array = GetArray(rows, columns, dimensionThree);

PrintArray(array, "Получили массив с индексами: ");
