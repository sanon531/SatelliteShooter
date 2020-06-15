using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBase : MonoBehaviour
{
    [SerializeField] public Transform firePoint;
    [SerializeField] public Vector3 angleToRotate;
    [SerializeField] public float bulletSpeed = 20;
    [SerializeField] public float bulletShotRate;
    [SerializeField] public bool currentPressed = false;

    protected ObjectManager objectManager;



    void Awake()
    {
        objectManager = GameObject.Find("SceneObjectManager").GetComponent<ObjectManager>();
    }


    protected void Fire() { }


}
