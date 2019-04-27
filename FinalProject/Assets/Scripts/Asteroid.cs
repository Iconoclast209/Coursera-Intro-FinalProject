using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    float colliderRadius = 1;
    /*  
    Screen wrap the asteroid. For example, when the asteroid leaves the bottom of the game window it should re-appear 
    at the top of the game window
    */

    private void Start()
    {
        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    private void OnBecameInvisible()
    {
        //Find current position
        Vector2 newPosition = transform.position;

        //Determine what edge of the screen the asteroid has exited
        if ((newPosition.x + colliderRadius) > ScreenUtils.ScreenRight)
        {
            newPosition.x *= -1;
        }
        else if ((newPosition.x - colliderRadius) < ScreenUtils.ScreenLeft)
        {
            newPosition.x *= -1;
        }

        if ((newPosition.y - colliderRadius) < ScreenUtils.ScreenBottom)
        {
            newPosition.y *= -1;
        }
        else if ((newPosition.y + colliderRadius) > ScreenUtils.ScreenTop)
        {
            newPosition.y *= -1;
        }

        //Adjust the asteroids's position to the opposite side of the screen
        transform.position = newPosition;

    }



}
