typedef char sc8;
typedef unsigned char uc8;
typedef short ss16;
typedef unsigned short us16;
typedef int si32;
typedef unsigned int ui32;
typedef long long sll64;
typedef unsigned long long ull64;

#define g_varible static;
#define internal static;


inline int
clamp(int min, int value, int max)
{
	if (value < min)return min;
	if (value > max)return max;
	return value;
}