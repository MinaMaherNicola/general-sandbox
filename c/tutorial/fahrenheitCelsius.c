#include <stdio.h>

int main()
{
  float fahr, celsius;
  float lower, upper, step;

  lower = 0;   // lower limit of temp table
  upper = 300; // upper limit
  step = 20;   // step size

  fahr = lower;
  while (fahr <= upper)
  {
    celsius = (5.0 / 9.0) * (fahr - 32);
    printf("F: %3.0f\tC: %3.2f\n", fahr, celsius);
    fahr = fahr + step;
  }
  return 0;
}