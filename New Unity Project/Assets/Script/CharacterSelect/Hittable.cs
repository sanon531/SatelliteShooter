using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hittable : MonoBehaviour
{
    public enum TTag { player, enemy, defence }



    [SerializeField] public float health = 500;
    [SerializeField] public TTag ttag = TTag.enemy;

    protected  ObjectManager objectManager;
    protected ParticleSystem ps;
    protected Gradient Grad;
    protected GradientColorKey[] colorKeys;
    protected GradientAlphaKey[] alphaKeys;


    // Start is called before the first frame update

    void Awake()
    {
        objectManager = GameObject.Find("SceneObjectManager").GetComponent<ObjectManager>();
        Grad = new Gradient();
        switch (ttag)
        {
            case TTag.defence:
                SetGradient(Color.green);
                break;
            case TTag.enemy:
                SetGradient(Color.red);
                break;
            case TTag.player:
                SetGradient(Color.blue);
                break;
        }

    }

    protected void SetGradient(Color color)
    {
        colorKeys = new GradientColorKey[2];
        colorKeys[0].color = color;
        colorKeys[0].time = 0f;
        colorKeys[1].color = new Color(0f,0f,0f,0f);
        colorKeys[0].time = 1f;
        //

        alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1.0f;
        alphaKeys[0].time = 0.0f;
        alphaKeys[1].alpha = 0.0f;
        alphaKeys[1].time = 1.0f;
        Grad.SetKeys(colorKeys,alphaKeys);
    }

    protected GameObject spawnParticle(GameObject gameObject)
    {
        GameObject particles = objectManager.MakeObj("BulletParticle1");
        ps = particles.GetComponent<ParticleSystem>();
        var col = ps.colorOverLifetime;
        Grad.SetKeys(colorKeys, alphaKeys);
        col.color = Grad;

        particles.transform.position = gameObject.transform.position;
        particles.transform.rotation = gameObject.transform.rotation;
        particles.SetActive(true);
        return particles;
    }



    protected GameObject spawnDead()
    {
        GameObject particles = objectManager.MakeObj("BulletParticle2");
        particles.transform.position = gameObject.transform.position;
        particles.transform.rotation = gameObject.transform.rotation;
        particles.SetActive(true);
        return particles;
    }

    public bool? Hit(float damage, TTag t,GameObject bullet)
    {
        if (t == ttag) return false;


        GameObject particle = spawnParticle(bullet);


        if (t == TTag.defence) return false;

        if (health - damage > 0)
        {
            health -= damage;
            bullet.SetActive(false);
        }
        else
        {
            health -= damage;

            GameObject deadParticle = spawnDead();
            gameObject.SetActive(false);
        }
        
        return true;
    }
}
