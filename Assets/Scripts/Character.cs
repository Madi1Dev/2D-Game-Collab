using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float MovementSpeed { get; protected set; } = 5f;
    public Rigidbody2D RigidBody { get; protected set; }
    public Vector2 MoveDirection { get; protected set; } = Vector2.zero;

    void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }


}
