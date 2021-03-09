﻿using System;
using System.Collections.Generic;

namespace DZ5_Algo_TreePrint
{
    public class UsingTree : ITree
    {
        public static Node rootNode;

        public void PrintTree()
        {
            Console.Clear();
            Console.WriteLine("Построение двоичного дерева.");
            Console.WriteLine();

            ConsolePrintTree();
        }

        public int [] PrintNodesBFS()
        {
            //BFS(breadth - first search) — поиск в ширину.
            //При поиске в дереве это значит, что мы ищем нужный нам элемент последовательно на каждом уровне дерева: 
            // - сначала первый уровень, потом второй, потом третий и т.д.
            //Для реализации этого алгоритма часто используют очередь.

            List<int> list = new List<int>();            
            var bufer = new Queue<Node>();

            Node root = rootNode;

            bufer.Enqueue(root);

            while (bufer.Count != 0)
            {
                Node element = bufer.Dequeue();
                
                list.Add(element.Value);

                if (element.LeftChild != null)
                {
                    bufer.Enqueue(element.LeftChild);
                }
                if (element.RightChild != null)
                {
                    bufer.Enqueue(element.RightChild);
                }
            }

            int[] nodeValues = list.ToArray();
            return nodeValues;
        }

        public int[] PrintNodesDFS()
        {
            //DFS(deep - first search) — поиск в глубину.
            //тут мы последовательно проходим по каждой ветви дерева до конца. 
            //Для реализации этого алгоритма часто используют стек.

            List<int> list = new List<int>();
            var stack = new Stack<Node>();

            Node root = rootNode;

            stack.Push(root);

            while (stack.Count != 0)
            {
                Node element = stack.Pop();

                list.Add(element.Value);

                if (element.RightChild != null)
                {
                    stack.Push(element.RightChild);
                }
                if (element.LeftChild != null)
                {
                    stack.Push(element.LeftChild);
                }
            }

            int[] nodeValues = list.ToArray();
            return nodeValues;
        }

        private void ConsolePrintTree()
        {
            if (rootNode != null)
            {
                int startX = Console.WindowWidth / 2 - 5;

                var bufer = new Queue<NodeInfo>();

                var root = new NodeInfo()
                {
                    Node = rootNode,
                    Depth = 1,
                    XPosition = startX
                };
                bufer.Enqueue(root);

                while (bufer.Count != 0)
                {
                    var element = bufer.Dequeue();

                    Console.SetCursorPosition(element.XPosition, element.Depth);
                    Console.Write("[" + element.Node.Value + "]");

                    var depth = element.Depth + 1;

                    int xPosition = startX / 2;
                    for (int i = 0; i < element.Depth - 1; i++)
                    {
                        xPosition = xPosition / 2;
                    }
                    if (element.Node.RightChild != null)
                    {
                        var right = new NodeInfo()
                        {
                            Node = element.Node.RightChild,
                            Depth = depth,
                            XPosition = element.XPosition + xPosition
                        };
                        bufer.Enqueue(right);

                        if (xPosition - 2 - element.Node.Value.ToString().Length > 0)
                            Console.Write(new string('_', xPosition - 2 - element.Node.Value.ToString().Length));
                    }

                    if (element.Node.LeftChild != null)
                    {
                        var left = new NodeInfo()
                        {
                            Node = element.Node.LeftChild,
                            Depth = depth,
                            XPosition = element.XPosition - xPosition
                        };
                        bufer.Enqueue(left);

                        if (xPosition - 2 - element.Node.Value.ToString().Length > 0)
                        {
                            Console.SetCursorPosition(element.XPosition - xPosition + 2 + element.Node.LeftChild.Value.ToString().Length,
                                element.Depth);
                            Console.Write(new string('_', xPosition - 2 - element.Node.LeftChild.Value.ToString().Length));
                        }
                    }
                }
            }
        }

        public void AddItem(int value)
        {
            Node newNode = new Node(value);
            Node currentNode = rootNode;

            bool nodeAdded = false;
            while (!nodeAdded)
            {
                if (rootNode == null)
                {
                    rootNode = newNode;
                    nodeAdded = true;
                }
                else
                {
                    if (value == currentNode.Value) // налево 
                    {
                        //ничего не делаем, выходим из while 
                        nodeAdded = true;
                    }
                    else if (value < currentNode.Value) // налево 
                    {
                        if (currentNode.LeftChild == null)
                        {
                            // добавляем 
                            currentNode.LeftChild = newNode;
                            nodeAdded = true;
                        }
                        else
                        {
                            currentNode = currentNode.LeftChild;
                        }
                    }
                    else // направо
                    {
                        if (currentNode.RightChild == null)
                        {
                            // добавляем 
                            currentNode.RightChild = newNode;
                            nodeAdded = true;
                        }
                        else
                        {
                            currentNode = currentNode.RightChild;
                        }
                    }
                }
            }
        }

        public void AddNodesRange(params int[] nodeValues)
        {
            for (int i = 0; i < nodeValues.Length; i++)
            {
                AddItem(nodeValues[i]);
            }
        }

        private int[] SortArrayToBalance(int[] nodeValues)
        {
            Array.Sort(nodeValues);

            List<int> list = new List<int>(nodeValues);
            List<int> listTarget = new List<int>();

            //Array.Clear(nodeValues, 0, nodeValues.Length); // необязательно, только для дебага

            GetMiddleValue(list, listTarget);

            nodeValues = listTarget.ToArray();
            return nodeValues;
        }

        private void GetMiddleValue(List<int> listSource, List<int> listTarget)
        {
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            for (int i = 0; i < listSource.Count / 2; i++)
            {
                leftList.Add(listSource[i]);
            }

            for (int i = listSource.Count / 2 + 1; i < listSource.Count; i++)
            {
                rightList.Add(listSource[i]);
            }

            listTarget.Add(listSource[listSource.Count / 2]);
            listSource.RemoveAt(listSource.Count / 2);

            if (leftList.Count > 0)
                GetMiddleValue(leftList, listTarget);

            if (rightList.Count > 0)
                GetMiddleValue(rightList, listTarget);
        }

        public Node GetNodeByValue(int value)
        {
            Node currentNode = rootNode;

            bool searching = true;
            while (searching)
            {
                if (currentNode.Value == value)
                {
                    return currentNode;
                }
                else if (value > currentNode.Value) // направо
                {
                    if (currentNode.RightChild == null)// выходим из цикла, ничего не найдено
                    {
                        searching = false;
                    }
                    else
                    {
                        currentNode = currentNode.RightChild;
                    }
                }
                else // налево
                {
                    if (currentNode.LeftChild == null)// выходим из цикла, ничего не найдено
                    {
                        searching = false;
                    }
                    else
                    {
                        currentNode = currentNode.LeftChild;
                    }
                }
            }

            // ничего не нашли
            return null;
        }

        public Node GetRoot()
        {
            return rootNode;
        }

        public void RemoveItem(int value)
        {
            Node deleteNode = GetNodeByValue(value);

            if (deleteNode != null)
            {
                int[] nodeValues = GetAllNodesBelow(deleteNode);//найти все потомство

                if (!deleteNode.Equals(rootNode))
                {
                    //найти предка и удалить ссылку на deleteNode
                    Node ancector = FindAncestor(deleteNode);

                    if (ancector != null)//проверка удаления root
                    {
                        if (value > ancector.Value)
                            ancector.RightChild = null;
                        else
                            ancector.LeftChild = null;
                    }
                }

                if (deleteNode.Equals(rootNode))
                {
                    rootNode = null;
                }

                //добавить ноды 
                if (nodeValues.Length > 0)
                {
                    nodeValues = SortArrayToBalance(nodeValues);
                    AddNodesRange(nodeValues);
                }
            }
        }

        private Node FindAncestor(Node deleteNode)
        {
            if (deleteNode.Equals(rootNode)) // нет предка у рута
            {
                return null;
            }

            Node currentNode = rootNode;
            Node ancestorNode = null;

            bool searching = true;
            while (searching)
            {
                if (deleteNode.Equals(currentNode))
                {
                    return ancestorNode;
                }
                else
                {
                    if (deleteNode.Value < currentNode.Value) // налево 
                    {
                        if (currentNode.LeftChild == null)
                        {
                            return null;
                        }
                        else
                        {
                            ancestorNode = currentNode;
                            currentNode = currentNode.LeftChild;
                        }
                    }
                    else // направо
                    {
                        if (currentNode.RightChild == null)
                        {
                            return null;
                        }
                        else
                        {
                            ancestorNode = currentNode;
                            currentNode = currentNode.RightChild;
                        }
                    }
                }
            }

            return null;
        }

        public int[] GetAllNodes()
        {
            Node root = rootNode;

            int[] nodesBelow = GetAllNodesBelow(root);

            int[] nodeValues = new int[nodesBelow.Length + 1];

            nodeValues[0] = rootNode.Value;
            for (int i = 0; i < nodesBelow.Length; i++)
            {
                nodeValues[i + 1] = nodesBelow[i];
            }

            Array.Sort(nodeValues);

            return nodeValues;
        }

        private int[] GetAllNodesBelow(Node node)
        {
            List<int> list = new List<int>();
            var bufer = new Queue<Node>();

            bufer.Enqueue(node);

            while (bufer.Count != 0)
            {
                Node element = bufer.Dequeue();
                if (element.Value != node.Value)// не добавляем первую ноду
                    list.Add(element.Value);

                if (element.LeftChild != null)
                {
                    bufer.Enqueue(element.LeftChild);
                }
                if (element.RightChild != null)
                {
                    bufer.Enqueue(element.RightChild);
                }
            }

            int[] nodeValues = list.ToArray();
            return nodeValues;
        }
    }
}
