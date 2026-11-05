#include <stdio.h>

int main(void)
{
  int x = 10;  // decimal
  int y = 012; // octal
  int z = 0xA; // hexa

  printf("Decimal:%d Octal:%o Hexadecimal:%x\n", x, y, z);
  printf("Decimal-Value:%d Octal-Value:%d Hexadecimal-Value:%d\n", x, y, z);
}