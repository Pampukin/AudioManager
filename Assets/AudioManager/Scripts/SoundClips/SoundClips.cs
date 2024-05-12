using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AudioManager
{
    [CreateAssetMenu(fileName = "Clips", menuName = "Scriptable Objects/SoundClips")]
    public class SoundClips : ScriptableObject
    {
        [SerializeField]
        private AudioClip[] _audioClips;
    
        private Dictionary<string, AudioClip> _audioDictionary;
        
        public Dictionary<string, AudioClip> AudioDictionary => _audioDictionary;
    
        public void Init()
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
    
        private void _CreateAudioType(string type)
        {
            List<string> enumList = new List<string>();
            // コード生成
            List<string> writeCodes = new List<string>();
            writeCodes.Add("// AbstractSoundClips.csで生成\n");
            writeCodes.Add("namespace AudioManager");
            writeCodes.Add("{");
            writeCodes.Add("\t"+ "/// <summary> AudioType </summary>");
            writeCodes.Add("\t" + $"public enum {type}");
            writeCodes.Add("\t" +"{");
            // シーン一覧からシーン名と状態を取得
            foreach (var clip in _audioClips)
            {
                if (clip == null) continue;
    
                string key = clip.name;
                while(key.Contains(" "))
                {
                    key = key.Replace(" ", "_");
                }
                key = key.Replace(" (UnityEngine.AudioClip)", "");
                
                if(enumList.Contains(key)) continue;
                enumList.Add(key);
                writeCodes.Add("\t" + "\t" + key + ",");
            }
    
            writeCodes.Add("\t" +"}");
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
        
#if UNITY_EDITOR
        protected void OnValidate()
        {
            _CreateAudioType(this.name);
        }
#endif
    }

}
