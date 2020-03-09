#include <iostream>


using namespace std;


class MyString
{
public:
	MyString() 
	{
		str = nullptr;
	}

	MyString(char* str)
	{
		length = FindLength(str);
		this->str = new char[length + 1];
		for (int i = 0; i < length; i++)
		{
			this->str[i] = str[i];
		}
		this->str[length] = '\0';
	}

	~MyString() 
	{
		delete[] this->str;
	}

	void Print()
	{
		cout << str <<endl;
	}
	int FindLength(char* str)
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


private:
	char* str;
	int length;

};

class Text
{
public:

	Text(char** stringArray, int n){
		MyString* text = new MyString[n];
		for (int i = 0; i < n; i++) {
			text[i] = MyString(stringArray[i]);
			text[i].Print();
		}
	}
	~Text() {
	}

private:
	MyString* text;

};


int main()
{
	int n = 4;
	char** stringsText = new char* [n];
	for (int i = 0; i < 5; i++) {
		stringsText[i] = new char[25];
	}

}
;
