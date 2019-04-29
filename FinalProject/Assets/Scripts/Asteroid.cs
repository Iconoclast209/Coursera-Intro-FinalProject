using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject asteroidPrefabSmall;
    [SerializeField]
    int healthRemaining = 2;
    float colliderRadius;

    private void Start()
    {
        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }



    public void DamageAsteroid()
    {
        healthRemaining--;
        if (healthRemaining == 1)
        {
            SpawnTwoSmallerAsteroids();
        }

        Destroy(this.gameObject);

    }

    void SpawnTwoSmallerAsteroids()
    {
        //Spawn two smaller asteroids at roughly the same position as the larger asteroid
        float xCoordinate = transform.position.x;
        float yCoordinate = transform.position.y;

        Vector3 spawnPosition = new Vector3(xCoordinate, yCoordinate, 0f);
        GameObject newAsteroid = Instantiate(asteroidPrefabSmall, spawnPosition, Quaternion.identity);
        //Offset the second asteroid slightly
        xCoordinate += 0.1f;
        yCoordinate += 0.1f;
        spawnPosition = new Vector3(xCoordinate, yCoordinate, 0f);
        GameObject newAsteroid2 = Instantiate(asteroidPrefabSmall, spawnPosition, Quaternion.identity);
        //Apply force so that the smaller asteroids continue to move in roughly the same direction as the larger asteroid.

    }

}
