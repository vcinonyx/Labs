#include<iostream>
#include<cstdio>
#include<cstdlib>

using namespace std;
class DLinkedList
{
public:

    DLinkedList()
    {
        head = NULL;
        tail = NULL;
        Length = 0;
    };

    ~DLinkedList()
    {
        Clear();
    };

    void insertFirst(double element)
    {
        node* newItem;
        newItem = new node;
        if (head == NULL)
        {
            head = newItem;
            newItem->prev = NULL;
            newItem->value = element;
            newItem->next = NULL;
            tail = newItem;
        }
        else
        {
            newItem->next = head;
            newItem->value = element;
            newItem->prev = NULL;
            head->prev = newItem;
            head = newItem;
        }
        
    }


    int Size()
    {
        node* item = head;
        int size = 0;
        while (item)
        {
            size++;
            item = item->next;

        }

        return size;
    }


    void DeleteItem(double element)
    {
        node* temp;
        temp = head;

        if (head == tail)
        {
            if (head->value != element)
            {
                return;
            }
            head = NULL;
            tail = NULL;
            delete temp;
            return;
        }

        if (head->value == element)
        {
            head = head->next;
            head->prev = NULL;
            delete temp;
            return;
        }

        else if (tail->value == element)
        {
            temp = tail;
            tail = tail->prev;
            tail->next = NULL;
            delete temp;
            return;
        }

        while (temp->value != element)
        {
            temp = temp->next;
            if (temp == NULL)
            {
                return;
            }
        }

        temp->next->prev = temp->prev;
        temp->prev->next = temp->next;
        delete temp;
    }

    double FindMax()
    {
        double max = FindMaxNode()->value;
        return max;
    }


    void DeleteAfteMax()
    {
        double max = FindMaxNode()->value;
        node* ptr = head;
        node* next;

        while (ptr->value != max)
        {
            next = ptr->next;
            ptr = next;
        }

        next = ptr->next;
        ptr = next;

        while (ptr != NULL)
        {
            next = ptr->next;
            DeleteItem(ptr->value);
            ptr = next;
        }
    }


    void printList()
    {
        node* temp;
        temp = head;
        while (temp != NULL)
        {
            cout << temp->value<<"->";
            temp = temp->next;
        }
        puts("");
    }

    void Clear()
    {
        node* current = head;
        node* next;

        while (current != NULL)
        {
            next = current->next;
            delete(current);
            current = next;
        }

        head = NULL;
    }

private:

    class node
    {
    public:
        node* next;
        node* prev;
        double value;

        node(float data = double(), node* pNext = NULL, node* pPrev = NULL)
        {
            this->value = data;
            this->next = pNext;
            this->prev = pPrev;
        }
    };

    int Length;
    node* head;
    node* tail;

    node* FindMaxNode()
    {
        node* max;
        node* current;
        current = head;
        max = current;

        while (current)
        {
            if (max->value <= current->value)  max = current;
            current = current->next;
        }
        return max;
    };




}; 
