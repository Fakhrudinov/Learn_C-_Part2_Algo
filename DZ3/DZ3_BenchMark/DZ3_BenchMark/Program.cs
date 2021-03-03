using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace DZ3_BenchMark
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alerxander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 
             * Протестируйте разные методы расчёта дистанции
             * Напишите тесты производительности для расчёта дистанции между точками с помощью BenchmarkDotNet. 
             * Рекомендуем сгенерировать заранее массив данных, чтобы расчёт шёл с различными значениями, 
             * но сам код генерации должен происходить вне участка кода, время которого будет тестироваться.
             */

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }


    public class BechmarkClass
    {
        public int SumValueType(int value)
        {
            return 9 + value;
        }

        public int SumRefType(object value)
        {
            return 9 + (int)value;
        }

        [Benchmark]
        public void TestSum()
        {
            SumValueType(99);
        }

        [Benchmark]
        public void TestSumBoxing()
        {
            object x = 99;
            SumRefType(x);
        }
    }
}
