namespace _02UnderstandingTypes;

public class NumberOfBytes
{
    public static void DisplayTypeInfo()
    {
        Console.WriteLine("Data Type    | Bytes");
        Console.WriteLine("-------------|------");
        Console.WriteLine($"sbyte        | {sizeof(sbyte)}");
        Console.WriteLine($"byte         | {sizeof(byte)}");
        Console.WriteLine($"short        | {sizeof(short)}");
        Console.WriteLine($"ushort       | {sizeof(ushort)}");
        Console.WriteLine($"int          | {sizeof(int)}");
        Console.WriteLine($"uint         | {sizeof(uint)}");
        Console.WriteLine($"long         | {sizeof(long)}");
        Console.WriteLine($"ulong        | {sizeof(ulong)}");
        Console.WriteLine($"float        | {sizeof(float)}");
        Console.WriteLine($"double       | {sizeof(double)}");
        Console.WriteLine($"decimal      | {sizeof(decimal)}");
    }
}