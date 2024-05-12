using JetBrains.Annotations;
using UnityEngine;

public class SE_AudioManager : AbstractAudioManager
{
    private static SE_AudioManager _instance;
    
    [CanBeNull]
    public static SE_AudioManager Instance => _instance;
    
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
    
    public void PlayOneShot(string key)
    {
        _audioSource.PlayOneShot(_soundClips.AudioDictionary[key]);
    }
}
