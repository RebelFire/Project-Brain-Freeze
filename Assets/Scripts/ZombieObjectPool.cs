using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private int poolSize;
    private List<GameObject> zombiePool = new List<GameObject>();

    private void Start () {

    }


    private void Return (GameObject zombie) {
        zombie.SetActive(false);
        zombie.transform.position = Vector3.zero;
        zombiePool.Add(zombie);
    }


    public GameObject Get () {
        if(zombiePool.Count > 0) {
            GameObject zombie = zombiePool[0];
            zombie.SetActive(true);
            zombiePool.RemoveAt(0);
            return zombie;
        }
        else {
            return SpawnZombie();
        }
        

    }

    public GameObject SpawnZombie () {
        GameObject zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        zombie.SetActive(false);
        zombiePool.Add(zombie);
        return zombie;
    }
}
