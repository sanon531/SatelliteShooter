using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class FixedButton : MonoBehaviour
{
    public static FixedButton instance;
    public static bool Clicked = false;
    public static bool Pressing = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
    }
    
    public void ButtonClicked()
    {
        Pressing = true;

        if (Clicked == false)
        {

            Clicked = true;
        }
        else
        {
            Clicked = false;

        }

    }

    public void ButtonUp()
    {
        Pressing = false;
    }





}