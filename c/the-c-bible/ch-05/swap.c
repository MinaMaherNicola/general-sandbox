#include <stdio.h>

void swap(int *, int *);

int main()
{
  int x = 10, y = 20;

  swap(&x, &y);
  printf("X: %d Y: %d\n", x, y);
  return 0;
}

void swap(int *a, int *b)
{
  int holder = *a;
  *a = *b;
  *b = holder;
}