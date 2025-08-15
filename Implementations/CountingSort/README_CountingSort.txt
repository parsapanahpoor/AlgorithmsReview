 Counting Sort Console Application

 Introduction

This program is a simple **console application** in C# that takes user input numbers and sorts them using the **Counting Sort algorithm**.
Counting Sort is a **non-comparison-based algorithm** for sorting integers and works by counting the number of occurrences of each value.

 Features

* Accept a list of integers from the user input
* Display the array before and after sorting
* Use the Counting Sort algorithm for sorting
* Provide a brief explanation of the algorithm in the program output

 Counting Sort Algorithm

 How it Works

1. **Find the maximum value in the array:** First, the maximum value is determined to set the size of the counting array.
2. **Create a counting array:** An array of length `(max + 1)` is created to store the frequency of each element.
3. **Count each element:** Traverse the original array and store the count of each number in the counting array.
4. **Reconstruct the sorted array:** The original array is rebuilt using the counting array. Each number is inserted as many times as it occurs.

 Example

Input:

```
4 2 2 8 3 3 1
```

Algorithm steps:

1. Maximum value: 8
2. Counting array: `[0,1,2,2,1,0,0,0,1]`
3. Reconstructed sorted array: `[1,2,2,3,3,4,8]`

 Time and Space Complexity

 Time Complexity

* Finding maximum value: **O(n)**
* Counting elements: **O(n)**
* Reconstructing sorted array from count array: **O(k)**
* **Total Time Complexity:** **O(n + k)**

Where `n` is the number of elements and `k` is the maximum value in the array.

 Space Complexity

* Counting array requires **O(k)** space
* Total Space Complexity: **O(n + k)**

 Key Points

* Stable algorithm: preserves relative order of equal elements
* Non-comparison-based: can be faster than comparison-based sorts for small `k`
* For negative numbers, an offset is needed to avoid negative indices

 How to Use

1. Open the project in **Visual Studio** or **VS Code**.
2. Run the program.
3. Enter your integers separated by **spaces** and press Enter.
4. The program displays the array before and after sorting.

 Sample Run

```
Enter numbers separated by space:
4 2 2 8 3 3 1

Before Sorting:
4 2 2 8 3 3 1

After Sorting:
1 2 2 3 3 4 8

Counting Sort is a non-comparison-based algorithm.
It counts the number of occurrences of each value and reconstructs the sorted output.
```

 Advantages and Limitations

**Advantages:**

* Very fast for arrays with limited range of values
* Does not require comparisons

**Limitations:**

* Only suitable for integers
* Requires extra memory equal to the maximum value in the array

 Conclusion

This program demonstrates the **Counting Sort algorithm** in action and helps users understand the concept of non-comparison-based sorting and counting-based reconstruction.
