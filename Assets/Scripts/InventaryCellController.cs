using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventaryCellController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private Image _imageItem;

    private Image _imageFrame;
    private Item _item;
    private int index = -1;

    public static UnityEvent<int> SelectItem = new UnityEvent<int>();

    public int Index
    {
        get { return index; }
        set { 
            if(index == -1)
                index = value; 
        }
    }

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
        GetComponent<Button>().onClick.AddListener(OnSelect);
    }

    public void Select(bool isSelect)
    {
        if (_item != null)
        {
            _label.enabled = isSelect;
            _imageFrame.enabled = isSelect;
        }
    }

    private void OnSelect()
    {
        Select(true);
        SelectItem.Invoke(index);
    }
}
