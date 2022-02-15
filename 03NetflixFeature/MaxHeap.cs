using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03NetflixFeature
{
    class MaxHeap<T> where T: IComparable<T>
    {
        List<T>? h = null;
        void PercolateUp(int i)
        {
            if (i <= 0) { return; }
            else if (h[parent(i)].CompareTo(h[i]) < 0)
            {
                // Swaps the value of two variables
                T temp = h[i];
                h[i] = h[parent(i)];
                h[parent(i)] = temp;
                PercolateUp(parent(i));
            }
        }

        public void MaxHeapify(int i)
        {
            int lc = lchild(i);
            int rc = rchild(i);
            int imax = i;

            if (lc < size() && (h[lc].CompareTo(h[imax]) > 0)) imax = lc;
            if (rc < size() && (h[rc].CompareTo(h[imax]) > 0)) imax = rc;
            if (i != imax)
            {
                T temp = h[i];
                h[i] = h[imax];
                h[imax] = temp;
                MaxHeapify(imax);
            }
        }

        public MaxHeap() => h = new List<T>();
        public int size() => h.Count;
        public T peek()
        {
            if (size() <= 0) { return (T)Convert.ChangeType(-1, typeof(T)); }
            else { return h[0]; }
        }
        public void insert(T key)
        {
            // Push elements into vector from the back
            h.Add(key);
            // Store index of last value of vector in variable i
            int i = size() - 1;
            // Restore heap property
            PercolateUp(i);
        }
        public void PrintHeap()
        {
            for (int i = 0; i <= size() - 1; i++)
            {
                Console.Write(h[i] + " ");
            }
            Console.WriteLine("");
        }
        public void BuildHeap(T[] arr, int size)
        {
            // Copy elements of array into the List h
            h.AddRange(arr);
            for (int i = (size - 1) / 2; i >= 0; i--)
            {
                MaxHeapify(i);
            }
        }
        public int parent(int i) => (i - 1) / 2;
        public int lchild(int i) => i * 2 + 1;
        public int rchild(int i) => i * 2 + 2;
        public void poll()
        {
            // Remove the last item from the list
            if (size() == 1) { h.RemoveAt(h.Count - 1); }
            else if (size() > 1)
            {
                // Swaps the value of two variables
                T temp = h[0];
                h[0] = h[size() - 1];
                h[size() - 1] = temp;

                // Deletes the last element
                h.RemoveAt(h.Count - 1);

                // Restore heap property
                MaxHeapify(0);
            }
        }
    }
}
