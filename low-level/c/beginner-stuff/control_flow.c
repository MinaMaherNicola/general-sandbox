#include <stdio.h>

int main(void)
{
  int x = 1;

  if (x == 1)
  {
    printf("[IF] Variable x is exactly 1\n");
  }
  else if (x > 1)
  {
    printf("[IF] Variable x is bigger than 1\n");
  }

  switch (x)
  {
  case 1:
    printf("[SWITCH] Variable x is exactly 1\n");
    break;
  default:
    printf("[SWITCH] Variable x is not 1\n");
  }

  for (int i = 0; i < 3; i++)
  {
    printf("[FOR] i = %d\n", i);
  }

  int i = 0;

  while (i < 3)
  {
    printf("[WHILE] i = %d\n", i);
    i++;
  }

  int h = 3;

  do
  {
    printf("[DO WHILE] i = %d\n", h);
    h++;
  } while (h < 3);

  printf("[DO WHILE after do while i = %d\n", h);
}