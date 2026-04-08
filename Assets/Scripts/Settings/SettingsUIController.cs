using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUIController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdownResolution;
    [SerializeField] private TMP_Dropdown _dropdownLanguage;
    [SerializeField] private Slider _sliderMusicVolume;
    [SerializeField] private Slider _sliderMouseSensitive;

    private void Start()
    {
        _dropdownResolution.onValueChanged.AddListener(SetResolution);
        _dropdownLanguage.onValueChanged.AddListener(SetLanguage);
        _sliderMouseSensitive.onValueChanged.AddListener(SetMouseSensitive);
        _sliderMusicVolume.onValueChanged.AddListener(SetMusicVolume);
    }

    private void OnEnable()
    {
        SettingsManager.instance.Load();
        UpdateUI();
    }

    private void SetResolution(int value)
    {
        SettingsManager.instance.Resolution = SettingsManager.instance.resolutions[value];
    }

    private void SetLanguage(int value)
    {
        SettingsManager.instance.Language = SettingsManager.instance.languages[value];
    }

    private void SetMouseSensitive(float value)
    {
        SettingsManager.instance.MouseSensitive = value;
    }

    private void SetMusicVolume(float value)
    {
        SettingsManager.instance.SoundVolume = value;
    }

    public void UpdateUI()
    {
        Debug.Log(1);
        _dropdownResolution.value = SettingsManager.instance.GetResolutionIndex;
        _dropdownLanguage.value = SettingsManager.instance.GetLanguageIndex;
        _sliderMouseSensitive.value = SettingsManager.instance.MouseSensitive;
        _sliderMusicVolume.value = SettingsManager.instance.SoundVolume;
    }

}
