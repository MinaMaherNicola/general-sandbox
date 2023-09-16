#include <stdio.h>

int power(int, int);

int main()
{
  printf("%d\n", power(5, 2));
  return 0;
}

int power(int x, int y)
{
  int result = 1;
  for (int i = 0; i < y; i++)
  {
    result *= x;
  }
  return result;
}