// See https://aka.ms/new-console-template for more information

int[] a, b;
Console.WriteLine("Enter first array");
var s = Console.ReadLine();
a = s.Split(' ').Select(x => int.Parse(x)).ToArray();
Console.WriteLine("Enter second array");
s = Console.ReadLine();
b = s.Split(' ').Select(int.Parse).ToArray();



