#include <stdio.h>

int binarySearch(int[], int);
int arrayLength(int[]);

int main()
{
  int arr[] = {1,
               2,
               3,
               4,
               5,
               6,
               7,
               8,
               10};

  printf("Index of 0: %d\n", binarySearch(arr, 0));
  printf("Index of 1: %d\n", binarySearch(arr, 1));
  printf("Index of 3: %d\n", binarySearch(arr, 3));
  printf("Index of 5: %d\n", binarySearch(arr, 5));
  printf("Index of 7: %d\n", binarySearch(arr, 7));
  printf("Index of 8: %d\n", binarySearch(arr, 8));
  printf("Index of 9: %d\n", binarySearch(arr, 9));
}

int binarySearch(int arr[], int target)
{
  int left = 0, right = arrayLength(arr) - 1, mid;
  while (left <= right)
  {
    mid = (right + left) / 2;
    if (arr[mid] > target)
    {
      right = mid - 1;
    }
    else if (arr[mid] < target)
    {
      left = mid + 1;
    }
    else
    {
      return mid;
    }
  }
  return -1;
}

int arrayLength(int arr[])
{
  int i = 0;
  while (arr[i] != '\0')
  {
    i++;
  }

  return i - 1;
}