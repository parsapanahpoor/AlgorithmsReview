using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static int step = 1;
    static Stopwatch sw = new Stopwatch();

    static void Main()
    {
        int[] arr = { 29, 10, 14, 37, 13 };
        int target = 37;

        sw.Start();
        LinearSearchWithSteps(arr, target);
        sw.Stop();
    }

    static void LinearSearchWithSteps(int[] arr, int target)
    {
        bool found = false;

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Clear();
            Console.WriteLine($"Step {step++}: Checking index {i}");
            PrintArray(arr, i);
            Thread.Sleep(5000);

            if (arr[i] == target)
            {
                Console.Clear();
                Console.WriteLine($"Step {step++}: ✅ Found target {target} at index {i}!");
                PrintArray(arr, i);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.Clear();
            Console.WriteLine($"❌ Target {target} not found in array.");
            PrintArray(arr, -1);
        }

        Console.WriteLine($"\nTotal Steps: {step - 1}");
        Console.WriteLine($"Execution Time: {sw.Elapsed.TotalSeconds:F3} seconds");
    }

    static void PrintArray(int[] arr, int highlightIndex)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == highlightIndex)
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
