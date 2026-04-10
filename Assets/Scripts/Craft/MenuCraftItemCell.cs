using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuCraftItemCell : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Button button;

    public UnityEvent<string> OnCraftItemSelect = new UnityEvent<string>();

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        OnCraftItemSelect?.Invoke(icon.sprite.name);
    }
}
