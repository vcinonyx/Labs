#include "String.h"

int main()
{
   CapitalString capitals((char*)("AUdi BMW Bentley Bang"));
   int B = capitals.FindChar();
   int capLength = capitals.GetLength();
   SymbolsString symbols((char*)("f&7 k**** :d :<> **"));
   int st = symbols.FindChar();
   int symbLength = symbols.GetLength();
}