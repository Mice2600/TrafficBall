using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemBox.Simpls;
using System;
using System.ComponentModel;

namespace SystemBox
{
    
    [Serializable]
    //[Clock]
    public class Clock 
    {
        public Clock(bool Play = false)
        {
            OnTime = 0;
            isPlaying = Play;
        }
        public Clock(float NTIme, bool Play = false)
        {
            OnTime = NTIme;
            isPlaying = Play;
        }
        public Clock(int NTIme, bool Play = false)
        {
            OnTime = NTIme;
            isPlaying = Play;
        }
        public Clock(string NTImess, bool Play = false)
        {
            try
            {
                OnTime = TMath.ReadTime(NTImess);
                isPlaying = Play;
            }
            catch (System.Exception asads)
            {
                OnTime = 0;
                isPlaying = Play;
                Debug.LogError(asads.Message);
            }

        }
        public void SetSpeed(float Speed) => this.Speed = Speed;
        public Clock(float OnTime, float Speed, bool isPlaying, float MoveFloat_oldFrem, bool MoveFloat_isoldFrem_Loded) 
        {
            this.MoveFloat_isoldFrem_Loded = MoveFloat_isoldFrem_Loded;
            this.MoveFloat_oldFrem = MoveFloat_oldFrem;
            this.isPlaying = isPlaying;
            this.Speed = Speed;
            this.OnTime = OnTime;
        }

        #region MyRegion

        public bool MoveFloat_isoldFrem_Loded;
        public float MoveFloat_oldFrem;
        public float OnTime
        {
            get
            {
                Worker();
                return _OnTime;
            }
            set
            {
                Worker();
                _OnTime = value;
            }
        } ///--------------
        private float _OnTime;
        public float Speed = 1;
        public bool isPlaying;

        private void Worker()
        {
            try
            {
                if (!isPlaying) MoveFloat_oldFrem = Time.time;
                if (!MoveFloat_isoldFrem_Loded) { MoveFloat_isoldFrem_Loded = true; MoveFloat_oldFrem = Time.time; }
                float SSTime = (Speed) * (Time.time - MoveFloat_oldFrem);
                MoveFloat_oldFrem = Time.time;
                _OnTime += SSTime;
            }
            catch (System.Exception) { }
        }

        #endregion
        public string ShowOnClock(bool ShowHour = false, bool ShowDay = false) => TMath.ShowOnClock((int)OnTime, ShowHour, ShowDay);
        public void Play(){isPlaying = true;}
        public void PlayNew() => PlayNew(0);
        public void PlayNew(string Time) => PlayNew(TMath.ReadTime(Time));
        public void PlayNew(int Time) => PlayNew((float)Time);
        public void PlayNew(float Time){isPlaying = true; OnTime = Time; }
        public void Stop(){isPlaying = false;}
        public void Reset()
        {
            OnTime = 0;
            isPlaying = false;
        }
        
        public override string ToString() => ShowOnClock();
        
        public static implicit operator float(Clock v) => (float)v.OnTime;
        public static implicit operator int(Clock v) => (int)v.OnTime;
        public static implicit operator string(Clock v) => v.ShowOnClock();
        public static implicit operator Clock(float v) => new Clock(v);
        public static implicit operator Clock(int v) => new Clock(v);
        public static implicit operator Clock(string v) => new Clock(TMath.ReadTime(v));
        public static Clock operator +(Clock left, float right)
        {
            left.OnTime += right;
            return left;
        }
        public static Clock operator +(Clock left, int right)
        {
            left.OnTime += right;
            return left;
        }
        public static Clock operator +(Clock left, string right)
        {
            left.OnTime += TMath.ReadTime(right);
            return left;
        }
        public static Clock operator +(Clock left, Clock right)
        {
            left.OnTime += right.OnTime;
            return left;
        }
        public static Clock operator -(Clock left, float right)
        {
            left.OnTime -= right;
            return left;
        }
        public static Clock operator -(Clock left, int right)
        {
            left.OnTime -= right;
            return left;
        }
        public static Clock operator -(Clock left, string right)
        {
            left.OnTime -= TMath.ReadTime(right);
            return left;
        }
        public static Clock operator -(Clock left, Clock right)
        {
            left.OnTime -= right.OnTime;
            return left;
        }
        public static Clock operator /(Clock left, float right)
        {
            left.OnTime /= right;
            return left;
        }
        public static Clock operator /(Clock left, int right)
        {
            left.OnTime /= right;
            return left;
        }
        public static Clock operator /(Clock left, string right)
        {
            left.OnTime /= TMath.ReadTime(right);
            return left;
        }
        public static Clock operator /(Clock left, Clock right)
        {
            left.OnTime /= right.OnTime;
            return left;
        }
        public static Clock operator *(Clock left, float right)
        {
            left.OnTime *= right;
            return left;
        }
        public static Clock operator *(Clock left, int right)
        {
            left.OnTime *= right;
            return left;
        }
        public static Clock operator *(Clock left, string right)
        {
            left.OnTime *= TMath.ReadTime(right);
            return left;
        }
        public static Clock operator *(Clock left, Clock right)
        {
            left.OnTime *= right.OnTime;
            return left;
        }

        

        #region == ><=
        public static bool operator ==(Clock L, Clock R) => L.OnTime == R.OnTime;
        public static bool operator !=(Clock L, Clock R) => L.OnTime != R.OnTime;

   

        public static bool operator ==(Clock L, int R) => L.OnTime == R;
        public static bool operator !=(Clock L, int R) => L.OnTime != R;
        public static bool operator ==(int L, Clock R) => R.OnTime == L;
        public static bool operator !=(int L, Clock R) => R.OnTime != L;

        public static bool operator ==(Clock L, float R) => L.OnTime == R;
        public static bool operator !=(Clock L, float R) => L.OnTime != R;
        public static bool operator ==(float L, Clock R) => R.OnTime == L;
        public static bool operator !=(float L, Clock R) => R.OnTime != L;

        public static bool operator >(Clock L, Clock R) => L.OnTime > R.OnTime;
        public static bool operator <(Clock L, Clock R) => L.OnTime < R.OnTime;

        public static bool operator >=(Clock L, Clock R) => L.OnTime >= R.OnTime;
        public static bool operator <=(Clock L, Clock R) => L.OnTime <= R.OnTime;


        public static bool operator >(Clock L, string R) => L.OnTime> TMath.ReadTime(R);
        public static bool operator <(Clock L, string R) => L.OnTime< TMath.ReadTime(R);
        public static bool operator >=(Clock L, string R) => L.OnTime >= TMath.ReadTime(R);
        public static bool operator <=(Clock L, string R) => L.OnTime <= TMath.ReadTime(R);

        public static bool operator >(string L, Clock R) => R.OnTime >TMath.ReadTime(L);
        public static bool operator <(string L, Clock R) => R.OnTime < TMath.ReadTime(L);
        public static bool operator >=(string L, Clock R) => R.OnTime >= TMath.ReadTime(L);
        public static bool operator <=(string L, Clock R) => R.OnTime <= TMath.ReadTime(L);

        public static bool operator >(Clock L, int R) => L.OnTime > R;
        public static bool operator <(Clock L, int R) => L.OnTime < R;
        public static bool operator >=(Clock L, int R) => L.OnTime >= R;
        public static bool operator <=(Clock L, int R) => L.OnTime <= R;

        public static bool operator >(int L, Clock R) => R.OnTime > L;
        public static bool operator <(int L, Clock R) => R.OnTime < L;
        public static bool operator >=(int L, Clock R) => R.OnTime >= L;
        public static bool operator <=(int L, Clock R) => R.OnTime <= L;

        public static bool operator >(Clock L, float R) => L.OnTime > R;
        public static bool operator <(Clock L, float R) => L.OnTime < R;
        public static bool operator >=(float L, Clock R) => R.OnTime >= L;
        public static bool operator <=(float L, Clock R) => R.OnTime <= L;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }
    
}