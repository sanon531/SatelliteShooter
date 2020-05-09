using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] public GameObject bulletOfPlayer;
    Coroutine corou1;
    // Start is called before the first frame update
    void Start()
    {
        corou1 = ShootingCoroutine;
        StartCoroutine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ShootingCoroutine() {

        Instantiate();

        yield return null;
    }
}
