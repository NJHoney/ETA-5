using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Char_Parameter
{
    public Char_Parameter(string Init_Name, int Init_HP_Full, int Init_ATK, int Init_SPMax)
    {
        HeroName = Init_Name;
        HP_Full = Init_HP_Full;
        HP_Current = HP_Full;
        Atk = Init_ATK;
        SPMax = Init_SPMax;
    }

    public Stopwatch SpGenerate = new Stopwatch();

    public string HeroName = "";

    public float HP_Full = 100;
    public float HP_Current = 100;

    public float Atk = 1;

    public float SPMax = 1400;
    public float SPCurrent = 0;
    public double TempSP = 0;
    public Vector3 ScaleVector;

}
