using JetBrains.Annotations;
using UnityEditorInternal;
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

        Debug.Log(_instance);
    }
    
    public void PlayBMG(string key)
    {
        Debug.Log("PlayBMG");
        _audioSource.clip = _soundClips.AudioDictionary[key];
        _audioSource.Play();
    }
}
