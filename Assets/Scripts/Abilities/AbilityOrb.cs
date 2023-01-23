using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityOrb : MonoBehaviour
{
    [SerializeField] bool GeneralOrb;
    [SerializeField] ChoiceEvent ChoiceEvent;
    [SerializeField] PlayerStats stats;
    [Space]
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
    [SerializeField] AbilityPool CommonPool;
    [SerializeField] AbilityPool UncommonPool;
    [SerializeField] AbilityPool RarePool;
    [SerializeField] AbilityPool EpicPool;
    [SerializeField] AbilityPool LegendaryPool;
    [SerializeField] AbilityPool FactionPool;

    List<PassiveAbility> intersectedPool;
    List<PassiveAbility> result;

    PassiveAbility GenerateAbility()
    {
        Rarity a = GenerateRarity();
        if (a == Rarity.Common)
        {
            intersectedPool = IntersectPool(CommonPool);
            return GetRandomFromList(intersectedPool);

        }
        else if (a == Rarity.Uncommon)
        {
            intersectedPool = IntersectPool(UncommonPool);
            return GetRandomFromList(intersectedPool);
        }
        else if (a == Rarity.Rare)
        {
            intersectedPool = IntersectPool(RarePool);
            return GetRandomFromList(intersectedPool);
        }
        else if (a == Rarity.Epic)
        {
            intersectedPool = IntersectPool(EpicPool);
            return GetRandomFromList(intersectedPool);
        }
        else if (a == Rarity.Legendary)
        {
            intersectedPool = IntersectPool(LegendaryPool);
            return GetRandomFromList(intersectedPool);
        }
        Debug.Log("Be se ment az ifekbe");
        return null;
    }
    PassiveAbility GetRandomFromList(List<PassiveAbility> list)
    {
        int a = Random.Range(0, list.Count);
        return list[a];
    }

    List<PassiveAbility> IntersectPool(AbilityPool pool)
    {
        if (GeneralOrb)
        {
            return pool.Items;
        }
        return (List<PassiveAbility>)pool.Items.Intersect(FactionPool.Items);
    }

    Rarity GenerateRarity()
    {
        float result = Random.Range(0, probabilities.Sum);
        result -= probabilities.Common;
        if (result <= 0)
        {
            probabilities.Rare += addToRare*2;
            probabilities.Epic += addToEpic*2;
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
        //InvokeRepeating("Test", 0, 1);
        result = new List<PassiveAbility>();
    }
    private void ResetProbalities()
    {
        probabilities.Common = defaultCommon;
        probabilities.Uncommon = defaultUncommon;
        probabilities.Rare = defaultRare;
        probabilities.Epic = defaultEpic;
        probabilities.Legendary = defaultLegendary;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int chNum = ((int)stats.ChoiceNumber.Value);
        for (int i = 0; i < chNum; i++)
        {
            PassiveAbility ab = GenerateAbility();
            if (ab == null)
            {
                Debug.Log("Nullot general");
            }
            result.Add(ab);
            
        }
        string message = "";
        foreach (var item in result)
        {
            if (item == null)
            {
                message += "null;";
            }
        }
        Debug.Log("Ability Orb: " + result.Count + "\n" + message);
        ChoiceEvent.Raise(result);
        result.Clear();
    }

}
