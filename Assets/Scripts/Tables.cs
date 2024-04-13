using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tables : MonoBehaviour {

    [SerializeField] private Transform[] tables;

    private List<Transform> emptyTables = new List<Transform>();

    private void Start() {
        emptyTables.AddRange(tables);
    }

    public Transform GetRandomTable () {
        int randomNumber = UnityEngine.Random.Range(0, emptyTables.Count);
        Transform table = emptyTables[randomNumber];
        emptyTables.RemoveAt(randomNumber);
        return table;
    }

    public void AddTableToList (Transform table) {
        emptyTables.Add(table);
    }


}
