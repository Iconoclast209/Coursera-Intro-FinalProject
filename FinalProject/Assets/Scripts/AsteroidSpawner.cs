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
        #region Select an Asteroid Prefab
        // Select a random prefab
        int index = Random.Range(0, asteroidPrefabs.Length - 1);

        // Store the collider radius
        float prefabRadius = asteroidPrefabs[index].GetComponent<CircleCollider2D>().radius;


        #endregion
        #region Determine Spawn Location
        float xCoordinate = 0f; 
        float yCoordinate = 0f;
        int sectorToSpawnIn = Random.Range(1, 9);

        if(sectorToSpawnIn == 1)
        {
            //determine random x,y pair within sector 1 (upper left)
            xCoordinate = Random.Range(ScreenUtils.ScreenLeft, 0);
            yCoordinate = ScreenUtils.ScreenTop + prefabRadius;
        }
        else if (sectorToSpawnIn == 2)
        {
            //determine random x,y pair within sector 2 (upper right)
            xCoordinate = Random.Range(0, ScreenUtils.ScreenRight);
            yCoordinate = ScreenUtils.ScreenTop + prefabRadius;
        }
        else if (sectorToSpawnIn == 3)
        {
            //determine random x,y pair within sector 3 (upper side right)
            xCoordinate = ScreenUtils.ScreenRight + prefabRadius;
            yCoordinate = Random.Range(0, ScreenUtils.ScreenTop);
        }
        else if (sectorToSpawnIn == 4)
        {
            //determine random x,y pair within sector 4 (lower side right)
            xCoordinate = ScreenUtils.ScreenRight + prefabRadius;
            yCoordinate = Random.Range(ScreenUtils.ScreenBottom, 0);
        }
        else if (sectorToSpawnIn == 5)
        {
            //determine random x,y pair within sector 4 (bottom right)
            xCoordinate = Random.Range(0, ScreenUtils.ScreenRight);
            yCoordinate = ScreenUtils.ScreenBottom - prefabRadius;
        }
        else if (sectorToSpawnIn == 6)
        {
            //determine random x,y pair within sector 4 (bottom left)
            xCoordinate = Random.Range(ScreenUtils.ScreenLeft, 0);
            yCoordinate = ScreenUtils.ScreenBottom - prefabRadius;
        }
        else if (sectorToSpawnIn == 7)
        {
            //determine random x,y pair within sector 4 (lower side left)
            xCoordinate = ScreenUtils.ScreenLeft - prefabRadius;
            yCoordinate = Random.Range(ScreenUtils.ScreenBottom, 0);
        }
        else
        {
            //determine random x,y pair within sector 4 (upper side left)
            xCoordinate = ScreenUtils.ScreenLeft - prefabRadius;
            yCoordinate = Random.Range(0, ScreenUtils.ScreenTop);
        }
        #endregion
        #region Determine Thrust
        Vector3 spawnPosition = new Vector3(xCoordinate, yCoordinate, 0f);
        // Create an asteroid 
        GameObject newAsteroid = Instantiate(asteroidPrefabs[index], spawnPosition, Quaternion.identity);

        // Select a random thrust
        float thrust = Random.RandomRange(thrustMin, thrustMax);
        
        // Select a direction towards the play space
        if(sectorToSpawnIn == 1 || sectorToSpawnIn == 2)
        {
            newAsteroid.GetComponent<Rigidbody2D>().AddForce(Vector2.down * thrust, ForceMode2D.Impulse);
        }
        else if (sectorToSpawnIn == 3 || sectorToSpawnIn == 4)
        {
            newAsteroid.GetComponent<Rigidbody2D>().AddForce(Vector2.left * thrust, ForceMode2D.Impulse);
        }
        else if (sectorToSpawnIn == 5 || sectorToSpawnIn == 6)
        {
            newAsteroid.GetComponent<Rigidbody2D>().AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
        }
        else
        {
            newAsteroid.GetComponent<Rigidbody2D>().AddForce(Vector2.right * thrust, ForceMode2D.Impulse);
        }
        #endregion

    }
}
