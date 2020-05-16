using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using PathCreation.Examples;

public class PlayerRotation : MonoBehaviour
{
    //[SerializeField] public PathFollower pathFollower; 
    //[Range (0f,180f)][SerializeField] public float rotateState = 180f;

    [SerializeField] public float rotateSpeed = 10f;
    [SerializeField] public FixedButton fixedButton;
    [SerializeField] public bool currentPressed = false;
    private Quaternion rotateGoal = Quaternion.Euler(new Vector3(0, 0, 0));

    Coroutine courou2;

    private void Update()
    {
        if (fixedButton.Pressed)
        {
            if(courou2 != null )
                StopCoroutine(courou2);

            courou2 = StartCoroutine(RotateBack());
        }
        if (!fixedButton.Pressed && courou2 !=null)
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
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rotateGoal , rotateSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator RotateBack()
    {
        rotateGoal = Quaternion.Euler(new Vector3(0, 0, 0));
        while (true)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rotateGoal, rotateSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
