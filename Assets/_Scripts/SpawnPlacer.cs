using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlacer : MonoBehaviour {

    public GameObject cubeOutline;

    public void SpawnIn()
    {
        Instantiate(cubeOutline, Vector3.zero, Quaternion.identity);
    }
}
