using AsyncAwait;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"Main: {Thread.CurrentThread.ManagedThreadId}");


            //AsyncAwaitSample asyncAwaitSample = new AsyncAwaitSample();
            //Task<bool> task = asyncAwaitSample.DoAsync();

            AsyncAwaitExceptionHandling asyncAwaitExceptionHandling = new AsyncAwaitExceptionHandling();
            //asyncAwaitExceptionHandling.MainTaskAsync();

            //Console.WriteLine("Before reading result");
            //Console.WriteLine(task.Result);

            //MergeSortSample mergeSortSample = new MergeSortSample();
            //mergeSortSample.MergeSort();

            //QueueWithArray queueWithArray = new QueueWithArray();
            //queueWithArray.Main();

            //UsersQueryExpression();

            //MergeSortSample mergeSortSample = new MergeSortSample();
            //mergeSortSample.MergeSort();

            ////Compare two object with Object.Equals
            //MySampleClass mySampleClass = new MySampleClass() { Name = "Manik", EmailAddress = "manik@manik.com" };
            //MySampleClass mySampleClass1 = new MySampleClass() { Name = "Manik", EmailAddress = "manik@manik.com" };
            //MySampleClass mySampleClass2 = new MySampleClass() { Name = "Test", EmailAddress = "Test@Test.com" };
            //Console.WriteLine($"Compare two objects with Equals: {Object.Equals(mySampleClass, mySampleClass1)}");

            //DoublyLinkedListSample doublyLinkedListSample = new DoublyLinkedListSample();

            //DataStructuresSample dataStructuresSample = new DataStructuresSample();

            //DictionaryUsingArray dictionaryUsingArray = new DictionaryUsingArray();

            //NumberToWordsTransformationApproachOne numberToWordsTransformationApproachOne = new NumberToWordsTransformationApproachOne();
            //NumberToWordsTransformationApproachTwo numberToWordsTransformationApproachTwo = new NumberToWordsTransformationApproachTwo();

            //StackWithArray stackWithArray = new StackWithArray();

            //MaxDepthOfTree maxDepthOfTree = new MaxDepthOfTree();
            //TreeInOrderPreOrderPostOrder treeInOrderPreOrderPostOrder = new TreeInOrderPreOrderPostOrder();
            //LevelOrderTreeTraversal levelOrderTreeTraversal = new LevelOrderTreeTraversal();
            //LinQSample linQQ = new LinQSample();

            StringReverse stringReverse = new StringReverse();

            //int x = 10;
            //Console.WriteLine(++x);
            //Console.WriteLine(x);
            //Console.WriteLine(x++);
            //Console.WriteLine(x);

            //YieldSample yieldSample = new YieldSample();

            //QuickSort quickSort = new QuickSort();
            //MaxOccuringCharInString maxOccuringCharInString = new MaxOccuringCharInString();
            //PosiblePolindromsInGivenString posiblePolindromsInGivenString = new PosiblePolindromsInGivenString("abbaeae");

            //GenericList genericList = new GenericList();
            //CircularQueue circularQueue = new CircularQueue();

            //Console.WriteLine("Has" == "has");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void UsersQueryExpression()
        {
            IQueryableSample queryableSample = new IQueryableSample();
            Mock<IDbContext> mockContext = new Mock<IDbContext>();
            //IDbContext dbContext = new dbDataContext();

            queryableSample.ReturnsUsers(mockContext.Object);
            //mockContext.Setup(c => c.GetUsers())
        }
    }

    public class MySampleClass
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
}