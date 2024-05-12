using UnityEngine;

[CreateAssetMenu(fileName = "SE_Clips", menuName = "Scriptable Objects/AudioClips/SE_SoundClips")]
public class SE_SoundClips : AbstractSoundClips
{
    private string EnumName = "SE_Types";
    protected override void OnValidate()
    {
        base.OnValidate();

        CreateAudioType(EnumName);
    }
}