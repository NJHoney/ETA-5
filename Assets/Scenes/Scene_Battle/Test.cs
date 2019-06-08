using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Test : MonoBehaviour
{
    Stopwatch SpGenerate= new Stopwatch();
    public float EnermyHP_Full = 100;
    public float EnermyHP_Current = 100;

    public float Player1_Atk = 1;

    public float SPMax = 1400;
    public float SPCurrent = 0;
    public double TempSP = 0;
    Vector3 ScaleVector;
    // Start is called before the first frame update
    void Start()
    {
        SpGenerate.Start();
    }

    // Update is called once per frame
    void Update()
    {
        RefleshStatus();
        ResetSPCurrent();
        //SPCurrent += 0.1f;
        //ScaleVector.x = SPCurrent;
        //this.transform.localScale = ScaleVector;
    }

    void ResetSPCurrent()
    {
        SPCurrent = SpGenerate.ElapsedMilliseconds;
        ScaleVector = transform.localScale;
        TempSP = (SPCurrent / SPMax) * 0.98f;
        ScaleVector.x = (float)TempSP;
        if(this.name== "SP_Param")
        {
            this.transform.localScale = ScaleVector;
        }
        

        if (SPCurrent > SPMax)
        {
            //do action
            EnermyHP_Current -= Player1_Atk;

            SpGenerate.Restart();
        }
    }

    void RefleshStatus()
    {
        if(this.name == "Enermy_HPParam")
        {
            ScaleVector = transform.localScale;
            ScaleVector.x = (EnermyHP_Current / EnermyHP_Full) * 0.98f;
            this.transform.localScale = ScaleVector;
        }
    }
}
