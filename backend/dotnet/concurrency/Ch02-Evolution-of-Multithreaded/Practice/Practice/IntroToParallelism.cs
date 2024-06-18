namespace Practice
{
    public static class IntroToParallelism
    {
        public static void Example()
        {
            Parallel.Invoke(
                () =>
                {
                    Console.WriteLine($"Hello from lambda, thread id: {Thread.CurrentThread.ManagedThreadId}");
                },
                new Action(() =>
                {
                    Console.WriteLine($"Hello from action, thread id: {Thread.CurrentThread.ManagedThreadId}");
                }),
                delegate ()
                {
                    Console.WriteLine($"Hello from delegate, thread id: {Thread.CurrentThread.ManagedThreadId}");
                });
        }
    }
}
