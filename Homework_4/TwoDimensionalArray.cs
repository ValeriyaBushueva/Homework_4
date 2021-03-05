using System;
using System.IO;

namespace Homework_4
{
    // Реализовать класс для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами.
    // Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство,
    // возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива,
    // метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)
    class TwoDimensionalArray
    {
        public int[,] a;

        //public TwoDimensionalArray() { }
        // Конструктор, заполняющий массив случайными числами
        public TwoDimensionalArray(int n, int m)
        {
            a = new int[n, m];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = random.Next();
                }
            }
        }

        //Конструктор, считывающий двумерный массив из файла
        public TwoDimensionalArray(string fileName)
        {
            fileName = "// ...//" + fileName;
            string[] ss = new string[0];
            try
            {
                ss = File.ReadAllLines(fileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не существует в : " + fileName);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Обнаружено исключение: " + ex.Message);
            }

            a = new int[ss.Length, ss.Length];

            for (int i = 0; i < ss.Length; i++)
            {
                string[] tempArray = ss[i].Split(' ');
                for (int j = 0; j < ss.Length; j++)
                {
                    a[i, j] = int.Parse(tempArray[j]);
                }
            }
        }

        //Свойство, возвращает максимальный элемент массива
        public int Max
        {
            get
            {
                int max = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] > max)
                        max = a[i, j];
                return max;
            }
        }

        // Метод возвращает сумму элементов массива
        public void Sum(out long sum)
        {
            sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            for (int j = 0; j < a.GetLength(1); j++)
                sum += a[i, j];
        }

        //Метод номер максимального элемента массива 
        public void IndexOfMax(out string index)
        {
            index = "-1, -1";
            int max = Max;
            for (int i = 0; i < a.GetLength(0); i++)
            for (int j = 0; j < a.GetLength(1); j++)
                if (a[i, j] == max)
                    index = i + ", " + j;
        }

        //Метод возвращает сумму элементов больше заданного
        public void SumMoreThan(out long sum, int min)
        {
            sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            for (int j = 0; j < a.GetLength(1); j++)
            {
                if (a[i, j] > min)
                    sum += a[i, j];
            }
        }

        //Свойство возвращает минимальный элемент массива
        public int Min
        {
            get
            {
                int min = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] < min)
                        min = a[i, j];

                return min;
            }
        }

        //Метод, возвращающий массив строк с элементами массива
        public string[] toString()
        {
            string[] s = new string[a.GetLength(0)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                s[i] += "[ ";
                for (int j = 0; j < a.GetLength(1); j++)
                    s[i] += String.Format($"{a[i, j]:D10} ");
                s[i] += " ]";
            }

            return s;
        }

        // Метод выводит в консоль двумерный массив
        public  void PrintTwoArray(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        //Метод, записывающий двумерный массив в файл
        public void SaveIntoFile(string filename)
        { 
            try
            {
                StreamWriter wr = new StreamWriter(filename);
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                        wr.Write(a[i, j] + " ");
                    
                    wr.Write(Environment.NewLine);
                }
                wr.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не существует в : " + filename);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Обнаружено исключение: " + ex.Message);
            }
        }

        // Метод, загружающий двумерный массив из файла

        public void LoadFromFile(string filename)
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                //string str = sr.ReadLine();
                int N = 4;
                a = new int[N, N];
                   
                for (int i = 0; i < N; i++)
                {
                    string[] tempArray = sr.ReadLine().Split(' ');
                    for (int j = 0; j < tempArray.Length - 1; j++)
                    {
                        a[i, j] = int.Parse(tempArray[j]);
                    }
                }

                sr.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не существует в : " + filename);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Обнаружено исключение: " + ex.Message);
            }
        }
    }
}