using System;
using System.Collections.Generic;

namespace DZ6_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            * Alerxander Fakhrudinov = Александр Фахрудинов
            * asbuka@gmail.com
            * 
            * Практическое задание
            * Модифицируйте DFS и BFS из предыдущего урока, но уже для графа, также с выводом каждого шага
            */

            Console.WriteLine("Graph");

            // [A]--3---[B]---2---[F]
            //  |      /  \      / |
            //  |     /    1    8  4
            //  |    /      \  /   |
            //  5   /       [E]   [H]
            //  |  12       5      7
            //  | /        /       |
            // [C]--1---[D]---10--[G]

            Node nodaA = new Node("A");
            Node nodaB = new Node("B");
            Node nodaC = new Node("C");
            Node nodaD = new Node("D");
            Node nodaE = new Node("E");
            Node nodaF = new Node("F");
            Node nodaG = new Node("G");
            Node nodaH = new Node("H");

            Edge.AddEdge(nodaA, nodaB, 3);
            Edge.AddEdge(nodaA, nodaC, 5);
            Edge.AddEdge(nodaB, nodaF, 2);
            Edge.AddEdge(nodaB, nodaE, 1);
            Edge.AddEdge(nodaB, nodaC, 12);
            Edge.AddEdge(nodaF, nodaE, 8);
            Edge.AddEdge(nodaF, nodaH, 4);
            Edge.AddEdge(nodaE, nodaD, 5);
            Edge.AddEdge(nodaH, nodaG, 7);
            Edge.AddEdge(nodaC, nodaD, 1);
            Edge.AddEdge(nodaD, nodaG, 10);


            Edge.PrintNodesBFS(nodaG);

            Edge.PrintNodesDFS(nodaG);

            Console.Read();
        }
    }
}
