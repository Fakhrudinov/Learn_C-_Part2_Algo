using System;

namespace DZ2_BinarySearch
{
    class Program
    {
        public class Tests
        {
            public int SearchValue { get; set; }
            public decimal ExpectedResult { get; set; }
        }

        static void Main(string[] args)
        {
            /*
             * Alexander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 
             * 2. Двоичный поиск
             * Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность и проверить работоспособность функции.
             */

            //Подсчет асимптотической сложности
            int[] testSearchValue = new int[]
            {
                99999, 5
            };

            int[] testData = new int[] 
            {
                10, 20, 30, 40, 50, 75, 100, 150, 200, 400, 600, 1000, 10000
            };

            foreach (int searchThis in testSearchValue)
            {
                Console.WriteLine($"Поиск числа {searchThis}");
                foreach (int testLenght in testData)
                {
                    Console.Write("Тест с размером массива " + testLenght);

                    int[] array = new int[testLenght];

                    //fill array
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = i;
                    }

                    int founded = BinarySearchWithCount(array, searchThis);
                }
            }

            /*
             * Тест при поиске заведомо несуществующего числа 99999 - как максимально затратный по итерациям поиск:
                Тест с размером массива 10, затрачено действий O(36)
                Тест с размером массива 20, затрачено действий O(44)
                Тест с размером массива 30, затрачено действий O(44)
                Тест с размером массива 40, затрачено действий O(52)
                Тест с размером массива 50, затрачено действий O(52)
                Тест с размером массива 75, затрачено действий O(60)
                Тест с размером массива 100, затрачено действий O(60)
                Тест с размером массива 150, затрачено действий O(68)
                Тест с размером массива 200, затрачено действий O(68)
                Тест с размером массива 400, затрачено действий O(76)
                Тест с размером массива 600, затрачено действий O(84)
                Тест с размером массива 1000, затрачено действий O(84)
                Тест с размером массива 10000, затрачено действий O(116)
             * 
             * Тест при поиске заведомо существующего числа 5:
                Тест с размером массива 10, затрачено действий O(25)
                Тест с размером массива 20, затрачено действий O(33)
                Тест с размером массива 30, затрачено действий O(41)
                Тест с размером массива 40, затрачено действий O(41)
                Тест с размером массива 50, затрачено действий O(25)
                Тест с размером массива 75, затрачено действий O(41)
                Тест с размером массива 100, затрачено действий O(33)
                Тест с размером массива 150, затрачено действий O(49)
                Тест с размером массива 200, затрачено действий O(41)
                Тест с размером массива 400, затрачено действий O(49)
                Тест с размером массива 600, затрачено действий O(65)
                Тест с размером массива 1000, затрачено действий O(81)
                Тест с размером массива 10000, затрачено действий O(97)
             * 
             * Данный алгоритм поиска следует применять при размерах входящих данных массива длинной более 40 элементов, 
             * т.к. при меньших массивах прямой перебор даст менее ресурсремкий результат.
             * 
             * п.с. на вебинаре был ответ про логарифм, к сожалению не смогу проверить утверждение - я это слово слышал в последний раз в школе в 1991 году...
             */

            //Проверка работоспособности функции
            //задаем массив, наполняем его данными
            int[] array2 = new int[100];

            //fill array
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = i;
            }
            //некоторые значения убираем, сохраняя сортировку.
            array2[1] = 2;
            array2[97] = 98;
            array2[49] = 48;

            Tests[] testSuit = new Tests[8];

            testSuit[0] = new Tests()//поиск первого элемента
            {
                SearchValue = 0,
                ExpectedResult = 0
            };
            testSuit[1] = new Tests()//поиск несуществующего элемента в начале массива
            {
                SearchValue = 1,
                ExpectedResult = -1
            };
            testSuit[2] = new Tests()//поиск в начале массива
            {
                SearchValue = 2,
                ExpectedResult = 2
            };
            testSuit[3] = new Tests()//поиск несуществующего элемента в середине массива
            {
                SearchValue = 49,
                ExpectedResult = -1
            };
            testSuit[4] = new Tests()//поиск в середине массива
            {
                SearchValue = 50,
                ExpectedResult = 50
            };
            testSuit[5] = new Tests()//поиск несуществующего элемента в конце массива
            {
                SearchValue = 97,
                ExpectedResult = -1
            };
            testSuit[6] = new Tests()//поиск в конце массива
            {
                SearchValue = 99,
                ExpectedResult = 99
            };
            testSuit[7] = new Tests()//поиск несуществующего элемента с значением за пределами массива
            {
                SearchValue = 999,
                ExpectedResult = -1
            };

            bool allpassed = true;//флаг успешности всех тестов
            foreach (Tests testCase in testSuit)
            {
                int testResult = BinarySearch(array2, testCase.SearchValue);
                if (testResult != testCase.ExpectedResult)
                {
                    allpassed = false;
                    Console.WriteLine($"Ошибка в алгоритме поиска - для входных данных {testCase.SearchValue} результат {testResult} != ожидаемому {testCase.ExpectedResult}");
                }
            }

            if (allpassed)
                Console.WriteLine("Все тесты пройдены, ОК.\n");


            Console.Read();
        }

        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }


        public static int BinarySearchWithCount(int[] inputArray, int searchValue)
        {
            int actionCount = 0;//подсчет действий этого метода

            int min = 0; //O(1) присвоение
            actionCount++;
            
            int max = inputArray.Length - 1; //O(2) //вычитание и присвоение
            actionCount+=2;

            while (min <= max) //O(1) сравнение
            {
                actionCount++;//сравнение в while

                int mid = (min + max) / 2;  //O(3) //сложение умножение присвоение
                actionCount += 3;

                if (searchValue == inputArray[mid]) //O(1)
                {
                    actionCount++;//сравнение в else

                    Console.WriteLine(", затрачено действий O(" + ++actionCount + ")");
                    return mid;  //O(1)                    
                }
                else if (searchValue < inputArray[mid]) //O(1)
                {
                    actionCount++;//сравнение в else
                    actionCount++;//сравнение в else if

                    max = mid - 1;  //O(2) //вычитание и присвоение
                    actionCount+=2;
                }
                else 
                {
                    actionCount++;//сравнение в else
                    actionCount++;//сравнение в else if

                    min = mid + 1;  //O(2)
                    actionCount+=2;
                }
            }
            Console.WriteLine(", затрачено действий O(" + ++actionCount + ")");
            return -1; //O(1) 
        }


    }
}
