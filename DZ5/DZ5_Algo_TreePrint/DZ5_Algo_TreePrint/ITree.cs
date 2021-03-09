using System;
using System.Collections.Generic;
using System.Text;

namespace DZ5_Algo_TreePrint
{
    public interface ITree
    {
        Node GetRoot();
        void AddItem(int value); // добавить узел
        void AddNodesRange(params int[] nodeValues);// добавить несколько узлов
        void RemoveItem(int value); // удалить узел по значению
        Node GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }
}
