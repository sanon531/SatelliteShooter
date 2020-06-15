using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public Button thisButton; 
    public static bool clicked = false;

    private void Start()
    {
        thisButton.onClick.AddListener(ClickNow);
    }

    void LateUpdate()
    {
        clicked = false;
    }

    public void ClickNow()
    {
        clicked = true;
    }

}
