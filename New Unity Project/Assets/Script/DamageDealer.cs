﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] public int damage = 100;
    [SerializeField] Hittable.TTag bullettag = Hittable.TTag.player;
    [SerializeField] public float DelayedTime = 3f;
    private void OnEnable()
    {
        StartCoroutine(DelayedOff(DelayedTime));
    }


    public int GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.GetComponent<Hittable>();
        if (other != null)
        {        
            collision.GetComponent<Hittable>().Hit(damage, bullettag, gameObject);
        }
    }
    private IEnumerator DelayedOff(float duration)
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }



}
