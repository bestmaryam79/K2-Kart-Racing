using KartGame.KartSystems;
using UnityEngine;
using UnityEngine.Events;

public class WaterRefactor : MonoBehaviour
{
    // The amount of time the powerup will be active on the kart.
    public float kartSpeedTimer;

    // The stats to apply to the kart when the powerup is activated.
    public ArcadeKart.StatPowerup boostStats = new ArcadeKart.StatPowerup();

    // Whether the powerup is currently cooling down.
    public bool isCoolingDown { get; private set; }

    // The time when the powerup was last activated.
    public float lastActivatedTimestamp { get; private set; }

    // The cooldown period for the powerup.
    public float cooldown = 5f;

    // Whether to disable the GameObject when the powerup is activated.
    public bool disableGameObjectWhenActivated;

    // The UnityEvent to invoke when the powerup is activated.
    public UnityEvent onPowerupActivated;

    // The UnityEvent to invoke when the powerup has finished cooling down.
    public UnityEvent onPowerupFinishCooldown;

    // Initializes the lastActivatedTimestamp to negative infinity to ensure that the powerup is ready to use.
    private void Awake()
    {
        lastActivatedTimestamp = -Mathf.Infinity;
    }

    // Checks whether the powerup is cooling down and invokes the onPowerupFinishCooldown event when the cooldown period is over.
    private void Update()
    {
        if (isCoolingDown)
        {
            if (Time.time - lastActivatedTimestamp > cooldown)
            {
                // Finished cooldown!
                isCoolingDown = false;
                onPowerupFinishCooldown?.Invoke();
            }
        }
    }

    // Called when a collider enters the trigger area of the water GameObject.
    private void OnTriggerEnter(Collider other)
    {
        // Ignore collisions when the powerup is cooling down.
        if (isCoolingDown)
        {
            return;
        }

        // Attempt to get the ArcadeKart component from the collider's Rigidbody.
        var rb = other.attachedRigidbody;
        if (rb == null)
        {
            return;
        }

        var kart = rb.GetComponent<ArcadeKart>();
        if (kart == null)
        {
            return;
        }

        // Apply the powerup to the kart and start the cooldown period.
        ApplyPowerup(kart);
        onPowerupActivated?.Invoke();
        isCoolingDown = true;

        // Disable the water GameObject if specified.
        if (disableGameObjectWhenActivated)
        {
            gameObject.SetActive(false);
        }
    }

    // Applies the powerup to the specified ArcadeKart instance.
    private void ApplyPowerup(ArcadeKart kart)
    {
        // Set the kart's top speed and reset the speed timer.
        kart.baseStats.TopSpeed = 5.0f;
        kart.kartSpeedTimer = 0.0f;

        // Add the powerup stats to the kart.
        kart.AddPowerup(boostStats);

        // Record the activation time.
        lastActivatedTimestamp = Time.time;
    }
}