#include <stdio.h>

int main()
{
  for (int i = 0; i <= 300; i += 20)
  {
    printf("%3d\t%6.2f\n", i, (5.0 / 9.0) * (i - 32.0));
  }
  return 0;
}