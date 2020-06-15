using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : Hittable
{


    public int patternIndex;
    public int currentPatternCount;
    public int[] patternCount;
    public SpawnSpaceship spawnSpaceship;

    public static GameObject player;
    public static GameObject fasterThanPlayer;

    private Vector2 bulletMoveDirection;


    private void OnEnable()
    {
        Invoke("Stop",0);
    }


    void Stop()
    {
        if (!gameObject.activeSelf)
        {
            return;
        }
        Invoke("Think", 1);
    }
    void Think()
    {
        if (health <= 0)
        {
            Application.Quit();
            return;
        } 
        patternIndex = (patternIndex == 3 ? 0 : patternIndex + 1);
        currentPatternCount = 0;

        Debug.Log(health);

        switch (patternIndex)
        {
            case 0:
                FireFoward();
                break;
            case 1:
                FireMissile();
                break;
            case 2:
                FireArc();
                break;
            case 3:
                FireAround();
                break;
        }
    }
    void FireFoward()
    {
        if (health <= 0)
        {
            Application.Quit();
            return;
        }


        GameObject bulletR = objectManager.MakeObj("BossBullet1");
        bulletR.transform.position = transform.position + Vector3.right * 5f;
        bulletR.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90f));

        GameObject bulletup = objectManager.MakeObj("BossBullet1");
        bulletup.transform.position = transform.position + Vector3.up * 5f;
        bulletup.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0f));

        GameObject bulletDown = objectManager.MakeObj("BossBullet1");
        bulletDown.transform.position = transform.position + Vector3.down * 5f;
        bulletDown.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180f));

        GameObject bulletleft = objectManager.MakeObj("BossBullet1");
        bulletleft.transform.position = transform.position + Vector3.left * 5f;
        bulletleft.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));

        Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidup = bulletup.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidDown = bulletDown.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidLL = bulletleft.GetComponent<Rigidbody2D>();


        rigidR.AddForce(Vector2.right *20, ForceMode2D.Impulse);
        rigidup.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        rigidDown.AddForce(Vector2.down * 20, ForceMode2D.Impulse);
        rigidLL.AddForce(Vector2.left * 20, ForceMode2D.Impulse);

        currentPatternCount++;
        if (currentPatternCount < patternCount[patternIndex])
        {
            Invoke("FireFoward", 0.1f);
        }
        else
        {
            Invoke("Think", 0.5f);
        }
    }
    void FireMissile()
    {
        if (health <= 0)
        {
            Application.Quit();
            return;
        }

        for (int index = 0; index < 5; index++)
        {

            GameObject bullet = objectManager.MakeObj("BossBullet2");
            bullet.transform.position = transform.position;
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 ranvec = new Vector2(Random.Range(5f, -5f), Random.Range(5f, -5f));


            float fRand = Random.Range(0f, 1f);

            Vector2 dirVec = player.transform.position - transform.position;

            if (fRand <= 0.5f)
            {

                dirVec = fasterThanPlayer.transform.position - transform.position;
            }


            dirVec += ranvec;

            rigid.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse );
        }


        currentPatternCount++;
        if (currentPatternCount < patternCount[patternIndex])
        {
            Invoke("FireMissile",0.5f);
        }
        else
        {
            Invoke("Think", 0.5f);

        }


    }
    void FireArc()
    {
        if (health <= 0)
        {
            Application.Quit();
            return;
        }

        GameObject bullet = objectManager.MakeObj("BossBullet1");
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(Mathf.Sin(Mathf.PI*currentPatternCount/patternCount[patternIndex]*20), -1);

        rigid.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);
        currentPatternCount++;
        if (currentPatternCount < patternCount[patternIndex])
            Invoke("FireArc", 0.1f);
        else
            Invoke("Think", 1f);

    }
    void FireAround()
    {
        if (health <= 0)
        {
            Application.Quit();
            return;
        }


        int roundNuma = 50;

        for (int index = 0; index < roundNuma; index++)
        {
            GameObject bullet = objectManager.MakeObj("BossBullet2");
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * index / roundNuma * 2 ),Mathf.Sin(Mathf.PI * index / roundNuma * 2));

            rigid.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);


        }



        currentPatternCount++;
        if (currentPatternCount < patternCount[patternIndex])
            Invoke("FireAround", 1.4f);
        else
            Invoke("Think", 3f);

    }



}
