using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
    /*
{
    public GameObject myCamera;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Bang bang");

            //get the forward direction 10 units from the camera
            Vector3 forward = myCamera.transform.TransformDirection(Vector3.forward) * 10;

            //draw a line
            Debug.DrawRay(myCamera.transform.position, forward, Color.red);

            //save a raycast to store the hit data
            RaycastHit hit;

            //raycast out, if we hit something return it to hit
            if (Physics.Raycast(myCamera.transform.position, forward, out hit))
            {
                Debug.Log("hit the " + hit.collider.gameObject.name);

                //grab their Damage script
                Damage bulletDamage = hit.collider.gameObject.GetComponent<Damage>();
                if (bulletDamage) //;check we got it and don't error
                    bulletDamage.TakeDamage(); //call their damage script

            }

        }

    }
}
*/

{

     //decalare and init shooter vars
public Rigidbody bullet;
public float power = 1500f;
public float moveSpeed = 2f;

// Update is called once per frame
void Update()
{

    if (Input.GetButtonDown("Fire1"))
    {
        //instantiate projectile - (overloads) what ?, where ?, a rotation ?
        Rigidbody instance = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
        //vector to represent forward direction of the current transform
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        instance.AddForce(fwd * power);
    }

}
 }
