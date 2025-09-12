using System;
using UnityEngine;

public class TextATK : MonoBehaviour

{
    public IDialogWriter writer;

    public string character;
    public string skill;
    public int damageDone;
    public int healDone;
    public bool isDebuffed;
    public string debuffAplied;
    public string enemyAffected;
    public string targetAlly;
    public bool isBuffed;
    public string buffAplied;


    public string Action()
    {
        return null;
    }
    void Update()
    {
        //if ()
        //{ }

    }
    public void WriteATK() 
    {
        if (damageDone > 0)
        {
            Console.WriteLine(character + "attacked" + enemyAffected + "causing" + damageDone + "damage");
        }
    }
    public void WriteHEAL()
    {
         if (healDone > 0)
        {
            Console.WriteLine(character + "healed" + targetAlly + "healing" + healDone);
        }

    }
    public void WriteDebuff()
    {
        if (isDebuffed = true)
        {
            Console.WriteLine(character + "debuffed" + enemyAffected + "aplying" + debuffAplied + "debuff");
        }
    }
    public void WriteBuff()
    {
      if (isBuffed = true)
        {
            Console.WriteLine(character + "buffed" + targetAlly + "aplying" + buffAplied);
        }
       
    }
}

