using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_Chest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        

        if (other.name=="KartBouncingCapsule")

        {
            Debug.Log(other.name);
            Collect playercollectscript = other.gameObject.GetComponent<Collect>();
            playercollectscript.collectedTreasure = true;
            playercollectscript.CollectedTreasureFunction();
            Destroy(gameObject);

        }
    }
}
