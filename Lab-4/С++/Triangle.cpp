#include "Triangle.h"

using namespace std;

Triangle::Triangle()
{
	X1 = 0;
	Y1 = 0;
	X2 = 0;
	Y2 = 1;
	X3 = 1;
	Y3 = 0;
}

Triangle::Triangle(double x1, double y1, double x2, double y2, double  x3, double y3)
{
	X1 = x1;
	Y1 = y1;
	X2 = x2;
	Y2 = y2;
	X3 = x3;
	Y3 = y3;
}

Triangle::Triangle(Triangle& copyTriangle)
{
	X1 = copyTriangle.X1;
	Y1 = copyTriangle.Y1;
	X2 = copyTriangle.X2;
	Y2 = copyTriangle.Y2;
	X3 = copyTriangle.X3;
	Y3 = copyTriangle.Y3;
}


double Triangle::Side(double x1, double y1, double x2, double y2)
	{
		return sqrt(pow((x1 - x2), 2) + pow((y1 - y2), 2));
	}

double Triangle::Perimeter()
	{
		double P = Side(X1, Y1, X2, Y2) + Side(X1, Y1, X3, Y3) + Side(X3, Y3, X2, Y2);
		return P;
	}

double Triangle::Square()
	{
		double S;
		double p = Perimeter() / 2;
		double a = Side(X1, Y1, X2, Y2);
		double b = Side(X2, Y2, X3, Y3);
		double c = Side(X1, Y1, X3, Y3);
		S = sqrt(p * (p - a) * (p - b) * (p - c));
		return S;
	}


Triangle Triangle::operator+(Triangle& T)
	{
		Triangle result(this->X1 + T.X1, this->Y1 + T.Y1, this->X2 + T.X2, this->Y2 + T.Y2, this->X3 + T.Y3, this->Y3 + T.Y3);
		return result;
	}

Triangle Triangle::operator *(double factor)
	{
		Triangle result(this->X1 * factor, this->Y1 * factor, this->X2 * factor, this->Y2 * factor, this->X3 * factor, this->Y3 * factor);
		return result;
	}

void Triangle::GetInfo()
	{
		cout << "Vertices: (" << X1 << "; " << Y1 << ")  (" << X2 << "; " << Y2 << ")  (" << X3 << "; " << Y3 << ")\n";
		cout << "Perimeter: " << Perimeter() << "\n";
		cout << "Square : " << Square() << "\n\n";
	}
;
