using Kryz.CharacterStats;
using Kryz.CharacterStats.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    public GameEvent WeightChanged;
    public DefaultStats defStats;

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

    public void ResetStats()
    {
        Strength = new CharacterStat(defStats.Strength);
        Agility = new CharacterStat(defStats.Agility);
        Intelligence= new CharacterStat(defStats.Intelligence);
        Wisdom = new CharacterStat(defStats.Wisdom);
        Constitution = new CharacterStat(defStats.Constitution);
        Vitality = new CharacterStat(defStats.Vitality);
        Blood = new CharacterStat(defStats.Blood);
        Friction = new CharacterStat(defStats.Friction);
        MaxSpeed = new CharacterStat(defStats.MaxSpeed);
        Acceleration = new CharacterStat(defStats.Acceleration);
        Weight = new CharacterStat(defStats.Weight);
        DashSpeed = new CharacterStat(defStats.DashSpeed);
        Soul = new CharacterStat(defStats.Soul);
        ChoiceNumber = new CharacterStat(defStats.ChoiceNumber);


    }
}
