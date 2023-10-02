#include <stdio.h>

int customStrlen(char *);

int main()
{
  printf("%d\n", customStrlen("Hello world!"));
  return 0;
}

int customStrlen(char *c)
{
  int output = 0;
  while (*c != '\0')
  {
    c++;
    output++;
  }
  return output;
}