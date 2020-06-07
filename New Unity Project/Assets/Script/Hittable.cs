using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hittable : MonoBehaviour
{
    public enum TTag { player, enemy }



    [SerializeField] public float health = 500;
    [SerializeField] public TTag ttag = TTag.enemy;
    [SerializeField] public GameObject particleExample;
    [SerializeField] public GameObject particleDead;

    public Slider hpSlider = null;


    private GameObject spwanedParticle;

    // Start is called before the first frame update

    private void Start()
    {
        
    }


    private GameObject spawnParticle(GameObject gameObject)
    {
        GameObject particles = (GameObject)Instantiate(particleExample);
        particles.transform.position = gameObject.transform.position;
        particles.transform.rotation = gameObject.transform.rotation;
        particles.SetActive(true);
        return particles;
    }
    private GameObject spawnDead()
    {
        GameObject particles = (GameObject)Instantiate(particleDead);
        particles.transform.position = gameObject.transform.position;
        particles.transform.rotation = gameObject.transform.rotation;
        particles.SetActive(true);
        return particles;
    }

    public bool? Hit(float damage, TTag t,GameObject bullet)
    {
        if (t == ttag) return false;

        if (particleExample != null )
        {
            GameObject particle = spawnParticle(bullet);

            if (health - damage > 0)
            {
                health -= damage;
                bullet.SetActive(false);
            }
            else
            {
                GameObject deadParticle = spawnDead();
                gameObject.SetActive(false);
            }
        }
        return true;
    }
}
