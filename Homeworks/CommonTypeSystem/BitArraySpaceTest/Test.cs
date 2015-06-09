using System;
using BitArraySpace;
using Extensions;

public class Test
{
    private static void Main()
    {
        BitArray64 num1 = new BitArray64(ulong.MaxValue);
        BitArray64 num2 = new BitArray64(ulong.MaxValue);
        BitArray64 num3 = new BitArray64(77777777777777);

        PrintBitArray(num1);
        PrintBitArray(num2);
        PrintBitArray(num3);
        Console.WriteLine();

        EqualChek(num1, num2);
        EqualChek(num1, num3);
        EqualChek(num2, num3);
        Console.WriteLine();

        Console.WriteLine(num1.GetHashCode());
        Console.WriteLine(num2.GetHashCode());
        Console.WriteLine(num3.GetHashCode());
        Console.WriteLine();
    }

    private static void PrintBitArray(BitArray64 num)
    {
        Console.WriteLine("The decimal number is: {0}\r\n", num.Number64);

        Console.WriteLine(num);

        foreach (var item in num)
        {
            Console.Write(item);
        }

        Console.WriteLine("\r\n\r\n");
    }

    private static void EqualChek(BitArray64 firstArr, BitArray64 secondArr)
    {
        Console.WriteLine(firstArr == secondArr);
        Console.WriteLine(firstArr.Equals(secondArr));
    }
}
