#include "Shape.h"
#include <algorithm> 

class Square :
    public Shape
{
private:
    
    float side;

    bool IsSquare()
    {
        std::sort(Sides, Sides + 6);
        if ((Sides[0] - Sides[3] == 0) && (Sides[4] - Sides[5]) == 0) // sides[4], sides[5] - diagonals, sides[0..3] - square's sides
        {
            return true;
        }
        else {
            return false;
        }
    }
public:

    Square(Point* coords, int size) : Shape(coords, size)
    {
        if ((size != 4) || (IsSquare() == false))
        {
            throw _invalid_parameter;
        }
        else {
            this->side = Sides[0];
        }

    }
    float Area()
    {
        return side * side;
    }
    float Perimeter()
    {
        return 4 * side;
    }
    float Side()
    {
        return side;
    }
};