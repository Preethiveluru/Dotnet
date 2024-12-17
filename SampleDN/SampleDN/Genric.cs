//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SampleDN
//{
//    internal class Genric
//    {
//        static void Main(string[] args)
//        {
//            // 1. List
//            List<int> numbers = new List<int>();
//            numbers.Add(1);
//            numbers.Add(2);
//            numbers.Add(3);
//            numbers.Remove(3);
//            numbers.Contains(3);
//            Console.WriteLine("List elements:");
//            foreach (int number in numbers)
//            {
//                Console.WriteLine(number);
//            }

//            // 2. Dictionary<TKey, TValue>
//            Dictionary<int, string> studentGrades = new Dictionary<int, string>();
//            studentGrades[1] = "A";
//            studentGrades[2] = "B";
//            studentGrades[3] = "A+";
//            Console.WriteLine("\nDictionary elements:");
//            foreach (var i in studentGrades)
//            {
//                Console.WriteLine($"Student ID: {i.Key}, Grade: {i.Value}");
//            }

//            // 3. HashSet<T>
//            HashSet<string> uniqueNames = new HashSet<string>();
//            uniqueNames.Add("Alice");
//            uniqueNames.Add("Bob");
//            uniqueNames.Add("Alice"); 
//            Console.WriteLine("\nHashSet elements:");
//            foreach (string name in uniqueNames)
//            {
//                Console.WriteLine(name);
//            }

//            // 4. Queue<T> 
//            Queue<string> taskQueue = new Queue<string>();
//            taskQueue.Enqueue("Task 1");
//            taskQueue.Enqueue("Task 2");
//            taskQueue.Enqueue("Task 3");
//            Console.WriteLine("\nQueue elements:");
//            while (taskQueue.Count > 0)
//            {
//                Console.WriteLine(taskQueue.Dequeue());
//            }

//            // 5. Stack<T> 
//            Stack<string> Stack = new Stack<string>();
//            Stack.Push("Page 1");
//            Stack.Push("Page 2");
//           Stack.Push("Page 3");
//            Console.WriteLine("\nStack elements:");
//            while (Stack.Count > 0)
//            {
//                Console.WriteLine(Stack.Pop());
//            }
//        }
//    }

//}
//using System;
//using System.Collections.Generic;

//namespace SampleDN
//{
//    internal class GenericDemo
//    {
//        // Generic method to display elements of any IEnumerable<T>
//        public static void DisplayElements<T>(IEnumerable<T> collection)
//        {
//            foreach (T item in collection)
//            {
//                Console.WriteLine(item);
//            }
//        }

//        // Generic method to add elements to a collection
//        public static void AddElements<T>(ICollection<T> collection, params T[] elements)
//        {
//            foreach (var element in elements)
//            {
//                collection.Add(element);
//            }
//        }

//        static void Main(string[] args)
//        {
//            // 1. List<T> with Generics
//            List<int> numbers = new List<int>();
//            AddElements(numbers, 1, 2,3);
//            numbers.Remove(3); 
//            Console.WriteLine("List elements:");
//            DisplayElements(numbers);

//            // 2. Dictionary<TKey, TValue> with Generics
//            Dictionary<int, string> studentGrades = new Dictionary<int, string>
//            {
//                { 1, "A" },
//                { 2, "B" },
//                { 3, "A+" }
//            };
//            Console.WriteLine("\nDictionary elements:");
//            foreach (var pair in studentGrades)
//            {
//                Console.WriteLine($"Student ID: {pair.Key}, Grade: {pair.Value}");
//            }

//            // 3. HashSet<T> with Generics
//            HashSet<string> uniqueNames = new HashSet<string>();
//            AddElements(uniqueNames, "Alice", "Bob", "Alice"); 
//            Console.WriteLine("\nHashSet elements:");
//            DisplayElements(uniqueNames);

            // 4. Queue<T> with Generics
            //Queue<string> taskQueue = new Queue<string>();
            //AddElements(taskQueue, "Task 1", "Task 2", "Task 3");
            //Console.WriteLine("\nQueue elements:");
            //while (taskQueue.Count > 0)
            //{
            //    Console.WriteLine(taskQueue.Dequeue());
            //}

            //// 5. Stack<T> with Generics
            //Stack<string> stack = new Stack<string>();
            //AddElements(stack, "Page 1", "Page 2", "Page 3");
            //Console.WriteLine("\nStack elements:");
            //while (stack.Count > 0)
            //{
            //    Console.WriteLine(stack.Pop());
            //}

           
//        }
//    }
//}

