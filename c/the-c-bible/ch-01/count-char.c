#include <stdio.h>

int main()
{
  int c, counter = 0;

  while ((c = getchar()) != EOF)
  {
    if (c != '\n')
    {
      counter++;
    }
  }
  printf("%d\n", counter);
  return 0;
}