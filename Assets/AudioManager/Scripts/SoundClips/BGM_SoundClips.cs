using UnityEngine;

[CreateAssetMenu(fileName = "BGM_Clips", menuName = "Scriptable Objects/AudioClips/BGM_SoundClips")]
public class BGM_SoundClips : AbstractSoundClips
{
    private string EnumName = "BGM_Types";
    protected override void OnValidate()
    {
        base.OnValidate();

        CreateAudioType(EnumName);
    }
}


