#include <cstring>
#include <string.h>
#include <iostream>

class BaseString;
class CapitalString;
class SymbolString;

class BaseString
{
protected:
    int length = 0;
    char* StrValue = nullptr;
public:
    BaseString() = default; 

    BaseString(char* val)
    {
        StrValue = val;
    }

    virtual int GetLength()
    {
        return 0;
    }
    virtual int FindChar()
    {
        return 0;
    }
};

class SymbolsString :
    public BaseString
{
public:
    SymbolsString(char* val): BaseString(val)
    {
        length = strlen(val);
        char* symbols = new char[length];
        int symbN = 0;
        int k = 0;
        for (int i = 0; i < length; i++) {
            if (isalnum(val[i]) == 0)
            {
                symbN++;
                symbols[k] = val[i];
                k++;
            }
        }
        length = symbN;
        StrValue = new char[length + 1];
        for (int i = 0; i < length; i++) {
            StrValue[i] = symbols[i];
        }
        StrValue[length] = '\0';
        
    }

    int GetLength() override
    {
        return length;
    }
    int FindChar() override
    {
        int counter = 0;
        for (int i = 0; StrValue[i] !='\0'; i++)
        {
            if (StrValue[i] == '*') {
                counter++;
            }
        }
        return counter;
    }
    char* GetValue()
    {
        return StrValue;
    }

};


class CapitalString :
    public BaseString
{
public:
    
    CapitalString(char* val): BaseString(val)
    {
        length = strlen(val);
        char* uppers = new char[length];
        int UpperN = 0;
        int k = 0;
        for (int i = 0; i < length; i++) {
            if (isupper(val[i]) != 0)
            {
                UpperN++;
                uppers[k] = val[i];
                k++;
            }
        }
        length = UpperN;
        StrValue = new char[length+1];
        for (int i = 0; i < length; i++) {
            StrValue[i] = uppers[i];
        }
        StrValue[length] = '\0';
    }
 
    int GetLength() override 
    {
        return strlen(StrValue);
    }
    
    int FindChar() override
    {
        int counter = 0;
        for (int i = 0; StrValue[i] !='\0'; i++)
        {
            if (StrValue[i] == 'B') {
                counter++;
            }
        }
        return counter;
    }
    
    char* GetValue()
    {
        return StrValue;
    }
};