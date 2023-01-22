using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ItemProbabilitySO : ScriptableObject
{
    public float Common;
    public float Uncommon;
    public float Rare;
    public float Epic;
    public float Legendary;

    public float Sum { get { return Common + Uncommon + Rare + Epic + Legendary; } }
}
