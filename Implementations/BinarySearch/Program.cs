using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static int step = 1;
    static Stopwatch sw = new Stopwatch();

    static void Main()
    {
        int[] arr = { 10, 13, 14, 29, 37 }; // آرایه مرتب‌شده
        int target = 29;

        sw.Start();
        BinarySearchWithSteps(arr, target);
        sw.Stop();
    }

    static void BinarySearchWithSteps(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;
        bool found = false;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            Console.Clear();
            Console.WriteLine($"Step {step++}: Checking middle index {mid}");
            PrintArray(arr, left, mid, right);
            Thread.Sleep(5000);

            if (arr[mid] == target)
            {
                Console.Clear();
                Console.WriteLine($"Step {step++}: ✅ Found target {target} at index {mid}!");
                PrintArray(arr, mid, mid, mid);
                found = true;
                break;
            }
            else if (arr[mid] < target)
            {
                Console.Clear();
                Console.WriteLine($"Step {step++}: {arr[mid]} < {target} → Searching right half");
                left = mid + 1;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Step {step++}: {arr[mid]} > {target} → Searching left half");
                right = mid - 1;
            }

            Thread.Sleep(5000);
        }

        if (!found)
        {
            Console.Clear();
            Console.WriteLine($"❌ Target {target} not found in array.");
            PrintArray(arr, -1, -1, -1);
        }

        Console.WriteLine($"\nTotal Steps: {step - 1}");
        Console.WriteLine($"Execution Time: {sw.Elapsed.TotalSeconds:F3} seconds");
    }

    static void PrintArray(int[] arr, int left, int mid, int right)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == mid)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{arr[i]}] ");
                Console.ResetColor();
            }
            else if (i >= left && i <= right)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {arr[i]} ");
                Console.ResetColor();
            }
            else
            {
                Console.Write($" {arr[i]} ");
            }
        }
        Console.WriteLine();
    }
}
