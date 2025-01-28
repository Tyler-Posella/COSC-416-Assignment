using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    // Fields
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnJump = new UnityEvent();

    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
            Debug.Log("W key pressed");
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
            Debug.Log("S key pressed");
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
            Debug.Log("D key pressed");
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
            Debug.Log("A key pressed");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
            Debug.Log("Spacebar pressed");
        }

        OnMove?.Invoke(inputVector);
    }
}
