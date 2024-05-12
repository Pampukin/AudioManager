using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "Clips", menuName = "Scriptable Objects/AudioClips/SoundClips")]
public class SoundClips : ScriptableObject
{
    [SerializeField]
    private AudioClip[] _audioClips;

    private Dictionary<string, AudioClip> _audioDictionary;
    
    public Dictionary<string, AudioClip> AudioDictionary => _audioDictionary;

    private void _init()
    {
        _audioDictionary = new Dictionary<string, AudioClip>();
        
        foreach (AudioClip clip in _audioClips)
        {
            if (clip == null) continue;

            string key = clip.name;
            while(key.Contains(" "))
            {
                key = key.Replace(" ", "_");
            }
            if(_audioDictionary.ContainsKey(key)) continue;
            _audioDictionary.Add(key, clip);
        }
    }

    protected void CreateAudioType(string type)
    {
        // コード生成
        List<string> writeCodes = new List<string>();
        writeCodes.Add("// AbstractSoundClips.csで生成\n");
        writeCodes.Add("/// <summary> AudioType </summary>");
        writeCodes.Add($"public enum {type}");
        writeCodes.Add("{");
        // シーン一覧からシーン名と状態を取得
        foreach (var key in _audioDictionary.Keys)
        {
            writeCodes.Add("\t" + key + ",");
        }

        writeCodes.Add("}");
        // 生成
        string filePath = Application.dataPath + $"/AudioManager/AudioType/{type}.cs";
        
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);
        StreamWriter sw = new StreamWriter(stream, Encoding.UTF8);
        sw.Write("");
        foreach (var code in writeCodes)
        {
            sw.WriteLine(code);
        }

        sw.Close();
    }
    
    protected void OnValidate()
    {
        _init();

        CreateAudioType(this.name);
    }
}
