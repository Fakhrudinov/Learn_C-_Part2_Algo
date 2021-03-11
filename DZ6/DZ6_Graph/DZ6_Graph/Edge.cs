using System;
using System.Collections.Generic;

namespace DZ6_Graph
{
    public class Edge
    {
        public int Weight { get; set; }

        public Node Node { get; set; }

        public Edge(Node connectNode, int weight)
        {
            Node = connectNode;
            Weight = weight;
        }

        public static void AddEdge(Node node1, Node node2, int weight)
        {
            node1.Edges.Add(new Edge(node2, weight));
            node2.Edges.Add(new Edge(node1, weight));
        }

        public static Dictionary<string, int> PrintNodesBFS(Node nodaStart)//ок
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();//собираем результаты для юнит тестов

            Console.WriteLine("\nВывод узлов графа алгоритмом BFS,\nстартовый узел " + nodaStart.Name);
            var bufer = new Queue<Node>();
            List<Node> listOfNodes = new List<Node>();//сюда соберем все уникальные ноды для последующего снятия признака посещенная

            bufer.Enqueue(nodaStart);
            nodaStart.IsPassed = true;
            nodaStart.WaveNumber = 1;

            while (bufer.Count != 0)
            {
                var currentNode = bufer.Dequeue();
                Console.WriteLine($"Имя ноды {currentNode.Name}, порядок вывода {currentNode.WaveNumber}");
                dict.Add(currentNode.Name, currentNode.WaveNumber);

                UniqueNodeCollect(listOfNodes, currentNode);

                List<Edge> listOfEdges = currentNode.Edges;
                foreach (var connection in listOfEdges)
                {
                    if (!connection.Node.IsPassed)
                    {
                        bufer.Enqueue(connection.Node);
                        connection.Node.IsPassed = true;
                        connection.Node.WaveNumber = currentNode.WaveNumber + 1;
                    }
                }
            }

            ResetStatusPassed(listOfNodes);

            return dict;
        }

        public static Dictionary<string, int> PrintNodesDFS(Node nodaStart)
        {
            //Последнее добавленное ребро будет взято первым

            Console.WriteLine("\nВывод узлов графа алгоритмом DFS,\nстартовый узел " + nodaStart.Name);

            Dictionary<string, int> dict = new Dictionary<string, int>();//собираем результаты для юнит тестов

            var stack = new Stack<Node>();
            List<Node> listOfNodes = new List<Node>();//сюда соберем все уникальные ноды для последующего снятия признака посещенная
            int waveNumb = 1;// порядковый номер вывода элемента

            stack.Push(nodaStart);
            //nodaStart.IsPassed = true;
            nodaStart.WaveNumber = waveNumb;

            while (stack.Count != 0)
            {
                var currentNode = stack.Pop();

                if (!currentNode.IsPassed)
                {
                    currentNode.WaveNumber = waveNumb;
                    currentNode.IsPassed = true;
                    Console.WriteLine($"Имя ноды {currentNode.Name}, порядок вывода {currentNode.WaveNumber}");
                    dict.Add(currentNode.Name, currentNode.WaveNumber);
                    waveNumb++;

                    UniqueNodeCollect(listOfNodes, currentNode);

                    List<Edge> listOfEdges = currentNode.Edges;
                    foreach (var connection in listOfEdges)
                    {
                        if (!connection.Node.IsPassed)
                        {
                            stack.Push(connection.Node);
                            //connection.Node.IsPassed = true;
                        }
                    }
                }
            }

            ResetStatusPassed(listOfNodes);

            return dict;
        }

        private static void ResetStatusPassed(List<Node> listOfNodes)
        {
            foreach (var node in listOfNodes)
            {
                node.IsPassed = false;
            }
        }

        private static void UniqueNodeCollect(List<Node> listOfNodes, Node currentNode)
        {
            bool exist = false;
            foreach (var node in listOfNodes)
            {
                if (currentNode.Name.Equals(node.Name))
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                listOfNodes.Add(currentNode);
            }
        }
    }
}
