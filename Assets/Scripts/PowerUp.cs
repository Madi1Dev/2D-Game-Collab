using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public Rigidbody2D RigidBody { get; protected set; }
    public int Amount = 0;
    public float Duration = 0;

    void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Player player = collider.GetComponent<Player>(); // the script itself
            if (player != null)
            {
                ApplyPowerUp(player);
                Destroy(gameObject);
            }
        }
    }

    private void ApplyPowerUp(Player player)
    {
        player.ApplyPowerUp(this);
    }

}
