using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpaceship : MonoBehaviour
{


    public GameObject[] charPrefabs;
    public GameObject player;

    void Start()
    {
        player = Instantiate(charPrefabs[(int)OverSceneData.instance.currentSpaceship]);
        player.transform.position = transform.position;

    }
}
