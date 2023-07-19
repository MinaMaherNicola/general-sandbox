#include <stdio.h>

void swap(int, int);

void swap(int a, int b)
{
  int t = a;
  a = b;
  b = t;
  printf("swap: a = %d, b = %d\n", a, b);
}

void swapWithPointers(int *, int *);

void swapWithPointers(int *pa, int *pb)
{
  int t = *pa;
  *pa = *pb;
  *pb = t;
}

int main(void)
{
  int a = 21;
  int b = 17;

  swapWithPointers(&a, &b);
  printf("main: a = %d, b = %d\n", a, b);
  return 0;
}