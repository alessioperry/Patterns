using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.Iterator
{
    public class Main
    {
        //K is the key, T is the data item 
        private abstract class Node<K, T>
        {
            public K Key;
            public T Item;
            public Node<K, T> NextNode;
        }

        public class LinkedList<K, T> : IEnumerable<T>
        {
            private Node<K, T> m_Head;

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                var current = m_Head;
                while (current != null)
                {
                    yield return current.Item;
                    current = current.NextNode;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<T>) this).GetEnumerator();
            }

        }

        delegate TOut MergeOne<in TIn, out TOut>(TIn a, TIn b);

        IEnumerable<TOut> Merge<TIn, TOut>(IEnumerable<TIn> first, IEnumerable<TIn> second,  MergeOne<TIn, TOut> factory)
        {
            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while (firstIter.MoveNext() && secondIter.MoveNext())
                yield return factory(firstIter.Current, secondIter.Current);
        }

        // Fifth attempt:
        //public IEnumerable<string> PeopleIKnowInNewYork(string city)
        //{
        //    var cityNumbers = PhoneBook.FindListFor(city);

        //    IEnumerable<string> names = Transform<PhoneEntry, string>(newYorkNumbers,
        //        delegate(PhoneEntry entry)
        //        {
        //            return string.Format(“{0} {1}”, entry.FirstName, entry.LastName);
        //        });
        //    return Filter(names, delegate(string name)
        //        { return RecognizePerson(name);} );
        //}


        delegate bool Predicate<in T>(T inputValue);

        private static IEnumerable<T> Filter<T>(IEnumerable<T> list, Predicate<T> condition)
        {
            return list.Where(item => condition(item));
        }
    }

}