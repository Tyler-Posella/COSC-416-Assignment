using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Variables
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float jumpForce = 1.0f;
    [SerializeField] private Rigidbody sphereRigidbody;
    private float sphereBottom;
    
    private void Start()
    {
        sphereBottom = sphereRigidbody.GetComponent<Collider>().bounds.extents.y;
    }
    public void MoveBall(Vector2 inputVector)
    {
        Vector3 inputXZPlane = new Vector3(inputVector.x, 0, inputVector.y);
        sphereRigidbody.AddForce(inputXZPlane * speed);
    }

    public void JumpBall()
    {
        if (IsGrounded())
        {
            sphereRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, sphereBottom + 0.1f);
    }
}
