using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] asteroidPrefabs;

    [SerializeField]
    float thrustMin;
    [SerializeField]
    float thrustMax;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SpawnAsteroid();
        }
    }

    void SpawnAsteroid()
    {
        // Select a random prefab
        int index = Random.Range(0, asteroidPrefabs.Length - 1);

        // Store the collider radius
        float prefabRadius = asteroidPrefabs[index].GetComponent<CircleCollider2D>().radius;
        // Select a random spawn point just outside camera window

        /*
        int quadrantToSpawnIn = Random.Range(1, 4);
        if(quadrantToSpawnIn == 1)
        {
            //determine random x,y pair within quadrant 1
        }
        */

        float xCoordinate = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
        float yCoordinate = Random.Range(ScreenUtils.ScreenBottom, ScreenUtils.ScreenTop);
        Vector3 spawnPosition = new Vector3(xCoordinate, yCoordinate, 0f);
        // Create an asteroid 
        GameObject newAsteroid = Instantiate(asteroidPrefabs[index], spawnPosition, Quaternion.identity);

        // Select a random velocity (towards camera window)
        float thrust = Random.RandomRange(thrustMin, thrustMax);
        newAsteroid.GetComponent<Rigidbody2D>().AddForce(Vector2.down * thrust, ForceMode2D.Impulse);




    }
}
