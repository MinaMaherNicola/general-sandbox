#include <stdio.h>

int main()
{
  int c;
  int counter = 0;
  while ((c = getchar()) != EOF)
  {
    if (c == '\n')
    {
      counter++;
    }
  }
  printf("number of new lines: %d\n", counter);
}