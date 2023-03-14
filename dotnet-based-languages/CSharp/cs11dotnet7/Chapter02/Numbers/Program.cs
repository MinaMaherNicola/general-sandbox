// three variables that store the number 2 million
int decimalNotation = 2_000_000;
int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
int hexadecimalNotation = 0x_001E_8480;
// check the three variables have the same value
// both statements output true
Console.WriteLine($"{decimalNotation == binaryNotation}");
Console.WriteLine($"{decimalNotation == hexadecimalNotation}");

double d1 = 0.1, d2 = 0.2;
decimal a = 0.1M, b = 0.2M;

Console.WriteLine(d1 + d2);
Console.WriteLine(a + b);

Console.WriteLine($"{12} appels cost {(12 * 2):C}");