using UnityEngine;

public class RandomItem : Item
{
    [SerializeField, Range(0f, 0.03f)] private float _maxScaleValue;
    [SerializeField, Range(0f, 0.03f)] private float _minScaleValue;
    public override float ScaleValue => Random.Range(_minScaleValue, _maxScaleValue);
}
