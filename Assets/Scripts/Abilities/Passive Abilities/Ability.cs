using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : ScriptableObject
{
    //image
    //description
    //rarity
    //isBoss
    public string Name;
    public Sprite Image;
    public Rarity Rarity;
    public Faction Faction;
    public string Description;
    public bool isBoss;

}
public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public enum Faction
{
    Might,
    Blood,
    Darkness,
    Technology,
    Swiftness
}