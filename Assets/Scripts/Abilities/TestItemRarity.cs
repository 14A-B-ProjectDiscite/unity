using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItemRarity : MonoBehaviour
{
    public float defaultCommon;
    public float defaultUncommon;
    public float defaultRare;
    public float defaultEpic;
    public float defaultLegendary;
    [Space]
    public float addToCommon;
    public float addToUncommon;
    public float addToRare;
    public float addToEpic;
    public float addToLegendary;

    [SerializeField] ItemProbabilitySO probabilities;
    /*
     * 
    Chance get items grouped by rarity:
    Early Game:
    Common: 60
    Uncommon: 30
    Rare: 9
    Epic: 1
    Legendary: 

     */
    [SerializeField] AbilityHolder AbilityPool;



    Rarity GenerateRarity()
    {
        float result = Random.Range(0, probabilities.Sum);
        result -= probabilities.Common;
        if (result <= 0)
        {
            probabilities.Rare += addToRare * 2;
            probabilities.Epic += addToEpic * 2;
            probabilities.Legendary += addToLegendary * 2;
            return Rarity.Common;
        }
        result -= probabilities.Uncommon;
        if (result <= 0)
        {
            probabilities.Rare += addToRare;
            probabilities.Epic += addToEpic;
            probabilities.Legendary += addToLegendary;
            return Rarity.Uncommon;
        }
        result -= probabilities.Rare;
        if (result <= 0)
        {
            probabilities.Rare = defaultRare;
            probabilities.Epic += addToEpic;
            probabilities.Legendary += addToLegendary;
            return Rarity.Rare;
        }
        result -= probabilities.Epic;
        if (result <= 0)
        {
            probabilities.Rare = defaultRare;
            probabilities.Epic = defaultEpic;
            probabilities.Legendary += addToLegendary;
            return Rarity.Epic;
        }
        ResetProbalities();
        return Rarity.Legendary;

    }

    // Update is called once per frame
    void Start()
    {
        ResetProbalities();
        InvokeRepeating("Test", 0, 1);
    }

    void Test()
    {
        string output = "";

        for (int i = 0; i < 4; i++)
        {
            int common = 0;
            int uncommon = 0;
            int rare = 0;
            int epic = 0;
            int legendary = 0;
            for (int j = 0; j < 28; j++)
            {
                Rarity a = GenerateRarity();
                if (a == Rarity.Common)
                {
                    common++;
                }
                else if (a == Rarity.Uncommon)
                {
                    uncommon++;
                }
                else if (a == Rarity.Rare)
                {
                    rare++;
                }
                else if (a == Rarity.Epic)
                {
                    epic++;
                }
                else if (a == Rarity.Legendary)
                {
                    legendary++;
                }
            }
            output += "Common: " + common + " Uncommon: " + uncommon + " Rare: " + rare + " Epic: " + epic + "Legendary: " + legendary + "\n";

        }
        Debug.Log(output);
        ResetProbalities();
    }

    private void ResetProbalities()
    {
        probabilities.Common = defaultCommon;
        probabilities.Uncommon = defaultUncommon;
        probabilities.Rare = defaultRare;
        probabilities.Epic = defaultEpic;
        probabilities.Legendary = defaultLegendary;
    }
}
