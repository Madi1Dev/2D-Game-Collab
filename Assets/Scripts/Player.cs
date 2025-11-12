using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    public string Name = "Fresh Beats";
    public InputAction PlayerMovement;
    public InputAction PlayerInteract;
    public InputAction PlayerAttack;
    
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
        Shoot();
    }
    
    private void Shoot()
    {
        Debug.Log($"{Name} is shooting with {AttackSpeed} attack speed.");
    }

    /*
    .started: when button is first pressed
    .performed: when the action completes (usually same as press for buttons)
    .canceled: when the button is released
    */

    public void ApplyPowerUp(PowerUp newPowerUp)
    {
        PowerUp existing = ActivePowerUps.Find(p => p.GetType() == newPowerUp.GetType());
        if (existing != null)
        {
            ActivePowerUps.RemoveAll(p => p.GetType() == newPowerUp.GetType());
        }

        if (newPowerUp is AttackSpeedPowerUp newASPowerUp)
        {
            AttackSpeed = BaseAttackSpeed;
            ActivePowerUps.Add(newASPowerUp);
            AttackSpeed = newASPowerUp.Amount;
            Debug.Log($"Applying {newASPowerUp.Amount} attack speed to {Name}!");
        }
    }
}

// projectiles
// player
// timer?
// enemies
// no health - 1 hit = death
// enemy manager
// projectile manager