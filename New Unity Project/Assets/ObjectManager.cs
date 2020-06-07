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
    public GameObject ItemFastPrefab;
    public GameObject ItemStrongPrefab;
    public GameObject ItemDoublePrefab;
    public GameObject ItemDefencePrefab;


    private GameObject[] targetPool; 
    private GameObject[] PlayerBullet1;
    private GameObject[] PlayerBullet2;
    private GameObject[] BulletParticle1;
    private GameObject[] BulletParticle2;
    private GameObject[] BossBullet1;
    private GameObject[] BossBullet2;

    private GameObject[] ItemFast;
    private GameObject[] ItemStrong;
    private GameObject[] ItemDouble;
    private GameObject[] ItemDefence;





    private void Awake()
    {
        PlayerBullet1 = new GameObject[100];
        PlayerBullet2 = new GameObject[100];
        BulletParticle1 = new GameObject[200];
        BulletParticle2 = new GameObject[200];

        BossBullet1 = new GameObject[20];
        BossBullet2 = new GameObject[20];

        ItemFast = new GameObject[4];
        ItemStrong = new GameObject[4];
        ItemDouble = new GameObject[4];
        ItemDefence = new GameObject[4];


        


        Generated();

    }

    private void Generated()
    {
        for (int index = 0; index < PlayerBullet1.Length; index++) {
            PlayerBullet1[index] =  Instantiate(PlayerBulletPrefab1);
            PlayerBullet1[index].SetActive(false);
        }
        for (int index = 0; index < PlayerBullet2.Length; index++)
        {
            PlayerBullet2[index] = Instantiate(PlayerBulletPrefab2);
            PlayerBullet2[index].SetActive(false);
        }
        for (int index = 0; index < BulletParticle1.Length; index++)
        {
            BulletParticle1[index] = Instantiate(BulletParticlePrefab1);
            BulletParticle1[index].SetActive(false);
        }
        for (int index = 0; index < BulletParticle2.Length; index++)
        {
            BulletParticle2[index] = Instantiate(BulletParticlePrefab2);
            BulletParticle2[index].SetActive(false);
        }
        for (int index = 0; index <BossBullet1.Length; index++)
        {
            BossBullet1[index] = Instantiate(BossBulletPrefab1);
            BossBullet1[index].SetActive(false);
        }
        for (int index = 0; index < BossBullet2.Length; index++)
        {
            BossBullet2[index] = Instantiate(BossBulletPrefab2);
            BossBullet2[index].SetActive(false);
        }
        for (int index = 0; index < ItemFast.Length; index++)
        {
            ItemFast[index] = Instantiate(ItemFastPrefab);
            ItemFast[index].SetActive(false);
        }
        for (int index = 0; index < ItemStrong.Length; index++)
        {
            ItemStrong[index] = Instantiate(ItemStrongPrefab);
            ItemStrong[index].SetActive(false);
        }
        for (int index = 0; index < ItemDouble.Length; index++)
        {
            ItemDouble[index] = Instantiate(ItemDoublePrefab);
            ItemDouble[index].SetActive(false);
        }
        for (int index = 0; index < ItemDefence.Length; index++)
        {
            ItemDefence[index] = Instantiate(ItemDefencePrefab);
            ItemDefence[index].SetActive(false);
        }


        if (StaticObjM == null) StaticObjM = this;
        else if (StaticObjM != null) return;
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
