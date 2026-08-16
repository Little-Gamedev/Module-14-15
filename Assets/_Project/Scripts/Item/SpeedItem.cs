using UnityEngine;

public class SpeedItem : Item
{
    [SerializeField] private float _addedSpeedCount = 1;
    public override void UseAbility(Player player)
    {
        player.AddSpeed(_addedSpeedCount);
        GetEffectTransform(player.LegsEffectTransform);
        base.UseAbility(player);
    }
}
