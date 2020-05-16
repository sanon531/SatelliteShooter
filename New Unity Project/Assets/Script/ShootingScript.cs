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
    public bool currentPressed = false;

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
        if (shotButton.Pressed && !currentPressed)
        {
            corou1 = StartCoroutine(ShootingCoroutine());
            currentPressed = true;
        }
        else if(!shotButton.Pressed && corou1 != null)
        {
            StopCoroutine(corou1);
            currentPressed = false;
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
