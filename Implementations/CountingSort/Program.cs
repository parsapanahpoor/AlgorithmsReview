class Program
{
    static void CountingSort(int[] array)
    {
        // پیدا کردن بیشترین مقدار آرایه
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
                max = array[i];
        }

        // آرایه شمارش
        int[] count = new int[max + 1];

        // شمارش تعداد هر عنصر
        for (int i = 0; i < array.Length; i++)
        {
            count[array[i]]++;
        }

        // بازسازی آرایه مرتب‌شده
        int index = 0;
        for (int i = 0; i < count.Length; i++)
        {
            while (count[i] > 0)
            {
                array[index] = i;
                index++;
                count[i]--;
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter numbers separated by space:");
        string input = Console.ReadLine();
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = Array.ConvertAll(parts, int.Parse);

        Console.WriteLine("\nBefore Sorting:");
        Console.WriteLine(string.Join(" ", numbers));

        CountingSort(numbers);

        Console.WriteLine("\nAfter Sorting:");
        Console.WriteLine(string.Join(" ", numbers));

        Console.WriteLine("\nCounting Sort is a non-comparison-based algorithm.\n" +
                          "It counts the number of occurrences of each value " +
                          "and reconstructs the sorted output.");
    }
}