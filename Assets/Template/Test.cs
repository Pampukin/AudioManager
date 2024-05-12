using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private SE_Clips _seClip;
    private string _seName => _seClip.ToString();
    
    [SerializeField]
    private BGM_Clips _bgmClip;
    private string _bgmName => _bgmClip.ToString();
    
    [SerializeField]
    private HogeType _hogeClip;
    private string _hogeName => _hogeClip.ToString();

    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            BGM_AudioManager.Instance?.PlayBGM(_bgmName);
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
