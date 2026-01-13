using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputAction moveAction;
    [SerializeField] private float speed;
    [SerializeField] private GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        
    }

    public void EnableMovement()
    {
        moveAction.Enable();
    }  

    public void DisableMovement()
    {
        moveAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {       

        Vector2 move = moveAction.ReadValue<Vector2>();

        //Debug.Log(move);

        Vector2 position = (Vector2)transform.position + move * speed;

        transform.position = position;

    }
}
