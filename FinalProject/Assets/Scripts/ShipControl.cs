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

    float colliderRadius;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        colliderRadius = GetComponent<CircleCollider2D>().radius;
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

    private void OnBecameInvisible()
    {
           //Find position on screen
        if((transform.position.x + colliderRadius) > ScreenUtils.ScreenRight)
        {
            Debug.Log("Ship has exited screen right.");
        }
        else if ((transform.position.x - colliderRadius) < ScreenUtils.ScreenLeft)
        {
            Debug.Log("Ship has exited screen left.");
        }
    }


}

