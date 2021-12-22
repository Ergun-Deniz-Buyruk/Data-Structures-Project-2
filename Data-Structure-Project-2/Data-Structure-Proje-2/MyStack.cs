using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structure_Proje_2
{
    /*
     * 2. sorunun a şıkkı icin kullanilacak olan Stack Sinifi.
     */
    internal class MyStack
    {
        private int top;
        private int maxSize;
        private Mahalle[] mahalleStackArray;

        public MyStack(int maxSize)
        {
            this.maxSize = maxSize;
            mahalleStackArray = new Mahalle[maxSize];
            top = -1;
        }

        public void push(Mahalle mahalle)
        {
            mahalleStackArray[++top] = mahalle;
        }

        public Mahalle pop()
        {
            return mahalleStackArray[top--];
        }

        public Mahalle peek()
        {
            return mahalleStackArray[top];
        }
        public bool isEmpty()
        {
            return (top == -1);
        }

        public bool isFull()
        {
            return (top == maxSize - 1);
        }
    }
}
