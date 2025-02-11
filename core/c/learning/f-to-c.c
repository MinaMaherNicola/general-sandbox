#include <stdio.h>

/*
  A program to convert fahrenheit to celsius
*/
#define UPPER 300
#define STEP 20

int main()
{
  double fahr = 0, cel;

  while (fahr <= UPPER)
  {
    cel = (5.0 / 9) * (fahr - 32.0);

    // this %3d is augmentation, it allows you to print right-justified numbers by adding 3 spaces to the left
    // as you can see, you could add points to this augmentation to specify how many floating point you need
    printf("%3.0fF\t%3.2fC\n", fahr, cel);

    fahr = fahr + STEP;
  }

  fahr = 0;
  printf("---------------------\n");

  while (fahr <= UPPER)
  {
    cel = 5 * (fahr - 32) / 9;
    printf("%fF\t%fC\n", fahr, cel);

    fahr = fahr + STEP;
  }
}