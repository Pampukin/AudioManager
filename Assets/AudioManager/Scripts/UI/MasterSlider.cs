namespace AudioManager
{
    public class MasterSlider : AbstractSlider
    {
        protected override void Start()
        {
            _dataName = "Master";
            base.Start();
        }
    }
}

