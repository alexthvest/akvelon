using System.Numerics;

namespace AddingBigNumbers;

internal class Program
{
    private static void Main(string[] args)
    {
        //var sum = BigNumberSummer.Sum("11", "99");
        var sum = BigNumberSummer.Sum("123453456456456789", "987465534643564654322");
        var rightSum = BigInteger.Parse("123453456456456789") + BigInteger.Parse("987465534643564654322");
        Console.WriteLine(sum);
        Console.WriteLine(rightSum);
    }
}