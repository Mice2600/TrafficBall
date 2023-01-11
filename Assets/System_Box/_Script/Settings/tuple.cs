using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;
using UnityEngine;
namespace SystemBox
{
    [BoxGroup(CenterLabel = false)]
    [System.Serializable]
    public class Tuple<v1, v2>
    {
       // [LabelText("$Item1Laby")]
        public v1 Item1;
        private string Item1Laby() => typeof(v1) == typeof(int) ? "Int" : typeof(v1).Name;
       // [LabelText("$Item2Laby")]
        public v2 Item2;

        private string Item2Laby() =>  typeof(v2) == typeof(int) ? "Int" : typeof(v2).Name;
        public Tuple()
        {

        }
        public Tuple(v1 value = default(v1), v2 value2 = default(v2))
        {
            this.Item1 = value;
            this.Item2 = value2;
        }
    }
    [BoxGroup(CenterLabel = false)]
    [System.Serializable]
    public class Tuple<v1, v2, v3>
    {
        [LabelText("$Item1Laby")]
        public v1 Item1;
        
        [LabelText("$Item2Laby")]
        public v2 Item2;
        
        [LabelText("$Item3Laby")]
        public v3 Item3;
        private string Item1Laby() => typeof(v1) == typeof(int) ? "Int" : typeof(v1).Name;
        private string Item2Laby() => typeof(v2) == typeof(int) ? "Int" : typeof(v2).Name;
        private string Item3Laby() => typeof(v3) == typeof(int) ? "Int" : typeof(v3).Name;
        public Tuple()
        {

        }
        public Tuple(v1 value = default(v1), v2 value2 = default(v2), v3 value3 = default(v3))
        {
            this.Item1 = value;
            this.Item2 = value2;
            this.Item3 = value3;
        }
    }
    [BoxGroup(CenterLabel = false)]
    [System.Serializable]
    public class Tuple<v1, v2, v3, v4>
    {

        [LabelText("$Item1Laby")]
        public v1 Item1;

        [LabelText("$Item2Laby")]
        public v2 Item2;

        [LabelText("$Item3Laby")]
        public v3 Item3;
        [LabelText("$Item4Laby")]
        public v4 Item4;
        private string Item1Laby() => typeof(v1) == typeof(int) ? "Int" : typeof(v1).Name;
        private string Item2Laby() => typeof(v2) == typeof(int) ? "Int" : typeof(v2).Name;
        private string Item3Laby() => typeof(v3) == typeof(int) ? "Int" : typeof(v3).Name;
        private string Item4Laby() => typeof(v4) == typeof(int) ? "Int" : typeof(v4).Name;

        public Tuple()
        {

        }
        public Tuple(v1 value = default(v1), v2 value2 = default(v2), v3 value3 = default(v3), v4 value4 = default(v4))
        {
            this.Item1 = value;
            this.Item2 = value2;
            this.Item3 = value3;
            this.Item4 = value4;
        }
    }
    [BoxGroup(CenterLabel = false)]
    [System.Serializable]
    public class Tuple<v1, v2, v3, v4, v5>
    {
        [LabelText("$Item1Laby")]
        public v1 Item1;

        [LabelText("$Item2Laby")]
        public v2 Item2;

        [LabelText("$Item3Laby")]
        public v3 Item3;
        [LabelText("$Item4Laby")]
        public v4 Item4;
        [LabelText("$Item5Laby")]
        public v5 Item5;
        private string Item1Laby() => typeof(v1) == typeof(int) ? "Int" : typeof(v1).Name;
        private string Item2Laby() => typeof(v2) == typeof(int) ? "Int" : typeof(v2).Name;
        private string Item3Laby() => typeof(v3) == typeof(int) ? "Int" : typeof(v3).Name;
        private string Item4Laby() => typeof(v4) == typeof(int) ? "Int" : typeof(v4).Name;
        private string Item5Laby() => typeof(v5) == typeof(int) ? "Int" : typeof(v5).Name;
        public Tuple()
        {

        }
        public Tuple(v1 value = default(v1), v2 value2 = default(v2), v3 value3 = default(v3), v4 value4 = default(v4), v5 value5 = default(v5))
        {
            this.Item1 = value;
            this.Item2 = value2;
            this.Item3 = value3;
            this.Item4 = value4;
            this.Item5 = value5;
        }
    }
    [BoxGroup(CenterLabel = false)]
    [System.Serializable]
    public class Tuple<v1, v2, v3, v4, v5, v6>
    {
        [LabelText("$Item1Laby")]
        public v1 Item1;
        [LabelText("$Item2Laby")]
        public v2 Item2;
        [LabelText("$Item3Laby")]
        public v3 Item3;
        [LabelText("$Item4Laby")]
        public v4 Item4;
        [LabelText("$Item5Laby")]
        public v5 Item5;
        [LabelText("$Item6Laby")]
        public v6 Item6;
        private string Item1Laby() => typeof(v1) == typeof(int) ? "Int" : typeof(v1).Name;
        private string Item2Laby() => typeof(v2) == typeof(int) ? "Int" : typeof(v2).Name;
        private string Item3Laby() => typeof(v3) == typeof(int) ? "Int" : typeof(v3).Name;
        private string Item4Laby() => typeof(v4) == typeof(int) ? "Int" : typeof(v4).Name;
        private string Item5Laby() => typeof(v5) == typeof(int) ? "Int" : typeof(v5).Name;
        private string Item6Laby() => typeof(v6) == typeof(int) ? "Int" : typeof(v6).Name;
        
        public Tuple()
        {

        }
        public Tuple(v1 value = default(v1), v2 value2 = default(v2), v3 value3 = default(v3), v4 value4 = default(v4), v5 value5 = default(v5), v6 value6 = default(v6))
        {
            this.Item1 = value;
            this.Item2 = value2;
            this.Item3 = value3;
            this.Item4 = value4;
            this.Item5 = value5;
            this.Item6 = value6;
        }
    }
    [BoxGroup(CenterLabel = false)]
    [System.Serializable]
    public class Tuple<v1, v2, v3, v4, v5, v6,v7>
    {
        [LabelText("$Item1Laby")]
        public v1 Item1;
        [LabelText("$Item2Laby")]
        public v2 Item2;
        [LabelText("$Item3Laby")]
        public v3 Item3;
        [LabelText("$Item4Laby")]
        public v4 Item4;
        [LabelText("$Item5Laby")]
        public v5 Item5;
        [LabelText("$Item6Laby")]
        public v6 Item6;
        [LabelText("$Item7Laby")]
        public v7 Item7;
        private string Item1Laby() => typeof(v1) == typeof(int) ? "Int" : typeof(v1).Name;
        private string Item2Laby() => typeof(v2) == typeof(int) ? "Int" : typeof(v2).Name;
        private string Item3Laby() => typeof(v3) == typeof(int) ? "Int" : typeof(v3).Name;
        private string Item4Laby() => typeof(v4) == typeof(int) ? "Int" : typeof(v4).Name;
        private string Item5Laby() => typeof(v5) == typeof(int) ? "Int" : typeof(v5).Name;
        private string Item6Laby() => typeof(v6) == typeof(int) ? "Int" : typeof(v6).Name;
        private string Item7Laby() => typeof(v7) == typeof(int) ? "Int" : typeof(v7).Name;

        public Tuple()
        {

        }
        public Tuple(v1 value = default(v1), v2 value2 = default(v2), v3 value3 = default(v3), v4 value4 = default(v4), v5 value5 = default(v5), v6 value6 = default(v6), v7 value7 = default(v7))
        {
            this.Item1 = value;
            this.Item2 = value2;
            this.Item3 = value3;
            this.Item4 = value4;
            this.Item5 = value5;
            this.Item6 = value6;
            this.Item7 = value7;
        }
    }
    [BoxGroup(CenterLabel = false)]
    [System.Serializable]
    public class Tuple<v1, v2, v3, v4, v5, v6, v7,v8>
    {
        [LabelText("$Item1Laby")]
        public v1 Item1;
        [LabelText("$Item2Laby")]
        public v2 Item2;
        [LabelText("$Item3Laby")]
        public v3 Item3;
        [LabelText("$Item4Laby")]
        public v4 Item4;
        [LabelText("$Item5Laby")]
        public v5 Item5;
        [LabelText("$Item6Laby")]
        public v6 Item6;
        [LabelText("$Item7Laby")]
        public v7 Item7;
        [LabelText("$Item8Laby")]
        public v8 Item8;
        private string Item1Laby() => typeof(v1) == typeof(int) ? "Int" : typeof(v1).Name;
        private string Item2Laby() => typeof(v2) == typeof(int) ? "Int" : typeof(v2).Name;
        private string Item3Laby() => typeof(v3) == typeof(int) ? "Int" : typeof(v3).Name;
        private string Item4Laby() => typeof(v4) == typeof(int) ? "Int" : typeof(v4).Name;
        private string Item5Laby() => typeof(v5) == typeof(int) ? "Int" : typeof(v5).Name;
        private string Item6Laby() => typeof(v6) == typeof(int) ? "Int" : typeof(v6).Name;
        private string Item7Laby() => typeof(v7) == typeof(int) ? "Int" : typeof(v7).Name;
        private string Item8Laby() => typeof(v8) == typeof(int) ? "Int" : typeof(v8).Name;

        public Tuple()
        {

        }
        public Tuple(v1 value = default(v1), v2 value2 = default(v2), v3 value3 = default(v3), v4 value4 = default(v4), v5 value5 = default(v5), v6 value6 = default(v6), v7 value7 = default(v7), v8 value8 = default(v8))
        {
            this.Item1 = value;
            this.Item2 = value2;
            this.Item3 = value3;
            this.Item4 = value4;
            this.Item5 = value5;
            this.Item6 = value6;
            this.Item7 = value7;
            this.Item8 = value8;
        }
    }
    [BoxGroup(CenterLabel = false)]
    [System.Serializable]
    public class Tuple<v1, v2, v3, v4, v5, v6, v7, v8,v9>
    {
        [LabelText("$Item1Laby")]
        public v1 Item1;
        [LabelText("$Item2Laby")]
        public v2 Item2;
        [LabelText("$Item3Laby")]
        public v3 Item3;
        [LabelText("$Item4Laby")]
        public v4 Item4;
        [LabelText("$Item5Laby")]
        public v5 Item5;
        [LabelText("$Item6Laby")]
        public v6 Item6;
        [LabelText("$Item7Laby")]
        public v7 Item7;
        [LabelText("$Item8Laby")]
        public v8 Item8;
        [LabelText("$Item9Laby")]
        public v9 Item9;
        private string Item1Laby() => typeof(v1) == typeof(int) ? "Int" : typeof(v1).Name;
        private string Item2Laby() => typeof(v2) == typeof(int) ? "Int" : typeof(v2).Name;
        private string Item3Laby() => typeof(v3) == typeof(int) ? "Int" : typeof(v3).Name;
        private string Item4Laby() => typeof(v4) == typeof(int) ? "Int" : typeof(v4).Name;
        private string Item5Laby() => typeof(v5) == typeof(int) ? "Int" : typeof(v5).Name;
        private string Item6Laby() => typeof(v6) == typeof(int) ? "Int" : typeof(v6).Name;
        private string Item7Laby() => typeof(v7) == typeof(int) ? "Int" : typeof(v7).Name;
        private string Item8Laby() => typeof(v8) == typeof(int) ? "Int" : typeof(v8).Name;
        private string Item9Laby() => typeof(v9) == typeof(int) ? "Int" : typeof(v9).Name;

        public Tuple()
        {

        }
        public Tuple(v1 value = default(v1), v2 value2 = default(v2), v3 value3 = default(v3), v4 value4 = default(v4), v5 value5 = default(v5), v6 value6 = default(v6), v7 value7 = default(v7), v8 value8 = default(v8), v9 value9 = default(v9))
        {
            this.Item1 = value;
            this.Item2 = value2;
            this.Item3 = value3;
            this.Item4 = value4;
            this.Item5 = value5;
            this.Item6 = value6;
            this.Item7 = value7;
            this.Item8 = value8;
            this.Item9 = value9;
        }
    }
    [BoxGroup(CenterLabel = false)]
    [System.Serializable]
    public class Tuple<v1, v2, v3, v4, v5, v6, v7, v8,v9,v10>
    {
        [LabelText("$Item1Laby")]
        public v1 Item1;
        [LabelText("$Item2Laby")]
        public v2 Item2;
        [LabelText("$Item3Laby")]
        public v3 Item3;
        [LabelText("$Item4Laby")]
        public v4 Item4;
        [LabelText("$Item5Laby")]
        public v5 Item5;
        [LabelText("$Item6Laby")]
        public v6 Item6;
        [LabelText("$Item7Laby")]
        public v7 Item7;
        [LabelText("$Item8Laby")]
        public v8 Item8;
        [LabelText("$Item9Laby")]
        public v9 Item9;
        [LabelText("$Item10Laby")]
        public v10 Item10;
        private string Item1Laby() => typeof(v1) == typeof(int) ? "Int" : typeof(v1).Name;
        private string Item2Laby() => typeof(v2) == typeof(int) ? "Int" : typeof(v2).Name;
        private string Item3Laby() => typeof(v3) == typeof(int) ? "Int" : typeof(v3).Name;
        private string Item4Laby() => typeof(v4) == typeof(int) ? "Int" : typeof(v4).Name;
        private string Item5Laby() => typeof(v5) == typeof(int) ? "Int" : typeof(v5).Name;
        private string Item6Laby() => typeof(v6) == typeof(int) ? "Int" : typeof(v6).Name;
        private string Item7Laby() => typeof(v7) == typeof(int) ? "Int" : typeof(v7).Name;
        private string Item8Laby() => typeof(v8) == typeof(int) ? "Int" : typeof(v8).Name;
        private string Item9Laby() => typeof(v9) == typeof(int) ? "Int" : typeof(v9).Name;
        private string Item10Laby() => typeof(v10) == typeof(int) ? "Int" : typeof(v10).Name;

        public Tuple()
        {

        }
        public Tuple(v1 value = default(v1), v2 value2 = default(v2), v3 value3 = default(v3), v4 value4 = default(v4), v5 value5 = default(v5), v6 value6 = default(v6), v7 value7 = default(v7), v8 value8 = default(v8), v9 value9 = default(v9), v10 value10 = default(v10))
        {
            this.Item1 = value;
            this.Item2 = value2;
            this.Item3 = value3;
            this.Item4 = value4;
            this.Item5 = value5;
            this.Item6 = value6;
            this.Item7 = value7;
            this.Item8 = value8;
            this.Item9 = value9;
            this.Item10 = value10;
        }
    }
}
