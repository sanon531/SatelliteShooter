using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickFlipScript : ShooterBase
{
    Coroutine corou1;

    protected ParticleSystem ps;
    protected Gradient Grad;
    protected GradientColorKey[] colorKeys;
    protected GradientAlphaKey[] alphaKeys;

 


    protected void SetGradient()
    {
        Debug.Log("a2");
        colorKeys = new GradientColorKey[2];
        colorKeys[0].color = Color.blue;
        colorKeys[0].time = 0f;

        colorKeys[1].color = new Color(0f, 0f, 0f, 0f);
        colorKeys[0].time = 1f;


        alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1.0f;
        alphaKeys[0].time = 0.0f;
        alphaKeys[1].alpha = 0.0f;
        alphaKeys[1].time = 1.0f;
        Grad.SetKeys(colorKeys, alphaKeys);
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
            GameObject laser = objectManager.MakeObj("PlayerBullet3");
            laser.transform.position = firePoint.position;
            laser.transform.rotation = firePoint.rotation;
            laser.GetComponent<Rigidbody2D>().AddForce(firePoint.up*bulletSpeed,ForceMode2D.Impulse);
            GameObject muzzle = objectManager.MakeObj("PlayerMuzzle1");
            muzzle.transform.position = firePoint.position;
            muzzle.transform.rotation = firePoint.rotation;
            yield return new WaitForSeconds(bulletShotRate);
        }
    }
}
