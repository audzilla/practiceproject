using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputAction moveAction;
    [SerializeField] private float speed;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();

    }
  

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        Debug.Log(move);

        Vector2 position = (Vector2)transform.position + move * speed;

        transform.position = position;

    }
}
