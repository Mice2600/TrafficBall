using System.Collections.Generic;
using UnityEngine;
namespace SystemBox
{
    public static class Data
    {
        #region Int
        private static Dictionary<string, int> IntValues;
        public static int Int(string key)
        {
            if (!(IntValues ??= new Dictionary<string, int>()).ContainsKey(key)) IntValues.Add(key, PlayerPrefs.GetInt(key));
            return IntValues[key];
        }
        public static int Int(string key, int value)
        {
            if (!(IntValues ??= new Dictionary<string, int>()).ContainsKey(key)) IntValues.Add(key, PlayerPrefs.GetInt(key));
            if (IntValues[key] != value)
            {
                IntValues[key] = value;
                PlayerPrefs.SetInt(key, value);
            }
            return IntValues[key];
        }
        #endregion
        #region float
        private static Dictionary<string, float> FloatValues;
        public static float Float(string key)
        {
            if (!(FloatValues ??= new Dictionary<string, float>()).ContainsKey(key)) FloatValues.Add(key, PlayerPrefs.GetFloat(key));
            return FloatValues[key];
        }
        public static float Float(string key, float value)
        {
            if (!(FloatValues ??= new Dictionary<string, float>()).ContainsKey(key)) FloatValues.Add(key, PlayerPrefs.GetFloat(key));
            if (FloatValues[key] != value)
            {
                FloatValues[key] = value;
                PlayerPrefs.SetFloat(key, value);
            }
            return FloatValues[key];
        }
        #endregion

        #region bool
        private static Dictionary<string, bool> BoolValues;
        public static bool Bool(string key)
        {
            if (!(BoolValues ??= new Dictionary<string, bool>()).ContainsKey(key)) BoolValues.Add(key, PlayerPrefs.GetInt(key) == 1);
            return BoolValues[key];
        }
        public static bool Bool(string key, bool value)
        {
            if (!(BoolValues ??= new Dictionary<string, bool>()).ContainsKey(key)) BoolValues.Add(key, PlayerPrefs.GetInt(key) == 1);
            if (BoolValues[key] != value)
            {
                BoolValues[key] = value;
                PlayerPrefs.SetInt(key, value ? 1 : 0);
            }
            return BoolValues[key];
        }
        #endregion

        #region string
        private static Dictionary<string, string> StringValues;
        public static string String(string key)
        {
            if (!(StringValues ??= new Dictionary<string, string>()).ContainsKey(key)) StringValues.Add(key, PlayerPrefs.GetString(key));
            return StringValues[key];
        }
        public static string String(string key, string value)
        {
            if (!(StringValues ??= new Dictionary<string, string>()).ContainsKey(key)) StringValues.Add(key, PlayerPrefs.GetString(key));
            if (StringValues[key] != value)
            {
                StringValues[key] = value;
                PlayerPrefs.SetString(key, value);
            }
            return StringValues[key];
        }
        #endregion

        #region Enum
        private static Dictionary<System.Type, Dictionary<string/*ID*/, string/*enumValue*/>> EnumValues;
        public static T Enum<T>(string key) where T : System.Enum
        {
            try
            {
                if (!(EnumValues ??= new Dictionary<System.Type, Dictionary<string, string>>()).ContainsKey(typeof(T)))
                    EnumValues.Add(typeof(T), new Dictionary<string, string>());
                if (!EnumValues[typeof(T)].ContainsKey(typeof(T) + key))
                {
                    if (PlayerPrefs.GetString(typeof(T) + key) == "") PlayerPrefs.SetString(typeof(T) + key, System.Enum.GetNames(typeof(T))[0]);
                    EnumValues[typeof(T)].Add(typeof(T) + key, PlayerPrefs.GetString(typeof(T) + key));
                }
                return (T)System.Enum.Parse(typeof(T), EnumValues[typeof(T)][typeof(T) + key]);
            }
            catch (System.Exception)
            {

                return default(T);
            }
        }
        public static T Enum<T>(string key, T value) where T : System.Enum
        {
            try
            {
                if (!(EnumValues ??= new Dictionary<System.Type, Dictionary<string, string>>()).ContainsKey(typeof(T)))
                    EnumValues.Add(typeof(T), new Dictionary<string, string>());
                if (!EnumValues[typeof(T)].ContainsKey(typeof(T) + key))
                {
                    if (PlayerPrefs.GetString(typeof(T) + key) == "") PlayerPrefs.SetString(typeof(T) + key, System.Enum.GetNames(typeof(T))[0]);
                    EnumValues[typeof(T)].Add(typeof(T) + key, PlayerPrefs.GetString(typeof(T) + key));
                }

                if (EnumValues[typeof(T)][typeof(T) + key] != System.Enum.GetName(typeof(T), value))
                {
                    PlayerPrefs.SetString(typeof(T) + key, System.Enum.GetName(typeof(T), value));
                    EnumValues[typeof(T)][typeof(T) + key] = PlayerPrefs.GetString(typeof(T) + key);
                }
                return (T)System.Enum.Parse(typeof(T), EnumValues[typeof(T)][typeof(T) + key]);
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }
        #endregion

        #region Element
        private static Dictionary<System.Type, Dictionary<string/*ID*/, string/*enumValue*/>> StructValues;
        public static T Element<T>(string key)
        {
            try
            {
                if (!(StructValues ??= new Dictionary<System.Type, Dictionary<string, string>>()).ContainsKey(typeof(T)))
                    StructValues.Add(typeof(T), new Dictionary<string, string>());
                if (!StructValues[typeof(T)].ContainsKey(typeof(T) + key))
                {
                    if (PlayerPrefs.GetString(typeof(T) + key) == "") PlayerPrefs.SetString(typeof(T) + key, "");
                    StructValues[typeof(T)].Add(typeof(T) + key, PlayerPrefs.GetString(typeof(T) + key));
                }

                return JsonUtility.FromJson<T>(StructValues[typeof(T)][typeof(T) + key]);
            }
            catch (System.Exception sad)
            {
                Debug.Log(sad);
                return default;
            }

        }
        public static T Element<T>(string key, T value)
        {
            try
            {
                if (!(StructValues ??= new Dictionary<System.Type, Dictionary<string, string>>()).ContainsKey(typeof(T)))
                    StructValues.Add(typeof(T), new Dictionary<string, string>());
                if (!StructValues[typeof(T)].ContainsKey(typeof(T) + key))
                {
                    if (PlayerPrefs.GetString(typeof(T) + key) == "") PlayerPrefs.SetString(typeof(T) + key, "");
                    StructValues[typeof(T)].Add(typeof(T) + key, PlayerPrefs.GetString(typeof(T) + key));
                }
                PlayerPrefs.SetString(typeof(T) + key, JsonUtility.ToJson(value));
                StructValues[typeof(T)][typeof(T) + key] = PlayerPrefs.GetString(typeof(T) + key);
                return JsonUtility.FromJson<T>(StructValues[typeof(T)][typeof(T) + key]);
            }
            catch (System.Exception sad)
            {
                Debug.Log(sad);
                return default;
            }
        }
        #endregion
   
    }
}