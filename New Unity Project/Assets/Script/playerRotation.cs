using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class PlayerRotation : MonoBehaviour
{
    //[SerializeField] public PathFollower pathFollower; 
    //[Range (0f,180f)][SerializeField] public float rotateState = 180f;
    [SerializeField] public float rotateSpeed = 10f;
    private Quaternion rotateGoal = Quaternion.Euler(new Vector3(0, 0, 0));

    Coroutine courou2;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(courou2 != null )
                StopCoroutine(courou2);

            courou2 = StartCoroutine(RotateBack());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (courou2 != null)
                StopCoroutine(courou2);

            courou2 = StartCoroutine(RotateFront());

        }

    }


    IEnumerator RotateFront() {
        rotateGoal = Quaternion.Euler(new Vector3(0, 0, 180));

        while (true)
        {
            
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, rotateGoal , rotateSpeed * Time.deltaTime);
            print(transform.localRotation.z);
            yield return new WaitForSeconds(0.01f);
        }

    }
    IEnumerator RotateBack()
    {
        print(transform.localRotation.z);
        rotateGoal = Quaternion.Euler(new Vector3(0, 0, 0));
        while (true)
        {
            print("dwwq");
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rotateGoal, rotateSpeed * Time.deltaTime);
            print(transform.localRotation.z);
         
            yield return new WaitForSeconds(0.01f);
        }
 
    }



}
