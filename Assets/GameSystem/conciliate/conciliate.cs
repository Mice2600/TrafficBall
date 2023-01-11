using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using SystemBox.Simpls;
using UnityEngine;

public static class conciliate
{
    public static bool CanMarge(List<Content> contents) 
    {
        if (contents.Count < 2) return false;
        for (int i = 0; i < contents.Count; i++)
            if (contents[0] != contents[i]) return false;
        return true;
    }
    public static bool TrayMarge(List<Content> contents, out Content Resultat) 
    {
        Resultat = new Content { Number = 0 };
        if (!CanMarge(contents))return false;
        Resultat = new Content { Number = contents[0] };
        for (int i = 0; i < contents.Count - 1; i++)
            Resultat *= 2;
        return true;
    }
    public static int NumberToAlgaritim(int content)
    {
        int AlgaritimNumber = 0;
        while (true) 
        {
            if (content <= 0 || content % 2 > 0) break;
            content = content / 2;
            AlgaritimNumber++;
        }
        return AlgaritimNumber;
    }
    public static int AlgaritimToNumber(int Algaritm) 
    {
        int Number = 1;
        for (int i = 0; i < Algaritm; i++)Number *= 2; 
        return Number;
    }
    private static Vector3 Bezier(Vector3[] points, float lerp)
    {
        Vector3 point = Vector3.zero;
        if (points == null) return point;

        lerp = Mathf.Clamp01(lerp);
        float inverseLerp = 1 - lerp;

        for (int i = 0; i < points.Length; i++)
        {
            //this is were the function can get expensive
            float coef = BinomialCoefficient(points.Length, i);
            float power = Mathf.Pow(lerp, i);
            float inversePower = Mathf.Pow(inverseLerp, points.Length - i - 1);


            if (power < float.Epsilon) power = 0;
            if (inversePower < float.Epsilon) inversePower = 0;

            Vector3 weightedPosition = points[i] * coef * power * inversePower;

            point += weightedPosition;
        }

        return point;
        int BinomialCoefficient(int size, int choose)
        {
            int result = 1;
            // use symmetry to reduce calculations
            if (choose > size - 1 - choose)
            {
                choose = size - 1 - choose;
            }

            for (int i = 1; i <= choose; i++, size--)
            {
                if (result / i > System.Int16.MaxValue)
                    return 0; //result overflowed, so we lost the value

                result = result / i * (size - 1) + result % i; // divide before multiply to better avoid reaching overflow
            }

            return result;
        }
    }
}