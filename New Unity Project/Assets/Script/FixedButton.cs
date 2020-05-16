using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class FixedButton : MonoBehaviour
{
   
    public bool Pressed = false ;
    

    public void ButtonDowned()
    {
        if (Pressed == false)
        {
            Pressed = true;
        }
        else
        {
            Pressed = false;
        }
    }

}