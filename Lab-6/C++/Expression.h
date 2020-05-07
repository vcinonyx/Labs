#include <iostream>
#include <fstream>

using namespace std;

class Expression 
{
private:
	double a, b, c, d;
	
public:

	Expression() { }

	Expression(double A, double B, double C, double D)
	{
		a = A;
		b = B;
		c = C;
		d = D;
	}

	double Calculate()
	{
		try
		{
			if (d > 41) 
			{
				throw invalid_argument("Square root of a negative number. Happened for d!");
			}

			if ((sqrt(41 - d) - b * a + c) == 0)
			{
				throw invalid_argument("Division by zero!");
			}

			return (a * b / 4 - 1) / (sqrt(41 - d) - b * a + c);
		}

		catch (const exception & ex)
		{
			std::ofstream out("log.txt", std::ios::app);
			if (out.is_open())
			{
				out << ex.what() << std::endl;
			}
			out.close();
			std::cout << ex.what() << "\n";
		}
	}

	double GetA() { return a; }
	double GetB() { return b; }
	double GetC() { return c; }
	double GetD() { return d; }
	void SetA(double A) { a = A; };
	void SetB(double B) { b = B; };
	void SetC(double C) { c = C; };
	void SetD(double D) { d = D; }

};
