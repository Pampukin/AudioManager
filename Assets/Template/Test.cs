using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private SE_Clips _seClip;
    private string _seName => _seClip.ToString();
    
    [SerializeField]
    private BGM_Clips _bgmClip;
    private string _bgmName => _bgmClip.ToString();

    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("PlayBMG");
            BGM_AudioManager.Instance?.PlayBMG(_bgmName);
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            BGM_AudioManager.Instance?.Stop();
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            SE_AudioManager.Instance?.PlayOneShot(_seName);
        }
        
        
    }
}
