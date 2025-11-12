using UnityEngine;

public class Enemy : Character
{
    public Player player;
    public float AggroRange { get; protected set; } = 10f;
    public float AttackRange { get; protected set; } = 5f;
    public float ReloadTime { get; protected set; } = 2f;
    public float ReloadTimer { get; protected set; } = 0f;
    public float ShootAnimTime { get; protected set; } = 1.5f;
    public float ShootTimer { get; protected set; } = 0f;

    private bool IsAggroed = false;
    private bool InRange = false;
    private bool IsShooting = false;
    private bool IsReloading = false;

    public Enemy()
    {
        MovementSpeed = 3f;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        IsAggroed = distance <= AggroRange;
        // InRange = distance <= AttackRange;

        // HandleTimers();
    }

    void FixedUpdate()
    {
        if (!IsAggroed)
        {
            return;
        }
        else
        {
            ChasePlayer();
            Shoot();
        }
        /*
        {
            if (IsShooting)
            {
                // play shooting animation
                return;
            }
            else
            {
                if (!InRange)
                {
                    ChasePlayer();
                }
                else if (!IsReloading)
                {
                    StartShooting();
                }
            }
        }
        */
    }

    private void ChasePlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        RigidBody.MovePosition(RigidBody.position + direction * MovementSpeed * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        Debug.Log("Shooting @Player!");
    }


    private void HandleTimers()
    {
        if (IsShooting)
        {
            ShootTimer -= Time.deltaTime;
            if (ShootTimer <= 0f)
            {
                FinishShooting();
            }
        }

        if (IsReloading)
        {
            ReloadTimer -= Time.deltaTime;
            if (ReloadTimer <= 0f)
            {
                FinishReload();
            }
        }
    }

    private void StartShooting()
    {
        IsShooting = true;
        ShootTimer = ShootAnimTime;
        Debug.Log("Started shooting!");
        // trigger animation
    }

    private void FinishShooting()
    {
        IsShooting = false;
        IsReloading = true;
        ReloadTimer = ReloadTime;
        Debug.Log("Finished shooting, now reloading...");
        // spawn projectile
    }

    private void FinishReload()
    {
        IsReloading = false;
        ReloadTimer = ReloadTime;
        Debug.Log("Finished reloading!");
    }
}
