using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
}
