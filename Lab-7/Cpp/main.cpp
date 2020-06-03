#include<cstdlib>
#include "DLinkedList.h"

using namespace std;




int main()
{
    DLinkedList Mylist = DLinkedList();
    Mylist.insertFirst(111);
    Mylist.insertFirst(12);
    Mylist.insertFirst(9);
    Mylist.insertFirst(1345);
    Mylist.insertFirst(1);
    Mylist.printList();
    Mylist.DeleteAfteMax();
    Mylist.printList();
    cout << Mylist.Size()  << endl;
    Mylist.Clear();
    return 0;
}