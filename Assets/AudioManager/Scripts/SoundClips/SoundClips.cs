using UnityEngine;

[CreateAssetMenu(fileName = "Clips", menuName = "Scriptable Objects/AudioClips/SoundClips")]
public class SoundClips : AbstractSoundClips
{
    protected override void OnValidate()
    {
        base.OnValidate();

        CreateAudioType(this.name);
    }
}
