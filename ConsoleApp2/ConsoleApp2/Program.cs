using System;
using System.Linq;

static class ArrayUtils
{
    public static double Product(double[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Массив не должен быть пустым или null.");

        return array.Aggregate(1.0, (acc, val) => acc * val);
    }

    public static double[] Sort(double[] array)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        return array.OrderBy(x => x).ToArray();
    }

    public static double[] FilterPositive(double[] array)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        return array.Where(x => x > 0).ToArray();
    }

    public static double Average(double[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Массив не должен быть пустым или null.");

        return array.Average();
    }

    public static double[] GenerateRandomArray(int size, double min, double max)
    {
        if (size <= 0)
            throw new ArgumentException("Размер массива должен быть больше 0.");

        Random rand = new Random();
        return Enumerable.Range(0, size).Select(_ => rand.NextDouble() * (max - min) + min).ToArray();
    }
}
class Program
{
    static void Main()
    {
        double[] numbers = { 1.5, 2.0, 3.5, 4.0 };

        Console.WriteLine("Исходный массив: " + string.Join(", ", numbers));
        Console.WriteLine("Произведение элементов: " + ArrayUtils.Product(numbers));

        double[] sorted = ArrayUtils.Sort(numbers);
        Console.WriteLine("Отсортированный массив: " + string.Join(", ", sorted));

        double[] positive = ArrayUtils.FilterPositive(numbers);
        Console.WriteLine("Положительные числа: " + string.Join(", ", positive));

        Console.WriteLine("Среднее значение: " + ArrayUtils.Average(numbers));

        double[] randomArray = ArrayUtils.GenerateRandomArray(5, 1.0, 10.0);
        Console.WriteLine("Случайный массив: " + string.Join(", ", randomArray));
    }
}
