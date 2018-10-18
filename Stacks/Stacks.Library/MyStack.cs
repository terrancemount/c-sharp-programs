using System;

namespace Stacks.Library
{
    public class MyStack
    {
        private object[] _items;

        private int _currentIndex;

        public MyStack(int capacity)
        {
            _items = new object[capacity];
            _currentIndex = 0;
        }

        public void Push(object obj)
        {
            if (obj == null)
                throw new NullReferenceException();

            _items[_currentIndex] = obj;
            _currentIndex++;
        }

        public object Pop()
        {
            if (_currentIndex == 0)
                return null;

            _currentIndex--;
            return _items[_currentIndex];
        }
    }
}
