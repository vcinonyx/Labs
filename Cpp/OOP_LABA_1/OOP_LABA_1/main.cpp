#include <iostream>
#include <string>
using namespace std;

class BitOperations {

public:
    void increment(int& i)
    {
        int mask = 1;
        while (i & mask)
        {
            i &= ~mask;
            mask <<= 1;
        }
        i |= mask;
    }

    bool comparison(int a, int b) {
        int mask = 1;
        int signA;   int signB;
        signA = a & (mask << sizeof(a)*8-1);
        signB = b & (mask << sizeof(a)*8-1);
        if (signA - signB >0) return false;
        if (signA - signB <0)  return true;

        if (signA == signB) {
            for (int i = sizeof(a) * 8 - 2; i >= 0; i--) {
                mask = 1 << i;
                if (((b & mask) != 0) && ((a & mask) == 0)) {
                    return true;
                }
                if (((a & mask) != 0) && ((b & mask) == 0)) {
                    return false;
                }
            }
        }
        return false;
    }
}
;
    
int main()
  {
        int i1 = 63;
        int i2 = -128;
        int i3 = 45;
        BitOperations test;
        test.increment(i1);
        test.increment(i2);
        test.increment(i3);
        bool result = test.comparison(33, 117);
        bool result1 = test.comparison(-6, -10);
        bool result2 = test.comparison(26, 26);
    }

