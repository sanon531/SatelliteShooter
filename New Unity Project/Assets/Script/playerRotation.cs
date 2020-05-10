using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class playerRotation : MonoBehaviour
{
    [SerializeField] public PathFollower pathFollower; 
    [SerializeField] public Vector3 angleman;
    [SerializeField] public float rotateSpeed;
    [SerializeField] FixedButton button;
    Coroutine courou2;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            courou2 = StartCoroutine(rotateIt());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(courou2);
        }

    }


    IEnumerator rotateIt() {

        print("aa");
        pathFollower.angleToRotate = Quaternion.Euler(0,180,0) * pathFollower.angleToRotate;

        yield return null;
    }

  
}
