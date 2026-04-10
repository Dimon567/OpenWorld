using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftController : MonoBehaviour
{
    [SerializeField] private GameObject _itemsMenu;
    [SerializeField] private CraftItemController _itemCraftMenu;
    [SerializeField] private string _iconPath;
    [SerializeField] private GameObject _craftCellPrefab;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Transform craftsContaner;

    public void  LoadItemsMenu(string folderName)
    {
        Clear();

        _itemsMenu.SetActive(true);
        title.text = folderName;

        Sprite[] sprites = Resources.LoadAll<Sprite>(Path.Combine(_iconPath, folderName));

        foreach (Sprite sprite in sprites)
        {
            GameObject obj = Instantiate(_craftCellPrefab, craftsContaner);
            obj.transform.GetChild(0).GetComponent<Image>().sprite = sprite;
            obj.GetComponent<MenuCraftItemCell>().OnCraftItemSelect.AddListener(SelectCraftItem);
        }
    }

    public void Clear()
    {
        for (int i = craftsContaner.childCount - 1; i >= 0; i--)
        {
            Destroy(craftsContaner.GetChild(i).gameObject);
        }
    }

    public void OpenCraft()
    {
        bool isOpen = this.gameObject.activeSelf;
        this.gameObject.SetActive(!isOpen);

        if (isOpen)
        {
            _itemsMenu.SetActive(false);
            _itemCraftMenu.gameObject.SetActive(false);
        }
    }

    public void SelectCraftItem(string iconName)
    {
        ItemData data = ItemContenerManager.instance.GetItemByPicture(iconName);
        if (data == null)
        {
            return;
        }

        _itemCraftMenu.gameObject.SetActive(true);
        _itemCraftMenu.item = data;
        _itemCraftMenu.UpdateUI();
    }

    

}
