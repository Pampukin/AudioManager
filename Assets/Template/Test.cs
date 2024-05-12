using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private SE_Types _seType;
    private string _seName => _seType.ToString();
    
    [SerializeField]
    private BGM_Types _bgmType;
    private string _bgmName => _bgmType.ToString();

    
    
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
