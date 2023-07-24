#include <stdio.h>
#include <string.h>

enum boolean
{
  NO,
  YES
};
int main()
{
  printf("%d\n", YES);

  int a = YES;

  if (a == 1)
  {
    printf("a = 1\n");
  }
  if (a == YES)
  {
    printf("a = YES\n");
  }
  return 0;
}