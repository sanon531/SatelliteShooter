using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.GetComponent<Hittable>();
        if (other != null)
        {

        }


    }


}
