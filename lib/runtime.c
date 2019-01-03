#include <stdio.h>
#include <stdlib.h>

extern void printInt(int v)
{
	printf("%d\n", v);
}
extern void printString(char* v)
{
	printf(v);
	printf("\n");
}
extern void error()
{
	exit(-1);
}
extern int readInt()
{
	int a;
	scanf("%d", &a);
	return a;
}

static char* append(char* base, char c, int* curIndex, int* len)
{
	if (*curIndex == *len)
	{
		(*len) = (*len) * 2 + 1;
		base = realloc(base, *len);
	}
	base[*curIndex] = c;
	(*curIndex)++;
	return base;
}

extern char* readString()
{
	int c;
	char* str = NULL;
	int curIndex = 0;
	int len = 0;
	while ((c = getchar()) != '\n')
	{
		str = append(str, c, &curIndex, &len);
	}
	return str;
}
