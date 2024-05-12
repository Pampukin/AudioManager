using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class AbstractSoundClips : ScriptableObject
{
    [SerializeField]
    private AudioClip[] _audioClips;

    private Dictionary<string, AudioClip> _audioDictionary;
    
    public Dictionary<string, AudioClip> AudioDictionary => _audioDictionary;

    private void _Init()
    {
        _audioDictionary = new Dictionary<string, AudioClip>();
        
        foreach (AudioClip clip in _audioClips)
        {
            if (clip == null || _audioDictionary.ContainsKey(clip.name)) continue;

            _audioDictionary.Add(clip.name, clip);
        }
    }

    protected void CreateAudioType(string script)
    {
        // コード生成
        List<string> writeCodes = new List<string>();
        writeCodes.Add("// AbstractSoundClips.csで生成\n");
        writeCodes.Add("/// <summary> AudioType </summary>");
        writeCodes.Add($"public enum {script}");
        writeCodes.Add("{");
        // シーン一覧からシーン名と状態を取得
        foreach (var key in _audioDictionary.Keys)
        {
            string keyName = key;
            while(keyName.Contains(" "))
            {
                keyName = keyName.Replace(" ", "_");
            }
            writeCodes.Add("\t" + keyName + ",");
        }

        writeCodes.Add("}");
        // 生成
        string filePath = Application.dataPath + $"/AudioManager/AudioType/{script}.cs";
        
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

    protected virtual void OnValidate()
    {
        _Init();
    }
}
