using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public InputAction PlayerMovement;
    public InputAction PlayerInteract;
    public InputAction PlayerAttack;
    public Rigidbody2D RigidBody { get; private set; }
    Vector2 MoveDirection = Vector2.zero;

    void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        PlayerMovement.Enable();
        PlayerInteract.Enable();
        PlayerInteract.performed += OnInteract;
        PlayerAttack.Enable();
        PlayerAttack.performed += OnAttack;
    }

    private void OnDisable()
    {
        PlayerMovement.Disable();
        PlayerInteract.Disable();
        PlayerAttack.Disable();
    }

    void Update()
    {
        MoveDirection = PlayerMovement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = RigidBody.position + MoveDirection * MovementSpeed * Time.fixedDeltaTime;
        RigidBody.MovePosition(newPosition);
    }

    private void OnInteract(InputAction.CallbackContext context) // necessary delegate even if not used
    {
        Debug.Log("Interacting!");
    }

    private void OnAttack(InputAction.CallbackContext context) // necessary delegate even if not used
    {
        Debug.Log("Attacking!");
        GetComponent<Animator>().SetTrigger("Attack"); // doesn't actually do anything because the animator has no attack
    }

    /*
    .started: when button is first pressed
    .performed: when the action completes (usually same as press for buttons)
    .canceled: when the button is released
    */

}
