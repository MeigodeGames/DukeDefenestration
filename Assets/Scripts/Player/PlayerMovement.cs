using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float m_WalkSpeed = 4.0f;

    private Vector3 m_Movement = Vector3.zero;
    private Rigidbody m_Body;

    private void Start()
    {
        m_Body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();

        m_Movement.x = input.x;
    }

    private void Move()
    {
        Vector3 displacement = m_Movement.normalized * m_WalkSpeed * Time.fixedDeltaTime;
        m_Body.MovePosition(m_Body.position + displacement);
    }
}
