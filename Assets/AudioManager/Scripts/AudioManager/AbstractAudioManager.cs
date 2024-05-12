using UnityEngine;

public abstract class AbstractAudioManager : MonoBehaviour
{
    [SerializeField]
    protected AbstractSoundClips _soundClips;

    protected AudioSource _audioSource;

    protected virtual void Awake()
    {
        _soundClips = _soundClips;
        _audioSource = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        foreach (var value in _soundClips.AudioDictionary)
        {
            Debug.Log(value.Key + " : " + value.Value.name);
        }
    }

    public void Stop()
    {
        _audioSource.Stop();
    }
}
