#include <cmath>


struct Point
{
    int x; int y;
    Point()
    {
        this->x = 0;
        this->y = 0;
    }
    Point(int X, int Y)
    {
        this->x = X;
        this->y = Y;
    }
};

class Shape
{
public:
    Shape(Point* coords, int size) {
        if (size > 2)
        {
            Points = new Point[size];
            for (int i = 0; i < size; i++) {
                Points[i] = coords[i];
            }
            int N = size + (size* (size - 3)) / 2; // add diagonals number
            Sides = new float[N];
            int Count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = (i + 1); j < size; j++)
                {
                    Sides[Count++] = GetLength(Points[j], Points[i]);
                }
            }
        }
        else {
            throw ("Coords amount should be >2");
        }
    }

protected:
    float* Sides;
    Point* Points;

    float GetLength(Point A, Point B)
    {
        return (float)sqrt(pow((A.x - B.x), 2) + pow((A.y-B.y), 2));
    }

};
