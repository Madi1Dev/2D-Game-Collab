using UnityEngine;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour
{
    public float BaseAttackSpeed { get; protected set; } = 1f;
    public float AttackSpeed { get; protected set; } = 1f;
    public float MovementSpeed { get; protected set; } = 5f;
    public Rigidbody2D RigidBody { get; protected set; }
    public Vector2 MoveDirection { get; protected set; } = Vector2.zero;

    public List<PowerUp> ActivePowerUps = new List<PowerUp>();

    void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        AttackSpeed = BaseAttackSpeed;
    }
}
