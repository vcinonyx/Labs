#include "Square.h"
#include <iostream>
int main()
{
    Point* abcd = new Point[4]
    { Point(1, 1),
      Point(1,0),
      Point(0, 1),
      Point(0, 0)
    };
     Square ABCD =  Square(abcd, 4);
     flaot area = ABCD.Area();
     float perimeter = ABCD.Perimeter();
     float side = ABCD.Side();
     return 0;
}