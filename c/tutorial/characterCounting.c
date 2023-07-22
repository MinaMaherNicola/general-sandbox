#include <stdio.h>

int main()
{
  unsigned int counter = 0;
  while (getchar() != EOF)
  {
    counter++;
  }
  printf("%d\n", counter);
}