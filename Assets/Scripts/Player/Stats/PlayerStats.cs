using Kryz.CharacterStats;
using Kryz.CharacterStats.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public List<CharacterStat> characterStats= new List<CharacterStat>();
    [SerializeField] StatPanel statPanel;

    private void Awake()
    {
        CharacterStat Strength = new CharacterStat();
        characterStats.Add(Strength);
        CharacterStat Agility = new CharacterStat();
        characterStats.Add(Agility);
        CharacterStat Weight = new CharacterStat();
        characterStats.Add(Weight);
        CharacterStat Stealth = new CharacterStat();
        characterStats.Add(Stealth);

        statPanel.SetStats(characterStats.ToArray());
        statPanel.UpdateStatValues();

    }
    public void AddStat(CharacterStat stat) {
        characterStats.Add(stat);
        statPanel.SetStats(characterStats.ToArray());
        statPanel.UpdateStatValues();
    }


    /*public void Equip(EquippableItem item)
    {

    }*/

}
