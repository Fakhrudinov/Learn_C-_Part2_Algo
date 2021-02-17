using System;

namespace DZ_1
{
    class Program
    {
        public class Tests
        {
            public int NumberToCheck { get; set; }
            public bool ExpectedResult { get; set; }        
        }

        static void Main(string[] args)
        {
            /*
             * Fakhrudinov Alexander = Фахрудинов Александр
             * asbuka@gmail.com
             * 
             * 1. Напишите на C# функцию согласно блок-схеме
             * Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки, простое число или нет.
             *      1.	Написать консольное приложение. 
             *      2.	Алгоритм реализовать отдельно в функции согласно блок-схеме.
             *      3.	Написать проверочный код в main функции .
             *      4.	Код выложить на GitHub.
             *      
             *      https://ru.wikipedia.org/wiki/%D0%9F%D1%80%D0%BE%D1%81%D1%82%D0%BE%D0%B5_%D1%87%D0%B8%D1%81%D0%BB%D0%BE
             *      Просто́е число́ — натуральное (целое положительное) число > 1, имеющее ровно два различных натуральных делителя — единицу и самого себя
             */


            Tests[] testSuit = new Tests[5];

            testSuit[0] = new Tests()
            {
                NumberToCheck = 2,
                ExpectedResult = true
            };

            testSuit[1] = new Tests()
            {
                NumberToCheck = 3,
                ExpectedResult = true
            };

            testSuit[2] = new Tests()
            {
                NumberToCheck = 4,
                ExpectedResult = false
            };

            testSuit[3] = new Tests()
            {
                NumberToCheck = 163,
                ExpectedResult = true
            };

            testSuit[4] = new Tests()
            {
                NumberToCheck = 164,
                ExpectedResult = false
            };

            bool allpassed = true;
            foreach (Tests testCase in testSuit)
            {
                bool resultActual = CheckNumberIsPrime(testCase.NumberToCheck); ;
                if (resultActual != testCase.ExpectedResult)
                {
                    allpassed = false;
                    Console.WriteLine($"Ошибка в проверке простого числа {testCase.NumberToCheck}, результат {resultActual} != ожидаемому {testCase.ExpectedResult}");
                }
            }

            if (allpassed)
                Console.WriteLine("Все тесты пройдены, ОК.\n");


            Console.WriteLine("Введите целое положительное число более единицы для проверки - 'Простое число'");
            string userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out int number) && number > 1 )
            {
                bool isPrime = CheckNumberIsPrime(number);

                if (isPrime)
                {
                    Console.WriteLine("Простое");
                }
                else
                {
                    Console.WriteLine("Не простое");
                }
            }
            else
            {
                Console.WriteLine("Введенное число не является целым и положительным больше 1.");
            }

            Console.Read();
        }

        private static bool CheckNumberIsPrime(int number)
        {

            int i = 2;// с двойки начинаем пробовать делить число
            int d = 0;// флаг простое число

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                    // break; //здесь можно было бы добавить break т.к. любое увеличение d - это ответ 'не простое'. Но в блок схеме break нет.
                }

                i++;
            }

            if (d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
