using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _audioMixer;
    
    public AudioMixer AudioMixer => _audioMixer;
    
    private static AudioMixerManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _addTag();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void _addTag(string tagName = "AudioMixer")
    {
        TagManager.AddTag(tagName);
        this.gameObject.tag = tagName;
    }

}
