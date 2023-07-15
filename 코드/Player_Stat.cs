using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Player_Stat : ScriptableObject
{
    public Stat[] stat;

    [System.Serializable]
    public struct Stat
    {
        public Sprite sprite;
        public float Speed;
        public float Weight;
        public float Length;
        public float StCharge;
        public float StDecrease;
        public float Dash;
        public float DashSt;
        public float Eyesight;
    }
}
