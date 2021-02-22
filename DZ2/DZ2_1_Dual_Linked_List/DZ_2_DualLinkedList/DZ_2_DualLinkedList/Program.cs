using System;

namespace GeekBrainsTests
{
    class Program
    {
        public class Tests
        {
            public int[] setValues { get; set; }
            public int?[] expectedValues { get; set; }
            public int? nodeTarget { get; set; }
        }

        static void Main(string[] args)
        {
            /*
             * Alexander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 
             * 1. Двусвязный список
             * Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом.
             */

            bool allpassed = true;

            ///проверка AddNode(value);
            Tests[] testSuitAddNode = new Tests[2];
            testSuitAddNode[0] = new Tests()//проверка добавления первой ноды
            {
                setValues = new int[] { 1 },
                expectedValues = new int?[] { 1 }
            };
            testSuitAddNode[1] = new Tests()//проверка добавления нод после первой
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { 1, 2, 3 },
            };
            foreach (Tests testCaseAddNode in testSuitAddNode)
            {
                //сначала добавляем ноды 
                PrepareTestEnvironment(testCaseAddNode.setValues);               

                //затем собираем все значения актуальных нод и сравниваем с контрольным
                CompareTestResult("AddNode(value)", testCaseAddNode.expectedValues, ref allpassed);
            }

            ///проверка AddNodeAfter
            Tests[] testSuitAddNodeAfter = new Tests[2];
            testSuitAddNodeAfter[0] = new Tests()//проверка добавление в конец
            {
                setValues = new int[] { 1 },
                expectedValues = new int?[] { 1 , 4 },
                nodeTarget = 0
            };
            testSuitAddNodeAfter[1] = new Tests()//проверка добавление между нодами
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { 1, 2, 4, 3 },
                nodeTarget = 1
            };
            foreach (Tests testCaseAddNodeAfter in testSuitAddNodeAfter)
            {
                //сначала добавляем ноды 
                PrepareTestEnvironment(testCaseAddNodeAfter.setValues);

                Node pointer = Node.Head;
                for(int i = 0; i < testCaseAddNodeAfter.nodeTarget; i++)
                {
                    pointer = pointer.NextNode;
                }
                Node.AddNodeAfter(pointer, 4);

                //затем собираем все значения актуальных нод и сравниваем с контрольным
                CompareTestResult("AddNode(value)", testCaseAddNodeAfter.expectedValues, ref allpassed);
            }

            /// RemoveNode by index
            Tests[] testSuitRemoveNode = new Tests[4];
            testSuitRemoveNode[0] = new Tests()// remove first
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { 2, 3 },
                nodeTarget = 0
            };
            testSuitRemoveNode[1] = new Tests()//remove middle
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { 1, 3 },
                nodeTarget = 1
            };
            testSuitRemoveNode[2] = new Tests()//remove last
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { 1, 2 },
                nodeTarget = 2
            };            
            testSuitRemoveNode[3] = new Tests()//remove non exist
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { 1, 2, 3 },
                nodeTarget = 10
            };
            foreach (Tests testCaseRemoveNode in testSuitRemoveNode)
            {
                //сначала добавляем ноды 
                PrepareTestEnvironment(testCaseRemoveNode.setValues);

                int target = (int)testCaseRemoveNode.nodeTarget;
                Node.RemoveNode(target);

                //затем собираем все значения актуальных нод и сравниваем с контрольным
                CompareTestResult($"RemoveNode({target})", testCaseRemoveNode.expectedValues, ref allpassed);
            }


            ///Node = FindNode(int searchValue)
            Tests[] testSuitFindNode = new Tests[4];
            testSuitFindNode[0] = new Tests()// FindNode first
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { 1 },
                nodeTarget = 1
            };
            testSuitFindNode[1] = new Tests()//FindNode middle
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { 1 },
                nodeTarget = 1
            };
            testSuitFindNode[2] = new Tests()//FindNode last
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { 3 },
                nodeTarget = 3
            };
            testSuitFindNode[3] = new Tests()//FindNode non exist
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { null },
                nodeTarget = 10
            };
            foreach (Tests testCaseFindNode in testSuitFindNode)
            {
                //сначала добавляем ноды 
                PrepareTestEnvironment(testCaseFindNode.setValues);

                int target = (int)testCaseFindNode.nodeTarget;
                Node resultNode = Node.FindNode(target);

                CheckFindTestresult(resultNode, $"FindNode({target})", testCaseFindNode.expectedValues[0], ref allpassed);
            }

            ///Node = FindNodeByIndex(int index)
            Tests[] testSuitFindNodeByIndex = new Tests[4];
            testSuitFindNodeByIndex[0] = new Tests()// FindNodeByIndex first
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { 1 },
                nodeTarget = 0
            };
            testSuitFindNodeByIndex[1] = new Tests()//FindNodeByIndex middle
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { 2 },
                nodeTarget = 1
            };
            testSuitFindNodeByIndex[2] = new Tests()//FindNodeByIndex last
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { 3 },
                nodeTarget = 2
            };
            testSuitFindNodeByIndex[3] = new Tests()//FindNodeByIndex non exist
            {
                setValues = new int[] { 1, 2, 3 },
                expectedValues = new int?[] { null },
                nodeTarget = 10
            };
            foreach (Tests testCaseFindNodeByIndex in testSuitFindNodeByIndex)
            {
                //сначала добавляем ноды 
                PrepareTestEnvironment(testCaseFindNodeByIndex.setValues);

                int target = (int)testCaseFindNodeByIndex.nodeTarget;
                Node resultNode = Node.FindNodeByIndex(target);

                CheckFindTestresult(resultNode, $"FindNodeByIndex({target})", testCaseFindNodeByIndex.expectedValues[0], ref allpassed);
            }

            if(allpassed)
                Console.WriteLine("All Tests passed, OK.");

            //some use examples
            Node.AddNodesRange(1, 2, 3, 4, 5);          // 1 2 3 4 5
            Node.AddNode(6);                            // 1 2 3 4 5 6
            Node.RemoveNode(2);                         // 1 2 4 5 6
            Node.AddNodeAfter(Node.FindNode(1), 777);   // 1 777 2 4 5 6
            Node.RemoveNode(Node.FindNodeByIndex(0));   // 777 2 4 5 6

            ShowNodeValues();

            Console.Read();
        }

        private static void CheckFindTestresult(Node result, string testName, int? expected, ref bool allpassed)
        {

            if (result != null)
            {
                if (result.Value != expected)
                {
                    allpassed = false;
                    Console.WriteLine($"Ошибка! Для метода {testName} ожидаемый результат {expected} != фактическому {result.Value}");
                }
            }
            else
            {
                if (expected != null)
                {
                    //string vv = Node.FindNodeByIndex(6)?.Value.ToString() ?? "null";
                    string actVal = result?.Value.ToString() ?? "null";
                    Console.WriteLine($"Ошибка! Для метода {testName} ожидаемый результат {expected} != фактическому {actVal}");
                    allpassed = false;
                }
            }

            //затем зачищаем за собой - удаляем все ноды.
            DeleteAlNodes();
        }

        private static void CompareTestResult(string testName, int?[] expectedValues, ref bool allpassed)
        {
            Node currentNode = Node.Head;
            int iterator = 0;

            while (currentNode != null)
            {
                if (currentNode.Value != expectedValues[iterator])
                {
                    allpassed = false;
                    Console.WriteLine($"Ошибка! Для метода {testName} ожидаемый результат {expectedValues[iterator]} != фактическому {currentNode.Value}");
                }
                currentNode = currentNode.NextNode;
                iterator++;
            }

            if (iterator < expectedValues.Length)
            {
                Console.WriteLine($"Ошибка! Для метода {testName} в ожидаемых значениях данных больше, чем в фактических результатах");
            }

            //затем зачищаем за собой - удаляем все ноды.
            DeleteAlNodes();
        }

        private static void PrepareTestEnvironment(int[] setValues)
        {
            foreach (int value in setValues)
            {
                Node.AddNode(value);
            }
        }

        private static void DeleteAlNodes()
        {
            Node currentNodeHead = Node.Head;

            while (currentNodeHead != null)
            {
                Node nodeToRemove = currentNodeHead;
                currentNodeHead = currentNodeHead.NextNode;
                Node.RemoveNode(nodeToRemove);
            }
        }

        private static void ShowNodeValues()
        {
            //список от начала
            Console.Write($"всего: {Node.Count}   ");            
            Node currentNodeHead = Node.Head;

            while (currentNodeHead != null)
            {
                Console.Write(currentNodeHead.Value + "-->");
                currentNodeHead = currentNodeHead.NextNode;
            }

            Console.WriteLine();

            //список от конца
            Console.Write($"всего: {Node.Count}   ");
            Node currentNodeTail = Node.Tail;
            while (currentNodeTail != null)
            { 
                Console.Write(currentNodeTail.Value + "-->");
                currentNodeTail = currentNodeTail.PrevNode;
            }
            Console.WriteLine();
        }
    }
}
