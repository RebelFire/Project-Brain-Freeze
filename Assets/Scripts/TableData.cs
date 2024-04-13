using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableData : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    public Transform[] GetWaypoints() {
        return waypoints;
    }
}
