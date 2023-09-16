#include <stdio.h>

int main()
{
  int c, counter = 0;

  while ((c = getchar()) != EOF)
  {
    if (c >= '0' && c <= '9')
      counter++;
  }

  printf("%d\n", counter);
  return 0;
}