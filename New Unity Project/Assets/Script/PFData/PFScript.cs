using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public Transform firePoint;
    [SerializeField] public Vector3 angleToRotate;
    [SerializeField] public float bulletSpeed = 30;
    [SerializeField] public float bulletShotRate = 0.1f;
    //public event  pressedEvent ; 
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
        if (FixedButton.Pressing && !currentPressed)
        {
            if (corou1 != null)
                StopCoroutine(corou1);

            corou1 = StartCoroutine(ShootingCoroutine());
            currentPressed = true;
        }
        else if (!FixedButton.Pressing && currentPressed)
        {
            if (corou1 != null)
                StopCoroutine(corou1);
            currentPressed = false;
        }
    }

    IEnumerator ShootingCoroutine()
    {

        while (true)
        {
            GameObject laser = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
            //laser.transform.Rotate(angleToRotate);
            laser.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
