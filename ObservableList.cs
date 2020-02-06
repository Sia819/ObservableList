using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ObservableExtension
{
    public class ObservableList<T> : INotifyCollectionChanged, IList<T>, ICollection<T>, IEnumerable<T>, IList, ICollection, IEnumerable
    {
        #region List<T>

        public ObservableList()
        {
            _items = new List<T>();
        }
        public ObservableList(int capacity)
        {
            _items = new List<T>(capacity);
        }
        public ObservableList(IEnumerable<T> collection)
        {
            _items = new List<T>(collection);
        }

        public readonly List<T> _items;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private void RaiseCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            CollectionChanged?.Invoke(sender, args);
        }

        public T this[Int32 index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }
        public int Count { get { return _items.Count; } }
        public int Capacity { get { return _items.Capacity; } set { _items.Capacity = value; } }

        public void Add(T item)
        {
            _items.Add(item);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }
        public void AddRange(IEnumerable<T> collection)
        {
            _items.AddRange(collection);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collection));
        }
        public void Clear()
        {
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            _items.Clear();
        }
        public bool Contains(T item) => _items.Contains(item);
        public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
        {
            var result = _items.ConvertAll<TOutput>(converter);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace));
            return result;
        }
        public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);
        public void CopyTo(int index, T[] array, int arrayIndex, int count) => _items.CopyTo(index, array, arrayIndex, count);
        public void CopyTo(T[] array) => _items.CopyTo(array);
        public bool Exists(Predicate<T> match) => _items.Exists(match);
        public T Find(Predicate<T> match) => _items.Find(match);
        public List<T> FindAll(Predicate<T> match) => _items.FindAll(match);
        public int FindIndex(Predicate<T> match) => _items.FindIndex(match);
        public int FindIndex(int startIndex, Predicate<T> match) => _items.FindIndex(startIndex, match);
        public int FindIndex(int startIndex, int count, Predicate<T> match) => _items.FindIndex(startIndex, count, match);
        public T FindLast(Predicate<T> match) => _items.FindLast(match);
        public int FindLastIndex(Predicate<T> match) => _items.FindLastIndex(match);
        public int FindLastIndex(int startIndex, Predicate<T> match) => _items.FindLastIndex(startIndex, match);
        public int FindLastIndex(int startIndex, int count, Predicate<T> match) => _items.FindLastIndex(startIndex, count, match);
        public void ForEach(Action<T> action) => _items.ForEach(action);
        public List<T>.Enumerator GetEnumerator() => _items.GetEnumerator();
        public List<T> GetRange(int index, int count) => _items.GetRange(index, count);
        public int IndexOf(T item, int index, int count) => _items.IndexOf(item, index, count);
        public int IndexOf(T item, int index) => _items.IndexOf(item, index);
        public int IndexOf(T item) => _items.IndexOf(item);
        public void Insert(int index, T item)
        {
            _items.Insert(index, item);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
        }
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            _items.InsertRange(index, collection);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }
        public int LastIndexOf(T item) => _items.LastIndexOf(item);
        public int LastIndexOf(T item, int index) => _items.LastIndexOf(item, index);
        public int LastIndexOf(T item, int index, int count) => _items.LastIndexOf(item, index, count);
        public Boolean Remove(T item)
        {
            var result = _items.Remove(item);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            return result;
        }
        public int RemoveAll(Predicate<T> match)
        {
            var result = _items.RemoveAll(match);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            return result;
        }
        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
        }
        public void RemoveRange(int index, int count)
        {
            _items.RemoveRange(index, count);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
        }
        public void Reverse(int index, int count)
        {
            _items.Reverse(index, count);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move));
        }
        public void Reverse()
        {
            _items.Reverse();
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move));
        }
        public void Sort(int index, int count, IComparer<T> comparer)
        {
            _items.Sort(index, count, comparer);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move));
        }
        public void Sort(Comparison<T> comparison)
        {
            _items.Sort(comparison);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move));
        }
        public void Sort()
        {
            _items.Sort();
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move));
        }
        public void Sort(IComparer<T> comparer)
        {
            _items.Sort(comparer);
            RaiseCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move));
        }
        public T[] ToArray()
        {
            return _items.ToArray();
        }
        public void TrimExcess()
        {
            _items.TrimExcess();
        }
        public bool TrueForAll(Predicate<T> match)
        {
            return _items.TrueForAll(match);
        }
        #endregion

        #region Interfaces
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection)_items).CopyTo(array, index);
        }

        public int Add(object value)
        {
            return ((IList)_items).Add(value);
        }

        public bool Contains(object value)
        {
            return ((IList)_items).Contains(value);
        }

        public int IndexOf(object value)
        {
            return ((IList)_items).IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            ((IList)_items).Insert(index, value);
        }

        public void Remove(object value)
        {
            ((IList)_items).Remove(value);
        }


        // Is this List read-only?
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        public object SyncRoot => ((ICollection)_items).SyncRoot;

        public bool IsSynchronized => ((ICollection)_items).IsSynchronized;

        public bool IsReadOnly => ((IList)_items).IsReadOnly;

        public bool IsFixedSize => ((IList)_items).IsFixedSize;

        object IList.this[int index] { get => ((IList)_items)[index]; set => ((IList)_items)[index] = value; }

        #endregion
    }
}