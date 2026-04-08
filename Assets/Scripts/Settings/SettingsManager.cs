using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;
    private SettingsData _settingsData;
    private string _path;

    public readonly List<Vector2Int> resolutions = new(){
        {new Vector2Int(1920,1080) },
        {new Vector2Int(1600,900) },
        {new Vector2Int(1280,720) },
    };
    public readonly List<string> languages = new()
    {
        "English",
        "Russian",
    };

    public Vector2Int Resolution
    {
        set {
            if (!resolutions.Contains(value))
            {
                return;
            }

            _settingsData.resolutionHeight = value.y;
            _settingsData.resolutionWidth = value.x;
        }
        get {
            return new Vector2Int(_settingsData.resolutionWidth, _settingsData.resolutionHeight);
        }
    }
    public string Language
    {
        set
        {
            if (!languages.Contains(value))
            {
                return;
            }
        }
        get
        {
            return _settingsData.language;
        }
    }
    public float SoundVolume
    {
        set { _settingsData.musicVolume = value; }
        get { return _settingsData.musicVolume; }
    }
    public float MouseSensitive
    {
        set { _settingsData.mouseSensitive = value; }
        get { return _settingsData.mouseSensitive; }
    }
    public int GetResolutionIndex
    {
        get { return resolutions.IndexOf(Resolution); }
    }
    public int GetLanguageIndex
    {
        get { return languages.IndexOf(Language); }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        _path = Path.Combine(Application.persistentDataPath, "settings.json");
        Load();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(_settingsData, true);
        File.WriteAllText(_path, json);
    }

    public void Load()
    {
        if (!File.Exists(_path))
        {
            _settingsData = new SettingsData();
            return;
        }
        
        string json = File.ReadAllText(_path);
        _settingsData = JsonUtility.FromJson<SettingsData>(json);
    }

}
