namespace Chapter03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] binaryObject = new byte[128];
            Random.Shared.NextBytes(binaryObject); // populates array with random bytes

            foreach (byte binaryObj in binaryObject)
            {
                Console.Write($"{binaryObj:X} "); // :X means format to hexadecimal values
            }
            Console.WriteLine();
            Console.WriteLine();

            string encoded = Convert.ToBase64String(binaryObject);
            Console.WriteLine(encoded);
            Console.WriteLine();
            Console.WriteLine();

            byte[]? binaryFromString = Convert.FromBase64String(encoded);

            foreach (byte binaryObj in binaryFromString)
            {
                Console.Write($"{binaryObj:X} ");
            }
            Console.WriteLine();
        }
    }
}