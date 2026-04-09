using UnityEditor.Actions;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _curHealth;

    [SerializeField] private int _maxWater;
    [SerializeField] private int _curWater;

    [SerializeField] private int _maxFood;
    [SerializeField] private int _curFood;

    [SerializeField] private int _maxTemprature;
    [SerializeField] private int _curTemprature;

    [SerializeField] private int _speed;
    [SerializeField] private bool _isRun;

    public InventoryManager inventary;
    public Vector2 direction;


    public Vector3 GetPosition{
        get {
            return gameObject.transform.position;
        }
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnRun(InputValue value)
    {
        if (value.isPressed)
        {
            _isRun = true;
            return;
        }
        _isRun = false;
    }

    private void Move()
    {
        Vector3 destination = transform.position + new Vector3(direction.x, 0, direction.y);
        int speed = _speed;

        if (_isRun)
        {
            speed *= 2;
        }

        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * speed);
    }

    private void OnLeftClick(InputValue value)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.tag == "Item")
            {
                int index = inventary.FindFreeCell() ?? -1;

                if (index == -1)
                {
                    return;
                }
                Item item = hit.collider.gameObject.GetComponent<Item>();

                inventary.AddItem(item, inventary.SelectCell);

                item.gameObject.SetActive(false);
            }
        }
    }


}
