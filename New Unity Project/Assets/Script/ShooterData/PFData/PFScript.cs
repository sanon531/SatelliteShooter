using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFScript : ShooterBase
{
    // Start is called before the first frame update
    
    
    Coroutine corou1;


    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    protected new virtual void Fire()
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

        GameObject laser = objectManager.MakeObj("PlayerBullet2");
        laser.transform.position = firePoint.position;
        laser.transform.rotation = firePoint.rotation;
        laser.transform.Rotate(angleToRotate);
        laser.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);

        yield return new WaitForSeconds(bulletShotRate);
    }
}
