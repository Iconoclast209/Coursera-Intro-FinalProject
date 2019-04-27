using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBolt : MonoBehaviour
{
    [SerializeField]
    float lifetime = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Make bolts destroy themselves after 2 seconds
        Invoke("DestroyMe", lifetime);
    }

    void DestroyMe()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
        }
    }
}
