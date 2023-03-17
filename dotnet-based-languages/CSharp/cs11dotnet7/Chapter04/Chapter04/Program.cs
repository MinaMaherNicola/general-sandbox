using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Chapter04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string logPath = @"E:\code\languages-sandbox\dotnet-based-languages\CSharp\cs11dotnet7\Chapter04\logs.txt";

            TextWriterTraceListener logFile = new(File.Create(logPath, 0, FileOptions.WriteThrough));
            Trace.Listeners.Add(logFile);

            Trace.AutoFlush = true;
            Debug.WriteLine("Debug is watching");
            Trace.WriteLine("Trace is watching");

            int unitInStocks = 12;
            LogSourceDetails(unitInStocks > 10);
        }

        static void LogSourceDetails(bool condition,
                                     [CallerMemberName] string member = "",
                                     [CallerFilePath] string filePath = "",
                                     [CallerLineNumber] int line = 0,
                                     [CallerArgumentExpression(nameof(condition))] string expression = "")
        {
            Trace.WriteLine($"{filePath}\n{member} on line {line}.\nExpression: {expression}");
        }
    }
}