using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickFlipScript : ShooterBase
{


    Coroutine corou1;

    void Awake()
    {
        objectManager = GameObject.Find("SceneObjectManager").GetComponent<ObjectManager>();
    }

    void Update()
    {
        Fire();
    }

    protected new virtual void Fire()
    {
        if (FixedButton.Clicked && !currentPressed)
        {
            corou1 = StartCoroutine(ShootingCoroutine());
            currentPressed = true;
        }
        else if(!FixedButton.Clicked && corou1 != null)
        {
            StopCoroutine(corou1);
            currentPressed = false;
        }
    }

    IEnumerator ShootingCoroutine() {

        while (true)
        {
            GameObject laser = objectManager.MakeObj("PlayerBullet1");
            laser.transform.position = firePoint.position;
            laser.transform.rotation = firePoint.rotation;
            laser.transform.Rotate(angleToRotate);
            laser.GetComponent<Rigidbody2D>().AddForce(firePoint.up*bulletSpeed,ForceMode2D.Impulse);

            yield return new WaitForSeconds(bulletShotRate);
        }
    }
}
