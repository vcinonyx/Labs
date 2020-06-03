#include <iostream>

class Triangle {

	
private:

	double X1, Y1, X2, Y2, X3, Y3;
	double Side(double x1, double y1, double x2, double y2);
	double Perimeter();
	double Square();
	
public:
	Triangle();
	Triangle(double x1, double y1, double x2, double y2, double  x3, double y3);
	Triangle(Triangle& copyTriangle);
	Triangle operator+(Triangle& T);
	void GetInfo();
	friend Triangle operator *(Triangle &T, double factor);
	friend Triangle operator *(double factor, Triangle &T);
};

	
