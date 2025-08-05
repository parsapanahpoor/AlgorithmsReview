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
        sw.Start();
        QuickSort(arr, 0, arr.Length - 1);
        sw.Stop();

        Console.Clear();
        Console.WriteLine("Final Sorted Array:");
        PrintArray(arr, -1, -1);
        Console.WriteLine($"\nTotal Steps: {step - 1}");
        Console.WriteLine($"Execution Time: {sw.Elapsed.TotalSeconds:F3} seconds");
    }

    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            Console.Clear();
            Console.WriteLine($"Step {step++}: Comparing {arr[j]} with pivot {pivot}");
            PrintArray(arr, j, high);
            Thread.Sleep(4000);

            if (arr[j] <= pivot)
            {
                i++;
                Swap(arr, i, j);

                Console.Clear();
                Console.WriteLine($"Step {step++}: Swapped index {i} and {j}");
                PrintArray(arr, i, j);
                Thread.Sleep(4000);
            }
        }

        Swap(arr, i + 1, high);

        Console.Clear();
        Console.WriteLine($"Step {step++}: Swapped pivot from index {high} to {i + 1}");
        PrintArray(arr, i + 1, high);
        Thread.Sleep(4000);

        return i + 1;
    }

    static void Swap(int[] arr, int i, int j)
    {
        if (i == j) return;
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static void PrintArray(int[] arr, int highlight1, int highlight2)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == highlight1 || i == highlight2)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
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
