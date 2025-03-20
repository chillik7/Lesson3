using System;
class A
{
    private int a, b;

    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }
    public double ComputeExpression()
    {
        return 1 / (1 + (a + b) / 2.0);
    }
    public int SquareDifference()
    {
        return (a - b) * (a - b);
    }
    static void Main()
    {
        Console.Write("Введите a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введите b: ");
        int b = int.Parse(Console.ReadLine());

        A obj = new A(a, b);

        Console.WriteLine("Результат выражения: " + obj.ComputeExpression());
        Console.WriteLine("Квадрат разности a и b: " + obj.SquareDifference());
    }
}
