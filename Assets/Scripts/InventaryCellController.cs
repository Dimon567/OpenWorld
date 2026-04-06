using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventaryCellController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private Image _imageItem;
    private Image _imageFrame;
    private Item _item;
    public Item DataItem
    {
        set
        {
            _item = value;

            if (value == null)
            {
                _imageItem.gameObject.SetActive(false);
                _imageItem.sprite = null;
                _label.text = string.Empty;
                return;
            }

            _imageItem.gameObject.SetActive(true);

            _imageItem.sprite = value.data.Icon;
            _label.text = value.data.Name;
        }
        get {  return _item; }
    }

    private void Start()
    {
        _imageFrame = GetComponent<Image>();
    }

    public void Select(bool isSelect)
    {
        if (_item != null)
        {
            _label.enabled = isSelect;
            _imageFrame.enabled = isSelect;
        }
    }
}
