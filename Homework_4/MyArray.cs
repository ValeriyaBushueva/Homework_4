using System;
using System.IO;

namespace Homework_4
{
    //  Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом. 
    // Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива, метод Multi,
    //  умножающий каждый элемент массива на определенное число, свойство MaxCount, возвращающее количество максимальных элементов.
    class MyArray
    {
        private int[] a;

        // n - размер массива. element - число, которым будет заполнен массив
        public MyArray(int n, int element)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = element;
            }
        }

        // Конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом
        public MyArray(int n, int firstElement, int step)
        {
            a = new int[n];
            a[0] = firstElement;
            for (int i = 0; i < n; i++)
            {
                if (i != 0)
                    a[i] = a[i - 1] + step;
            }
        }

        //Конструктор, считывающий массив из файла
        public MyArray(string fileName)
        {
            if (File.Exists(fileName))
            {
                string[] ss = File.ReadAllLines(fileName);
                a = new int[ss.Length];
                for (int i = 0; i < ss.Length; i++)
                {
                    a[i] = int.Parse(ss[i]);
                }
            }
            else Console.WriteLine("Ошибка! Файл не найден!");
        }

        // Свойство возвращает максимальный элемент массива
        public int Max
        {
            get
            {
                int max = a[0];
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > max) max = a[i];
                }

                return max;
            }
        }

        //Свойство возвращает сумму элементов массива
        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    sum += a[i];
                }

                return sum;
            }
        }

        // Метод меняет знаки у всех элементов массива
        public int Inverse
        {
            set
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = a[i] * -1;
                }
            }
        }

        // Метод умножает каждый элемент массива на определенное число
        public int Multi
        {
            set
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = a[i] * value;
                }
            }
        }

        //Свойство возвращает минимальный элемент массива
        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i] < min) min = a[i];
                }

                return min;
            }
        }

        //Свойство возвращает число положительных элементов массива
        public int CountPositiv
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > 0) count++;
                }

                return count;
            }
        }


        //Свойство возвращает количество максимальных элементов
        public int MaxCount
        {
            get
            {
                int max = Max;
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == max) count++;
                }

                return count;
            }
        }

        //Метод, возвращающий строковое представление массива

        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
            {
                s = s + v + " ";
            }

            return s;
        }

        //Метод, записывающий массив в файл
        public static void SaveIntoFile(int[] a, string filename)
        {
            StreamWriter wr = new StreamWriter(filename);
            wr.Write(a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                wr.WriteLine(a[i]);
            }

            wr.Close();
        }

        // Метод, загружающий массив из файла
        public static int[] LoadFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                string str = reader.ReadLine();
                int.TryParse(str, out int len);
                int[] a = new int [len];
                for (int i = 0; i < len; i++)
                {
                    int.TryParse(reader.ReadLine(), out int num);
                    a[i] = num;
                }

                reader.Close();
                return a;
            }

            throw new Exception("Файл не найден!!!");
        }
    }
}