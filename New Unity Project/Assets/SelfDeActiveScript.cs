using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDeActiveScript : MonoBehaviour
{
    public float delayedTime = 3f; 

    private void OnEnable()
    {
        Invoke("selfDeActive", delayedTime);
    }
    // Update is called once per frame


    private void selfDeActive()
    {
        gameObject.SetActive(false);
    }




}
