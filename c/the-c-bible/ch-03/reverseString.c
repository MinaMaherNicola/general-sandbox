#include <stdio.h>

int stringLength(char[]);
void reverseString(char[]);

int main()
{
  char s[] = {'M', 'I', 'N', 'A'};
  int length = stringLength(s);
  reverseString(s);
  for (int i = 0; i < length; i++)
  {
    printf("%c", s[i]);
  }
  printf("\n");
}

void reverseString(char s[])
{
  int left = 0, right = stringLength(s) - 1, holder;
  while (left <= right)
  {
    holder = s[left], s[left] = s[right], s[right] = holder;
    left++, right--;
  }
}

int stringLength(char s[])
{
  int c = 0;
  while (s[c] != '\0')
  {
    c++;
  }
  return c;
}
