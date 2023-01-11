using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace SystemBox
{
    /// <summary>
    /// List Utulity SystemBox
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    [System.Serializable]
    public class LoopList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection, IList
    {
        public LoopList() { }
        public LoopList(T ts)
        {
            try
            {
                NList.Clear();
                NList.Add(ts);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public LoopList(List<T> ts)
        {
            try
            {
                NList.Clear();
                for (int i = 0; i < ts.Count; i++) NList.Add(ts[i]);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public LoopList(params T[] ts)
        {
            try
            {
                NList.Clear();
                NList = ts.ToList();
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public LoopList(IEnumerable<T> collection)
        {
            try
            {
                NList = new List<T>(collection);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }


        #region ListOrginal

        [SerializeField]
        private List<T> NList = new List<T>();
        public T this[int index]
        {
            get
            {
                try
                {
                    if (index >= 0)
                    {
                        int levv = (index / NList.Count);
                        index -= (levv * NList.Count);
                        return NList[index];
                    }
                    else 
                    {
                        index = Mathf.Abs(index);
                        int levv = (index / NList.Count);
                        index -= (levv * NList.Count);
                        return NList[(NList.Count) - index];
                    }
                    
                }
                catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
            }
            set
            {
                try
                {

                    if (index >= 0)
                    {
                        int levv = (index / NList.Count);
                        index -= (levv * NList.Count);
                        NList[index] = value;
                    }
                    else
                    {
                        index = Mathf.Abs(index);
                        int levv = (index / NList.Count);
                        index -= (levv * NList.Count);
                        NList[(NList.Count) - index] = value;
                    }
                }
                catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
            }
        }
        public int Count
        {
            get
            {
                try
                {
                    return NList.Count;
                }
                catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
            }
        }
        public int Capacity { get; set; }

        public void Add(T item)
        {
            try
            {
                NList.Add(item);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void AddRange(IEnumerable<T> collection)
        {
            try
            {
                NList.AddRange(collection);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int BinarySearch(T item)
        {
            try
            {
                return NList.BinarySearch(item);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int BinarySearch(T item, IComparer<T> comparer)
        {
            try
            {
                return NList.BinarySearch(item, comparer);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        {
            try
            {
                return NList.BinarySearch(index, count, item, comparer);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void Clear()
        {
            try
            {
                NList.Clear();
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }

        public bool Contains(T item)
        {
            try
            {
                return NList.Contains(item);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            try
            {
                NList.CopyTo(index, array, arrayIndex, count);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            try
            {
                NList.CopyTo(array, arrayIndex);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void CopyTo(T[] array)
        {
            try
            {
                NList.CopyTo(array);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public bool Exists(System.Predicate<T> match)
        {
            try
            {
                return NList.Exists(match);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public T Find(System.Predicate<T> match)
        {
            try
            {
                return NList.Find(match);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public List<T> FindAll(System.Predicate<T> match)
        {
            try
            {
                return NList.FindAll(match);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }

        public int FindIndex(int startIndex, int count, System.Predicate<T> match)
        {
            try
            {
                return NList.FindIndex(startIndex, count, match);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int FindIndex(int startIndex, System.Predicate<T> match)
        {
            try
            {
                return NList.FindIndex(startIndex, match);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int FindIndex(System.Predicate<T> match)
        {
            try
            {
                return NList.FindIndex(match);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public T FindLast(System.Predicate<T> match)
        {
            try
            {
                return NList.FindLast(match);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int FindLastIndex(int startIndex, int count, System.Predicate<T> match)
        {
            try
            {
                return NList.FindLastIndex(startIndex, count, match);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int FindLastIndex(int startIndex, System.Predicate<T> match)
        {
            try
            {
                return NList.FindIndex(startIndex, match);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int FindLastIndex(System.Predicate<T> match)
        {
            try
            {
                return NList.FindLastIndex(match);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }

        public List<T> GetRange(int index, int count)
        {
            try
            {
                return NList.GetRange(index, count);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int IndexOf(T item, int index, int count)
        {
            try
            {
                return NList.IndexOf(item, index, count);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int IndexOf(T item, int index)
        {
            try
            {
                return NList.IndexOf(item, index);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int IndexOf(T item)
        {
            try
            {
                return NList.IndexOf(item);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void Insert(int index, T item)
        {
            try
            {
                NList.Insert(index, item);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            try
            {
                NList.InsertRange(index, collection);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int LastIndexOf(T item)
        {
            try
            {
                return NList.LastIndexOf(item);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int LastIndexOf(T item, int index)
        {
            try
            {
                return NList.LastIndexOf(item, index);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int LastIndexOf(T item, int index, int count)
        {
            try
            {
                return NList.LastIndexOf(item, index, count);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public bool Remove(T item)
        {
            try
            {
                return NList.Remove(item);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public int RemoveAll(System.Predicate<T> match)
        {
            try
            {
                return NList.RemoveAll(match);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void RemoveAt(int index)
        {
            try
            {
                NList.RemoveAt(index);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void RemoveRange(int index, int count)
        {
            try
            {
                NList.RemoveRange(index, count);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void Reverse(int index, int count)
        {
            try
            {
                NList.Reverse(index, count);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void Reverse()
        {
            try
            {
                NList.Reverse();
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void Sort(System.Comparison<T> comparison)
        {
            try
            {
                NList.Sort(comparison);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void Sort(int index, int count, IComparer<T> comparer)
        {
            try
            {
                NList.Sort(index, count, comparer);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void Sort()
        {
            try
            {
                NList.Sort();
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void Sort(IComparer<T> comparer)
        {
            try
            {
                NList.Sort(comparer);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public T[] ToArray()
        {
            try
            {
                return NList.ToArray();
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void TrimExcess()
        {
            try
            {
                NList.TrimExcess();
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public bool TrueForAll(System.Predicate<T> match)
        {
            try
            {
                return NList.TrueForAll(match);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }

        private bool IsReadOnly => throw new System.NotImplementedException();

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(System.Array array, int index)
        {
            throw new System.NotImplementedException();
        }

        public int Add(object value)
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new System.NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new System.NotImplementedException();
        }
        public bool IsSynchronized => throw new System.NotImplementedException();

        public object SyncRoot => throw new System.NotImplementedException();

        public bool IsFixedSize => throw new System.NotImplementedException();

        bool IList.IsReadOnly => throw new System.NotImplementedException();

        bool ICollection<T>.IsReadOnly => ((ICollection<T>)NList).IsReadOnly;

        object IList.this[int index] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        #endregion

        

        /// <summary>
        /// random Mixes List
        /// </summary>
        /// <param name="AsNew">false if u want mix ur list, true if u want new mixed list</param>
        /// <returns>random mixed list</returns>
        public LoopList<T> Mix(bool AsNew = false)//Tested
        {
            try
            {
                if (!AsNew)
                {
                    List<T> _New = new List<T>();
                    while (NList.Count > 0)
                    {
                        int d = Random.Range(0, NList.Count);
                        T sdd = NList[d];
                        NList.RemoveAt(d);
                        _New.Add(sdd);
                    }
                    NList = _New;
                    return this;
                }
                LoopList<T> New = new LoopList<T>();
                List<T> Old = new List<T>(NList);
                while (Old.Count > 0)
                {
                    int d = Random.Range(0, Old.Count);
                    T sdd = Old[d];
                    Old.RemoveAt(d);
                    New.Add(sdd);
                }
                return New;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        /// <summary>
        /// Replace Indexses, { A,B,C,D } so ReplaceIndexses(0,2) then { C,B,A,D }
        /// </summary>
        /// <param name="Firs"> first index to Replace </param>
        /// <param name="second"> second index to Replace  </param>
        /// <param name="AsNew"> true if u want new Replaced list , false if u want Replace ur list</param>
        public LoopList<T> ReplaceIndexses(int Firs, int second, bool AsNew = false)//Tested
        {
            try
            {
                if (!AsNew)
                {
                    T d = NList[Firs];
                    NList[Firs] = NList[second];
                    NList[second] = d;
                    return this;
                }
                LoopList<T> das = new LoopList<T>(NList);
                T f = das[Firs];
                das[Firs] = das[second];
                das[second] = f;
                return das;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        /// <summary>
        /// Count - 1
        /// </summary>
        public int LastIndex
        {
            get
            {
                try
                {
                    return NList.Count - 1;
                }
                catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
            }
        }
        /// <summary>
        /// List[Count - 1]
        /// </summary>
        public T Last
        {
            get
            {
                try
                {
                    return NList[LastIndex];
                }
                catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
            }
            set 
            {
                try
                {
                    NList[LastIndex] = value;
                }
                catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
            }
        }

        /// <summary>
        /// List[0]
        /// </summary>
        public T First
        {
            get
            {
                try
                {
                    return NList[0];
                }
                catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
            }
            set
            {
                try
                {
                    NList[0] = value;
                }
                catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
            }
        }
        /// <summary>
        /// int Random(0, Count)
        /// </summary>
        public int RandomIndex
        {
            get
            {
                try
                {
                    return Random.Range(0, NList.Count);
                }
                catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
            }
        }
        /// <summary>
        /// T Random(0, Count)
        /// </summary>
        public T RandomItem
        {
            get
            {
                try
                {
                    return NList[Random.Range(0, NList.Count)];
                }
                catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
            }
        }


        /// <summary>
        /// list.RemoveAt(Range(0, list.Count));
        /// </summary>
        /// <returns> removved item </returns>
        public T RemoveRandomItem()//Tested
        {
            try
            {
                int d = Random.Range(0, NList.Count);
                T sdd = NList[d];
                NList.RemoveAt(d);
                return sdd;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        /// <summary>
        /// RemoveAt with return
        /// list.RemoveAt(Range(0, list.Count));
        /// </summary>
        /// <returns> returns removed item </returns>
        public T TakeOff(int index)//Tested
        {
            try
            {
                int d = index;
                T sdd = NList[d];
                NList.RemoveAt(d);
                return sdd;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        /// <summary>
        /// RemoveAt(0)
        /// </summary>
        public T RemoveFirst()//Tested
        {
            try
            {
                T d = NList[0];
                NList.RemoveAt(0);
                return d;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        /// <summary>
        /// RemoveAt(Count - 1)
        /// </summary>
        public T RemoveLast()//Tested
        {
            try
            {
                T d = NList[Count - 1];
                NList.RemoveAt(Count - 1);
                return d;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        /// <returns> true if count == 0 </returns>
        public bool IsEnpty()
        {
            try { return NList.Count == 0; }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        /// <summary>
        /// berilgan idexda keyingisini qaytaradi bosa
        /// </summary>
        /// <returns>List(List.IndexOf(item)+1)</returns>
        public T NextOf(T item)//Tested
        {
            try
            {
                return NList[NList.IndexOf(item) + 1];
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }

        /// <summary>
        /// berilgan idexda oldingisini qaytaradi bosa
        /// </summary>
        /// <returns>List(List.IndexOf(item)-1)</returns>
        public T PreviousOf(T item)//Tested
        {
            try
            {
                return NList[NList.IndexOf(item) - 1];
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }


        public void Add(IEnumerable<T> Tll)
        {
            try
            {
                NList.AddRange(Tll);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public LoopList<T> AddAndReturn(T item) //Tested
        {
            try
            {
                NList.Add(item);
                return this;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public T AddAndReturnLast(T item)  //Tested
        {
            try
            {
                NList.Add(item);
                return this[Count - 1];
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        /// <summary>
        /// Adds Item  where u want
        /// </summary>
        /// <param name="item"> Item </param>
        /// <param name="Index"> index to start adding </param>
        public TList<T> AddTo(int Index, T item)
        {
            try
            {
                List<T> Newlist = new List<T>();
                if (NList.Count == 0) Newlist.Add(item);
                for (int i = 0; i < NList.Count; i++)
                {
                    if (i == Index) Newlist.Add(item);
                    Newlist.Add(NList[i]);
                }
                if (Newlist.Count == Index) Newlist.Add(item);
                NList = new List<T>(Newlist);
                return new TList<T>(this) ;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        /// <summary>
        /// Adds Item  where u want
        /// </summary>
        /// <param name="items"> Item </param>
        /// <param name="Index"> index to start adding </param>
        public LoopList<T> AddTo(int Index, TList<T> items) //Tested
        {
            try
            {
                List<T> Newlist = new List<T>();
                if (NList.Count == 0) items.ForEach(A => Newlist.Add(A));
                for (int i = 0; i < NList.Count; i++)
                {
                    if (i == Index) items.ForEach(A => Newlist.Add(A));
                    Newlist.Add(NList[i]);
                }
                NList = Newlist;
                return this;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }

        /// <summary>
        /// Adds Item  where u want
        /// </summary>
        /// <param name="items"> Item </param>
        /// <param name="Index"> index to start adding </param>
        public LoopList<T> AddTo(int Index, params T[] items)  //Tested
        {
            try
            {
                List<T> Newlist = new List<T>();
                if (NList.Count == 0) items.ToList().ForEach(A => Newlist.Add(A));
                for (int i = 0; i < NList.Count; i++)
                {
                    if (i == Index) items.ToList().ForEach(A => Newlist.Add(A));
                    Newlist.Add(NList[i]);
                }
                NList = Newlist;
                return this;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        /// <summary>
        /// Adds Item  where u want
        /// </summary>
        /// <param name="items"> Item </param>
        /// <param name="Index"> index to start adding </param>
        public LoopList<T> AddTo(int Index, List<T> items) //Tested
        {
            try
            {
                List<T> Newlist = new List<T>();
                if (NList.Count == 0) items.ForEach(A => Newlist.Add(A));
                for (int i = 0; i < NList.Count; i++)
                {
                    if (i == Index) items.ForEach(A => Newlist.Add(A));
                    Newlist.Add(NList[i]);
                }
                NList = Newlist;
                return this;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        /// <summary>
        /// Adds Item Many that u wanted
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="HowMatch">how match u want to add</param>
        public void AddMany(T item, int HowMatch)
        {
            try
            {
                for (int i = 0; i < HowMatch; i++)
                {
                    NList.Add(item);
                }
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        /// <summary>
        /// Adds Item Many that u wanted and where u wanted
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="HowMatch">how match u want to add</param>
        /// <param name="Index">where u want to add</param>
        public LoopList<T> AddManyTo(T item, int HowMatch, int Index)//Tested
        {
            try
            {
                LoopList<T> Newlist = new LoopList<T>();
                for (int i = 0; i < NList.Count; i++)
                {
                    if (i == Index)
                    {
                        for (int f = 0; f < HowMatch; f++)
                        {
                            Newlist.NList.Add(item);
                        }
                    }
                    Newlist.NList.Add(NList[i]);
                }
                NList = new List<T>(Newlist);
                return this;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }

        }


        public LoopList<T> AddIf(T item, bool Test)
        {
            if (!Test) return this;
            try
            {
                NList.Add(item);
                return this;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }


        public LoopList<T> AddIf(IEnumerable<T> item, bool Test)
        {
            if (!Test) return this;
            try
            {
                this.Add(item);
                return this;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }

        public LoopList<T> AddIfDirty(T item)
        {
            try
            {
                if (NList.IndexOf(item) == -1) NList.Add(item);
                return this;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public bool IsIndex(T item)
        {
            try
            {
                return NList.IndexOf(item) != -1;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public void ForEach(System.Action<T> action)//Tested
        {
            try
            {
                NList.ForEach(action);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }

        public void ForEach(System.Action<T, int> action)//Tested
        {
            try
            {
                int HowMatch = Count;
                for (int i = 0; i < HowMatch; i++) action.Invoke(NList[i], i);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }

    

        #region operator 
        public static LoopList<T> operator +(LoopList<T> left, T right)
        {
            try
            {
                left.NList.Add(right);
                return left;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public static LoopList<T> operator -(LoopList<T> left, T right)
        {
            try
            {
                left.NList.Remove(right);
                return left;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        #endregion

    }
}
