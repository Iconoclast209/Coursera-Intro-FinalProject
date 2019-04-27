using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{

    [SerializeField]
    GameObject laserBolt;
    [SerializeField]
    float thrust = 100;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 laserVector = new Vector3(transform.position.x, transform.position.y,0f);
            //GameObject currentLaserBolt = Instantiate(laserBolt, laserVector, Quaternion.identity);
            Quaternion laserQuaternion = this.transform.rotation;
            GameObject currentLaserBolt = Instantiate(laserBolt, laserVector, laserQuaternion);
            currentLaserBolt.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * thrust, ForceMode2D.Impulse);
        }
    }
}
