#include <stdio.h>

void changeArray(int arr[]);

int main()
{
  int arr[5] = {1, 2, 3, 4, 5};
  changeArray(arr);
  printf("%d\n", arr[0]);

  return 0;
}

void changeArray(int arr[])
{
  arr[0] = 500;
}