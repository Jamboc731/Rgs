using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSO : ScriptableObject
{

    public int attack;
    public int threshold;
    public string [] traits;
    private int cost;
    private Traits traitList;


    private void Awake ()
    {

        traitList = GameObject.Find ("Manager").GetComponent<Traits>();

        cost = FindCost ();

    }

    private int FindCost ()
    {
        int cost = 0;

        cost += attack;
        cost += threshold;

        for (int i = 0; i < traits.Length; i++)
        {
            int isMultiplicative = System.Array.IndexOf (traitList.multiplicative, traits [i]);
            int traitNumber = System.Array.IndexOf (traitList.traitName, traits [i]);
            if (isMultiplicative > -1)
            {
                cost += traitList.traitCost [traitNumber] * System.Convert.ToInt32(traits[i].Substring(traits[i].Length - 1));
            }
            else
            {
                cost += traitList.traitCost [traitNumber];
            }
        }

        cost /= 2;

        return cost;
    }

}
