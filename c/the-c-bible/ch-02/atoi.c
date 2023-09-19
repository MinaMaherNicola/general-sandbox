#include <stdio.h>

int atoiClone(const char[]);

int main()
{
  char s[] = "124125WQE512";
  printf("%d\n", atoiClone(s));
  return 0;
}

int atoiClone(const char s[])
{
  int i = 0, n = 0;

  while (s[i] != '\0' && s[i] > '0' && s[i] <= '9')
  {
    n = (10 * n) + (s[i] - '0');
    i++;
  }
  return n;
}