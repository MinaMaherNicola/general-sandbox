#include <stdio.h>

int main(void)
{
  float a = 123.456f;
  printf("%f\n", a);   // weird print
  printf("%.3f\n", a); // correct print
}