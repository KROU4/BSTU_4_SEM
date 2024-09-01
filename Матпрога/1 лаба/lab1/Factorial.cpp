#include "Factorial.h"
#include <iostream>
using namespace std;

long double factorial(int num)
{
	if (num == 1) return 1;
	return num * factorial(num - 1);
}