using System;
using System.Collections.Generic;

namespace Heap
{
    public class Heap
    {
        private Func<int, int, bool> _parentWithChildComparer;

        private List<int> _heap = new List<int>();

        public Heap(Func<int, int, bool> parentWithChildComparer)
        {
            _parentWithChildComparer = parentWithChildComparer;
        }

        public int Count
        {
            get { return _heap.Count; }
        }

        public void Add(int value)
        {
            _heap.Add(value);
            SwiftUp(_heap.Count - 1);
        }

        public int Remove()
        {
            var root = _heap[0];
            _heap[0] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);
            SwiftDown(0);
            return root;
        }

        public int Peek()
        {
            return _heap[0];
        }
        private void SwiftDown(int index)
        {
            var childOne = index * 2 + 1;
            while (childOne < _heap.Count)
            {
                var childTwo = index * 2 + 2;
                var indexToSwap = childOne;
                if (childTwo < _heap.Count && _parentWithChildComparer(_heap[childTwo], _heap[childOne]))
                    indexToSwap = childTwo;

                if (_parentWithChildComparer(_heap[index], _heap[indexToSwap]))
                    return;

                Swap(index, indexToSwap);
                index = indexToSwap;
                childOne = index * 2 + 1;
            }
        }

        private void SwiftUp(int index)
        {
            var parent = (index - 1) / 2;
            while (index > 0)
            {
                if (_parentWithChildComparer(_heap[parent], _heap[index]))
                    return;

                Swap(parent, index);

                index = parent;
                parent = (index - 1) / 2;
            }
        }

        private void Swap(int i, int j)
        {
            var temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }
    }
}