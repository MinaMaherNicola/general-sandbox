namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.ProcessorCount);
            ThreadPool.GetAvailableThreads(out int workerThreads, out int completionPortThreads);
            Console.WriteLine($"Number of available worker threads: {workerThreads}");
            Console.WriteLine($"Number of available asynchronous I/O threads: {completionPortThreads}");
        }
    }
}
