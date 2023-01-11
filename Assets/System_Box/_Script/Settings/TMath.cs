using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SystemBox.Simpls
{

    public static class TMath
    {
        public static int ToInt(this float value) => Mathf.RoundToInt(value);
        public static float ToDeltaTime(this float value) => value * Time.deltaTime;
        public static float ToDeltaTime(this int value) => value * Time.deltaTime;


        public static Vector4 Vector4Random(Vector4 First, Vector4 Secon) => new Vector4(Random.Range(First.x, Secon.x), Random.Range(First.y, Secon.y), Random.Range(First.z, Secon.z), Random.Range(First.w, Secon.w));
        public static Vector3 Vector3Random(Vector3 First, Vector3 Secon) => new Vector3(Random.Range(First.x, Secon.x), Random.Range(First.y, Secon.y), Random.Range(First.z, Secon.z));
        public static Vector2 Vector2Random(Vector2 First, Vector2 Secon) => new Vector2(Random.Range(First.x, Secon.x), Random.Range(First.y, Secon.y));

        public static Vector3 Vector3Exsampl() => new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(-1000, 1000));

        public static Vector3 Vector3Exsampl(float Dis) => new Vector3(Random.Range(-Mathf.Abs(Dis), Mathf.Abs(Dis)), Random.Range(-Mathf.Abs(Dis), Mathf.Abs(Dis)), Random.Range(-Mathf.Abs(Dis), Mathf.Abs(Dis)));
        public static Vector3 Vector3Exsampl(float Dis, Vector3 Pivo) =>
            new Vector3(Random.Range(Pivo.x + -Mathf.Abs(Dis), Pivo.x + Mathf.Abs(Dis)),
                            Random.Range(Pivo.y + -Mathf.Abs(Dis), Pivo.y + Mathf.Abs(Dis)),
                                Random.Range(Pivo.z + -Mathf.Abs(Dis), Pivo.z + Mathf.Abs(Dis)));
        public static Vector3 Vector3Exsampl(float Dis_Max, float Dis_Min)
        {
            float x = Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            x = (Random.Range(0, 100) > 50) ? x : -x;
            float y = Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            y = (Random.Range(0, 100) > 50) ? y : -y;
            float z = Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            z = (Random.Range(0, 100) > 50) ? z : -z;
            float w = Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            w = (Random.Range(0, 100) > 50) ? w : -w;
            return new Vector3(x, y, z);
        }
        public static Vector4 Vector3Exsampl(float Dis_Max, float Dis_Min, Vector3 Pivo)
        {
            float x = Pivo.x + Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            x = (Random.Range(0, 100) > 50) ? x : -x;
            float y = Pivo.y + Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            y = (Random.Range(0, 100) > 50) ? y : -y;
            float z = Pivo.z + Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            z = (Random.Range(0, 100) > 50) ? z : -z;

            return new Vector3(x, y, z);
        }

        #region SphereRandom


        private static Vector3 _Vector3Sphere_Worker(Vector3 d) => new Vector3(Random.Range(-Mathf.Abs(d.x), Mathf.Abs(d.x)), Random.Range(-Mathf.Abs(d.y), Mathf.Abs(d.y)), Random.Range(-Mathf.Abs(d.z), Mathf.Abs(d.z)));
        public static Vector3 Vector3SphereExsampl(float Dis, Sides IgnorSides = Sides.none)
        {
            Vector3 vector_ = _Vector3Sphere_Worker(_SetVector3_Worker(Vector3.one * .1f, IgnorSides, 0));
            vector_ = Vector3.MoveTowards(vector_, Vector3.zero, -Mathf.Abs(Dis));
            return vector_;
        }
        public static Vector3 Vector3SphereExsampl(float MinDis, float AfterMinDis, Sides IgnorSides = Sides.none)
        {
            Vector3 vector_ = _Vector3Sphere_Worker(_SetVector3_Worker(Vector3.one * .1f, IgnorSides, 0));
            vector_ = Vector3.MoveTowards(vector_, Vector3.zero, -Random.Range(Mathf.Abs(MinDis), Mathf.Abs(MinDis) + Mathf.Abs(AfterMinDis)));
            return vector_;
        }
        public static Vector3 Vector3SphereExsampl(float Dis, Vector3 Pivot, Sides IgnorSides = Sides.none)
        {
            Vector3 vector_ = _Vector3Sphere_Worker(_SetVector3_Worker(Vector3.one * .1f, IgnorSides, 0));
            vector_ = Vector3.MoveTowards(vector_, Vector3.zero, -Mathf.Abs(Dis));
            vector_ = Pivot + vector_;
            return vector_;
        }
        public static Vector3 Vector3SphereExsampl(float MinDis, float AfterMinDis, Vector3 Pivot, Sides IgnorSides = Sides.none)
        {
            Vector3 vector_ = _Vector3Sphere_Worker(_SetVector3_Worker(Vector3.one * .1f, IgnorSides, 0));
            vector_ = Vector3.MoveTowards(vector_, Vector3.zero, -Random.Range(Mathf.Abs(MinDis), Mathf.Abs(MinDis) + Mathf.Abs(AfterMinDis)));
            vector_ = Pivot + vector_;
            return vector_;
        }

        public static Vector2 Vector2SphereExsampl(float Dis)
        {
            Vector3 vector_ = new Vector3(Random.Range(-Mathf.Abs(.1f), Mathf.Abs(.1f)), Random.Range(-Mathf.Abs(.1f), Mathf.Abs(.1f)), Random.Range(-Mathf.Abs(.1f), Mathf.Abs(.1f)));
            vector_ = Vector3.MoveTowards(vector_, Vector3.zero, -Mathf.Abs(Dis));
            return vector_;
        }
        public static Vector2 Vector2SphereExsampl(float MinDis, float AfterMinDis)
        {
            Vector3 vector_ = new Vector3(Random.Range(-Mathf.Abs(.1f), Mathf.Abs(.1f)), Random.Range(-Mathf.Abs(.1f), Mathf.Abs(.1f)), Random.Range(-Mathf.Abs(.1f), Mathf.Abs(.1f)));
            vector_ = Vector3.MoveTowards(vector_, Vector3.zero, -Random.Range(Mathf.Abs(MinDis), Mathf.Abs(MinDis) + Mathf.Abs(AfterMinDis)));
            return vector_;
        }
        public static Vector2 Vector2SphereExsampl(float Dis, Vector3 Pivot)
        {
            Vector3 vector_ = new Vector3(Random.Range(-Mathf.Abs(.1f), Mathf.Abs(.1f)), Random.Range(-Mathf.Abs(.1f), Mathf.Abs(.1f)), Random.Range(-Mathf.Abs(.1f), Mathf.Abs(.1f)));
            vector_ = Vector3.MoveTowards(vector_, Vector3.zero, -Mathf.Abs(Dis));
            vector_ = Pivot + vector_;
            return vector_;
        }
        public static Vector2 Vector2SphereExsampl(float MinDis, float AfterMinDis, Vector3 Pivot)
        {
            Vector3 vector_ = new Vector3(Random.Range(-Mathf.Abs(.1f), Mathf.Abs(.1f)), Random.Range(-Mathf.Abs(.1f), Mathf.Abs(.1f)), Random.Range(-Mathf.Abs(.1f), Mathf.Abs(.1f)));
            vector_ = Vector3.MoveTowards(vector_, Vector3.zero, -Random.Range(Mathf.Abs(MinDis), Mathf.Abs(MinDis) + Mathf.Abs(AfterMinDis)));
            vector_ = Pivot + vector_;
            return vector_;
        }

        #endregion
        public static Vector3 SetVector3(GameObject game, Sides IgnorSides = Sides.none, bool isLocal = false, float ValueForIgnoredSide = 0f)
        {
            if (game == null) { Debug.LogError("Object is null"); return Vector3.zero; }
            return _SetVector3_Worker((isLocal) ? game.transform.localPosition : game.transform.position, IgnorSides, ValueForIgnoredSide);
        }

        public static Vector3 SetVector3(Transform game, Sides IgnorSides = Sides.none, bool isLocal = false, float ValueForIgnoredSide = 0f)
        {
            if (game == null) { Debug.LogError("Object is null"); return Vector3.zero; }
            return _SetVector3_Worker((isLocal) ? game.transform.localPosition : game.transform.position, IgnorSides, ValueForIgnoredSide);
        }
        public static Vector3 SetVector3(Vector3 vector, Sides IgnorSides = Sides.none, float ValueForIgnoredSide = 0f)
        {
            return _SetVector3_Worker(vector, IgnorSides, ValueForIgnoredSide);
        }


        private static Vector3 _SetVector3_Worker(Vector3 game, Sides IgnorSides, float ValueForIgnoredSide)
        {
            if (IgnorSides == Sides.X) return new Vector3(ValueForIgnoredSide, game.y, game.z);
            if (IgnorSides == Sides.Y) return new Vector3(game.x, ValueForIgnoredSide, game.z);
            if (IgnorSides == Sides.Z) return new Vector3(game.x, game.y, ValueForIgnoredSide);

            if (IgnorSides == Sides.X_Y) return new Vector3(0, 0, game.z);
            if (IgnorSides == Sides.X_Z) return new Vector3(0, game.y, ValueForIgnoredSide);
            if (IgnorSides == Sides.Y_Z) return new Vector3(game.x, ValueForIgnoredSide, ValueForIgnoredSide);
            return new Vector3(game.x, game.y, game.z);
        }

        public static int RangeList(int Lenght) => Random.Range(0, Lenght);

        public enum Sides { none, X, Y, Z, X_Y, X_Z, Y_Z, }
        public static Vector4 Vector4Exsampl(float Dis) => new Vector4(Random.Range(-Mathf.Abs(Dis), Mathf.Abs(Dis)), Random.Range(-Mathf.Abs(Dis), Mathf.Abs(Dis)), Random.Range(-Mathf.Abs(Dis), Mathf.Abs(Dis)), Random.Range(-Mathf.Abs(Dis), Mathf.Abs(Dis)));

        public static Vector4 Vector4Exsampl(float Dis_Max, float Dis_Min)
        {
            float x = Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            x = (Random.Range(0, 100) > 50) ? x : -x;
            float y = Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            y = (Random.Range(0, 100) > 50) ? y : -y;
            float z = Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            z = (Random.Range(0, 100) > 50) ? z : -z;
            float w = Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            w = (Random.Range(0, 100) > 50) ? w : -w;
            return new Vector4(x, y, z, w);
        }
        public static Vector4 Vector4Exsampl(float Dis_Max, float Dis_Min, Vector4 Pivo)
        {
            float x = Pivo.x + Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            x = (Random.Range(0, 100) > 50) ? x : -x;
            float y = Pivo.y + Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            y = (Random.Range(0, 100) > 50) ? y : -y;
            float z = Pivo.z + Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            z = (Random.Range(0, 100) > 50) ? z : -z;
            float w = Pivo.w + Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            w = (Random.Range(0, 100) > 50) ? w : -w;
            return new Vector4(x, y, z, w);
        }



        public static Vector4 Vector4Exsampl(float Dis, Vector4 Pivo) =>
            new Vector4(Random.Range(Pivo.x + -Mathf.Abs(Dis), Pivo.x + Mathf.Abs(Dis)),
                            Random.Range(Pivo.y + -Mathf.Abs(Dis), Pivo.y + Mathf.Abs(Dis)),
                                Random.Range(Pivo.z + -Mathf.Abs(Dis), Pivo.z + Mathf.Abs(Dis)),
                                    Random.Range(Pivo.w + -Mathf.Abs(Dis), Pivo.w + Mathf.Abs(Dis)));

        public static Vector2 Vector2Exsampl(float Dis) => new Vector2(Random.Range(-Mathf.Abs(Dis), Mathf.Abs(Dis)), Random.Range(-Mathf.Abs(Dis), Mathf.Abs(Dis)));
        public static Vector2 Vector2Exsampl(float Dis_Max, float Dis_Min)
        {
            float x = Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            x = (Random.Range(0, 100) > 50) ? x : -x;
            float y = Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            y = (Random.Range(0, 100) > 50) ? y : -y;
            return new Vector2(x, y);
        }

        public static Vector2 Vector2Exsampl(float Dis, Vector2 Pivo) =>
            new Vector2(Random.Range(Pivo.x + -Mathf.Abs(Dis), Pivo.x + Mathf.Abs(Dis)),
                            Random.Range(Pivo.y + -Mathf.Abs(Dis), Pivo.y + Mathf.Abs(Dis)));
        
        public static Vector4 Vector2Exsampl(float Dis_Max, float Dis_Min, Vector2 Pivo)
        {
            float x = Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            x = (Random.Range(0, 100) > 50) ? x : -x;
            float y = Random.Range(Mathf.Abs(Dis_Min), Mathf.Abs(Dis_Max));
            y = (Random.Range(0, 100) > 50) ? y : -y;
            return new Vector2(x, y);
        }

        #region Percent 


        /// <summary>
        /// Ikta flotnim ortasida turgan objectni hisoplidi
        /// </summary>
        /// <param name="MinTime"> MaxTime dan kichkina son bo'lishi kere </param>
        /// <param name="MaxTime"> MinTime dan ktta son bo'lishi kere </param>
        /// <param name="OnTime"> Kereli time </param>
        /// <param name="give_0_100"> true for 0 - 100 | false for 0 - 1 </param>
        /// <returns>Percent</returns>
        public static float GetPercent(float MinTime, float MaxTime, float OnTime, bool give_0_100 = true)
        {
            if (give_0_100) return ((OnTime + Mathf.Abs(MinTime)) / Distance(MinTime, MaxTime)) * 100f;
            else return (OnTime + Mathf.Abs(MinTime)) / Distance(MinTime, MaxTime);
        }

        /// <summary>
        /// 0 dan  MaxTime ni rasida turgan ojectni hisoplidi
        /// </summary>
        /// <param name="MaxTime"> MinTime dan ktta son bo'lishi kere </param>
        /// <param name="OnTime"> Kereli time </param>
        /// <param name="give_0_100"> true for 0 - 100 | false for 0 - 1 </param>
        /// <returns>Percent</returns>

        public static float GetPercent(float MaxTime, float OnTime, bool give_0_100 = true)
        {
            if (give_0_100) return (OnTime / MaxTime) * 100f;
            else return OnTime / MaxTime;
        }






        #endregion


        #region Percent_curve
        public static float Get_CurveTime_Percent(float onPercentTime, AnimationCurve curve, bool give_0_100 = true)
        {
            float ofset = Distance(curve.keys[0].time, curve.keys[curve.keys.Length - 1].time);
            if (give_0_100) return curve.Evaluate(curve.keys[0].time + ofset * (onPercentTime / 100));
            else return curve.Evaluate(curve.keys[0].time + ofset * onPercentTime);
        }
        public static float Get_Curve_Lenght(AnimationCurve curve) => Distance(curve.keys[0].time, curve.keys[curve.keys.Length - 1].time);

        public static List<float> GetBitwinTimes(int onPercentTime, AnimationCurve curve, bool Bitwin = true)
        {
            List<float> ss = new List<float>();
            for (int i = 0; i < ((Bitwin) ? onPercentTime + 1 : onPercentTime); i++)
                ss.Add(Get_CurveTime_Percent((100f / ((Bitwin) ? onPercentTime + 1 : onPercentTime)) * i, curve));
            if (Bitwin) ss.RemoveAt(0);
            return ss;
        }



        #endregion

        #region Time



        public static int ReadTime(string NS)
        {
            try
            {
                bool AALL = true;
                if (NS[0] == '-'){ NS=  NS.Remove(0,1); AALL = false; }
                if (NS.Length == 5 && (NS[2] == ':' || NS[2] == '.'))
                    if (AALL) return ((int.Parse(NS[0].ToString() + NS[1].ToString())) * 60) + int.Parse(NS[3].ToString() + NS[4].ToString()); 
                    else return -((int.Parse(NS[0].ToString() + NS[1].ToString())) * 60) + int.Parse(NS[3].ToString() + NS[4].ToString());
                if (NS.Length == 8 && ((NS[2] == ':' || NS[2] == '.') && (NS[5] == ':' || NS[5] == '.')))
                    if (AALL) return (((((int.Parse(NS[0].ToString() + NS[1].ToString()))) * 60) + (int.Parse(NS[3].ToString() + NS[4].ToString()))) * 60) + int.Parse(NS[6].ToString() + NS[7].ToString());
                    else return -(((((int.Parse(NS[0].ToString() + NS[1].ToString()))) * 60) + (int.Parse(NS[3].ToString() + NS[4].ToString()))) * 60) + int.Parse(NS[6].ToString() + NS[7].ToString());
                if (NS.Length == 11 && ((NS[2] == ':' || NS[2] == '.') && (NS[5] == ':' || NS[5] == '.') && (NS[8] == ':' || NS[8] == '.')))
                    if (AALL) return  (((((((int.Parse(NS[0].ToString() + NS[1].ToString()))) * 24) + (int.Parse(NS[3].ToString() + NS[4].ToString()))) * 60) + int.Parse(NS[6].ToString() + NS[7].ToString())) * 60) + int.Parse(NS[9].ToString() + NS[10].ToString());
                    else return -(((((((int.Parse(NS[0].ToString() + NS[1].ToString()))) * 24) + (int.Parse(NS[3].ToString() + NS[4].ToString()))) * 60) + int.Parse(NS[6].ToString() + NS[7].ToString())) * 60) + int.Parse(NS[9].ToString() + NS[10].ToString());
            }
            catch (System.Exception sda) { Debug.Log(sda.Message); }
            return 0;
        }
        public static string ShowOnClock(int Time, bool ShowHour = false, bool ShowDay = false)
        {
            try
            {
                string IssMenn = "";
                if (Time < 0) { Time = -Time; IssMenn = "-"; }
                string TimeString = "";
                int Day = 0;
                int Hour = 0;
                int Minut = 0;
                while (true)
                {
                    if (Hour - 23 > 0)
                    {
                        Day++;
                        Hour -= 23;
                    }
                    else if (Minut - 59 > 0)
                    {
                        Hour++;
                        Minut -= 60;
                    }
                    else if (Time - 59 > 0)
                    {
                        Time -= 60;
                        Minut++;
                    }
                    else
                    {
                        TimeString =
                            ((ShowDay) ? ((Day > 9) ? "" : "0") + Day + ":" : "") +
                            ((ShowHour) ? ((Hour > 9) ? "" : "0") + Hour + ":" : "") +
                            ((Minut > 9) ? "" : "0") + Minut + ":" +
                            ((Time > 9) ? "" : "0") + Time;
                        break;
                    }
                }
                return IssMenn+TimeString;
            }
            catch (System.Exception das)
            {
                Debug.Log(das.Message);
            }
            return "00:00";

        }
        #endregion


        public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta)
        {
            Vector3 a = target - current;
            float magnitude = a.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == 0f) return target;
            return current + a / magnitude * maxDistanceDelta;
        }
        public static float MoveTowards(float current, float target, float maxDelta)
        {
            if (Mathf.Abs(target - current) <= maxDelta) return target;
            return current + Mathf.Sign(target - current) * maxDelta;
        }

        public static bool CheckIsTwoElementIntersection(Transform E1, Transform E2)
        {
            Vector3 MovePoint = MoveTowards(E1.position, E2.position,
                Distance(
                    new Vector3(E1.position.x + (E1.lossyScale.x / 2), E1.position.y + (E1.lossyScale.y / 2), E1.position.z + (E1.lossyScale.z / 2)), E1.position));
            Vector3 MaxXYZ = new Vector3(E2.position.x + (E2.lossyScale.x / 2), E2.position.y + (E2.lossyScale.y / 2), E2.position.z + (E2.lossyScale.z / 2));
            Vector3 MinXYZ = new Vector3(E2.position.x - (E2.lossyScale.x / 2), E2.position.y - (E2.lossyScale.y / 2), E2.position.z - (E2.lossyScale.z / 2));

            MovePoint.x = (MovePoint.x > E1.position.x + (E1.lossyScale.x / 2)) ? E1.position.x + (E1.lossyScale.x / 2) :
                (MovePoint.x < E1.position.x - (E1.lossyScale.x / 2)) ? E1.position.x - (E1.lossyScale.x / 2) : MovePoint.x;
            MovePoint.y = (MovePoint.y > E1.position.y + (E1.lossyScale.y / 2)) ? E1.position.y + (E1.lossyScale.y / 2) :
                (MovePoint.y < E1.position.y - (E1.lossyScale.y / 2)) ? E1.position.y - (E1.lossyScale.y / 2) : MovePoint.y;
            MovePoint.z = (MovePoint.z > E1.position.z + (E1.lossyScale.z / 2)) ? E1.position.z + (E1.lossyScale.z / 2) :
                (MovePoint.z < E1.position.z - (E1.lossyScale.z / 2)) ? E1.position.z - (E1.lossyScale.z / 2) : MovePoint.z;

            return MovePoint.x < MaxXYZ.x && MovePoint.y < MaxXYZ.y && MovePoint.z < MaxXYZ.z && MovePoint.x > MinXYZ.x && MovePoint.y > MinXYZ.y && MovePoint.z > MinXYZ.z;

        }
        public static float Distance(Vector3 value1, Vector3 value2)
        {
            float v1 = value1.x - value2.x, v2 = value1.y - value2.y, v3 = value1.z - value2.z;
            return (float)System.Math.Sqrt((v1 * v1) + (v2 * v2) + (v3 * v3));
        }
        public static float Distance(float V1, float V2) => Vector2.Distance(new Vector2(0f, V1), new Vector2(0f, V2));
        public static float Distance(Vector2 value1, Vector2 value2) => Vector2.Distance(value1, value2);


        public static bool lineLineIntersection(Vector2 A_Start, Vector2 A_End, Vector2 B_Start, Vector2 B_End, out Vector2 intersection)
        {
            intersection = Vector2.zero;
            // Line AB represented as a1x + b1y = c1 
            double a1 = A_End.y - A_Start.y;
            double b1 = A_Start.x - A_End.x;
            double c1 = a1 * (A_Start.x) + b1 * (A_Start.y);

            // Line CD represented as a2x + b2y = c2 
            double a2 = B_End.y - B_Start.y;
            double b2 = B_Start.x - B_End.x;
            double c2 = a2 * (B_Start.x) + b2 * (B_Start.y);

            double determinant = a1 * b2 - a2 * b1;

            if (determinant == 0) return false;
            double x = (b2 * c1 - b1 * c2) / determinant;
            double y = (a1 * c2 - a2 * c1) / determinant;
            intersection = new Vector2((float)x, (float)y);
            if (
                siIn(
                new Vector2((A_Start.x < A_End.x) ? A_Start.x : A_End.x, (A_Start.y < A_End.y) ? A_Start.y : A_End.y),
                new Vector2((A_Start.x > A_End.x) ? A_Start.x : A_End.x, (A_Start.y > A_End.y) ? A_Start.y : A_End.y), intersection) &&
                siIn(new Vector2((B_Start.x < B_End.x) ? B_Start.x : B_End.x, (B_Start.y < B_End.y) ? B_Start.y : B_End.y),
                new Vector2((B_Start.x > B_End.x) ? B_Start.x : B_End.x, (B_Start.y > B_End.y) ? B_Start.y : B_End.y), intersection))
            {
                return true;
            }
            intersection = Vector2.zero;
            return false;

            bool siIn(Vector2 s, Vector2 e, Vector2 p) => p.x > s.x && p.x < e.x && p.y > s.y && p.y < e.y;

        }




    }



}
