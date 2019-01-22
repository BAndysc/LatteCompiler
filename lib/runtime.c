#ifdef _MSC_VER
#include <stdio.h>
#else
#define NULL 0
typedef unsigned int size_t;
extern int printf(const char *format, ...);
extern int scanf(const char *format, ...);
extern int getchar(void);
extern void exit(int status);
extern void *memcpy(void *dest, const void *src, size_t n);
extern size_t strlen(const char *s);
extern void *malloc(size_t size);
extern void free(void *ptr);
extern void *calloc(size_t nmemb, size_t size);
extern void *realloc(void *ptr, size_t size);
#endif

extern int* lat_malloc(int size)
{
	return calloc(size, 1);
}

extern void printInt(int v)
{
	printf("%d\n", v);
}
extern void printString(char* v)
{
	if (!v)
		printf("\n");
	else
		printf("%s\n", v);
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

static int lat_strlen(char* str)
{
	if (!str)
		return 0;
	return strlen(str);
}

extern char* concat_string(char* str1, char* str2)
{
	int str1_len = lat_strlen(str1);
	int str2_len = lat_strlen(str2);
	if (str1_len + str2_len == 0)
		return NULL;

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

extern int lat_strcmp(char* str1, char* str2)
{
	if (str1 == str2)
		return 1;

	if (str1 == NULL)
		return *str2 == 0;

	if (*str1 == 0)
		return str2 == NULL;

	while (*str1 == *str2 && *str1 != 0 && *str2 != 0)
	{
		str1++;
		str2++;
	}

	return *str1 == 0 && *str2 == 0;
}
