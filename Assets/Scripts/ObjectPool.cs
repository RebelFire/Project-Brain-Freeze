using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class ObjectPool : MonoBehaviour {


    private List<GameObject> zombies;
    [SerializeField] private GameObject zombiePrefab;
    private int poolSize = 10;


    private void Start () {
        zombies = new List<GameObject>();
        for(int i = 0; i < poolSize; i++) {
            SpawnZombie();
        }
    }

    private GameObject SpawnZombie () {
        GameObject zombie = Instantiate(zombiePrefab, transform);
        ReturnToPool(zombie);
        return zombie;
    }
    public GameObject Get () {

        if(zombies.Count == 0) {
            return SpawnZombie();
        }
        GameObject zombie = zombies[zombies.Count - 1];
        zombies.RemoveAt(zombies.Count - 1);
        return zombie;
    }

    public void ReturnToPool (GameObject zombie) {
        zombies.Add(zombie);
        zombie.SetActive(false);
    }
}