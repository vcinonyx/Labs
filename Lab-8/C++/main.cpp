#include <iostream>
#include "Lab8_lib.h"

bool Compare(double arr1[], double arr2[], int i)
{
    return arr1[i] == arr2[i];
}

bool (*point)(double arr1[], double arr2[], int i);

int main()
{
    Account* A = new Account(3);
    A->Put(120);
    A->UseInternet(12);

    double a[3] = { 1,2,3 };
    double b[3] = { 3,2,1 };
    point = Compare;
    std::cout << point(a, b, 1) << "\n";
    std::cout << point(a, b, 2) << "\n";
}