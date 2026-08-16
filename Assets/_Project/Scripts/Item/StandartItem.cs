using UnityEngine;

public class StandartItem : Item
{
    [SerializeField, Range(0, 0.03f)] private float _scaleValue;
    public override float ScaleValue => _scaleValue;
}
