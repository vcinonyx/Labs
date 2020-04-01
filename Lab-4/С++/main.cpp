#include "Triangle.h"

using namespace std;

int main() 
{
	Triangle T1;
	Triangle T2(1., 2., 4., 1., 6., 8.);	
	Triangle T3(T2);
	T1.GetInfo();
	T2.GetInfo();
	T3.GetInfo();
	T3 = T3 * 2;
	T1 = T3 + T2;
	T3.GetInfo();
	T1.GetInfo();
}
