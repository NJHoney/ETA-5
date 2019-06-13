using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Char_Parameter Hero = new Char_Parameter("Dragon", 1000, 2, 1000);
    public GameObject Enermy;
    // Start is called before the first frame update
    void Start()
    {
        Hero.SpGenerate.Start();
    }

    // Update is called once per frame
    void Update()
    {
        ResetSPCurrent();
    }

    void ResetSPCurrent()
    {
        Hero.SPCurrent = Hero.SpGenerate.ElapsedMilliseconds;

        //UnityEngine.Debug.Log(transform.Find("SP_Param").name);
        try
        {
            Hero.TempSP = (Hero.SPCurrent / Hero.SPMax) * 0.245f;
            Hero.ScaleVector = transform.Find("SP_Param").localScale;
            Hero.ScaleVector.x = (float)Hero.TempSP;
            transform.Find("SP_Param").transform.localScale = Hero.ScaleVector;
        }
        catch (Exception e)
        {

        }

        //SPObj.transform.localScale = ScaleVector;
        //this.GetComponentInChildren.gameObject....transform.localScale = ScaleVector;

        if (Hero.SPCurrent > Hero.SPMax)
        {
            //do action
            try
            {
                Enermy = GameObject.Find("Hero");
                if(Enermy.GetComponent<Player1>().Hero.HP_Current>0)
                {
                    Enermy.GetComponent<Player1>().Hero.HP_Current -= Hero.Atk;
                    Enermy.GetComponent<Player1>().Hero.ScaleVector = Enermy.GetComponent<Player1>().transform.Find("HP_Param").localScale;
                    Enermy.GetComponent<Player1>().Hero.ScaleVector.x = (Enermy.GetComponent<Player1>().Hero.HP_Current / Enermy.GetComponent<Player1>().Hero.HP_Full) * 0.245f;
                    Enermy.GetComponent<Player1>().transform.Find("HP_Param").localScale = Enermy.GetComponent<Player1>().Hero.ScaleVector;
                }
                else
                {
                    Enermy = GameObject.Find("Thief");
                    if(Enermy.GetComponent<Player2>().Hero.HP_Current > 0)
                    {
                        Enermy.GetComponent<Player2>().Hero.HP_Current -= Hero.Atk;
                        Enermy.GetComponent<Player2>().Hero.ScaleVector = Enermy.GetComponent<Player2>().transform.Find("HP_Param").localScale;
                        Enermy.GetComponent<Player2>().Hero.ScaleVector.x = (Enermy.GetComponent<Player2>().Hero.HP_Current / Enermy.GetComponent<Player2>().Hero.HP_Full) * 0.245f;
                        Enermy.GetComponent<Player2>().transform.Find("HP_Param").localScale = Enermy.GetComponent<Player2>().Hero.ScaleVector;
                    }
                    else
                    {
                        //게임오버
                    }
                }
                
            }
            catch (Exception e)
            {

            }


            Hero.SpGenerate.Restart();
        }
    }
}
