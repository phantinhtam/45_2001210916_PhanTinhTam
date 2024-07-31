using System;
using System.IO;

class QuickSort
{
    public static void Main()
    {
        int[] arr = { 34, 7, 23, 32, 5, 62 };
        Console.WriteLine("Mảng ban đầu:");
        PrintArray(arr);

        QuickSortAlgorithm(arr, 0, arr.Length - 1);

        Console.WriteLine("\nMảng sau khi sắp xếp:");
        PrintArray(arr);

        // Ghi độ phức tạp vào file
        File.WriteAllText("QuickSortComplexity.txt", "Độ phức tạp của QuickSort: O(n log n) trong trung bình và tốt nhất, O(n^2) trong trường hợp xấu nhất.");
    }

    static void QuickSortAlgorithm(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            QuickSortAlgorithm(arr, low, pi - 1);
            QuickSortAlgorithm(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);
        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;

                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;

        return i + 1;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
