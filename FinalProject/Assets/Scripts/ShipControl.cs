using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 180.0f;
    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    float thrust = 0.2f;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        
        //Rotate
        if (input != 0)
        {
            Vector3 rotationForShip = new Vector3(0, 0, input);
            rotationForShip *= -rotationSpeed * Time.deltaTime;
            transform.Rotate(rotationForShip,Space.Self);
        }

        //Apply thrust
        if (Input.GetKey(KeyCode.Space))
        {

            Vector2 forwardVector = new Vector2(0,1);
            rb2d.AddRelativeForce(forwardVector * thrust * Time.deltaTime, ForceMode2D.Impulse);
        }
        
    }

    

}

/*
 * // Smoothly tilts a transform towards a target rotation.
        

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

       
*/