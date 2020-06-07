using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBase : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public Transform firePoint;
    [SerializeField] public Vector3 angleToRotate;
    [SerializeField] public float bulletSpeed = 20;
    [SerializeField] public float bulletShotRate;
    public ObjectManager objectManager; 

    public bool currentPressed = false;

    protected void Fire() { }








}
