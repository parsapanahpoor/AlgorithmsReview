using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        int[] arr = { 29, 10, 14, 37, 13 };
        BubbleSortWithSteps(arr);
    }

    static void BubbleSortWithSteps(int[] arr)
    {
        int n = arr.Length;
        int step = 1;
        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                Console.Clear();
                Console.WriteLine($"Step {step++}: Comparing index {j} and {j + 1}");
                PrintArray(arr, j, j + 1);
                Thread.Sleep(1000);

                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;

                    Console.Clear();
                    Console.WriteLine($"Step {step++}: Swapped index {j} and {j + 1}");
                    PrintArray(arr, j, j + 1);
                    Thread.Sleep(1000);
                }
            }
        }

        sw.Stop();
        Console.Clear();
        Console.WriteLine("Final Sorted Array:");
        PrintArray(arr, -1, -1);
        Console.WriteLine($"\nTotal Steps: {step - 1}");
        Console.WriteLine($"Execution Time: {sw.Elapsed.TotalSeconds:F3} seconds");
    }

    static void PrintArray(int[] arr, int highlight1, int highlight2)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == highlight1 || i == highlight2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{arr[i]}] ");
                Console.ResetColor();
            }
            else
            {
                Console.Write($" {arr[i]}  ");
            }
        }
        Console.WriteLine();
    }
}
