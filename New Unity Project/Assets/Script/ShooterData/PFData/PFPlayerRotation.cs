using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFPlayerRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float rotateSpeed = 10f;
    [SerializeField] public bool currentPressed = false;
    private Quaternion rotateGoal = Quaternion.Euler(new Vector3(0, 0, 0));
    private Quaternion _targetRotation = Quaternion.identity;

    Coroutine courou2;

    private void Update()
    {
        if (FixedButton.Pressing)
        {
            if (courou2 != null)
                StopCoroutine(courou2);

            courou2 = StartCoroutine(RotateBack());
        }
        if (!FixedButton.Pressing && courou2 != null)
        {
            if (courou2 != null)
                StopCoroutine(courou2);
            courou2 = StartCoroutine(RotateFront());

        }
    }
    IEnumerator RotateFront()
    {
        rotateGoal = Quaternion.Euler(new Vector3(0, 0, 180f));
        while (true)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rotateGoal, rotateSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator RotateBack()
    {
        rotateGoal = Quaternion.Euler(new Vector3(0, 0, 0f));
        while (true)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(new Vector3(0, 0, 0f)), rotateSpeed * Time.deltaTime);
            //transform.localRotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(90f, -90f, 0));
            yield return new WaitForSeconds(0.01f);
        }
    }
}
