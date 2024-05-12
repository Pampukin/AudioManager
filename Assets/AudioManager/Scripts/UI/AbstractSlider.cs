using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace AudioManager
{
    public abstract class AbstractSlider : MonoBehaviour
    {
        private AudioMixerManager _audioMixerManager;
    
        protected AudioMixer _audioMixer;

        protected Slider _slider;
    
        protected string _dataName;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        protected virtual void Start()
        {
            _audioMixerManager = GameObject.FindWithTag("AudioMixer").GetComponent<AudioMixerManager>();
            _audioMixer = _audioMixerManager.AudioMixer;
        
            _slider.onValueChanged.AddListener((value) => SetValue(_dataName));
        
            _audioMixer.GetFloat(_dataName, out float value);
            _slider.value = InvLerp(value);
        }

        public virtual void SetValue(string name)
        {
            _audioMixer.SetFloat(name, Lerp(_slider.value));
        }

        protected float Lerp(float value)
        {
            float interpolatedValue = Mathf.Lerp(0, 1, value);

            // 補完された値を結果の範囲にマッピングする
            return Mathf.Lerp(-80, 20, interpolatedValue);
        }
    
        protected float InvLerp(float value)
        {
            float interpolatedValue = Mathf.InverseLerp(-80, 20, value);
        
            return Mathf.Lerp(0,1, interpolatedValue);
        }
        
        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveAllListeners();
        }
    }
}
