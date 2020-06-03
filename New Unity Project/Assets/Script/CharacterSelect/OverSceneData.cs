using UnityEngine;


using System.Collections;

public enum Spaceship
{
    TouchFlip, PressFlip, Triangle
}

public class OverSceneData : MonoBehaviour
{

    public static OverSceneData instance;
    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }

    public Spaceship currentSpaceship;


}
