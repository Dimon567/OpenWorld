using UnityEngine;

public class ItemContenerManager : MonoBehaviour
{

    public static ItemContenerManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
            return;
        }
        instance = this;
    }

    public void SpawnItem(Item item, Vector3 position, Quaternion rotation = new Quaternion())
    {
        if (IsOnScene(item))
        {
            item.transform.position = position;
            item.transform.rotation = rotation;
            item.gameObject.SetActive(true);
            return;
        }

        Instantiate(item, position, rotation, transform);
    }

    public void PickUpItem(Item item)
    {
          item.gameObject.SetActive(false);
    }

    public bool IsOnScene(Item findItem)
    {
        Item[] items = GetComponentsInChildren<Item>();

        foreach (Item item in items)
        {
            if (findItem == item)
            {
                return true;
            }
        }

        return false;
    }
}
