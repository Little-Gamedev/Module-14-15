using UnityEngine;

public class HealItem : Item
{
    [SerializeField] private int _addedHealthCount = 5;

    public override void UseAbility(Player player)
    {
        player.AddHealth(_addedHealthCount);
        GetEffectTransform(player.LegsEffectTransform);
        base.UseAbility(player);
    }
}
