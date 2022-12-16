using KartGame.KartSystems;
using UnityEngine;
using UnityEngine.Events;

public class Water : MonoBehaviour
{
    public float kartSpeedTimer;
    public ArcadeKart.StatPowerup boostStats = new ArcadeKart.StatPowerup
    {
         
    };

    public bool isCoolingDown { get; private set; }
    public float lastActivatedTimestamp { get; private set; }

    public float cooldown = 5f;

    public bool disableGameObjectWhenActivated;
    public UnityEvent onPowerupActivated;
    public UnityEvent onPowerupFinishCooldown;

    private void Awake()
    {
        lastActivatedTimestamp = -9999f;
    }


    private void Update()
    {
        if (isCoolingDown)
        {

            if (Time.time - lastActivatedTimestamp > cooldown)
            {
                //finished cooldown!
                isCoolingDown = false;
                onPowerupFinishCooldown.Invoke();
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isCoolingDown) return;

        var rb = other.attachedRigidbody;
        if (rb)
        {

            var kart = rb.GetComponent<ArcadeKart>();

            if (kart)
            {
                kart.baseStats.TopSpeed = 5.0f;
                kart.kartSpeedTimer = 0.0f; //Reset the time



                lastActivatedTimestamp = Time.time;
                kart.AddPowerup(this.boostStats);
                onPowerupActivated.Invoke();
                isCoolingDown = true;

                if (disableGameObjectWhenActivated) this.gameObject.SetActive(false);
            }
        }
    }

}