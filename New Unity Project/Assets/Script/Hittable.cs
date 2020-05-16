using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour
{
    [SerializeField] float health = 500;
    public enum TTag { player, enemy }
    public TTag ttag = TTag.enemy;
    public GameObject particleExample;
    public GameObject particleDead;
    private GameObject spwanedParticle;
    // Start is called before the first frame update

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
                Destroy(bullet);
            }
            else
            {
                GameObject deadParticle = spawnDead();
                Destroy(gameObject);
            }
        }
        return true;
    }
}
