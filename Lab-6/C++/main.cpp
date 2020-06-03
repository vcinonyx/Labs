#include "Expression.h"

int main()
{    
    Expression example[] = { Expression(),  Expression(1, 4, 2, 45),  Expression(0, 0, 0, 41) };  
    example[0].SetA(1);
    example[0].SetB(2);
    example[0].SetC(3);
    example[0].SetD(4);
    for (int i = 0; i < 3; i++)
    {
        example[i].Calculate();
    }
}
