using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    //This class will allow any of the objects in the game to screen wrap.  

    float colliderRadius;

    private void Start()
    {
        if(GetComponent<CircleCollider2D>() != null)
        {
            colliderRadius = GetComponent<CircleCollider2D>().radius;
        }
        else if(GetComponent<CapsuleCollider2D>() != null)
        {
            colliderRadius = GetComponent<CapsuleCollider2D>().size.y / 2;
        }
    }

    private void OnBecameInvisible()
    {
        //Find current position
        Vector2 newPosition = transform.position;

        //Determine what edge of the screen the object has exited
        if ((newPosition.x + colliderRadius) > ScreenUtils.ScreenRight || (newPosition.x - colliderRadius) < ScreenUtils.ScreenLeft)
        {
            newPosition.x *= -1;
        }

        if ((newPosition.y - colliderRadius) < ScreenUtils.ScreenBottom || (newPosition.y + colliderRadius) > ScreenUtils.ScreenTop)
        {
            newPosition.y *= -1;
        }

        //Adjust the object's position to the opposite side of the screen
        transform.position = newPosition;
    }


}
