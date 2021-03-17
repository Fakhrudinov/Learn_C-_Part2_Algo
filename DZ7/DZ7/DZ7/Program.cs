using System;

namespace DZ7
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            * Alerxander Fakhrudinov = Александр Фахрудинов
            * asbuka@gmail.com
            * 
            * Практическое задание
            * Для прямоугольного поля размера M на N клеток, подсчитать количество путей из верхней левой клетки в правую нижнюю.
            * Известно что ходить можно только на одну клетку вправо или вниз.
            */

            Console.WriteLine("Количество маршрутов.");

            //получить обычный массив вариантов ходов
            int[,] array = GetSimpleMoveArray(3,5);
            PrintArrayToConsole(array);

            Console.WriteLine("\nКоличество маршрутов с препятствиями.");
            
            //подготовка 

            int[,] mapBannedMove = new int[5, 5];
            //заполнить массив единицами. 1=ход разрешен
            FillArrayWith_1(mapBannedMove);
            // установим запрет
            mapBannedMove[1, 2] = 0;
            //mapBannedMove[3, 2] = 0;
            mapBannedMove[3, 1] = 0;

            //рассчет
            int[,] arrayWithBan = GetSimpleMoveArrayWithBlock(mapBannedMove);
            PrintArrayToConsole(arrayWithBan);

            Console.Read();
        }
        /// <summary>
        /// Массив расчета возможных ходов при наличии запрещенных клеток. На вход подается массив с запрещенными ходами
        /// </summary>
        /// <param name="mapBannedMove"></param> 
        /// <returns></returns>
        public static int[,] GetSimpleMoveArrayWithBlock(int[,] mapBannedMove)
        {
            int[,] array = new int[mapBannedMove.GetLength(0), mapBannedMove.GetLength(1)];
            int row, col;

            for (col = 0; col < mapBannedMove.GetLength(1); col++)
            {
                if (mapBannedMove[0, col] == 1)
                    array[0, col] = 1; // Первая строка заполнена единицами
                else
                {
                    array[0, col] = 0; // ноль, ход запрещен
                    // и далее в этой строке должны быть нули
                    if (col + 1 < mapBannedMove.GetLength(1))
                    {
                        mapBannedMove[0, col + 1] = 0;
                    }
                }
            }

            for (row = 1; row < mapBannedMove.GetLength(0); row++)
            {
                if (mapBannedMove[row, 0] == 1)
                    array[row, 0] = 1; // Первая колонка заполнена единицами
                else
                {
                    array[row, 0] = 0; // ноль, ход запрещен
                    // и далее в первом столбце должны быть нули
                    if (row + 1 < mapBannedMove.GetLength(0))
                    {
                        mapBannedMove[row + 1, 0] = 0;
                    }
                }

                for (col = 1; col < mapBannedMove.GetLength(1); col++)
                {
                    if (mapBannedMove[row, col] == 1)
                        array[row, col] = array[row, col - 1] + array[row - 1, col];
                    else
                        array[row, col] = 0;
                }
                // W(a,b) = W(a, b – 1) + W(a – 1, b), если Map[a][b] = 1,
                // W(a, b) = 0, если Map[a][b] = 0.
            }

            return array;
        }

        /// <summary>
        /// Массив расчета возможных ходов. На вход подается размер массива
        /// </summary>
        /// <param name="y"></param> rows num
        /// <param name="x"></param> cell num
        /// <returns></returns>
        public static int[,] GetSimpleMoveArray(int y, int x)
        {
            int[,] array = new int[y, x];
            int row, col;

            for (col = 0; col < x; col++)
                array[0, col] = 1; // Первая строка заполнена единицами

            for (row = 1; row < y; row++)
            {
                array[row, 0] = 1; // Первая колонка заполнена единицами

                for (col = 1; col < x; col++)
                    array[row, col] = array[row, col - 1] + array[row - 1, col];
                // W(a, b) = W(a, b − 1) + W(a − 1, b)
            }

            return array;
        }

        private static void PrintArrayToConsole(int[,] arr)
        {
            int minLenght = arr[arr.GetLength(0) - 1, arr.GetLength(1) - 1].ToString().Length;

            //верхняя сетка таблицы
            Console.Write("+");
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                Console.Write("-".PadLeft(minLenght + 1, '-'));
                Console.Write("-+");
            }
            Console.WriteLine();

            //строки таблицы
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                Console.Write("|");
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    if (arr[row, col] == 0)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($" {arr[row, col].ToString().PadLeft(minLenght, ' ')}");
                    Console.ResetColor();

                    Console.Write(" |");
                }
                Console.WriteLine();

                //нижняя строка сетки для каждой строки
                Console.Write("+");

                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write("-".PadLeft(minLenght + 1, '-'));
                    Console.Write("-+");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Итого возможных маршрутов: {arr[arr.GetLength(0) - 1, arr.GetLength(1) - 1]}");
        }

        private static void FillArrayWith_1(int[,] mapBannedMove)
        {
            for (int row = 0; row < mapBannedMove.GetLength(0); row++)
            {
                for (int col = 0; col < mapBannedMove.GetLength(1); col++)
                {
                    mapBannedMove[row, col] = 1;
                }
            }
        }
    }
}