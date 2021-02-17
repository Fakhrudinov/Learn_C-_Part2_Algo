using System;

namespace DZ_1_3
{
    class Program
    {
        public class Tests
        {
            public int IndexFibonacci { get; set; }
            public decimal ExpectedFibonacciNumber { get; set; }
        }

        static void Main(string[] args)
        {
            /*
            * Alerxander Fakhrudinov = Александр Фахрудинов
            * asbuka@gmail.com
            * 
            * 3. Реализуйте функцию вычисления числа Фибоначчи
            * Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл).
            * 
            * https://ru.wikipedia.org/wiki/%D0%A7%D0%B8%D1%81%D0%BB%D0%B0_%D0%A4%D0%B8%D0%B1%D0%BE%D0%BD%D0%B0%D1%87%D1%87%D0%B8
            * Максимальное расчитываемое число 139 и -139
            * т.к. после него идет превышение decimal.MaxValue
            */

            Tests [] testSuit = new Tests[5];

            testSuit[0] = new Tests()
            {
                IndexFibonacci = 0,
                ExpectedFibonacciNumber = 0
            };
            testSuit[1] = new Tests()
            {
                IndexFibonacci = 10,
                ExpectedFibonacciNumber = 55
            };
            testSuit[2] = new Tests()
            {
                IndexFibonacci = 139,
                ExpectedFibonacciNumber = 50095301248058391139327916261M
            };
            testSuit[3] = new Tests()
            {
                IndexFibonacci = -139,
                ExpectedFibonacciNumber = -50095301248058391139327916261M
            };
            testSuit[4] = new Tests()
            {
                IndexFibonacci = -10,
                ExpectedFibonacciNumber = -55
            };

            bool allpassed = true;
            foreach (Tests testCase in testSuit)
            {
                var resultLoop = GetFibonacciWithLoop(testCase.IndexFibonacci);
                if (resultLoop != testCase.ExpectedFibonacciNumber)
                {
                    allpassed = false;
                    Console.WriteLine($"Ошибка в расчете циклом - для входных данных {testCase.IndexFibonacci} результат {resultLoop} != ожидаемому {testCase.ExpectedFibonacciNumber}");
                }

                var resultRekur = GetFibonacciWithRecursion(testCase.IndexFibonacci);
                if (resultRekur != testCase.ExpectedFibonacciNumber)
                {
                    allpassed = false;
                    Console.WriteLine($"Ошибка в расчете рекурсией - для входных данных {testCase.IndexFibonacci} результат {resultRekur} != ожидаемому {testCase.ExpectedFibonacciNumber}");
                }
            }

            if(allpassed)
                Console.WriteLine("Все тесты пройдены, ОК.\n");


            //пользовательский ввод
            Console.WriteLine("Введите значение - целое число как индекс последовательности для расчета числа Фибоначчи. \nМаксимальное расчитываемое число от -139 до 139");
            string userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out int index))
            {
                if (index > -140 && index < 140)
                {
                    decimal resultLoop = GetFibonacciWithLoop(index);
                    Console.WriteLine("Результат вычисления методом в цикле:     " + resultLoop);

                    decimal resultRecursion = GetFibonacciWithRecursion(index);
                    Console.WriteLine("Результат вычисления методом с рекурсией: " + resultRecursion);                    
                }
                else
                {
                    Console.WriteLine("Введенное число не может быть расчитано из за его величины. Максимальное расчитываемое число от -139 до 139");
                }
            }
            else
            {
                Console.WriteLine("Введенное число не удалось преобразовать в индекс для вычисления последовательности");
            }

            Console.Read();
        }

        private static decimal GetFibonacciWithRecursion(int index)
        {
            int startNumber = CalculateStartNumber(index);

            decimal resultRecursion = CalculateFibonacciWithRecursion(Math.Abs(index), startNumber, 0);

            return resultRecursion;
        }

        private static decimal GetFibonacciWithLoop(int index)
        {
            int startNumber = CalculateStartNumber(index);

            decimal resultLoop = CalculateFibonacciWithLoop(Math.Abs(index), startNumber);

            return resultLoop;
        }

        private static int CalculateStartNumber(int index)
        {
            int startNumber = 0;
            if (index < 0) //вычисление отрицательных чисел Фибоначчи
            {
                startNumber = -1;
            }
            else if (index > 0)//вычисление положительных
            {
                startNumber = 1;
            }
            else // index == 0
            {
                startNumber = 0;
            }

            return startNumber;
        }

        private static decimal CalculateFibonacciWithLoop(int index, decimal startNumber)
        {
            if (startNumber == 0)//для вычисления индекса 0
                return 0;

            decimal prev = 0; // предыдущее число
            decimal result = 1;
            int i = 1; // начинаем с 1 т.к. первый шаг у нас всегда есть, 0 отсекается.
            try
            {
                for (; i <= index; i++)
                {
                    result = prev + startNumber;
                    startNumber = prev;
                    prev = result;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка! Число в результате слишком большое.");
                return 0;
            }
            return result;
        }

        private static decimal CalculateFibonacciWithRecursion(int fibonacciIndex, decimal startNumber, decimal prev)
        {
            if (fibonacciIndex == 0)//для вычисления индекса 0
                return 0;

            decimal result = 0;
            try
            {
                result = prev + startNumber;

                if (fibonacciIndex == 1)//остановка на 1 - т.к. первый шаг у нас всегда есть, 0 отсекается.
                {
                    return result;
                }

                result = CalculateFibonacciWithRecursion(--fibonacciIndex, prev, prev + startNumber);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка! Число в результате слишком большое.");
                //return 0;
            }

            return result;
        }
    }
}
