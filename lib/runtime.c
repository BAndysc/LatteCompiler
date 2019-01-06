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
	getchar();
	return a;
}

extern char* concat_string(char* str1, char* str2)
{
	int str1_len = strlen(str1);
	int str2_len = strlen(str2);
	int totalLen = str1_len + str2_len + 1;
	char* newstr = malloc(sizeof(char) * totalLen);
	memcpy(newstr, str1, str1_len);
	memcpy(newstr + str1_len, str2, str2_len);
	newstr[totalLen - 1] = 0;
	return newstr;
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
