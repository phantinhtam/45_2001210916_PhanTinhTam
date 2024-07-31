using System;
using System.Collections.Generic;
using System.IO;

class KnapsackGreedy
{
    public static void Main()
    {
        int W = 50; // trọng lượng tối đa của ba lô
        Item[] items = {
            new Item(60, 10),
            new Item(100, 20),
            new Item(120, 30)
        };

        double maxValue = Knapsack(items, W);

        Console.WriteLine("Giá trị lớn nhất có thể đạt được: " + maxValue);

        // Ghi độ phức tạp vào file
        File.WriteAllText("KnapsackComplexity.txt", "Độ phức tạp của giải thuật tham lam cho bài toán Knapsack: O(n log n) do cần sắp xếp các đồ vật theo giá trị/trọng lượng.");
    }

    public static double Knapsack(Item[] items, int W)
    {
        // Sắp xếp các đồ vật theo tỷ lệ giá trị/trọng lượng giảm dần
        Array.Sort(items, delegate (Item x, Item y)
        {
            return y.ValuePerWeight().CompareTo(x.ValuePerWeight());
        });

        double totalValue = 0;
        int currentWeight = 0;

        foreach (Item item in items)
        {
            if (currentWeight + item.Weight <= W)
            {
                currentWeight += item.Weight;
                totalValue += item.Value;
            }
        }

        return totalValue;
    }
}

class Item
{
    public int Value { get; set; }
    public int Weight { get; set; }

    public Item(int value, int weight)
    {
        Value = value;
        Weight = weight;
    }

    public double ValuePerWeight()
    {
        return (double)Value / Weight;
    }
}
