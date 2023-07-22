#include <stdio.h>

int main()
{
  int c;
  if ((c = getchar()) == EOF)
  {
    printf("%c\n", c);
    printf("%d\n", c);
  }
  else
  {
    printf("%c\n", c);
    printf("%d\n", c);
  }

  return 0;
}