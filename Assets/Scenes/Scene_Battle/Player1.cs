using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Char_Parameter Hero = new Char_Parameter("Warrior", 100, 3, 1800);
    public GameObject Enermy;
    // Start is called before the first frame update
    void Start()
    {
        Hero.SpGenerate.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(Hero.HP_Current>0)
        {
            ResetSPCurrent();
        }
        
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
                Enermy = GameObject.Find("Dragon");
                Enermy.GetComponent<Dragon>().Hero.HP_Current -= Hero.Atk;
                Enermy.GetComponent<Dragon>().Hero.ScaleVector = Enermy.GetComponent<Dragon>().transform.Find("HP_Param").localScale;
                Enermy.GetComponent<Dragon>().Hero.ScaleVector.x = (Enermy.GetComponent<Dragon>().Hero.HP_Current / Enermy.GetComponent<Dragon>().Hero.HP_Full) * 0.245f;
                Enermy.GetComponent<Dragon>().transform.Find("HP_Param").localScale = Enermy.GetComponent<Dragon>().Hero.ScaleVector;
            }
            catch (Exception e)
            {

            }


            Hero.SpGenerate.Restart();
        }
    }
}
