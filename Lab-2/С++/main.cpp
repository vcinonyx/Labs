#include <iostream>

using namespace std;


class MyString
{
public:
    char* str;
    int length;

    MyString(int len)
    {
        length = len;
        str = new char[lenth];
    }

    MyString(char* str)
    {
        length = Length(str);
        this->str = new char[length + 1];
        for (int i = 0; i < this->length; i++)
        {
            this->str[i] = str[i];
        }
        this->str[this->length] = '\0';
    }

    void Print()
    {
        cout << str << endl;
    }
    int Length(char* str)
    {
        int i = 0;
        while (str[i] != '\0')
        {
            i++;
        }
        return i;
    }

    int Length() {
        return length;
    }

    int FindStr(char* Str0) {
        bool flag;
        int str0_length = Length(Str0);
        int counter = 0;
        for (int i = 0; i < this->length; i++) {
            if(Str0[0] == this->str[i]){
                flag = true;
                for (int m = 0; m < str0_length; m++) {
                    if (Str0[m] != this->str[i + m]) {
                        flag = false;
                        break;
                    }
                }
                if (flag) counter += 1;
            }
        }
        return counter;
    }

    void Replace(char a, char b) {
        for (int i = 0; i < this->length; i++) {
            if (this->str[i] == a) this->str[i] = b;
        }
    }
};


char* ConvertToChar(string S) {
    char* convertedStr = new char[S.length()];
    int i;
    S += '\0';
    size_t length = S.length();
    for (i = 0; i < length; i++) {
        convertedStr[i] = S[i];
    }
    return convertedStr;
}

class Text
{
public:
    
    MyString* text;
    int rows;
    Text() {
        rows = 0;
        text = new MyString[rows];
    }


    Text(char** stringArray, int n) {    
        this->rows = n;
        this->text = new MyString[this->rows];
        for (int i = 0; i < this->rows; i++) {
            this->text[i] = MyString(stringArray[i]);
          }
     }


    void AddString(char* str) {
    
        MyString* copyText = new MyString[this->rows];
        for (int i = 0; i < this->rows; i++) {
            copyText[i] = this->text[i];
        }
        this->rows += 1;
        this->text = new MyString[this->rows];
        for (int i = 0; i < this->rows - 1; i++) {
            this->text[i] = copyText[i];
        }
        delete[] copyText;
        this->text[this->rows - 1] = MyString(str);  
    }


    void DelString(int rowN) {
    
        this->rows--;
        for (int i = rowN - 1; i < this->rows; i++) {
            this->text[i] = this->text[i + 1];
        }
        MyString* newText = new MyString[this->rows];
        for (int i = 0; i < this->rows; i++) {
            newText[i] = this->text[i];
        }
        this->text = new MyString[this->rows];
        for (int i = 0; i < this->rows; i++) {
            this->text[i] = newText[i];
           
        }

        delete[] newText;
    }

    void Clear() {
        this->text = new MyString[0];
    }

    int CharCounter() {
        int counter = 0;
        for (int i = 0; i < this->rows; i++) {
            counter += this->text[i].Length();
        }
        return counter;
    }

    int Find(char* s) {
        int counter = 0;;
        for (int i = 0; i < this->rows; i++) {
            counter += this->text[i].FindStr(s);
        }
        return counter;
    }

    void Replace(char a, char b) {
        for (int i = 0; i < this->rows; i++) {
            this->text[i].Replace(a, b);
            this->text[i].Print();
        }
    }
};


int main()
{
    int n = 4;
    char** stringsArray = new char* [n];
    Text text_obj = Text();
    text_obj.AddString(ConvertToChar("who shot ya?"));
    text_obj.AddString(ConvertToChar("thatn is lit af"));
    text_obj.AddString(ConvertToChar("luca materazzi vs zizu"));
    text_obj.CharCounter();
    text_obj.Find(ConvertToChar("who"));
    text_obj.Replace('a', 'm');
    text_obj.DelString(2);
    text_obj.Clear();
};
