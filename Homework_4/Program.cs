using System;


// Бушуева Валерия
namespace Homework_4
{
    internal class Program
    {
        #region Task1
        //Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
        //Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3.
        //В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
        
        //Метод подсчёта количества пар элементов массива, в которых хотя бы одно число делится на 3
        static int GetNumberOfPairs(int[] array, int length)
        {
            int amountOfPairs = 0;
            for (int i = 0; i < length-1; i++)
            {
                if (array[i] % 3 == 0 || array[i+1] % 3 == 0)
                {
                    amountOfPairs++;
                }
            }
            return amountOfPairs;
        }
        #endregion
        
        public static void Main(string[] args)
        {
           TASK1();
           TASK2();
           TASK4();
           
        }

        public static void TASK1()
        {
            Console.Title = " Программа 1. Найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3.";
            
            const int arrayLenght = 20;
            int[] myArray = new int[arrayLenght];
            Random random = new Random();
            int result;
            
            Console.WriteLine("Программа подсчёта пар элементов, в которых хотя бы одно число делится на 3.");
            Console.Write("\nВ следующем массиве [ ");
            
            for (int i = 0; i < arrayLenght; i++)
            {
                myArray[i] = random.Next(-10000, 10001);
                Console.Write(myArray[i] + ", ");
            }
            Console.WriteLine("\b\b ]\n");
            
            result = GetNumberOfPairs(myArray, arrayLenght);
            
            Console.WriteLine($"Количество пар: {result}");
            Console.ReadKey();
            Console.Clear();

        }

        public static void TASK2()
        {
            Console.Title = "Программа 2. Дописать класс для работы с одномерным массивом.";
            
            Console.Write("Введите желаемый размер массива: ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("Введите первый элемент массива: ");
            int firstElement = int.Parse(Console.ReadLine());
            Console.Write("Введите шаг для добавления последующих элементов: ");
            int step = int.Parse(Console.ReadLine());
            
            MyArray a = new MyArray(size, firstElement, step);
            
            Console.WriteLine("\nСоздан массив: [ " + a + " ]\n");
            
            Console.WriteLine("Сумма элементов массива: " + a.Sum);
            
            a.Inverse = -1;
            
            Console.WriteLine("Массив с изменёнными знаками: [ " + a + " ]\n");
            
            Console.Write("Введите число, на которое будут умножены элементы массива: ");
            
            a.Multi = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Массив, умноженный на число: [ " + a + " ]\n");
            
            Console.WriteLine("Максимальный элемент массива: " + a.Max);
            
            Console.WriteLine("Количество максимальных элементов массива: " + a.MaxCount);
            Console.ReadKey();
            
            Console.WriteLine("=============================================================");
            
            Console.WriteLine("\nДалее массив создаётся загрузкой данных из файла.");
            int[] array = MyArray.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "ArayList.txt");
            
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{array[i]}");
            }
            
            Console.ReadKey();
            
            Console.WriteLine("\nМассив сохранен в файл ");
            MyArray.SaveIntoFile(array, AppDomain.CurrentDomain.BaseDirectory + "ArayListSave.txt");
            Console.ReadKey();
            Console.Clear();

        }

        public static void TASK4()
        {
             Console.Title = "Программа 4. Реализовать класс для работы с двумерным массивом";
            
            Console.Write("Введите желаемое количество строк массива: ");
            int size1 = int.Parse(Console.ReadLine());
            Console.Write("Введите желаемое количество столбцов массива: ");
            int size2 = int.Parse(Console.ReadLine());
            
            TwoDimensionalArray twoarray = new TwoDimensionalArray(size1, size2);
            
            Console.WriteLine("\nСоздан массив: ");
            twoarray.PrintTwoArray(twoarray.toString());
            long sum = 0;
            twoarray.Sum(out sum);
            
            Console.WriteLine("Сумма элементов массива: " + sum);
            
            twoarray.SumMoreThan(out sum, twoarray.a[0, 0]);
            Console.WriteLine("Cумма элементов массива, которые больше, первого элемента: " + sum);
            
            Console.WriteLine("Максимальный элемент массива: " + twoarray.Max);
            
            Console.WriteLine("Минимальный элемент массива: " + twoarray.Min);
            
            string numOfMax = "";
            twoarray.IndexOfMax(out numOfMax);
            Console.WriteLine("Номер максимального элемента: " + numOfMax);

            Console.WriteLine("=============================================================");
            
            var newTwoArray = new TwoDimensionalArray(4, 4);
            
            Console.WriteLine("\nДалее массив создаётся загрузкой данных из файла.");
            newTwoArray.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "LoadTwoArray.txt");

            for (int i = 0; i < newTwoArray.a.GetLength(0); i++)
            {
                for (int j = 0; j < newTwoArray.a.GetLength(1); j++)
                {
                    Console.Write($"{newTwoArray.a[i,j]} ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();

            newTwoArray.SaveIntoFile(AppDomain.CurrentDomain.BaseDirectory + "LoadTwoArraySave.txt");
            Console.WriteLine("\nМассив сохранен в файл ");
            
            Console.ReadKey();
            Console.Clear();
            
        }
    }
    
}

