using Kryz.CharacterStats;
using Kryz.CharacterStats.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    public GameEvent WeightChanged;

    public CharacterStat Strength; //how much stun, meele damage
    public CharacterStat Agility; //speed, attack speed, animationspeed, dashspeed
    public CharacterStat Intelligence; //Energy damage, max energy
    public CharacterStat Wisdom; //Energy damage, energy regeneration
    public CharacterStat Constitution; //Max hp, resistances


    public CharacterStat Vitality; //hp regeneration
    public CharacterStat Blood; //Blood skills
    public CharacterStat Friction;
    public CharacterStat MaxSpeed;
    public CharacterStat Acceleration;
    public CharacterStat Weight;
    public CharacterStat DashSpeed;
    public CharacterStat Soul; //Summoning, Soul powers

    public CharacterStat ChoiceNumber;

}
