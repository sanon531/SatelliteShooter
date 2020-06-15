using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager StaticObjM;
    public GameObject PlayerBulletPrefab1;
    public GameObject PlayerBulletPrefab2;
    public GameObject BulletParticlePrefab1;
    public GameObject BulletParticlePrefab2;
    public GameObject BossBulletPrefab1;
    public GameObject BossBulletPrefab2;
    public GameObject BossBulletPrefab3;
    public GameObject ItemFastPrefab;
    public GameObject ItemStrongPrefab;
    public GameObject ItemDoublePrefab;
    public GameObject ItemDefencePrefab;


    public GameObject PlayerBulletPrefab3;
    public GameObject PlayerMuzzlePrefab1;
    private GameObject[] PlayerMuzzle1;

    private GameObject[] PlayerBullet3;

    private GameObject[] targetPool; 
    private GameObject[] PlayerBullet1;
    private GameObject[] PlayerBullet2;
    private GameObject[] BulletParticle1;
    private GameObject[] BulletParticle2;
    private GameObject[] BossBullet1;
    private GameObject[] BossBullet2;
    private GameObject[] BossBullet3;
    private GameObject[] ItemFast;
    private GameObject[] ItemStrong;
    private GameObject[] ItemDouble;
    private GameObject[] ItemDefence;








    private void Awake()
    {
        PlayerBullet1 = new GameObject[100];
        PlayerBullet2 = new GameObject[1];
        BulletParticle1 = new GameObject[50];
        BulletParticle2 = new GameObject[50];

        PlayerBullet3 = new GameObject[100];

        PlayerMuzzle1 = new GameObject[25];

        BossBullet1 = new GameObject[100];
        BossBullet2 = new GameObject[100];
        BossBullet3 = new GameObject[100];

        ItemFast = new GameObject[1];
        ItemStrong = new GameObject[1];
        ItemDouble = new GameObject[4];
        ItemDefence = new GameObject[4];

        Generated();

    }

    private void Generated()
    {
        CalcFancy(PlayerBullet1, PlayerBulletPrefab1);
        CalcFancy(PlayerBullet2, PlayerBulletPrefab2);
        CalcFancy(PlayerBullet3, PlayerBulletPrefab3);
        CalcFancy(BulletParticle1, BulletParticlePrefab1);
        CalcFancy(BulletParticle2, BulletParticlePrefab2);
        CalcFancy(BossBullet1, BossBulletPrefab1);
        CalcFancy(BossBullet2, BossBulletPrefab2);
        CalcFancy(BossBullet3, BossBulletPrefab3);
        CalcFancy(PlayerMuzzle1, PlayerMuzzlePrefab1);

        CalcFancy(ItemFast, ItemFastPrefab);
        CalcFancy(ItemStrong, ItemStrongPrefab);
        CalcFancy(ItemDouble, ItemDoublePrefab);
        CalcFancy(ItemDefence, ItemDefencePrefab);




        if (StaticObjM == null) StaticObjM = this;
        else if (StaticObjM != null) return;
    }

    private void CalcFancy(GameObject[] gameObjects,GameObject gameObjectit)
    {
        for (int index = 0; index < gameObjects.Length; index++)
        {
            gameObjects[index] = Instantiate(gameObjectit);
            gameObjects[index].transform.parent = transform;
            gameObjects[index].SetActive(false);
        }


    }




    public GameObject MakeObj(string type)
    {       
        switch (type)
        {
            case "PlayerBullet1":
                targetPool = PlayerBullet1;
                break;
            case "PlayerBullet2":
                targetPool = PlayerBullet2;
                break;
            case "PlayerBullet3":
                targetPool = PlayerBullet3;
                break;
            case "PlayerMuzzle1":
                targetPool = PlayerMuzzle1;
                break;
            case "BulletParticle1":
                targetPool = BulletParticle1;
                break;
            case "BulletParticle2":
                targetPool = BulletParticle2;
                break;
            case "BossBullet1":
                targetPool = BossBullet1;
                break;
            case "BossBullet2":
                targetPool = BossBullet2;
                break;
            case "BossBullet3":
                targetPool = BossBullet3;
                break;
            case "ItemFast":
                targetPool = ItemFast;
                break;
            case "ItemStrong":
                targetPool = ItemStrong;
                break;
            case "ItemDouble":
                targetPool = ItemDouble;
                break;
            case "ItemDefence":
                targetPool = ItemDefence;

                break;
        }
        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }
        return null;

    }
}
