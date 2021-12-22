using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structure_Proje_2
{
    /*
     * 4. sorunun a şıkkı icin kullanilacak olan Integer Kuyruk Sinifi.
     */
    internal class MyIntQueue
    {
        private int maxSize;
        private int[] intQueueArray;
        private int front;
        private int rear;
        private int numberOfElements;

        public MyIntQueue(int maxsize)
        {
            maxSize = maxsize;
            intQueueArray = new int[maxSize];
            front = numberOfElements = 0;
            rear = -1;
        }

        public void insert(int sayi)
        {
            if (rear == maxSize - 1)
            {
                rear = -1;
            }
            intQueueArray[++rear] = sayi;
            numberOfElements++;
        }

        public int remove()
        {
            int temp = intQueueArray[front++];
            if (front == maxSize)
            {
                front = 0;
            }
            numberOfElements--;
            return temp;
        }

        public bool isEmpty()
        {
            return (numberOfElements == 0);
        }

        public int peekFront()
        {
            return intQueueArray[front];
        }

        public bool isFull()
        {
            return (numberOfElements == maxSize);
        }

        public int size()
        {
            return numberOfElements;
        }
    }
}
