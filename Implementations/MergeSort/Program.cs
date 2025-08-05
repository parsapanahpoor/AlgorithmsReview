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
        MergeSort(arr, 0, arr.Length - 1);
        sw.Stop();

        Console.Clear();
        Console.WriteLine("Final Sorted Array:");
        PrintArray(arr, -1, -1);
        Console.WriteLine($"\nTotal Steps: {step - 1}");
        Console.WriteLine($"Execution Time: {sw.Elapsed.TotalSeconds:F3} seconds");
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            MergeSort(arr, left, middle);
            MergeSort(arr, middle + 1, right);

            Merge(arr, left, middle, right);
        }
    }

    static void Merge(int[] arr, int left, int middle, int right)
    {
        int[] leftArray = new int[middle - left + 1];
        int[] rightArray = new int[right - middle];

        Array.Copy(arr, left, leftArray, 0, leftArray.Length);
        Array.Copy(arr, middle + 1, rightArray, 0, rightArray.Length);

        int i = 0, j = 0, k = left;

        while (i < leftArray.Length && j < rightArray.Length)
        {
            Console.Clear();
            Console.WriteLine($"Step {step++}: Merging index {k}");
            PrintArray(arr, k, -1);
            Thread.Sleep(5000);

            if (leftArray[i] <= rightArray[j])
            {
                arr[k++] = leftArray[i++];
            }
            else
            {
                arr[k++] = rightArray[j++];
            }
        }

        while (i < leftArray.Length)
        {
            Console.Clear();
            Console.WriteLine($"Step {step++}: Copying from left array to index {k}");
            PrintArray(arr, k, -1);
            Thread.Sleep(5000);
            arr[k++] = leftArray[i++];
        }

        while (j < rightArray.Length)
        {
            Console.Clear();
            Console.WriteLine($"Step {step++}: Copying from right array to index {k}");
            PrintArray(arr, k, -1);
            Thread.Sleep(5000);
            arr[k++] = rightArray[j++];
        }
    }

    static void PrintArray(int[] arr, int highlight, int secondHighlight)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == highlight || i == secondHighlight)
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
