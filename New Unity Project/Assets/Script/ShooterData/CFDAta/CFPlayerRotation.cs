using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using PathCreation.Examples;

public class CFPlayerRotation : MonoBehaviour
{
    //[SerializeField] public PathFollower pathFollower; 
    //[Range (0f,180f)][SerializeField] public float rotateState = 180f;

    [SerializeField] public float rotateSpeed = 10f;
    [SerializeField] public bool currentPressed = false;
    private Quaternion rotateGoal = Quaternion.Euler(new Vector3(0, 0, 0));
    private Quaternion _targetRotation = Quaternion.identity;

    Coroutine courou2;

    private void Update()
    {
        if (FixedButton.Clicked)
        {
            if(courou2 != null )
                StopCoroutine(courou2);
            courou2 = StartCoroutine(RotateBack());
        }
        if (!FixedButton.Clicked && courou2 !=null)
        {
            if (courou2 != null)
                StopCoroutine(courou2);
            courou2 = StartCoroutine(RotateFront());
        }
    }
    IEnumerator RotateFront() {
        rotateGoal = Quaternion.Euler(new Vector3(0, 0, 180f));
        while (true)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rotateGoal , rotateSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator RotateBack()
    {
        rotateGoal = Quaternion.Euler(new Vector3(0,0,0f));
        while (true)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(new Vector3(0, 0, 0f)), rotateSpeed * Time.deltaTime);
            //transform.localRotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(90f, -90f, 0));
            yield return new WaitForSeconds(0.01f);
        }
    }
}
