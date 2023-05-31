using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class Program
{
    [UnmanagedCallersOnly(EntryPoint = "PreMainFunction", CallConvs = new Type[] { typeof(CallConvCdecl) })]
    static void PreMainFunction(int amount)
    {
        Console.WriteLine($"Hello from PreMainFunction, got {amount}");
    }

    static void Main(string[] args)
    {
        Console.WriteLine($"In managed main, got {args.Length} args:");
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine($"args[{i}]: {args[i]}");
        }
    }
}