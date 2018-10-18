using System;

namespace Stacks.Library
{
    public class MyGenericStack<T>
    {
        private T _item;

        public MyGenericStack(int capacity)
        {

        }

        public void Push(T item)
        {
            _item = item;
        }
        
        public T Pop()
        {
            return _item;
        }

      
    }
}
