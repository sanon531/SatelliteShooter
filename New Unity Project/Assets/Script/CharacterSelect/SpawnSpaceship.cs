using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpaceship : MonoBehaviour
{


    public GameObject[] charPrefabs;
    private GameObject player;

    void Start()
    {
        player = Instantiate(charPrefabs[(int)OverSceneData.instance.currentSpaceship]);
        BossScript.player = player;
        player.transform.position = transform.position;
        BossScript.fasterThanPlayer = GameObject.Find("FasterThanPlayer");

    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
