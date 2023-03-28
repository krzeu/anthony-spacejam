using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AstroidSpawner : MonoBehaviour
{
     [Header("Size of spawner area")]
      public Vector3 spawnerSize;

    // rate of spawn//

    public float spawnRate = 1f;

    // model of spawn//
    [SerializeField] private GameObject asteriodModel;

    private float spawnTimer = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, spawnerSize);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer > spawnRate)
        {
            spawnTimer = 0;
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        //random plats för pigmen // 
        Vector3 spawnPoint = transform.position + new Vector3( UnityEngine.Random.Range(-spawnerSize.x/2, spawnerSize.x/2),
                                                               UnityEngine.Random.Range(-spawnerSize.y / 2, spawnerSize.y / 2),
                                                               UnityEngine.Random.Range(-spawnerSize.z/2, spawnerSize.z/2));

        GameObject asteroid = Instantiate(asteriodModel, spawnPoint, transform.rotation);
       
        // sätter alla kloner i en parent//
        asteroid.transform.SetParent(this.transform);

    }

}
