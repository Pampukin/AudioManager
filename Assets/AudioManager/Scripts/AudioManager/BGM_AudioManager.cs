using JetBrains.Annotations;
using UnityEngine;

public class BGM_AudioManager : AbstractAudioManager
{
    private static BGM_AudioManager _instance;
    
    [CanBeNull]
    public static BGM_AudioManager Instance => _instance;
    
    protected override void Awake()
    {
        base.Awake();
        
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayBGM(string key)
    {
        _audioSource.clip = _soundClips.AudioDictionary[key];
        _audioSource.Play();
    }
}
