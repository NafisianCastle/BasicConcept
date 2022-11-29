namespace Generics
{
    public class MyStack<T>
    {
        readonly int m_Size;
        readonly T[] m_Items;

        int m_StackPointer = 0;

        public MyStack(int size)
        {
            m_Size = size;
            m_Items = new T[m_Size];
        }

        public T Pop()
        {
            m_StackPointer--;
            return m_Items[m_StackPointer];
        }

        public void Push(T item)
        {
            m_Items[m_StackPointer] = item;
            m_StackPointer++;
        }
    }
}
