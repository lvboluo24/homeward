using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    [Tooltip("音乐大小")]
    public int music_bgm_size;
    [Tooltip("音效大小")]
    public int sound_bgm_size;
    [Tooltip("保存次数")]
    public int save_index;
    void Start()
    {
        save();
        load();
    }

    // Update is called once per frame
    void Update()
    {

    }

public void save()
    {
        game_data data = ScriptableObject.CreateInstance<game_data>();
        data.music_bgm_size = music_bgm_size;
        data.sound_bgm_size = sound_bgm_size;
        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/save.json", json);
        
    }

    public void load()
    {
        string json = System.IO.File.ReadAllText(Application.persistentDataPath + "/save.json");
        game_data data = ScriptableObject.CreateInstance<game_data>();
        JsonUtility.FromJsonOverwrite(json, data);
       music_bgm_size = data.music_bgm_size;
       sound_bgm_size = data.sound_bgm_size;
    }

}
//游戏数据
public class game_data : ScriptableObject
{
    [Tooltip("音乐大小")]
    public int music_bgm_size;
    [Tooltip("音效大小")]
    public int sound_bgm_size;
    [Tooltip("保存次数")]
    public int save_index;
}
