using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 180.0f;
    [SerializeField]
    float thrust = 0.2f;

    float colliderRadius;
    Rigidbody2D rb2d;

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
        //Find current position
        Vector2 newPosition = transform.position;
        
        //Determine what edge of the screen the ship has exited
        if((newPosition.x + colliderRadius) > ScreenUtils.ScreenRight)
        {
            newPosition.x *= -1;
            /*if(newPosition.y > ScreenUtils.ScreenTop)
            {
                newPosition.y = ScreenUtils.ScreenTop - 0.001f;
            }*/
        }
        else if ((newPosition.x - colliderRadius) < ScreenUtils.ScreenLeft)
        {
            newPosition.x *= -1;
            if (newPosition.y > ScreenUtils.ScreenTop)
            {
                newPosition.y = ScreenUtils.ScreenTop - 0.001f;
            }
        }

        if ((newPosition.y - colliderRadius) < ScreenUtils.ScreenBottom)
        {
            newPosition.y *= -1;
        }
        else if ((newPosition.y + colliderRadius) > ScreenUtils.ScreenTop)
        {
            newPosition.y *= -1;
        }

        //Adjust the ship's position to the opposite side of the screen
        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Ship has collided with asteroid.");
            DestroyShip();
        }
    }

    void DestroyShip()
    {
        //instantiate explosion
        Destroy(this.gameObject);
        //reset game
    }

}

