using UnityEngine;

public class MasterSlider : AbstractSlider
{
    protected override void Start()
    {
        _dataName = "Master";
        base.Start();
    }
}
