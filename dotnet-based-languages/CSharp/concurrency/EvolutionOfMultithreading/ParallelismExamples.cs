namespace EvolutionOfMultithreading;
public class ParallelismExamples
{
  public void DoWorkInParallel()
  {
    Parallel.Invoke(
      DoComplexWork,
      () =>
      {
        Console.WriteLine($"Hello from lambda expression. Thread id: {Thread.CurrentThread.ManagedThreadId}");
      },
      new Action(() =>
      {
        Console.WriteLine($"Hello from Action. Thread id: {Thread.CurrentThread.ManagedThreadId}");
      }),
      delegate ()
      {
        Console.WriteLine($"Hello from delegate. Thread id: {Thread.CurrentThread.ManagedThreadId}");
      }
    );
  }

  private void DoComplexWork()
  {
    Console.WriteLine($"Hello from DoComplexWork. Thread id: {Thread.CurrentThread.ManagedThreadId}");
  }

  public void ParallelForEach(List<int> numbers)
  {
    Parallel.ForEach(numbers, (number) =>
    {
      if (DateTime.Now.ToLongTimeString().Contains(number.ToString()))
      {
        Console.WriteLine($"The current time contains the number {number}. Thread id: {Thread.CurrentThread.ManagedThreadId}");
      }
      else
      {
        Console.WriteLine($"The current time does not contain the number {number}. Thread id: {Thread.CurrentThread.ManagedThreadId}");
      }
    });
  }

  public void ExecuteLINQ(List<int> numbers)
  {
    OutputNumbers(numbers.Where(n => n % 2 == 0), "Regular");
  }

  public void ExecutePLINQ(List<int> numbers)
  {
    OutputNumbers(numbers.AsParallel().Where(n => n % 2 == 0), "PLINQ");
  }

  private void OutputNumbers(IEnumerable<int> numbers, string type)
  {
    Console.WriteLine($"{type} number string: {string.Join(',', numbers)}");
  }
}