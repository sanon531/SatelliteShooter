using UnityEngine;
using System.Collections;

namespace PixelArsenal
{
    public class FXAddProjectileScript : MonoBehaviour
    {
        public GameObject projectileParticle; // Effect attached to the gameobject as child
        [Header("Adjust if not using Sphere Collider")]
        public float colliderRadius = 1f;
        [Range(0f, 1f)] // This is an offset that moves the impact effect slightly away from the point of impact to reduce clipping of the impact effect
        public float collideOffset = 0.15f;

        void Start()
        {
            projectileParticle = Instantiate(projectileParticle, transform.position, transform.rotation) as GameObject;
            projectileParticle.transform.parent = transform;
        }

        


        void FixedUpdate()
        {

            float radius; // Sets the radius of the collision detection
            if (transform.GetComponent<CircleCollider2D>())
                radius = transform.GetComponent<CircleCollider2D>().radius;
            else
                radius = colliderRadius;


    
        }
    }
}