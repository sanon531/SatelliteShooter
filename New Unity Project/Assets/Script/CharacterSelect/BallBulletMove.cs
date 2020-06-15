using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBulletMove : MonoBehaviour
{
    public bool isRotate = true;

    private Coroutine corou;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (isRotate)
            corou = StartCoroutine("SpinningMove");

    }

    // Update is called once per frame
    void Update()
    {
        //if (enemyName)
    }
    IEnumerator SpinningMove()
    {
        while (true) {
            transform.Rotate(Vector3.forward * 20);
            yield return new WaitForSeconds(0.1f);

        }
    }

}
