using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public FixedButton shotButton;
    [SerializeField] public Transform firePoint;
    [SerializeField] public Vector3 angleToRotate;
    [SerializeField] public float bulletSpeed = 20;
    [SerializeField] public float bulletShotRate;

    Coroutine corou1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            corou1 = StartCoroutine(ShootingCoroutine());
        }
        if (Input.GetButtonUp("Fire1")) 
        {
            StopCoroutine(corou1);
        }
    }

    IEnumerator ShootingCoroutine() {

        while (true)
        {
            GameObject laser = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
            laser.transform.Rotate(angleToRotate);
            laser.GetComponent<Rigidbody2D>().AddForce(firePoint.up*bulletSpeed,ForceMode2D.Impulse);

            yield return new WaitForSeconds(bulletShotRate);
        }
    }
}
