using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SystemBox.Simpls
{
    public static class Comand
    {
        public static void ClearChilds(Transform parent)
        {
            if (parent == null) return;
            while (parent.childCount > 0)
            {
                GameObject ds = parent.GetChild(0).gameObject;
                ds.transform.SetParent(null);
                if (Application.isPlaying)
                    MonoBehaviour.Destroy(ds);
                else
                    MonoBehaviour.DestroyImmediate(ds);
            }
        }


        #region IsColled
        private static Dictionary<string, IsColled_Values> IsColled_Resurses = new Dictionary<string, IsColled_Values>();
        private class IsColled_Values
        {
            public IsColled_Values() { }
            public IsColled_Values(int _Firs, int _Last, MonoBehaviour mono)
            {
                IsUsing_ID_mono = mono != null;
                First = _Firs;
                Last = _Last;
                ID_mono = mono;
            }
            public int First;
            public int Last;
            public bool IsUsing_ID_mono;
            public MonoBehaviour ID_mono = null;
        }

        public static bool IsColled(string ID) => IsColled(ID, 1, null);
        public static bool IsColled(string ID, int Last_call) => IsColled(ID, Last_call, null);
        public static bool IsColled(string ID, MonoBehaviour mono) => IsColled(ID, 1, mono);
        public static bool IsColled(MonoBehaviour mono) => IsColled(mono.GetHashCode().ToString(), 1, mono);
        public static bool IsColled(string ID, int Last_call, MonoBehaviour mono = null)
        {
            if (Last_call < 1) Last_call = 1;
            if (mono != null) ID += mono.GetHashCode();
            if (IsColled_Resurses.ContainsKey(ID))
            {

                if (!IsColled_Resurses[ID].IsUsing_ID_mono && mono == null)
                {
                    if (IsColled_Resurses[ID].First == IsColled_Resurses[ID].Last) return true;
                    IsColled_Resurses[ID].First++;
                    return false;
                }
                if (IsColled_Resurses[ID].ID_mono == null || IsColled_Resurses[ID].ID_mono != mono)
                {
                    IsColled_Resurses[ID] = new IsColled_Values(1, Last_call, mono);
                    return false;
                }
                if (IsColled_Resurses[ID].First == IsColled_Resurses[ID].Last) return true;
                IsColled_Resurses[ID].First++;
                return false;


            }
            else
            {
                IsColled_Resurses.Add(ID, new IsColled_Values(1, Last_call, mono));
                return false;
            }
        }
        public static void Reset_IsColled(string ID)
        {
            if (IsColled_Resurses.ContainsKey(ID))
            {
                IsColled_Resurses.Remove(ID);
            }
        }
        public static void Reset_IsColled(string ID, MonoBehaviour mono)
        {
            if (IsColled_Resurses.ContainsKey(ID + mono.GetHashCode().ToString()))
            {
                IsColled_Resurses.Remove(ID + mono.GetHashCode().ToString());
            }
        }
        public static void Reset_All_IsColled()
        {
            IsColled_Resurses = new Dictionary<string, IsColled_Values>();
        }
        public static void Reset_IsColled(MonoBehaviour mono)
        {
            if (mono == null) return;
            foreach (KeyValuePair<string, IsColled_Values> kvp in IsColled_Resurses)
            {
                if (IsColled_Resurses[kvp.Key].IsUsing_ID_mono && IsColled_Resurses[kvp.Key].ID_mono == mono) IsColled_Resurses[kvp.Key].First = 0;
            }

        }
        #endregion

        #region IsColled_Player_Prefes


        public static bool IsColled_Player_Prefes(string ID, int Last_call = 0)
        {
            if (Last_call < 1) Last_call = 1;
            if (PlayerPrefs.GetInt("SystemBox/IsColled") == 0)
            {
                PlayerPrefs.SetInt("SystemBox/IsColled", 1);
                return false;
            }
            else
            {
                if (PlayerPrefs.GetInt("SystemBox/IsColled") >= Last_call) return true;
                PlayerPrefs.SetInt("SystemBox/IsColled", PlayerPrefs.GetInt("SystemBox/IsColled") + 1);
                return false;
            }
        }

        #endregion



        #region OneFreme

        private static Dictionary<string, int> _OneFreamValue = new Dictionary<string, int>();
        /// <summary>
        /// use for stiglton metods for one job in one fream
        /// </summary>
        /// <param name="ID"></param>
        /// <returns> true if u cilled first time on this fream </returns>
        public static bool OneFream(string ID) 
        {
            if (!_OneFreamValue.ContainsKey(ID))
                _OneFreamValue.Add(ID, -1);
            bool Answer = _OneFreamValue[ID] != Time.frameCount;
            _OneFreamValue[ID] = Time.frameCount;
            return Answer;
        }
        #endregion

    }
}