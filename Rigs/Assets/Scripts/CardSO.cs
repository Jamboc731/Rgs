using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card", menuName = "New Card")]
public class CardSO : ScriptableObject
{

    public new string name;
    public Texture2D cardImage;
    public int attack;
    public int threshold;
    public string [] traits = new string[] { };
    [HideInInspector]
    public int cost;
    private Traits traitList;


    private void OnEnable ()
    {
        //Debug.Log("Start"); 
        traitList = GameObject.Find ("Manager").GetComponent<Traits>();

        cost = FindCost ();

    }

    private int FindCost ()
    {
        int cost = 0;

        cost += attack;
        cost += threshold - 2;

        for (int i = 0; i < traits.Length; i++)
        {
            string temp = traits[i].Substring(0, traits[i].Length - 2);
            int isMultiplicative = System.Array.IndexOf (traitList.multiplicative, temp);
            int traitNumber = System.Array.IndexOf (traitList.traitName, temp);
            if (isMultiplicative > -1)
            {
                cost += traitList.traitCost [traitNumber] * System.Convert.ToInt32(traits[i].Substring(traits[i].Length - 1));
            }
            else
            {
                cost += traitList.traitCost [traitNumber];
            }
        }

        cost = Mathf.FloorToInt(cost/2);

        return cost;
    }

}
