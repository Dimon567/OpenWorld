using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
<<<<<<< HEAD
=======

>>>>>>> cd9da03ca6cd72e41fb651aa5853c600f0281aaf
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
<<<<<<< HEAD

=======
>>>>>>> cd9da03ca6cd72e41fb651aa5853c600f0281aaf
}
