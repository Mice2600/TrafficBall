using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;
using SystemBox;
using SystemBox.Simpls;


namespace SystemBox
{
    public class SimplsExsanple
    {
    }
    public static class Tools
    {
        public static void ClearChilds(this GameObject parent) => ClearChilds(parent.transform);
        public static void ClearChilds(this Transform parent)
        {
            if (parent == null) return;
            while (parent.childCount > 0)
            {
                TList<Transform> ds = parent.Childs();
                for (int i = 0; i < ds.Count; i++)
                {
                    ds[i].SetParent(null);
                    if (Application.isPlaying)
                        MonoBehaviour.Destroy(ds[i].gameObject);
                    else
                        MonoBehaviour.DestroyImmediate(ds[i].gameObject);
                }
                
                
            }
        }
        public static TList<Transform> Childs(this Transform parent)
        {
            TList<Transform> Childss = new TList<Transform>();
            if (parent == null) return Childss;
            for (int i = 0; i < parent.childCount; i++)
                Childss += parent.GetChild(i);
            return Childss;
        }

        
        #region Destroy
        public static void DestroyAll(this List<GameObject> list)
        {
            try
            {
                foreach (GameObject t in list) ToDestroy(t);
            }
            catch (System.Exception XX) { throw ExceptionThrow(XX); }
        }
        public static void DestroyAll(this List<Transform> list)
        {
            try
            {
                foreach (Transform t in list) ToDestroy(t);
            }
            catch (System.Exception XX) { throw ExceptionThrow(XX); }
        }
        public static void DestroyAll(this TList<GameObject> list)
        {
            try
            {
                foreach (GameObject t in list) ToDestroy(t);
            }
            catch (System.Exception XX) { throw ExceptionThrow(XX); }
        }
        public static void DestroyAll(this TList<Transform> list)
        {
            try
            {
                foreach (Transform t in list) ToDestroy(t);   
            }
            catch (System.Exception XX) { throw ExceptionThrow(XX); }
        }
        public static void DestroyAll(this Transform[] list)
        {
            try
            {
                foreach (Transform t in list) ToDestroy(t);
            }
            catch (System.Exception XX) { throw ExceptionThrow(XX); }
        }
        public static void DestroyAll(this GameObject[] list)
        {
            try
            {
                foreach (GameObject t in list) ToDestroy(t);
            }
            catch (System.Exception XX) { throw ExceptionThrow(XX); }
        }
        public static void DestroyAll<T>(this List<T> list, bool WithGameObject = false) where T : MonoBehaviour
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (WithGameObject)
                        ToDestroy(list[i].gameObject);
                    else ToDestroy(list[i]);
                }
            }
            catch (System.Exception XX) { throw ExceptionThrow(XX); }
        }
        public static void DestroyAll<T>(this TList<T> list, bool WithGameObject = false) where T : MonoBehaviour
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (WithGameObject)
                        ToDestroy(list[i].gameObject);
                    else ToDestroy(list[i]);
                }
            }
            catch (System.Exception XX) { throw ExceptionThrow(XX); }
        }
        public static void DestroyAll<T>(this T[] list, bool WithGameObject = false) where T : MonoBehaviour
        {
            try
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (WithGameObject)
                        ToDestroy(list[i].gameObject);
                    else ToDestroy(list[i]);
                }
            }
            catch (System.Exception XX) { throw ExceptionThrow(XX); }
        }

        public static void ToDestroy(this Transform Item) 
        {
            if (Item == null) return;
            ToDestroy(Item.gameObject); 
        }
        public static void ToDestroy(this GameObject Item)
        {
            if (Item == null) return;
            Item.transform.SetParent(null);
            if (Application.isPlaying) MonoBehaviour.Destroy(Item);
            else MonoBehaviour.DestroyImmediate(Item);
        }
        public static void ToDestroy(this MonoBehaviour Item)
        {
            if (Item == null) return;
            if (Application.isPlaying) MonoBehaviour.Destroy(Item);
            else MonoBehaviour.DestroyImmediate(Item);
        }
        public static void ToDestroy(this AudioBehaviour Item)
        {
            if (Item == null) return;
            if (Application.isPlaying) MonoBehaviour.Destroy(Item);
            else MonoBehaviour.DestroyImmediate(Item);
        }

        #endregion

        /// <summary>
        /// loop for value time
        /// </summary>
        /// <param name="action"> Deleget </param>
        public static void For(this int value, System.Action action)
        {
            for (int i = 0; i < value; i++) action.Invoke();
        }
        /// <summary>
        /// loop for value time
        /// </summary>
        /// <param name="action"> Deleget I = Loop Time </param>
        public static void For(this int value, System.Action<int> action)
        {
            for (int i = 0; i < value; i++) action.Invoke(i);
        }

        public static SystemBox.Editor.CustomException ExceptionThrow(System.Exception XX, int stackTrace = 2)
        {
            SystemBox.Editor.CustomException dsa = new SystemBox.Editor.CustomException(XX.Message);
            dsa.stackTrace_my = new System.Diagnostics.StackTrace(stackTrace, true).ToString();
            return dsa;
        }

        #region Vector3


        public static void MoveTowards(this Transform current, Vector3 target, float maxDistanceDelta) 
        {
            Vector3 a = target - current.position;
            float magnitude = a.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == 0f) { current.position = target; return; }
            current.position = current.position + a / magnitude * maxDistanceDelta;
        }
        public static void MoveTowardslocal(this Transform current, Vector3 target, float maxDistanceDelta)
        {
            Vector3 a = target - current.localPosition;
            float magnitude = a.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == 0f) { current.localPosition = target; return; }
            current.localPosition = current.localPosition + a / magnitude * maxDistanceDelta;
        }
        public static Vector3 MoveTowards(this Vector3 current, Vector3 target, float maxDistanceDelta)
        {
            Vector3 a = target - current;
            float magnitude = a.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == 0f) { return target; }
            return current + a / magnitude * maxDistanceDelta;
        }

        #endregion

    }
    public static class ListTools
    {
        public static T Firs<T>(this List<T> list)//Tested
        {
            try { return list[0]; }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        public static T Last<T>(this List<T> list)//Tested
        {
            try { return list[list.Count - 1]; }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <returns> new Rotated List from List  </returns>
        /// <param name="AsNew">false if u want Rotat ur list, true if u want new Rotated list</param>
        public static List<T> Rotate<T>(this List<T> list, bool AsNew = false)//Tested
        {
            try
            {
                if (!AsNew)
                {
                    List<T> ssdas = new List<T>();
                    for (int i = list.Count - 1; i >= 0; i--) { ssdas.Add(list[i]); }
                    list.Clear();
                    ssdas.ForEach(ss => list.Add(ss));
                    return list;
                }
                TList<T> das = new TList<T>();
                for (int i = list.Count - 1; i >= 0; i--) { das.Add(list[i]); }
                return das;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 1); }
        }
        /// <summary>
        /// random Mixes List
        /// </summary>
        /// <param name="AsNew">false if u want mix ur list, true if u want new mixed list</param>
        /// <returns>random mixed list</returns>
        public static List<T> Mix<T>(this List<T> list, bool AsNew = false)//Tested
        {
            try
            {
                if (!AsNew)
                {
                    TList<T> _New = new TList<T>();
                    while (list.Count > 0)
                    {
                        int d = Random.Range(0, list.Count);
                        T sdd = list[d];
                        list.RemoveAt(d);
                        _New.Add(sdd);
                    }
                    _New.ForEach(ss => list.Add(ss));
                    return list;
                }
                TList<T> New = new TList<T>();
                TList<T> Old = new TList<T>(list);
                while (Old.Count > 0)
                {
                    int d = Random.Range(0, Old.Count);
                    T sdd = Old[d];
                    Old.RemoveAt(d);
                    New.Add(sdd);
                }
                return New;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// Replace Indexses, { A,B,C,D } so ReplaceIndexses(0,2) then { C,B,A,D }
        /// </summary>
        /// <param name="Firs"> first index to Replace </param>
        /// <param name="second"> second index to Replace  </param>
        /// <param name="AsNew"> true if u want new Replaced list , false if u want Replace ur list</param>
        public static List<T> ReplaceIndexses<T>(this List<T> list, int Firs, int second, bool AsNew = false)
        {
            try
            {
                if (!AsNew)
                {
                    T d = list[Firs];
                    list[Firs] = list[second];
                    list[second] = d;
                    return list;
                }
                List<T> das = new List<T>(list);
                T f = das[Firs];
                das[Firs] = das[second];
                das[second] = f;
                return das;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// Count - 1
        /// </summary>
        public static int LastIndex<T>(this List<T> list)//Tested
        {
            try
            {
                return list.Count - 1;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// int Random(0, Count)
        /// </summary>
        public static int RandomIndex<T>(this List<T> list)//Tested
        {
            try
            {
                return Random.Range(0, list.Count);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// T Random(0, Count)
        /// </summary>
        public static T RandomItem<T>(this List<T> list)//Tested
        {
            try
            {
                return list[Random.Range(0, list.Count)];
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// list.RemoveAt(Range(0, list.Count));
        /// </summary>
        /// <returns> removved item </returns>
        public static T RemoveRandomItem<T>(this List<T> list)//Tested
        {
            try
            {
                int d = Random.Range(0, list.Count);
                T sdd = list[d];
                list.RemoveAt(d);
                return sdd;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// RemoveAt with return
        /// list.RemoveAt(Range(0, list.Count));
        /// </summary>
        /// <returns> returns removed item </returns>
        public static T TakeOff<T>(this List<T> list, int index)//Tested
        {
            try
            {
                T sdd = list[index];
                list.RemoveAt(index);
                return sdd;
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// RemoveAt(0)
        /// </summary>
        public static void RemoveFirst<T>(this List<T> list)
        {
            try { list.RemoveAt(0); }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// RemoveAt(Count - 1)
        /// </summary>
        public static void RemoveLast<T>(this List<T> list)//Tested
        {
            try { list.RemoveAt(list.Count - 1); }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <returns> true if count == 0 </returns>
        public static bool IsEnpty<T>(this List<T> list)//Tested
        {
            try { return list.Count == 0; }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        public static T AddReturn<T>(this List<T> list, T item)//Tested
        {
            try
            {
                list.Add(item);
                return list[list.Count - 1];
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// Adds Item  where u want
        /// </summary>
        /// <param name="item"> Item </param>
        /// <param name="Index"> index to start adding </param>
        /// /// <returns> returns Added item </returns>
        public static T AddTo<T>(this List<T> list, T item, int Index)//Tested
        {
            try
            {
                TList<T> Newlist = new TList<T>();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == Index) Newlist.Add(item);
                    Newlist.Add(list[i]);
                }
                list.Clear();
                Newlist.ForEach(d => list.Add(d));
                return list[Index];
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// Adds Item  where u want
        /// </summary>
        /// <param name="items"> Items </param>
        /// <param name="Index"> index to start adding </param>
        /// <returns> returns Added items </returns>
        public static void AddTo<T>(this List<T> list, int Index, params T[] items)//Tested
        {
            try
            {
                TList<T> Newlist = new TList<T>();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == Index) items.ToList().ForEach(A => Newlist.Add(A));
                    Newlist.Add(list[i]);
                }
                list.Clear();
                Newlist.ForEach(d => list.Add(d));
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// Adds Item  where u want
        /// </summary>
        /// <param name="items"> Items </param>
        /// <param name="Index"> index to start adding </param>
        public static void AddTo<T>(this List<T> list, int Index, List<T> items)//Tested
        {
            try
            {
                TList<T> Newlist = new TList<T>();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == Index) items.ForEach(A => Newlist.Add(A));
                    Newlist.Add(list[i]);
                }
                list.Clear();
                Newlist.ForEach(d => list.Add(d));
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// Adds Item Many that u wanted
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="HowMatch">how match u want to add</param>
        public static void AddMany<T>(this List<T> list, T item, int HowMatch)//Tested
        {
            try
            {
                for (int i = 0; i < HowMatch; i++) list.Add(item);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        /// <summary>
        /// Adds Item Many that u wanted and where u wanted
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="HowMatch">how match u want to add</param>
        /// <param name="Index">where u want to add</param>
        public static void AddManyTo<T>(this List<T> list, T item, int HowMatch, int Index)//Tested
        {
            try
            {
                TList<T> Newlist = new TList<T>();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == Index) { for (int f = 0; f < HowMatch; f++) Newlist.Add(item); }
                    Newlist.Add(list[i]);
                }
                list.Clear();
                Newlist.ForEach(d => list.Add(d));
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 1); }
        }

        public static void ForEach<T>(this List<T> list, System.Action<T, int> action)
        {
            try
            {
                int HowMatch = list.Count;
                for (int i = 0; i < HowMatch; i++) action.Invoke(list[i], i);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }
        public static void ForEach<T>(this T[] list, System.Action<T, int> action)
        {
            try
            {
                int HowMatch = list.Length;
                for (int i = 0; i < HowMatch; i++) action.Invoke(list[i], i);
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX, 2); }
        }

        public static void RemoveNulls<T>(this List<T> list) where T : class
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == null)
                    {
                        list.RemoveAt(i);
                        if (list.Count == 0) break;
                        i--;
                    }
                }
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }
        public static void RemoveNulls<T>(this TList<T> list) where T : class
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == null)
                    {
                        list.RemoveAt(i);
                        if (list.Count == 0) break;
                        i--;
                    }
                }
            }
            catch (System.Exception XX) { throw Tools.ExceptionThrow(XX); }
        }






        public static T[] Add<T>(this T[] array, T item)
        {
            if (array == null) { return new T[] { item }; }
            T[] result = new T[array.Length + 1];
            array.CopyTo(result, 0);
            result[array.Length] = item;
            return result;
        }


        public static T[] Remove<T>(this T[] original, T itemToRemove)
        {
            int numIdx = System.Array.IndexOf(original, itemToRemove);
            if (numIdx == -1) return original;
            List<T> tmp = new List<T>(original);
            tmp.RemoveAt(numIdx);
            return tmp.ToArray();
        }

        public static T[] RemoveAt<T>(this T[] arr, int index)
        {
            for (int a = index; a < arr.Length - 1; a++) arr[a] = arr[a + 1];
            System.Array.Resize(ref arr, arr.Length - 1);
            return arr;
        }


    }

}
namespace SystemBox.Engine
{


    public class ItemEngine : MonoBehaviour
    {
        public System.Action update;
        public void Update() => update?.Invoke();
    }

    public static class Engine 
    {
        static Engine ()
        {
            Engins = new Dictionary<string, ItemEngine>();
        }
        public static Dictionary<string, ItemEngine> Engins;
        public static void Update_Engins(string ID, System.Action action) => Get_Engine(ID).update = action;
        public static void Stop_Update_Engins(string ID) => Get_Engine(ID).update = delegate () { };
        public static ItemEngine Get_Engine(string ID)
        {
            if (!Engins.ContainsKey(ID))
            {
                Engins.Add(ID, new GameObject("Engine" + ID).AddComponent<ItemEngine>());
                MonoBehaviour.DontDestroyOnLoad(Engins[ID].gameObject);
            }
            return Engins[ID];
        }
        public static void Destroy_Engine(string ID)
        {
            if (!Engins.ContainsKey(ID)) return;
            GameObject ToDestroy = Engins[ID].gameObject;
            Engins.Remove(ID);
            MonoBehaviour.Destroy(ToDestroy);
        }
        
    }

    public static class Engine<T>
    {
        static Engine()
        {
            Engins = new GameObject("Engine" + typeof(T)).AddComponent<ItemEngine<T>>();
        }
        private static ItemEngine Engins;
        
        public static void Update_Engins(System.Action action) => Engins.update = action;
        public static void Stop_Update_Engins() => Engins.update = delegate () { };
        public static ItemEngine Get_Engine() => Engins;

        public static void Destroy_Engine()
        {
            GameObject ToDestroy = Engins.gameObject;
            MonoBehaviour.Destroy(ToDestroy);
        }
        public class ItemEngine<G> : ItemEngine{}
    }


}
namespace SystemBox.Editor
{
    public class CustomException : System.Exception
    {
        public CustomException() : base()
        {
        }
        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public string stackTrace_my;
        public override string StackTrace => stackTrace_my;
    }
}



