using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        int[] arr = { 29, 10, 14, 37, 13 };
        SelectionSortWithSteps(arr);
    }

    static void SelectionSortWithSteps(int[] arr)
    {
        int n = arr.Length;
        int step = 1;
        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                Console.Clear();
                Console.WriteLine($"Step {step++}: Comparing index {minIndex} and {j}");
                PrintArray(arr, minIndex, j);
                Thread.Sleep(3000);

                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                    Console.Clear();
                    Console.WriteLine($"Step {step++}: New minimum found at index {minIndex}");
                    PrintArray(arr, i, minIndex);
                    Thread.Sleep(3000);
                }
            }

            if (minIndex != i)
            {
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;

                Console.Clear();
                Console.WriteLine($"Step {step++}: Swapped index {i} and {minIndex}");
                PrintArray(arr, i, minIndex);
                Thread.Sleep(3000);
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
                Console.ForegroundColor = ConsoleColor.Cyan;
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
