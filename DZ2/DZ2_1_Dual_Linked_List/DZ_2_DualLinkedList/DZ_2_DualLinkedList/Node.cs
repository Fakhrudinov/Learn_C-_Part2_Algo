using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBrainsTests
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public static Node Head { get; set; } // головной/первый элемент
        public static Node Tail { get; set; } // последний/хвостовой элемент
        public static int Count { get; set; }  // количество элементов в списке

        /// <summary>
        /// Add single node with value
        /// </summary>
        /// <param name="value"></param>
        public static void AddNode(int value) // добавляет новый элемент списка
        {
            Node node = new Node();
            if (Head == null)// добавляем первую ноду
            {
                Head = node;
            }
            else// добавляем в конец
            {
                Tail.NextNode = node;
                node.PrevNode = Tail;
            }
            Tail = node;
            Tail.Value = value;
            Count++;
        }

        /// <summary>
        /// Add few nodes with values sended in params
        /// </summary>
        /// <param name="nodesValue"></param>
        public static void AddNodesRange(params int[] nodesValue)
        {
            for (int i = 0; i < nodesValue.Length; i++)
            {
                AddNode(nodesValue[i]);
            }
        }

        /// <summary>
        /// return summary count of all exist nodes
        /// </summary>
        /// <returns></returns>
        public static int GetCount()
        {
            return Count;
        }

        /// <summary>
        /// Add new node after exist node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public static void AddNodeAfter(Node node, int value) // добавляет новый элемент списка после определённого элемента
        {
            if (node != null)
            {
                //     -->a       -->c
                // node    newNode    second
                //     <--b       <--d

                Node newNode = new Node { Value = value };
                Node nextLink = node.NextNode;

                if (node.NextNode == null)//если добавлять после последней
                {
                    Tail = newNode;
                    Tail.Value = value;
                }
                else
                {
                    newNode.NextNode = nextLink;//c    
                    node.NextNode.PrevNode = newNode;//d
                }

                node.NextNode = newNode;//a
                newNode.PrevNode = node;//b

                Count++;
            }
        }

        /// <summary>
        /// Remove node by node index
        /// </summary>
        /// <param name="indexToRemove"></param>
        public static void RemoveNode(int indexToRemove) // удаляет элемент по порядковому номеру
        {
            Node nodeToRemove = Head;

            //вычисляем какую ноду удалить и отправляем в метод удаления ноды
            if (indexToRemove == 0)
            {
                nodeToRemove = Head;
            }
            else if (indexToRemove > 0)
            {
                while (indexToRemove > 0)
                {
                    if(nodeToRemove.NextNode != null)
                    {
                        nodeToRemove = nodeToRemove.NextNode;
                        indexToRemove--;
                    }
                    else // попытка удаления несуществующей ноды
                    {
                        return;
                    }
                }
            }
            RemoveNode(nodeToRemove);
        }

        /// <summary>
        /// Remove node by node
        /// </summary>
        /// <param name="nodeToRemove"></param>
        public static void RemoveNode(Node nodeToRemove) // удаляет указанный элемент
        {
            if (nodeToRemove == Head)
            {
                if (Head.NextNode != null)
                {
                    Head = Head.NextNode;
                    Head.PrevNode = null;
                }
                else// если это начало и у начала нет ссылки на продолжение
                {
                    Head.PrevNode = null;
                    Head = null;
                    Tail.PrevNode = null;
                    Tail = null;
                }                
                Count--;
            }
            else
            {
                //     -->a       -->c
                // node    delete    second
                //     <--b       <--d
                if (nodeToRemove != null && nodeToRemove.PrevNode != null)//проверка на удаление несуществующей ноды
                {
                    if (nodeToRemove.NextNode == null)//проверка на удаление последней ноды
                    {
                        nodeToRemove.PrevNode.NextNode = null; // a -> c
                        Tail = nodeToRemove.PrevNode;
                    }
                    else
                    {
                        nodeToRemove.PrevNode.NextNode = nodeToRemove.NextNode; // a -> c
                        nodeToRemove.NextNode.PrevNode = nodeToRemove.PrevNode; // d -> b
                    }
                    Count--;
                }
            }
        }

        /// <summary>
        /// Find Node by value searchValue
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static Node FindNode(int searchValue) // ищет элемент по его значению
        {
            Node currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                    return currentNode;

                currentNode = currentNode.NextNode;
            }

            return null; // если ничего не нашли, то null
        }

        /// <summary>
        /// Find Node by node index searchIndex
        /// </summary>
        /// <param name="searchIndex"></param>
        /// <returns></returns>
        public static Node FindNodeByIndex(int searchIndex)// ищет элемент по его индексу
        {
            Node nodeByIndex = new Node();

            //вычисляем какую ноду удалить и отправляем в метод удаления ноды
            if (searchIndex == 0)
            {
                nodeByIndex = Head;
            }
            else if (searchIndex > 0)
            {
                nodeByIndex = Head;
                while (searchIndex > 0)
                {
                    if(nodeByIndex != null)// если нет связанного списка
                        nodeByIndex = nodeByIndex.NextNode;
                    searchIndex--;
                }
            }

            if (nodeByIndex != null)
            {
                return nodeByIndex;
            }
            else // если ничего не нашли, то null
            {
                return null;
            }
        }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodesRange(params int[] nodesValue); // добавляет несколько элементов списка подряд
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
        Node FindNodeByIndex(Node node);// ищет элемент по его индексу
    }



}
