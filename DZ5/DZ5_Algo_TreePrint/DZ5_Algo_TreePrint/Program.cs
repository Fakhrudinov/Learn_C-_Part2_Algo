using System;


namespace DZ5_Algo_TreePrint
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
            * Alerxander Fakhrudinov = Александр Фахрудинов
            * asbuka@gmail.com
            * 
            * Реализуйте DFS и BFS для дерева с выводом каждого шага в консоль. 
            */

            Console.SetWindowSize(120, 30);

            UsingTree setNode = new UsingTree();
            setNode.AddNodesRange(100, 50, 150, 25, 75, 125, 175, 5, 105);

            setNode.PrintTree();
            
            Console.WriteLine();
            int [] nodesBFS = setNode.PrintNodesBFS();
            PrintResult("BFS (breadth-first search) — поиск в ширину", nodesBFS);

            int[] nodesDFS = setNode.PrintNodesDFS();
            PrintResult("DFS (deep-first search) — поиск в глубину", nodesDFS);

            Console.ReadLine();
        }

        private static void PrintResult(string name, int[] nodesBFS)
        {
            Console.WriteLine($"\nРезультат обхода нод методом {name}:");
            foreach (int nodeValue in nodesBFS)
            {
                Console.Write($"{nodeValue}, ");
            }
            Console.WriteLine();
        }
    }
}
