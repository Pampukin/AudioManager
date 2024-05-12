using UnityEngine;

namespace AudioManager
{
    public abstract class AbstractAudioManager : MonoBehaviour
    {
        [SerializeField]
        protected SoundClips _soundClips;

        protected AudioSource _audioSource;

        protected virtual void Awake()
        {
            _audioSource = this.GetComponent<AudioSource>();
        }
    
        public void Stop()
        {
            _audioSource.Stop();
        }
    }
}

