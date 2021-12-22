using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structure_Proje_2
{
    /*
     * 2. sorunun b şıkkı icin kullanilacak olan Queue Sinifi.
     */
    internal class MyQueue
    {
        private int maxSize;
        private Mahalle[] mahalleQueueArray;
        private int front;
        private int rear;
        private int numberOfElements;

        public MyQueue(int maxsize)
        {
            maxSize = maxsize;
            mahalleQueueArray = new Mahalle[maxSize];
            front = numberOfElements = 0;
            rear = -1;
        }
        
        public void insert(Mahalle mahalle)
        {
            if (rear == maxSize - 1)
            {
                rear = -1;
            }
            mahalleQueueArray[++rear] = mahalle;
            numberOfElements++;
        }

        public Mahalle remove()
        {
            Mahalle temp = mahalleQueueArray[front++];
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

        public Mahalle peekFront()
        {
            return mahalleQueueArray[front];
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
