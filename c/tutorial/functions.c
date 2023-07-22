#include <stdio.h>

int power(int, int);

int main()
{
  for (int i = 0; i < 10; i++)
  {
    printf("%d ^ %d = %d\n", 2, i, power(2, i));
  }
  return 0;
}

int power(int m, int n)
{
  int result = 1;
  for (int i = 0; i < n; i++)
  {
    result *= m;
  }
  return result;
}