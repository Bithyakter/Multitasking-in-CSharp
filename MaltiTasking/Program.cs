using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaltiTasking
{
    class Program
    {
        private static void CreateTaskUsingAction()
        {
            Console.WriteLine("This Task is created using Action.\n");
        }

        private static void CreateTaskUsingDelegate()
        
            Console.WriteLine("This Task is created using Delegate.\n");
        }

        private static void CreateTaskUsingLambdaNamedMethod()
        {
            Console.WriteLine("This Task is created using Lambda and Named Method.\n");
        }

        private static void CreateTaskUsingLambdaAndAnonymousMethod()
        {
            Console.WriteLine("This Task is created using Lambda and Anonymous Method.\n");
        }

        private static void CreateTaskUsingAsyncAwait()
        {
            Console.WriteLine("This Task is created using Async and Await.\n");
        }

        private static async void CreateAsyncTask()
        {
            await Task.Run(() => CreateTaskUsingAsyncAwait());
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }


        private static async void SolveTheMath(int firstInt, int secondtInt)
        {
            int result = await Task.FromResult(Add(firstInt, secondtInt));
            await Task.Delay(1000);
            Console.WriteLine("Result = " + result.ToString());
        }



        static void Main(string[] args)
        {

            Console.WriteLine("==========================\n");

            
            Task actionTask = new Task(new Action(CreateTaskUsingAction)); 
            actionTask.Wait(1000);	//Creating a Task using Action
            actionTask.Start();

            
            Task delegateTask = new Task(delegate { CreateTaskUsingDelegate(); }); 
            delegateTask.Wait(1000);	//Creating a Task using Delegate.
            delegateTask.Start();

            
            Task lambdaAndNamedMethodTask = new Task(() => CreateTaskUsingLambdaAndNamedMethod()); 
            lambdaAndNamedMethodTask.Wait(1000);	//Creating a Task using Lambda and Named Method.
            lambdaAndNamedMethodTask.Start();

            
            Task lambdaAndAnonymousMethodTask = new Task(() => { CreateTaskUsingLambdaAndAnonymousMethod(); }); 
            lambdaAndAnonymousMethodTask.Wait(1000);	//Creating a Task using Lambda and Anonymous Method.
            lambdaAndAnonymousMethodTask.Start();

            
            CreateAsyncTask();  	//Creating a Task using Async and Await.

            Console.Write("\nFirst Integer = ");
            int firstInt = int.Parse(Console.ReadLine());
            Console.Write("Second Integer = ");
            int secondtInt = int.Parse(Console.ReadLine());

            SolveTheMath(firstInt, secondtInt); //Creating a Task using FromResult Method.

            Console.ReadKey();
        }


        private static void FactorialUsingTask(int x) 
        {
            Task.Run<long>(() =>
            {
                long r = FactorialWithDelay(x);
                return r;
            })
              .ContinueWith((t) =>
              { 
                  Console.WriteLine($"{x}!={t.Result}"); 
              });
        }

        private static long FactorialWithDelay(int n)
        {
            long f = 1;
            for (int i = n; i >= 1; i--)
            { 
                Thread.Sleep(100); f *= i; 
            }
            return f;

        }
    }
}
