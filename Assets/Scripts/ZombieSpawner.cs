using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private ZombieMovementPoints zombieMovementPoints;
    private float nextSpawnTime = 0f;
    private int activeZombieCount = 0;
    [SerializeField] private int maxZombieCount = 5;
    [SerializeField] private Tables tables;
    private void Start () {

        objectPool = objectPool.GetComponent<ObjectPool>();
        tables = tables.GetComponent<Tables>();
    }

    private void Update () {
        if (activeZombieCount < maxZombieCount) {
            if (nextSpawnTime <= 0) {
                SpawnZombie();
                IncreaseSpawnedZombie();
                nextSpawnTime = spawnInterval;
            }
            else {
                nextSpawnTime -= Time.deltaTime;
            }

        }
    }

    private void SpawnZombie () {
        GameObject zombie = objectPool.Get();
        Transform table = tables.GetRandomTable();
        Transform[] tableTransforms = table.GetComponent<TableData>().GetWaypoints();
        zombie.GetComponent<ZombieMovement>().SetZombieMovementPoints(tableTransforms);
        zombie.transform.position = transform.position;
        zombie.SetActive(true);
    }

    private void IncreaseSpawnedZombie () {
        activeZombieCount++;
    }

    public void DecreaseSpawnedZombie () {
        activeZombieCount--;
    }
}