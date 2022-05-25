

using System.Collections;

foreach (var item in func(2, 10))
{
    Console.WriteLine(item);
}
Console.Read();

static IEnumerable func(int start, int number)
{
    for (int i = 0; i < number; i++)
    {
        yield return start + 2 * i;
    }
}

