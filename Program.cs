// using System.Diagnostics;

// const int size = 50_000_000;
// int[] data = new int[size];
// for (int i = 0; i < data.Length; i++)
// {
//     data[i] = i;
// }
// long sum = 0;
// Stopwatch timer = Stopwatch.StartNew();
// for (int i = 0; i < data.Length; i += 16)
// {
//     sum += data[i];
// }
// timer.Stop();
// Console.WriteLine($"Результат:{sum}");
// Console.WriteLine($"Время:{timer.ElapsedMilliseconds}мс");

using System.Diagnostics;

const int size = 50_000_000;
const int accesses = 50_000_000;
int[] data = new int[size];
for (int i = 0; i < data.Length; i++)
{
    data[i] = i;
}
RunTest("Шаг 1", data, 1, accesses);
RunTest("Шаг", data, 16, accesses);
static void RunTest(string name, int[] data, int step, int accesses)
{
    long sum = 0;
    Stopwatch timer = Stopwatch.StartNew();
    int index = 0;
    for (int i = 0; i < accesses; i++)
    {
        sum += data[index];
        index += step;
        if (index >= data.Length)
        {
            index -= data.Length;
        }
    }
    timer.Stop();
    Console.WriteLine($"{sum}: {timer.ElapsedMilliseconds}мс");
    Console.WriteLine($" Сумма: {sum}");
    Console.WriteLine();
}