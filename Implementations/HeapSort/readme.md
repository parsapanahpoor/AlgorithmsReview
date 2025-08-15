***

# Heap Sort in C#

## English Article

### Introduction to Heap Sort
**Heap Sort** is a comparison-based sorting algorithm that utilizes a **binary heap** data structure to sort data. It operates by first transforming the input array into a **max-heap**, where the largest element resides at the root. Subsequently, the algorithm repeatedly extracts the root element and rebuilds the heap until all elements are sorted. Heap Sort is an **in-place** algorithm, meaning it requires **O(1) extra space**. However, it is **not stable**, which means that equal elements may not preserve their original relative order after sorting. It guarantees **O(n log n) time complexity** in both average and worst cases, making it an efficient choice for large datasets.

### How Heap Sort Works
Heap Sort consists of two primary phases:
1.  **Build a max-heap**: The array is treated as a complete binary tree and "heapified" so that each node is greater than or equal to its children. This process is done in-place by iterating backward from the last non-leaf node and calling a `Heapify` function on each node.
2.  **Sort by extraction**: The root (which contains the maximum element) is repeatedly swapped with the last element of the heap. The size of the heap is then reduced by one, and `Heapify` is called on the new root to restore the max-heap property. This phase systematically moves the largest elements to the end of the array, one by one, resulting in a fully sorted array.

### Phases in Detail
*   **Heapify Phase**: The array is converted into a max-heap, ensuring that the largest element is at index 0. This phase can be completed in **O(n) time** by calling `Heapify` from the last parent node (index `n/2 - 1`) down to index 0.
*   **Sort Phase**: For each index `i` from `n-1` down to 1, the current root `array` (which is the maximum element) is swapped with `array[i]`. After the swap, the largest element is moved to its final sorted position at the end of the array, and the heap size effectively shrinks by one. `Heapify` is then called on the root with the reduced heap size (`i`) to re-heapify the remaining elements. This recursive process ensures the heap property is maintained as elements are extracted.

For example, given `int[] array = {12, 2, 24, 51, 8, -5}`, after all steps, heap sort will transform it into `{-5, 2, 8, 12, 24, 51}`.

### Implementing Heap Sort in C#
The core of Heap Sort lies in two methods: `Sort` (to build the heap and extract elements) and `Heapify` (to enforce the heap property).

```csharp
public static class HeapSort
{
    // Sorts the array in-place in ascending order
    public static void Sort(int[] array)
    {
        int n = array.Length;

        if (n <= 1)
            return;

        // Build max heap: Start from the last non-leaf node and go up to the root
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(array, n, i);
        }

        // One by one extract elements from the heap
        for (int i = n - 1; i >= 0; i--)
        {
            // Move current root (max) to end of the current array segment
            int temp = array;
            array = array[i];
            array[i] = temp;

            // Heapify the reduced heap (excluding the already sorted elements)
            Heapify(array, i, 0);
        }
    }

    // Ensures the subtree rooted at 'root' is a max-heap
    // 'size' represents the current size of the heap part of the array
    private static void Heapify(int[] array, int size, int root)
    {
        int largest = root;       // Initialize largest as root
        int left = 2 * root + 1;  // Left child index
        int right = 2 * root + 2; // Right child index

        // If left child exists and is larger than current largest
        if (left < size && array[left] > array[largest])
        {
            largest = left;
        }

        // If right child exists and is larger than current largest
        if (right < size && array[right] > array[largest])
        {
            largest = right;
        }

        // If largest is not the root, swap and recursively heapify the affected sub-tree
        if (largest != root)
        {
            int swap = array[root];
            array[root] = array[largest];
            array[largest] = swap;

            // Recursively heapify the affected sub-tree
            Heapify(array, size, largest);
        }
    }
}
```

**How it works**: The `Sort` method first builds a max-heap by calling `Heapify` on each non-leaf node, iterating from indices `n/2 - 1` down to `0`. Then, it enters a loop that repeatedly swaps `array` (the maximum element) with the last element of the current heap segment. After each swap, the heap size is reduced, and `Heapify` is called on the root to rebuild the heap property for the remaining elements. The `Heapify` function itself compares a given node with its children and swaps it with the larger child if necessary, recursing until the subtree satisfies the max-heap property. This in-place process ultimately yields a sorted array.

### Testing Methodology with Sample Datasets
To verify the correctness and measure the performance of Heap Sort, it is recommended to test with various datasets:

*   **Correctness Tests**: Start with small sample arrays (e.g., random values, already sorted, reverse-sorted, or arrays with duplicates) to ensure the implementation correctly sorts each case.
*   **Performance Tests**: Use large arrays to compare timing under different scenarios:
    *   **Random array (average case)**: Filled with random values within a specified range.
    *   **Sorted array (worst case for Heap Sort)**: An ascending sequence of distinct values (e.g., 0, 1, 2, ...).
    *   **Identical array (best case)**: All elements are equal.

For example, test suites often include methods like `CreateRandomArray(size, min, max)`, `CreateSortedArray(size)`, and `CreateIdenticalArray(size, min, max)` to generate these cases. Using such sample data helps observe how execution time varies with input. Benchmarking libraries or `System.Diagnostics.Stopwatch` can be used to measure sort time on each dataset.

### Time and Space Complexity
*   **Time Complexity**: In almost all cases, Heap Sort runs in **O(n log n) time**.
    *   Building the initial heap takes **O(n) time**.
    *   Each of the `n` extract-and-heapify steps costs **O(log n)**.
    *   The total time complexity is therefore **O(n + n log n) = O(n log n)**.
    *   This complexity holds for both average and worst cases. If all elements are equal, some implementations might perform closer to O(n) because the `heapify` step does minimal work, but generally, **O(n log n)** is assumed.
*   **Space Complexity**: Heap Sort is an **in-place algorithm**, requiring only **O(1) auxiliary space**. The heap is maintained within the input array itself, eliminating the need for large additional data structures.
*   **Stability**: Heap Sort is **not stable**. Equal elements may not preserve their original relative order after sorting. This is a key difference from stable sorting algorithms like Merge Sort.

### Performance Test Results
In a practical benchmark (sorting 2,000,000 integers), Code Maze reported the following times on a typical machine:
*   **Best Case (all values identical)**: ~13.13 ms
*   **Average Case (random values)**: ~223.24 ms
*   **Worst Case (sorted values)**: ~210.33 ms

These results demonstrate that sorting a random array (average case) and an already sorted array (worst case) take similar time, which aligns with the **O(n log n) complexity**. The array with identical elements runs significantly faster because minimal swapping is required. Overall, the observed performance matches the theoretical **O(n log n)** behavior. (Actual timings will vary with hardware, data ranges, and implementation details.)

### Example Usage and Benchmarking
Here's an example of using the `HeapSort` implementation:

```csharp
// Example usage
int[] data = { 12, 2, 24, 51, 8, -5 };
Console.WriteLine("Before: " + string.Join(", ", data));

// Perform heap sort in-place
HeapSort.Sort(data);

Console.WriteLine("After:  " + string.Join(", ", data));
// Output: After: -5, 2, 8, 12, 24, 51
```

To measure performance, you can use `System.Diagnostics.Stopwatch`:

```csharp
// Example benchmarking with Stopwatch
int[] largeArray = CreateRandomArray(1000000, 1, 1000000); // Assuming CreateRandomArray exists
var stopwatch = Stopwatch.StartNew();
HeapSort.Sort(largeArray);
stopwatch.Stop();
Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} ms");
```

For more rigorous benchmarks and professional performance analysis, consider using tools like BenchmarkDotNet.

### Summary and Best Practices
**Summary**: Heap Sort is a **robust, in-place sorting algorithm** with guaranteed **O(n log n) performance**. It first builds a max-heap and then sorts by repeatedly extracting the maximum element. Its worst-case time complexity is better than simple sorts (like bubble or insertion sort), but it is generally **slower in practice than optimized quicksort** for average data.

**When to use**: Use Heap Sort when you require an **in-place sort with good worst-case guarantees** and can **tolerate instability**. It is particularly useful for large datasets where extra memory is limited. For many applications, however, language-provided sort routines (e.g., C#'s `Array.Sort`) may employ faster hybrid algorithms (often introsort).

**Best practices**:
*   **Handle edge cases**: Ensure your implementation correctly handles empty arrays, single-element arrays, and null references.
*   **Test thoroughly**: Test with a variety of datasets (random, sorted, reverse-sorted, duplicates) to catch potential issues.
*   **Be aware of instability**: Remember that Heap Sort is not stable; if the original relative order of equal elements matters, use a stable sorting algorithm instead.
*   **Measure performance**: Utilize built-in tools like `Stopwatch` or dedicated benchmarking libraries for accurate performance measurements.
*   **Code clarity**: Comment and structure your code clearly, for instance, by separating the heap-building loop and the extraction loop, and documenting the purpose of each part.

By following these guidelines and understanding Heap Sort's behavior, you can effectively implement and use this algorithm in your C# projects.

***

<div dir="rtl" lang="fa">

# مرتبسازی هیپ در سی‌شارپ

## مقاله فارسی

### معرفی مرتبسازی هیپ
**مرتبسازی هیپ** (Heap Sort) یک الگوریتم مرتبسازی **مبتنی بر مقایسه** است که برای مرتب کردن داده‌ها از ساختار داده‌ای **هیپ دودویی** استفاده می‌کند. این الگوریتم ابتدا آرایه‌ی ورودی را به یک **هیپ بیشینه** تبدیل می‌کند (بزرگترین عنصر در ریشه قرار می‌گیرد). سپس، به صورت مکرر ریشه‌ی هیپ استخراج شده و هیپ بازسازی می‌شود تا در نهایت همه عناصر مرتب شوند. مرتبسازی هیپ **درجا** (in-place) انجام می‌شود و به **O(1) فضای اضافی** نیاز دارد. اما، این الگوریتم **پایدار نیست**؛ به این معنی که عناصر با مقادیر یکسان ممکن است پس از مرتبسازی، ترتیب اصلی خود را حفظ نکنند. پیچیدگی زمانی آن در حالت میانگین و بدترین حالت برابر با **O(n log n)** است که آن را برای مجموعه‌داده‌های بزرگ کارآمد می‌سازد.

### روند کار مرتبسازی هیپ
مرتبسازی هیپ شامل دو مرحله اصلی است:
1.  **ساختن هیپ بیشینه**: آرایه به عنوان یک درخت دودویی کامل در نظر گرفته شده و "هیپیفای" (heapify) می‌شود تا هر گره از فرزندان خود بزرگتر یا مساوی باشد. این کار به صورت درجا انجام می‌شود؛ با شروع از آخرین گره والد (آخرین گرهی که فرزند دارد) و حرکت به سمت عقب، تابع `Heapify` روی هر گره فراخوانی می‌شود.
2.  **مرتبسازی با استخراج**: ریشه‌ی هیپ (بزرگترین عنصر) به صورت تکراری با آخرین عنصر هیپ مبادله می‌شود. سپس اندازه‌ی هیپ یک واحد کم شده و `Heapify` دوباره روی ریشه‌ی جدید فراخوانی می‌شود تا خاصیت هیپ بیشینه حفظ شود. این مرحله بزرگترین عناصر را یکی یکی به انتهای آرایه منتقل می‌کند، که در نهایت منجر به یک آرایه‌ی کاملاً مرتب می‌شود.

### مراحل الگوریتم به تفصیل
*   **مرحله‌ی ساخت هیپ**: آرایه به یک هیپ بیشینه تبدیل می‌شود به طوری که بزرگترین عنصر در اندیس 0 قرار گیرد. این مرحله می‌تواند در **زمان O(n)** با فراخوانی `Heapify` از آخرین گره والد (اندیس `n/2 - 1`) تا اندیس 0 انجام شود.
*   **مرحله‌ی مرتبسازی**: برای هر اندیس `i` از `n-1` به سمت 1، ریشه‌ی فعلی `array` (که بزرگترین عنصر است) با `array[i]` جابجا می‌شود. پس از جابجایی، بزرگترین عنصر به موقعیت نهایی مرتب شده‌ی خود در انتهای آرایه منتقل می‌شود و اندازه‌ی هیپ به طور موثر یک واحد کاهش می‌یابد. سپس `Heapify` با اندازه‌ی هیپ کاهش یافته (`i`) روی ریشه فراخوانی می‌شود تا عناصر باقی‌مانده مجدداً هیپیفای شوند. این فرآیند بازگشتی تضمین می‌کند که خاصیت هیپ در حین استخراج عناصر حفظ شود.

به عنوان مثال، برای آرایه‌ی `int[] array = {12, 2, 24, 51, 8, -5}`، مرتبسازی هیپ پس از تمام مراحل آن را به `{-5, 2, 8, 12, 24, 51}` تبدیل می‌کند.

### پیاده‌سازی مرتبسازی هیپ در سی‌شارپ
هسته‌ی مرتبسازی هیپ دو متد است: `Sort` (برای ساخت هیپ و استخراج عناصر) و `Heapify` (برای اعمال خاصیت هیپ).

</div>

```csharp
public static class HeapSort
{
    // مرتبسازی آرایه به صورت صعودی (درجا)
    public static void Sort(int[] array)
    {
        int n = array.Length;

        if (n <= 1)
            return;

        // ایجاد هیپ بیشینه در آرایه: از آخرین گره غیربرگ شروع کرده و به سمت ریشه بروید
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(array, n, i);
        }

        // استخراج عناصر از هیپ یکییکی
        for (int i = n - 1; i >= 0; i--)
        {
            // ریشه (بزرگترین عنصر) را به انتهای بخش فعلی آرایه منتقل کن
            int temp = array;
            array = array[i];
            array[i] = temp;

            // هیپیفای کردن هیپ با اندازه‌ی کاهش یافته (به جز عناصر مرتب شده)
            Heapify(array, i, 0);
        }
    }

    // تابع کمکی: زیردرختی با ریشه‌ی 'root' را به هیپ بیشینه تبدیل می‌کند
    // 'size' نمایانگر اندازه‌ی فعلی بخش هیپ در آرایه است
    private static void Heapify(int[] array, int size, int root)
    {
        int largest = root;       // بزرگترین را ریشه در نظر بگیر
        int left = 2 * root + 1;  // اندیس فرزند چپ
        int right = 2 * root + 2; // اندیس فرزند راست

        // اگر فرزند چپ وجود دارد و از بزرگترین فعلی بزرگتر است
        if (left < size && array[left] > array[largest])
        {
            largest = left;
        }

        // اگر فرزند راست وجود دارد و از بزرگترین فعلی بزرگتر است
        if (right < size && array[right] > array[largest])
        {
            largest = right;
        }

        // اگر بزرگترین گره تغییر کرده بود، جابجا کن و به صورت بازگشتی زیردرخت تحت تأثیر را هیپیفای کن
        if (largest != root)
        {
            int swap = array[root];
            array[root] = array[largest];
            array[largest] = swap;

            // ادامه هیپیفای کردن زیردرخت تحت تأثیر
            Heapify(array, size, largest);
        }
    }
}
```

<div dir="rtl" lang="fa">

**توضیح کد**: متد `Sort` ابتدا با فراخوانی `Heapify` روی هر گره غیربرگ، از اندیس `n/2 - 1` به سمت 0، یک هیپ بیشینه می‌سازد. سپس، وارد حلقه‌ای می‌شود که هر بار ریشه‌ی هیپ (بزرگترین مقدار) را با آخرین عنصر در محدوده‌ی فعلی جابجا می‌کند. پس از هر جابجایی، اندازه‌ی هیپ کاهش می‌یابد و `Heapify` دوباره روی ریشه اجرا می‌شود تا خاصیت هیپ برای عناصر باقی‌مانده بازسازی شود. خود تابع `Heapify`، یک گره را با فرزندانش مقایسه می‌کند و در صورت نیاز آن را با فرزند بزرگتر جابجا می‌کند و به صورت بازگشتی ادامه می‌دهد تا زیردرخت خاصیت هیپ بیشینه را برآورده کند. این فرآیند درجا در نهایت منجر به یک آرایه‌ی مرتب شده می‌شود.

### روش آزمایش و مجموعه‌داده‌های نمونه
برای اطمینان از صحت و سنجش عملکرد مرتبسازی هیپ، توصیه می‌شود آن را با مجموعه‌داده‌های مختلف آزمایش کنید:

*   **آزمایش صحت**: ابتدا با آرایه‌های کوچک نمونه (مانند آرایه‌های با مقادیر تصادفی، از قبل مرتب شده، معکوس مرتب شده یا شامل مقادیر تکراری) شروع کنید تا از صحت خروجی پیاده‌سازی اطمینان حاصل شود.
*   **آزمایش عملکرد**: از آرایه‌های بزرگ برای مقایسه‌ی زمان اجرا در حالات مختلف استفاده کنید:
    *   **آرایه‌ی تصادفی (حالت متوسط)**: با اعداد تصادفی در یک دامنه مشخص پر شده است.
    *   **آرایه‌ی مرتب شده (بدترین حالت برای مرتبسازی هیپ)**: یک توالی صعودی از مقادیر متمایز (مانند 0, 1, 2, ...).
    *   **آرایه‌ی با تمام عناصر یکسان (بهترین حالت)**: تمام مقادیر آن برابر است.

به عنوان مثال، مجموعه‌های تست اغلب شامل متدهایی مانند `CreateRandomArray(size, min, max)`، `CreateSortedArray(size)`، و `CreateIdenticalArray(size, min, max)` برای تولید این حالت‌ها هستند. استفاده از چنین داده‌های نمونه‌ای به سنجش زمان اجرا در حالات بهترین، متوسط و بد کمک می‌کند. برای اندازه‌گیری زمان مرتبسازی روی هر مجموعه‌داده می‌توان از کتابخانه‌های بنچمارکینگ یا `System.Diagnostics.Stopwatch` استفاده کرد.

### پیچیدگی زمانی و فضایی
*   **پیچیدگی زمانی**: تقریباً در تمام موارد، مرتبسازی هیپ در **زمان O(n log n)** اجرا می‌شود.
    *   ساختن هیپ اولیه **زمان O(n)** می‌برد.
    *   هر کدام از `n` مرحله‌ی استخراج و هیپیفای **O(log n) زمان** هزینه دارد.
    *   بنابراین، پیچیدگی زمانی کل **O(n + n log n) = O(n log n)** است.
    *   این پیچیدگی برای هر دو حالت متوسط و بدترین حالت صادق است. اگر تمام عناصر یکسان باشند، برخی پیاده‌سازی‌ها ممکن است نزدیک به O(n) عمل کنند زیرا مرحله `heapify` حداقل کار را انجام می‌دهد، اما به طور کلی **O(n log n)** فرض می‌شود.
*   **پیچیدگی فضایی**: مرتبسازی هیپ یک **الگوریتم درجا** است و تنها به **O(1) فضای کمکی** نیاز دارد. هیپ درون خود آرایه‌ی ورودی نگهداری می‌شود و نیازی به ساختارهای داده‌ی اضافی بزرگ نیست.
*   **پایداری**: مرتبسازی هیپ **پایدار نیست**. عناصر با مقادیر یکسان ممکن است پس از مرتبسازی، ترتیب اصلی خود را حفظ نکنند. این تفاوت کلیدی آن با الگوریتم‌های مرتبسازی پایدار مانند Merge Sort است.

### نتایج تست عملکرد
در یک بنچمارک عملی (مرتبسازی 2,000,000 عدد صحیح)، Code Maze زمان‌های زیر را روی یک ماشین معمولی گزارش کرده است:
*   **بهترین حالت (تمام مقادیر یکسان)**: حدود 13.13 میلی‌ثانیه
*   **حالت میانگین (مقادیر تصادفی)**: حدود 223.24 میلی‌ثانیه
*   **بدترین حالت (مقادیر مرتب شده)**: حدود 210.33 میلی‌ثانیه

این نتایج نشان می‌دهند که مرتبسازی یک آرایه‌ی تصادفی (حالت متوسط) و یک آرایه‌ی از قبل مرتب شده (بدترین حالت) زمان مشابهی می‌برند، که با **پیچیدگی O(n log n)** همخوانی دارد. آرایه‌ای با عناصر یکسان به طور قابل توجهی سریعتر اجرا می‌شود، زیرا نیاز به جابجایی قابل توجهی نیست. به طور کلی، عملکرد مشاهده شده با رفتار نظری **O(n log n)** مطابقت دارد. (زمان‌های دقیق ممکن است بسته به سختافزار، محدوده‌ی داده‌ها و جزئیات پیاده‌سازی متفاوت باشد.)

### نمونه استفاده و بنچمارک
در اینجا مثالی از استفاده از پیاده‌سازی `HeapSort` آورده شده است:

</div>

```csharp
// مثال استفاده
int[] data = { 12, 2, 24, 51, 8, -5 };
Console.WriteLine("قبل: " + string.Join(", ", data));

// انجام مرتبسازی هیپ درجا
HeapSort.Sort(data);

Console.WriteLine("بعد: " + string.Join(", ", data));
// خروجی: بعد: -5, 2, 8, 12, 24, 51
```

<div dir="rtl" lang="fa">

برای اندازه‌گیری عملکرد، می‌توانید از `System.Diagnostics.Stopwatch` استفاده کنید:

</div>

```csharp
// مثال بنچمارکینگ با Stopwatch
int[] largeArray = CreateRandomArray(1000000, 1, 1000000); // فرض بر وجود CreateRandomArray
var stopwatch = Stopwatch.StartNew();
HeapSort.Sort(largeArray);
stopwatch.Stop();
Console.WriteLine($"زمان اجرا: {stopwatch.ElapsedMilliseconds} میلیثانیه");
```

<div dir="rtl" lang="fa">

برای بنچمارک‌های دقیق‌تر و تحلیل عملکرد حرفه‌ای، ابزارهایی مانند BenchmarkDotNet را در نظر بگیرید.

### خلاصه و بهترین روش‌ها
**خلاصه**: مرتبسازی هیپ یک **الگوریتم مرتبسازی درجا و قوی** با **عملکرد تضمین شده O(n log n)** است. ابتدا یک هیپ بیشینه می‌سازد و سپس با استخراج مکرر بزرگترین عنصر، آرایه را مرتب می‌کند. پیچیدگی زمانی آن در بدترین حالت از مرتبسازی‌های ساده (مانند مرتبسازی حبابی یا درجی) بهتر است، اما معمولاً **در عمل از quicksort بهینه شده کندتر است** برای داده‌های متوسط.

**موارد استفاده**: زمانی از مرتبسازی هیپ استفاده کنید که به یک **مرتبسازی درجا با تضمین‌های خوب در بدترین حالت** نیاز دارید و می‌توانید **عدم پایداری را تحمل کنید**. این الگوریتم به ویژه برای مجموعه‌داده‌های بزرگ که حافظه‌ی اضافی محدود است، مفید است. با این حال، برای بسیاری از کاربردها، توابع مرتبسازی پیش‌فرض زبان (مانند `Array.Sort` در سی‌شارپ) ممکن است از الگوریتم‌های هیبریدی سریعتر (اغلب introsort) استفاده کنند.

**بهترین روش‌ها**:
*   **رسیدگی به حالت‌های مرزی**: اطمینان حاصل کنید که پیاده‌سازی شما به درستی آرایه‌های خالی، آرایه‌های تک‌عنصر و ارجاعات null را مدیریت می‌کند.
*   **تست جامع**: با انواع مجموعه‌داده‌ها (تصادفی، مرتب شده، معکوس مرتب شده، تکراری) تست کنید تا مشکلات احتمالی را شناسایی کنید.
*   **آگاهی از عدم پایداری**: به خاطر داشته باشید که مرتبسازی هیپ پایدار نیست؛ اگر ترتیب نسبی اصلی عناصر با مقادیر یکسان اهمیت دارد، به جای آن از یک الگوریتم مرتبسازی پایدار استفاده کنید.
*   **اندازه‌گیری عملکرد**: برای اندازه‌گیری دقیق عملکرد از ابزارهای داخلی مانند `Stopwatch` یا کتابخانه‌های بنچمارکینگ اختصاصی استفاده کنید.
*   **وضوح کد**: کد خود را به وضوح کامنت‌گذاری و ساختاردهی کنید؛ به عنوان مثال، حلقه‌ی ساخت هیپ و حلقه‌ی استخراج را در متد خود جدا کنید و هدف هر بخش را مستند کنید.

با رعایت این دستورالعمل‌ها و درک رفتار مرتبسازی هیپ، می‌توانید این الگوریتم را به طور موثر در پروژه‌های سی‌شارپ خود پیاده‌سازی و استفاده کنید.

</div>