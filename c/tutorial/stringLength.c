#include <stdio.h>
#define MAX_LENGTH 1000

int main()
{
  char c, str[MAX_LENGTH];
  int counter = 0;
  printf("Enter your string: ");
  while ((c = getchar()) != EOF && c != '\n' && counter < MAX_LENGTH)
  {
    str[counter] = c;
    counter++;
  }
  str[counter] = '\0';
  printf("String: %s\tLength: %d\n", str, counter);

  return 0;
}