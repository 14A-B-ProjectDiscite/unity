using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    [SerializeField]
    List<AbilityCard> cards;
    [SerializeField]
    List<PassiveAbility> abilities;
    public void NewChoice(List<PassiveAbility> list)
    {
        
        abilities = list;
        Debug.Log("Choice Manager list: " + list[0].Name + " " + list[1].Name + " " + list[2].Name);
        ActivateCards();
    }

    public void Close()
    {

    }

    private void ActivateCards()
    {
        foreach (AbilityCard card in cards)
        {
            card.gameObject.SetActive(false);
        }
        for (int i = 0; i < abilities.Count; i++)
        {
            cards[i].gameObject.SetActive(true);
            cards[i].ChangeAbility(abilities[i]);
        }
    }
}
