// مثال استفاده
int[] data = { 12, 2, 24, 51, 8, -5 };
Console.WriteLine("قبل: " + string.Join(", ", data));

// انجام مرتبسازی هیپ درجا
HeapSort.Sort(data);

Console.WriteLine("بعد: " + string.Join(", ", data));
// خروجی: بعد: -5, 2, 8, 12, 24, 51



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
            int temp = array[0];
            array[0] = array[i];
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