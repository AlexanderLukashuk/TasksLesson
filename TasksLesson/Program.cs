using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TasksLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task task = new Task(() =>
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
            //    //TODO
            //});
            //task.Start();

            ////Task longOptimalTask = Task.Factory.StartNew();

            //Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
            //    //TODO
            //});

            // эквивалент
            //Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
            //    //TODO
            //}, default(CancellationToken), TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);

            //Task.Run(() => 
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
            //    //TODO
            //});

            //var taskResult = Task.Run(() =>
            //{
            //    Thread.Sleep(4000);
            //    //throw new FileNotFoundException("Oops");
            //    return 3;
            //});

            ////var exception = taskResult.Exception;
            //while(!taskResult.IsCompleted)
            //{
            //    Console.WriteLine("Происходит выполнение...");
            //    Thread.Sleep(700);
            //}
            //var result = taskResult.Result;



            // Отмена задачи
            //CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            ////CancellationToken token = cancellationTokenSource.Token;

            //var potentialCancelledTask = Task.Run(() =>
            //{
            //    Console.WriteLine("Запуск");
            //    Thread.Sleep(4000);
            //    //throw new FileNotFoundException("Oops");
            //    Console.WriteLine("Готово");
            //    return 3;
            //}, cancellationTokenSource.Token);

            ////Thread.Sleep(3000);
            //cancellationTokenSource.Cancel();

            //Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
            //    //TODO
            //}, default, TaskCreationOptions.LongRunning, TaskScheduler.Default);

            Task.Run(() =>
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
                //throw new FileNotFoundException("Oops");
                return 1;
            }).ContinueWith((result) =>
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
                // работаем с result
                Thread.Sleep(1000);
                return 2;
            }).ContinueWith((result) =>
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
                return 3;
            });

            Task.Run(LongOperation);

            Console.ReadLine();
        }

        private static void LongOperation()
        {
            Task.Run(() => { });
        }
    }
}
