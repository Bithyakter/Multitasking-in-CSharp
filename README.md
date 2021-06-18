# Multitasking-in-CSharp
Multitasking in CSharp

        class Program
    {
        /*=======================Task Using Delegate====================*/
        private static void PerformTaskUsingDelegate()
        {
            Console.WriteLine("This Task Performed using Delegate.\n");
        }

        /*=======================Task Using Action====================*/
        private static void PerofrmTaskUsingAction()
        {
            Console.WriteLine("This Task Performed using Action.\n");
        }

        /*=======================Task Using Lambda And Named Method====================*/
        private static void PerformTaskLambdaNamedMethod()
        {
            Console.WriteLine("This Task Performed using Lambda and Named Method.\n");
        }

        /*=======================Task Using AsyncAwait====================*/
        private static void PerformTaskgAsyncAwait()
        {
            Console.WriteLine("This Task Performed using Async and Await.\n");
        }
        private static async void PerformAsyncTask()
        {
            await Task.Run(() => PerformTaskgAsyncAwait());
        }

        /*=======================Task Using FromResult Method====================*/
        private static int PerformAdd(int num1, int num2)
        {
            return num1 + num2;
        }
        private static async void Summation(int number1, int number2)
        {
            int result = await Task.FromResult(PerformAdd(number1, number2));
            await Task.Delay(1000);
            Console.WriteLine("Result = " + result.ToString());
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Print MultiTasking with Asynchronous");
            Console.WriteLine("==========================================\n");

            //Task Using Delegate.
            Task delegateTask = new Task(delegate { PerformTaskUsingDelegate(); });
            delegateTask.Wait(1200);
            delegateTask.Start();

            //Task Using Action
            Task actionTask = new Task(new Action(PerofrmTaskUsingAction));
            actionTask.Wait(1200);
            actionTask.Start();

            //Task using Lambda and Named Method.
            Task lambda = new Task(() => PerformTaskLambdaNamedMethod());
            lambda.Wait(1200);
            lambda.Start();

            //Task using Async and Await.
            PerformAsyncTask();

            //Task Using From Result Method
            Console.Write("\nEnter First Number = ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Second Number = ");
            int num2 = int.Parse(Console.ReadLine());

            Summation(num1, num2);


            Console.ReadLine();
        }
    }
