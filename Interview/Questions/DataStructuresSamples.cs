using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    public class DataStructuresSamples
    {
        LinkedListNode<int> head = new LinkedListNode<int>(10);
        LinkedListNode<int> middle1 = new LinkedListNode<int>(15);
        LinkedListNode<int> middle2 = new LinkedListNode<int>(20);
        LinkedListNode<int> tail = new LinkedListNode<int>(25);

        LinkedList<int> lList = new LinkedList<int>();
        public DataStructuresSamples()
        {
            lList.AddFirst(head);
            lList.AddLast(middle1);
            lList.AddLast(middle2);
            lList.AddLast(tail);
        }

        public IEnumerable<int> YieldList()
        {
            LinkedListNode<int> current = head;

            while(current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public string HashTableSample()
        {
            HashSet<int> h = new HashSet<int>();

        }
    }
}
