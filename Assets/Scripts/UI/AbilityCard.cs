using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCard : MonoBehaviour
{
    [SerializeField] PassiveAbility Ability;
    [SerializeField] AbilityHolder Holder;
    [Space]
    [SerializeField] Text nameText;
    [SerializeField] Text rarityText;
    [SerializeField] Text factionText;
    [SerializeField] Text descriptionText;
    [SerializeField] Image image;
    [SerializeField] Image bannerImage;
    [SerializeField] Color commonColor;
    [SerializeField] Color uncommonColor;
    [SerializeField] Color rareColor;
    [SerializeField] Color epicColor;
    [SerializeField] Color legendaryColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Choose()
    {
        Holder.Add(Ability);
    }

    public void ChangeAbility( PassiveAbility ability)
    {
        Ability = ability;
        UpdateCard();
    }

    public void UpdateCard()
    {
        nameText.text = Ability.Name;
        rarityText.text = Ability.Rarity.ToString();
        factionText.text = Ability.Faction.ToString();
        descriptionText.text = Ability.Description;
        image.sprite = Ability.Image;

        if (Ability.Rarity== Rarity.Common)
        {
            rarityText.color = commonColor;
            bannerImage.color = commonColor;
        }
        else if (Ability.Rarity== Rarity.Uncommon)
        {
            rarityText.color = uncommonColor;
            bannerImage.color = uncommonColor;
        }
        else if (Ability.Rarity== Rarity.Rare)
        {
            rarityText.color = rareColor;
            bannerImage.color = rareColor;
        }
        else if (Ability.Rarity== Rarity.Epic)
        {
            rarityText.color = epicColor;
            bannerImage.color = epicColor;
        }
        else if (Ability.Rarity== Rarity.Legendary)
        {
            rarityText.color = legendaryColor;
            bannerImage.color = legendaryColor;
        }

    }
}
