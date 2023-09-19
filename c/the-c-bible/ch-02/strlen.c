#include <stdio.h>

int stringLength(char[]);

int main()
{
  char myString[] = "Hello";

  printf("%d\n", stringLength(myString));
  return 0;
}

int stringLength(char c[])
{
  int i = 0;
  while (c[i] != '\0')
  {
    i++;
  }
  return i;
}